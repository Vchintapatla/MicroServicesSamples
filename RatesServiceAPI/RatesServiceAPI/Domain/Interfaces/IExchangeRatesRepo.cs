using RatesServiceAPI.Infrastrucutre.Data;

namespace RatesServiceAPI.Domain.Interfaces
{
	public interface IExchangeRatesRepo
	{
		Task<ExchangeRate> GetExchangeRateByCode(string currency);
		Task UpdateAsync(ExchangeRate exRate);
	}
}
