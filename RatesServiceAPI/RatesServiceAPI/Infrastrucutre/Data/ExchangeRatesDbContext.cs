using Microsoft.EntityFrameworkCore;

namespace RatesServiceAPI.Infrastrucutre.Data
{
	public class ExchangeRatesDbContext : DbContext
	{
		public ExchangeRatesDbContext(DbContextOptions<ExchangeRatesDbContext> options) : base(options)
		{
			InitializeData();
		}
		private void InitializeData()
		{
			ExchangeRatesList = new List<ExchangeRate>
			{
				new ExchangeRate { Id = 1, Code = "BTC", Value = 58871.01m },
				new ExchangeRate { Id = 2, Code = "ETH", Value = 2682.019m },
				new ExchangeRate { Id = 3, Code = "BNB", Value = 512.95m },
				new ExchangeRate { Id = 4, Code = "USDT", Value = 1.000135m },
				new ExchangeRate { Id = 5, Code = "ADA", Value = 0.335245m },
				new ExchangeRate { Id = 6, Code = "SHIB", Value = 0.105241m },
				new ExchangeRate { Id = 7, Code = "DOGE", Value = 0.565457m }
			};
		}
		public DbSet<ExchangeRate> ExchangeRates { get; set; }
		public List<ExchangeRate> ExchangeRatesList { get; set; }
		// Seed data for initial products and customers
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			// Seed ExchangeRates
			modelBuilder.Entity<ExchangeRate>().HasData(
				new ExchangeRate { Id = 1, Code = "BTC", Value = 58871.01m },
				new ExchangeRate { Id = 2, Code = "ETH", Value = 2682.019m },
				new ExchangeRate { Id = 3, Code = "BNB", Value = 512.95m },
				new ExchangeRate { Id = 4, Code = "USDT", Value = 1.000135m },
				new ExchangeRate { Id = 5, Code = "ADA", Value = 0.335245m },
				new ExchangeRate { Id = 6, Code = "SHIB", Value = 0.105241m },
				new ExchangeRate { Id = 7, Code = "DOGE", Value = 0.565457m }
			);
			
		}

		public async Task<ExchangeRate> GetExchangeRateByCode( string code )
		{
			var rate = ExchangeRatesList.Find(r => r.Code == code);
			if(rate == null)
			{
				return new ExchangeRate { Id = ExchangeRatesList.Count() + 1, Code = code, Value = 1.0m };
			}
			return rate;
		}

		public async Task UpdateExchangeRateAsyc(ExchangeRate exchangeRate)
		{
			var rate = ExchangeRatesList.Find(r => r.Code == exchangeRate.Code);
			if (rate != null)
			{
				rate.Value = exchangeRate.Value;
			}
			else
			{
				exchangeRate.Id = ExchangeRatesList.Count() + 1;
				ExchangeRatesList.Add(exchangeRate);
			}
			//await SaveChangesAsync();
		}
	}
}
