using CourierPricingCalculator.Domain;
using CourierPricingCalculator.Utilities;

namespace CourierPricingCalculator;

public class CourierPricing
{
    public Quote Calculate(IEnumerable<Parcel> parcels, bool isSpeedyShipping = false)
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

            var weightLimit = parcelSize switch
            {
                ParcelSize.Small => 1m,
                ParcelSize.Medium => 3m,
                ParcelSize.Large => 6m,
                ParcelSize.Xl => 10m,
                _ => 0m
            };

            var overweightKg = Math.Max(0m, parcel.Weight - weightLimit);
            var overweightCharge = overweightKg * 2m;

            var finalPrice = new Money(
                parcelPrice.Amount + overweightCharge,
                Money.DefaultCurrencyCode
            );

            lineItems.Add(new ParcelLineItem(finalPrice, parcelSize));
        }

        var subtotal = new Money(
            lineItems.Sum(lineItem => lineItem.Cost.Amount),
            Money.DefaultCurrencyCode
        );

        if (isSpeedyShipping && subtotal.Amount > 0m)
        {
            lineItems.Add(new SpeedyShippingLineItem("Speedy shipping", subtotal));
        }

        var total = new Money(
            lineItems.Sum(lineItem => lineItem.Cost.Amount),
            Money.DefaultCurrencyCode
        );

        return new Quote(total, lineItems);
    }
}

