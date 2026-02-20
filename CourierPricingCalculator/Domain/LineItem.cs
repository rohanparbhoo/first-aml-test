namespace CourierPricingCalculator.Domain
{
	public class LineItem
	{
		public Money Cost { get; }

		public LineItem(Money cost)
		{
			Cost = cost;
		}
	}
}

