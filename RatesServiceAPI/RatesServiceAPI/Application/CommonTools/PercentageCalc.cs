namespace RatesServiceAPI.Application.CommonTools
{
	public class PercentageCalc
	{
		public static bool IsPercentageGreaterThan(decimal oldRate, decimal newRate, decimal maxPerc)
		{
			if (oldRate == 0)
				return false;

			if (newRate == 0)
				return false;

			var change = ((newRate - oldRate) / oldRate) * 100;

			if (Decimal.Compare(change, maxPerc) > 0)
			{
				return true;
			}

			return false;
		}

	}
}
