namespace RatesServiceAPI.Infrastrucutre.Data
{
	public class ExchangeRate
	{
		public int Id { get; set; }
		public required string Code { get; set; }
		public decimal Value { get; set; }
	}
}
