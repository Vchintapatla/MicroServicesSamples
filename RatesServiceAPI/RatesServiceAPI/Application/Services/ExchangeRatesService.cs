using RatesServiceAPI.Application.CommonTools;
using RatesServiceAPI.Domain.Interfaces;
using RatesServiceAPI.Infrastrucutre.Data;

namespace RatesServiceAPI.Application.Services
{
	public class ExchangeRatesService
	{
		private readonly IExchangeRatesRepo _exchangeRatesRepo;
		public ExchangeRatesService(IExchangeRatesRepo exchangeRatesRepo)
		{
			_exchangeRatesRepo = exchangeRatesRepo;
		}
		public async Task UpdateExchangeRates()
		{
			var newExchangeRates = await ExternalExRatesService.GetCurrencyLiveRatesAsync();
			ProcessExchangeRates(newExchangeRates);
		}

		private async void ProcessExchangeRates(IList<ExchangeRate> newExRates)
		{
			List<ExchangeRate> highVariationRates = new List<ExchangeRate>();
			foreach (var newRate in newExRates)
			{
				var oldExRate = await _exchangeRatesRepo.GetExchangeRateByCode(newRate.Code);
				if (oldExRate != null)
				{
					if (PercentageCalc.IsPercentageGreaterThan(oldExRate.Value, newRate.Value, 5))
					{
						highVariationRates.Add(newRate);
					}
				}

				// update the new rate to the repo
				await _exchangeRatesRepo.UpdateAsync(newRate);
			}

			PositionsServiceConnector.UpdatePositionsService(highVariationRates);
		}
	}
}
