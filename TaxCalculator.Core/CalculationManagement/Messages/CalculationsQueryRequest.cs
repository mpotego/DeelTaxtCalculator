using MediatR;
using TaxCalculator.Model.Dto;

namespace TaxCalculator.Api.Core.CalculationManagement.Messages
{
    public class CalculationsQueryRequest : IRequest<CalculationsQueryResponse>
    {
        public GetCalculationsRequestDto Request { get; set; }
    }
}
