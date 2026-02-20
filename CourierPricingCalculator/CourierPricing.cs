using CourierPricingCalculator.Domain;
using CourierPricingCalculator.Utilities;

namespace CourierPricingCalculator;

public class CourierPricing
{
    public Quote Calculate(IEnumerable<Parcel> parcels)
    {
        if (parcels is null)
        {
            throw new ArgumentNullException($"{nameof(parcels)} can not be null.");
        }

        var parcelsList = parcels.ToList();

        if (!parcelsList.Any())
        {
            return new Quote(Money.Zero, new List<LineItem>());
        }

        var lineItems = new List<LineItem>();
        foreach(Parcel parcel in parcels)
        {
            var parcelSize = ParcelSizing.GetSize(parcel);
            var parcelPrice = ParcelPricing.GetPrice(parcelSize);

            lineItems.Add(new ParcelLineItem(parcelPrice, parcelSize));
        }

        var totalCost = new Money(lineItems.Sum(lineItem => lineItem.Cost.Amount), Money.DefaultCurrencyCode);

        return new Quote(totalCost, lineItems);
    }
}

