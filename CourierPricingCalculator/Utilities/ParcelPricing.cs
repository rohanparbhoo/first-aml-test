using CourierPricingCalculator.Domain;

namespace CourierPricingCalculator.Utilities
{
	public static class ParcelPricing
	{
		public static Money GetPrice(ParcelSize size)
		{
			return size switch
			{
				ParcelSize.Small => new Money(3.00m, Money.DefaultCurrencyCode),
				ParcelSize.Medium => new Money(8.00m, Money.DefaultCurrencyCode),
				ParcelSize.Large => new Money(15.00m, Money.DefaultCurrencyCode),
				ParcelSize.Xl => new Money(25.00m, Money.DefaultCurrencyCode),
				_ => throw new ArgumentOutOfRangeException(nameof(size), $"Not expected parcel size value: {size}")
			};
		}
	}
}

