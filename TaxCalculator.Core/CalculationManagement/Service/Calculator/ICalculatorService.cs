using TaxCalculator.Model.Dto;

namespace TaxCalculator.Core.CalculationManagement.Service.Calculator
{
    public interface ICalculatorService
    {
        Task<CalculateResponseDto> CalculateAsync(CalculateRequestDto requestDto);
        Task<GetCalculationsResponseDto> GetCalculationsAsync(GetCalculationsRequestDto request);
    }
}
