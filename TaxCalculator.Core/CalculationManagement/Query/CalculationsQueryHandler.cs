using MediatR;
using TaxCalculator.Api.Core.CalculationManagement.Messages;
using TaxCalculator.Core.CalculationManagement.Service.Calculator;
using TaxCalculator.DB.Tables;
using TaxCalculator.Model.Dto;

namespace TaxCalculator.Api.Core.CalculationManagement.Command
{
    public class CalculationsQueryHandler : IRequestHandler<CalculationsQueryRequest, CalculationsQueryResponse>
    {
        private readonly ICalculatorService _calculatorService;

        public CalculationsQueryHandler(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public async Task<CalculationsQueryResponse> Handle(CalculationsQueryRequest request, CancellationToken cancellationToken)
        {
            CalculationsQueryResponse response = new CalculationsQueryResponse(); 

            response.Reponse = await _calculatorService.GetCalculationsAsync(request.Request);

            return response;
        }

    }
}