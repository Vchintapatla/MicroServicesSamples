using System.Text;
using System.Text.Json;
using RatesServiceAPI.Infrastrucutre.Data;

namespace RatesServiceAPI.Application.Services
{
	public class PositionsServiceConnector
	{
		public static void UpdatePositionsService(IList<ExchangeRate> exchangeRates)
		{
			HttpClient client = new HttpClient();
			string apiUrl =$"http://localhost:5050/positions";
			string strObject = JsonSerializer.Serialize(exchangeRates);

			HttpContent httpContent = new StringContent(strObject, Encoding.UTF8, "application/json");

			var response = client.PutAsync(apiUrl, httpContent, new CancellationToken(false)).Result;

			if (response != null && response.IsSuccessStatusCode)
			{
				var data = response.Content.ReadAsStringAsync().Result;
			}

		}
	}
}
