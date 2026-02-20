namespace CourierPricingCalculator.Domain
{
    public class ParcelLineItem : LineItem
    {
        public ParcelSize Size { get; }

        public ParcelLineItem(Money cost, ParcelSize size) : base (cost)
        { 
            Size = size;
        }
    }
}

