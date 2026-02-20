namespace CourierPricingCalculator.Domain
{
    public class ParcelLineItem : LineItem
    {
        public int Width { get; }
        public int Height { get; }
        public int Length { get; }
        public ParcelSize Size { get; }

        public ParcelLineItem(int width, int height, int length, ParcelSize size)
        {
            Width = width;
            Height = height;
            Length = length;
            Size = size;
        }
    }
}

