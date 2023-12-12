using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaxCalculator.Model.Dto;
using TaxCalculator.Web.Models;

namespace TaxCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculatorApiClient _calculatorApiClient;

        public HomeController(ILogger<HomeController> logger, ICalculatorApiClient calculatorApiClient)
        {
            _logger = logger;
            _calculatorApiClient = calculatorApiClient;
        }

        public async Task<IActionResult> Index()
        {
            try
            {

                ViewData.Model = new List<CalculationResultDto>();
                var responseDto = await _calculatorApiClient.GetCalculationsAsync(new GetCalculationsRequestDto() { Id = null });
                if (responseDto != null && responseDto.IsSuccessfull)
                {
                    ViewData.Model = responseDto.Data;
                }
                else
                { 
                    TempData["msg"] = string.Join('\n', responseDto.ErrorList);
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                _logger.LogError(new EventId(1), ex.Message);
            }
            return View();
        }

        public async Task<IActionResult> Calculate([Bind]CalculateRequestDto requestDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var responseDto = await _calculatorApiClient.CalculateAsync(requestDto);

                    if (responseDto != null && responseDto.IsSuccessfull)
                    {
                        TempData["msg"] = "Saved successfully. ";

                        return RedirectToAction("Index");

                    }
                    else
                    {
                        TempData["msg"] = string.Join('\n',  responseDto.ErrorList);
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
                _logger.LogError(new EventId(1), ex.Message);
            }

            return View();
        }
         
    }
}