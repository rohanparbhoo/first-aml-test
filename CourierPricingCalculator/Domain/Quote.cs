namespace CourierPricingCalculator.Domain
{
	public class Quote
	{
		public Money TotalCost { get; }
		public IReadOnlyList<LineItem> LineItems { get; }

		public Quote(Money totalCost, IReadOnlyList<LineItem> lineItems)
		{
			TotalCost = totalCost;
			LineItems = lineItems;
		}
	}
}

