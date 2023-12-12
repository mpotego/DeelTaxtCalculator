using MediatR;
using TaxCalculator.Model.Dto;

namespace TaxCalculator.Api.Core.CalculationManagement.Messages
{
    public class CalculateCommandRequest : IRequest<CalculateCommandResponse>
    {
        public CalculateRequestDto Request { get; set; }
    }
}
