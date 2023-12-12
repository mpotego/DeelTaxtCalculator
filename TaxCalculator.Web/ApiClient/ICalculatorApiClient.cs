using TaxCalculator.Model.Dto;

namespace TaxCalculator.Web
{
    public interface ICalculatorApiClient
    {
        Task<GetCalculationsResponseDto> GetCalculationsAsync(GetCalculationsRequestDto requestDto);
        Task<CalculateResponseDto> CalculateAsync(CalculateRequestDto requestDto);
    }
}
