using PositionsService.Infrastructure.Data;
using RatesServiceAPI.Infrastrucutre.Data;

namespace PositionsService.Domain.Interfaces
{
	public interface IPositionsRepository
	{
		Task<IEnumerable<Position>> GetPositionsAsync();
		Task UpdatePositionAsync(ExchangeRate updatedRate);
	}
}
