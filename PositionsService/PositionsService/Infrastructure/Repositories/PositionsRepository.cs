using PositionsService.Domain.Interfaces;
using PositionsService.Infrastructure.Data;
using RatesServiceAPI.Infrastrucutre.Data;

namespace PositionsService.Infrastructure.Repositories
{
	public class PositionsRepository : IPositionsRepository
	{
		PositionsServiceDbContext _dbContext;
		public PositionsRepository(PositionsServiceDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Position>> GetPositionsAsync()
		{
			return await _dbContext.GetPositionsAsync();
		}

		public async Task UpdatePositionAsync(ExchangeRate updatedRate)
		{
			await _dbContext.UpdatePositionAsync(updatedRate);
		}
	}
}
