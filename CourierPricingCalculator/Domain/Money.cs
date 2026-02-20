namespace CourierPricingCalculator.Domain
{
	public class Money
	{
        public static Money Zero => new Money(0.00m, "NZD");
        public decimal Amount { get; }
		public string Currency { get; }

		public Money(decimal amount, string currency)
		{
			Amount = amount;
			Currency = currency;
		}
	}
}

