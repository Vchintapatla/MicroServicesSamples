using Microsoft.AspNetCore.Mvc;
using RatesServiceAPI.Application.Services;

namespace RatesServiceAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ExchangeRateController : ControllerBase
	{
		private readonly ExchangeRatesService _exRateService;

		public ExchangeRateController(ExchangeRatesService exRateService)
		{
			_exRateService = exRateService;
		}

		[HttpGet]
		public ActionResult GetExchangeRates()
		{
			return Ok(_exRateService.UpdateExchangeRates());
		}
	}
}
