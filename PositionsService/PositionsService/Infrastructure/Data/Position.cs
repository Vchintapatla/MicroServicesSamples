namespace PositionsService.Infrastructure.Data
{
	public class Position
	{
		public int Id { get; set; }
		public string Instrument { get; set; }
		public int Quantity { get; set; }
		public decimal InitialRate { get; set; }
		public string Side { get; set; }
	}
}
