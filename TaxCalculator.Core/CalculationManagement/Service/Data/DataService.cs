using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TaxCalculator.DB;
using TaxCalculator.DB.Tables;
using TaxCalculator.Model.Dto;
using TaxCalculator.Model.Enum;

namespace TaxCalculator.Core.CalculationManagement.Service.Data
{
    public class DataService : IDataService
    {

        private readonly TaxCalculatorDbContext _taxCalculatorDbContext;

        public DataService(TaxCalculatorDbContext taxCalculatorDbContext)
        {
            _taxCalculatorDbContext = taxCalculatorDbContext;
        }

        public async Task<PayRangeSetting> GetPayRangeSettingAsync(CalculateRequestDto request)
        {
            PayRangeSetting? payRangeSettings = null;

            var dbQuery = from postalCode in _taxCalculatorDbContext.PostalCodes
                          join payRangeSetting in _taxCalculatorDbContext.PayRangeSettings
                          on postalCode.TaxTypeId equals payRangeSetting.TaxTypeId
                          where
                          postalCode.Code.ToUpper() == request.PostalCode.ToUpper()
                          && request.Amount >= payRangeSetting.From && (request.Amount <= payRangeSetting.To || payRangeSetting.To == null)
                          //orderby payRangeSetting.From descending
                          select
                          payRangeSetting;


            payRangeSettings = await dbQuery.FirstOrDefaultAsync();

            return payRangeSettings;
        }

        public async Task<long> SaveCalculationAsync(CalculateDataDto request, long payRangeSettinId)
        {
            var _postalCode = _taxCalculatorDbContext.PostalCodes.FirstOrDefault(x => x.Code.ToUpper() == request.PostalCode.ToUpper());
            CalculationResult calculationResult = new CalculationResult()
            {
                Created = DateTime.Now,
                PayAmount = request.Amount,
                TaxAmount = request.TaxAmount,
                PostalCodeId = _postalCode.Id,
                PayRangeSettingId = payRangeSettinId
            };

            await _taxCalculatorDbContext.AddAsync(calculationResult);

            await _taxCalculatorDbContext.SaveChangesAsync();

            return calculationResult.Id;
        }

        public async Task<List<CalculationResultDto>> GetCalculationsAsync(GetCalculationsRequestDto request)
        {
            string isoCurrencySymbol = RegionInfo.CurrentRegion.ISOCurrencySymbol;

            var dbQuery = from calculation in _taxCalculatorDbContext.CalculationResults
                          join postalCode in _taxCalculatorDbContext.PostalCodes
                          on calculation.PostalCodeId equals postalCode.Id
                          join taxType in _taxCalculatorDbContext.TaxtTypes
                          on postalCode.TaxTypeId equals taxType.Id
                          join setting in _taxCalculatorDbContext.PayRangeSettings
                          on calculation.PayRangeSettingId equals setting.Id
                          where request.Id == null || calculation.Id == request.Id
                          orderby calculation.Id descending
                          select
                          new CalculationResultDto()
                          {
                              Created = calculation.Created,
                              Id = calculation.Id,
                              PayAmount = calculation.PayAmount,
                              TaxAmount = calculation.TaxAmount,
                              PostalCodeId = postalCode.Id,
                              PostalCode = postalCode.Code,
                              TaxtTypeId = taxType.Id,
                              TaxtTypeName = taxType.Name,
                              AppliedTaxId = setting.Id,
                              AppliedTax = setting == null ? "" : "Range (" + setting.From + "," + setting.To + ") - " + setting.CalculationValue + (setting.CalculationTypeId == 1 ? "%" : isoCurrencySymbol)
                          };

            return await dbQuery.ToListAsync();
        }

    }
}
