using Microsoft.AspNetCore.Mvc;
using PositionsServiceAPI.Application.Services;
using PositionsServiceAPI.Infrastructure.Data;
using RatesServiceAPI.Infrastrucutre.Data;

namespace PositionsServiceAPI.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class PositionsController : ControllerBase
	{
		private PositionsServices _positionsServices;

		public PositionsController(PositionsServices positionsServices)
		{
			_positionsServices = positionsServices;
		}

		[HttpGet]
		public IEnumerable<Position> Get()
		{
			return _positionsServices.GetPositionsAsync().Result;
		}

		[HttpPut]
		public async void Put([FromBody] IList<ExchangeRate> updatedRates)
		{
			await _positionsServices.UpdatePositionsAsync(updatedRates);
		}
	}
}
