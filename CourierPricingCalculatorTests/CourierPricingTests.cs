using CourierPricingCalculator;
using CourierPricingCalculator.Domain;

namespace CourierPricingCalculatorTests;

public class CourierPricingCalculatorTests
{
    private static CourierPricing CreateSut() => new CourierPricing();

    [Fact]
    public void WhenThereAreNoParcels_CourierPricing_ReturnsAnEmptyQuote()
    {
        var sut = CreateSut();

        var quote = sut.Calculate(Array.Empty<Parcel>());

        Assert.NotNull(quote);
        Assert.Equal(0.00m, quote.TotalCost.Amount);
        Assert.Empty(quote.LineItems);
    }

    [Fact]
    public void WhenANullIsPassed_CourierPricing_ThrowsAnException()
    {
        var sut = CreateSut();

        Assert.Throws<ArgumentNullException>(() => sut.Calculate(null));
    }

    [Theory]
    [InlineData(9, 9, 9, ParcelSize.Small, 3)]
    [InlineData(10, 9, 9, ParcelSize.Medium, 8)]
    [InlineData(49, 49, 49, ParcelSize.Medium, 8)]
    [InlineData(50, 49, 49, ParcelSize.Large, 15)]
    [InlineData(99, 99, 99, ParcelSize.Large, 15)]
    [InlineData(100, 1, 1, ParcelSize.Xl, 25)]
    [InlineData(1, 100, 1, ParcelSize.Xl, 25)]
    [InlineData(1, 1, 100, ParcelSize.Xl, 25)]
    public void CourierPricing_ClassifiesSizeAndAppliesPrice_ReturnsAQuote(
            int length, int width, int height,
            ParcelSize expectedSize,
            decimal expectedCost)
    {
        var sut = CreateSut();

        var parcels = new[]
        {
            new Parcel(length, width, height, 0)
        };

        var quote = sut.Calculate(parcels);

        Assert.Single(quote.LineItems);

        var parcelItem = Assert.IsType<ParcelLineItem>(quote.LineItems[0]);
        Assert.Equal(expectedSize, parcelItem.Size);
        Assert.Equal(expectedCost, parcelItem.Cost.Amount);
        Assert.Equal(expectedCost, quote.TotalCost.Amount);
    }

    [Fact]
    public void CourierPricing_WhenSpeedyShippingIsEnabled_DoublesTotalAndAddsLineItem()
    {
        var sut = CreateSut();

        var parcels = new[]
        {
            new Parcel(9, 9, 9, 0),
            new Parcel(10, 10, 10, 0),
        };

        var normalCourierPricing = sut.Calculate(parcels, false);
        var speedyCourierPricing = sut.Calculate(parcels, true);

        Assert.Equal(11m, normalCourierPricing.TotalCost.Amount);
        Assert.Equal(22m, speedyCourierPricing.TotalCost.Amount);

        Assert.Equal(normalCourierPricing.LineItems.Count + 1, speedyCourierPricing.LineItems.Count);
    }

    [Fact]
    public void CourierPricing_WhenParcelOverWeightLimit_AddsSurcharge()
    {
        var sut = CreateSut();

        var parcels = new[]
        {
            new Parcel(9, 9, 9, 3m)
        };

        var quote = sut.Calculate(parcels);

        Assert.Equal(7m, quote.TotalCost.Amount);
    }
}
