namespace CourierPricingCalculator.Domain
{
	public static class ParcelSizing
	{
        private static readonly int SmallSize = 10;
        private static readonly int MediumSize = 50;
        private static readonly int LargeSize = 100;

        public static ParcelSize GetSize(ParcelLineItem parcel)
		{
            if (parcel.Width < SmallSize && parcel.Height < SmallSize && parcel.Length < SmallSize)
            {
                return ParcelSize.Small;
            }

            if (parcel.Width < MediumSize && parcel.Height < MediumSize && parcel.Length < MediumSize)
            {
                return ParcelSize.Medium;
            }

            if (parcel.Width < LargeSize && parcel.Height < LargeSize && parcel.Length < LargeSize)
            {
                return ParcelSize.Large;
            }

            return ParcelSize.Xl;
        }
	}
}

