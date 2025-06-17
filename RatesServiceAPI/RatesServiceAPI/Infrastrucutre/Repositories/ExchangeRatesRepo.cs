using RatesServiceAPI.Domain.Interfaces;
using RatesServiceAPI.Infrastrucutre.Data;

namespace RatesServiceAPI.Infrastrucutre.Repositories
{
	public class ExchangeRatesRepo : IExchangeRatesRepo
	{
		private ExchangeRatesDbContext _exRatesDbContext;

		public ExchangeRatesRepo(ExchangeRatesDbContext exRatesDbContext)
		{
			_exRatesDbContext = exRatesDbContext;
		}
		public async Task UpdateAsync(ExchangeRate exRate)
		{
			await _exRatesDbContext.UpdateExchangeRateAsyc(exRate);
		}

		public async Task<ExchangeRate> GetExchangeRateByCode(string code)
		{
			return await _exRatesDbContext.GetExchangeRateByCode(code);
		}
	}
}
