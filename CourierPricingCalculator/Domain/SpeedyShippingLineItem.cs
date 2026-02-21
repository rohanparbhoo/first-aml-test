namespace CourierPricingCalculator.Domain
{
	public class SpeedyShippingLineItem : LineItem
	{
        public string Description { get; }

        public SpeedyShippingLineItem(string description, Money cost) : base(cost)
        {
            Description = description;
        }
    }
}

