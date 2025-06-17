/// PositionsServices.cs
/// This file has code to excute any application related code which can be accessed from controller
///
using PositionsService.Domain.Interfaces;
using PositionsService.Infrastructure.Data;
using RatesServiceAPI.Infrastrucutre.Data;

namespace PositionsService.Application.Services
{
	public class PositionsServices
	{
		private readonly IPositionsRepository _positionsRepository;

		public PositionsServices(IPositionsRepository positionsRepository)
		{
			_positionsRepository = positionsRepository;
		}

		public async Task<IEnumerable<Position>> GetPositionsAsync()
		{
			return await _positionsRepository.GetPositionsAsync();
		}

		public async Task UpdatePositionsAsync(IEnumerable<ExchangeRate> exchangeRates)
		{
			foreach (var exchangeRate in exchangeRates)
			{
				await _positionsRepository.UpdatePositionAsync(exchangeRate);
			}

			// To Do: Notify UI about the changes in Positions
		}
	}
}
