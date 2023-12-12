using Microsoft.AspNetCore.Mvc; 
using MediatR;
using TaxCalculator.Api.Core.CalculationManagement.Messages;
using TaxCalculator.Model.Dto;

namespace TaxCalculator.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ILogger<TaxCalculatorController> _logger;
        private readonly IMediator _mediator;

        public TaxCalculatorController(ILogger<TaxCalculatorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("Calculate")]
        [ProducesResponseType(typeof(CalculateResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> CalculateAsync(CalculateRequestDto requestDto)
        {
            try
            {
                var response = await _mediator.Send(new CalculateCommandRequest() { Request = requestDto });
                return Ok(response.Reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(1), ex, "Error on Calculate");
                var response = new CalculateResponseDto() { ErrorList = new List<string>() { "A server Error occured. Please contaact system admin." } };
                return Ok(response);
            }
        }

        [HttpPost("GetCalculations")]
        [ProducesResponseType(typeof(GetCalculationsResponseDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCalculationsAsync(GetCalculationsRequestDto requestDto)
        {
            try
            {
                var response = await _mediator.Send(new CalculationsQueryRequest() { Request = requestDto });
                return Ok(response.Reponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(1), ex, "Error on Calculate");
                var response = new GetCalculationsResponseDto() { ErrorList = new List<string>() { "A server Error occured. Please contaact system admin." } };
                return Ok(response);
            }
        }
        
    }
}