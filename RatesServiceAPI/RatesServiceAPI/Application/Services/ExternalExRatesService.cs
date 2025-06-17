using RatesServiceAPI.Infrastrucutre.Data;

namespace RatesServiceAPI.Application.Services
{
	public class ExternalExRatesService
	{
		public static async Task<IList<ExchangeRate>> GetCurrencyLiveRatesAsync()
		{
			//add euro with rate 1
			var ratesToEuro = new List<ExchangeRate>
			{
				new ExchangeRate { Id = 1, Code = "BTC", Value = 58890.01m },
				new ExchangeRate { Id = 2, Code = "ETH", Value = 2680.019m },
				new ExchangeRate { Id = 3, Code = "BNB", Value = 519.95m },
				new ExchangeRate { Id = 4, Code = "USDT", Value = 1.001135m },
				new ExchangeRate { Id = 5, Code = "ADA", Value = 0.335255m },
				new ExchangeRate { Id = 6, Code = "SHIB", Value = 0.105441m },
				new ExchangeRate { Id = 7, Code = "DOGE", Value = 0.665457m }
			};

			return ratesToEuro.ToList();
		}

	}
}
