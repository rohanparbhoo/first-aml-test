using System;
namespace CourierPricingCalculator.Domain
{
	public class Parcel
	{
        public int Width { get; }
        public int Height { get; }
        public int Length { get; }
        public decimal Weight{ get; }

        public Parcel(int width, int height, int length, decimal weight)
        {
            Width = width;
            Height = height;
            Length = length;
            Weight = weight;
        }
    }
}

