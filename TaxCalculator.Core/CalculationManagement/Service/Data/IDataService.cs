using TaxCalculator.DB.Tables;
using TaxCalculator.Model.Dto;

namespace TaxCalculator.Core.CalculationManagement.Service.Data
{
    public interface IDataService
    {
        Task<PayRangeSetting> GetPayRangeSettingAsync(CalculateRequestDto request);

        Task<long> SaveCalculationAsync(CalculateDataDto request, long payRangeSettinId);

        Task<List<CalculationResultDto>> GetCalculationsAsync(GetCalculationsRequestDto request);
    }
}
