using MediatR;
using TaxCalculator.Api.Core.CalculationManagement.Messages;
using TaxCalculator.Core.CalculationManagement.Service.Calculator;

namespace TaxCalculator.Api.Core.CalculationManagement.Command
{
    public class CalculateCommandHandler : IRequestHandler<CalculateCommandRequest, CalculateCommandResponse>
    {
        private readonly ICalculatorService _calculatorService;

        public CalculateCommandHandler(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public async Task<CalculateCommandResponse> Handle(CalculateCommandRequest request, CancellationToken cancellationToken)
        {
            CalculateCommandResponse response = new CalculateCommandResponse();

            response.Reponse = await _calculatorService.CalculateAsync(request.Request);

            return response;
        }

    }
}