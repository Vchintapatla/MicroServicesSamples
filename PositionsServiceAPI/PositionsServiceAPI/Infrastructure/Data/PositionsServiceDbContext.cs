using Microsoft.EntityFrameworkCore;
using RatesServiceAPI.Infrastrucutre.Data;

namespace PositionsServiceAPI.Infrastructure.Data
{
	public class PositionsServiceDbContext : DbContext
	{
		public PositionsServiceDbContext(DbContextOptions<PositionsServiceDbContext> options)
			: base(options)
		{
			InitializeData();
		}

		public void InitializeData()
		{
			PositionsList = new List<Position>
			{
				new Position { Id = 1, Instrument = "BTC", Quantity = 3, InitialRate = 58871.01m, Side = "BUY" },
				new Position { Id = 2, Instrument = "ETH", Quantity = 10, InitialRate = 2682.019m, Side = "SELL" },
				new Position { Id = 3, Instrument = "BNB", Quantity = 20, InitialRate = 512.95m, Side = "BUY" },
				new Position { Id = 4, Instrument = "USDT", Quantity = 5, InitialRate = 1.000135m, Side = "BUY" },
				new Position { Id = 5, Instrument = "ADA", Quantity = 10000, InitialRate = 0.335245m, Side = "BUY" },
				new Position { Id = 6, Instrument = "SHIB", Quantity = 5000, InitialRate = 0.105241m, Side = "SELL" },
				new Position { Id = 7, Instrument = "DOGE", Quantity = 43000, InitialRate = 0.565457m, Side = "SELL" }
			};
		}
		public DbSet<Position> Positions { get; set; }
		public List<Position> PositionsList { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Seed Positions
			modelBuilder.Entity<Position>().HasData(
				new Position { Id = 1, Instrument = "BTC", Quantity = 3, InitialRate = 58871.01m, Side = "BUY" },
				new Position { Id = 2, Instrument = "ETH", Quantity = 10, InitialRate = 2682.019m, Side = "SELL" },
				new Position { Id = 3, Instrument = "BNB", Quantity = 20, InitialRate = 512.95m, Side = "BUY" },
				new Position { Id = 4, Instrument = "USDT", Quantity = 5, InitialRate = 1.000135m, Side = "BUY" },
				new Position { Id = 5, Instrument = "ADA", Quantity = 10000, InitialRate = 0.335245m, Side = "BUY" },
				new Position { Id = 6, Instrument = "SHIB", Quantity = 5000, InitialRate = 0.105241m, Side = "SELL" },
				new Position { Id = 7, Instrument = "DOGE", Quantity = 43000, InitialRate = 0.565457m, Side = "SELL" }
			);

		}

		public async Task<IEnumerable<Position>> GetPositionsAsync()
		{
			return PositionsList;
		}

		public async Task UpdatePositionAsync(ExchangeRate exchangeRate)
		{
			PositionsList.Where(p => p.Instrument == exchangeRate.Code).ToList().ForEach(p => p.InitialRate = exchangeRate.Value);
			//await SaveChangesAsync();
		}
	}
}
