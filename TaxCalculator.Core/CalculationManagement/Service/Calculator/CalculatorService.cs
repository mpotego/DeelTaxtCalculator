using TaxCalculator.Core.CalculationManagement.Service.Data;
using TaxCalculator.DB;
using TaxCalculator.Model.Dto;
using TaxCalculator.Model.Enum;

namespace TaxCalculator.Core.CalculationManagement.Service.Calculator
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IDataService _dataService;

        public CalculatorService(IDataService dataService)
        {
            _dataService = dataService;
        }

        public async Task<CalculateResponseDto> CalculateAsync(CalculateRequestDto requestDto)
        {
            var response = new CalculateResponseDto();


            response.ErrorList = validateCalculateRequest(requestDto);
            if (!response.IsSuccessfull)
            {
                return response;
            }

            var settings = await _dataService.GetPayRangeSettingAsync(requestDto);

            if (settings == null)
            {
                response.ErrorList.Add("No settings found the provided request.");
                return response;
            }

            switch (settings.CalculationTypeId)
            {
                case (int)CalculationTypeEnum.Percentage:
                    response.Data.TaxAmount = requestDto.Amount * (settings.CalculationValue / 100);
                    break;
                case (int)CalculationTypeEnum.FlatValue:
                    response.Data.TaxAmount = settings.CalculationValue;
                    break;
            }

            response.Data.Amount = requestDto.Amount;
            response.Data.PostalCode = requestDto.PostalCode;
            response.Data.Id = await _dataService.SaveCalculationAsync(response.Data, settings.Id);

            return response;
        }

        public async Task<GetCalculationsResponseDto> GetCalculationsAsync(GetCalculationsRequestDto request)
        {
            var response = new GetCalculationsResponseDto();

            response.Data = await _dataService.GetCalculationsAsync(request);

            return response;
        }

        private List<string> validateCalculateRequest(CalculateRequestDto requestDto)
        {
            List<string> errors = new List<string>();
            if (requestDto == null)
            {
                errors.Add("Request cannot be null.");
            }
            else
            {
                if (requestDto.Amount <= 0)
                {
                    errors.Add("Amount must be greater than zero.");
                }

                if (string.IsNullOrEmpty(requestDto.PostalCode))
                {
                    errors.Add("PostalCode cannot be null or empty.");
                }
            }

            return errors;
        }
    }
}
