namespace CestlheureduBK.Common;

public record CategorieDisplay(string Id, string Name, bool SubCategory);
public record SnackAmountDisplay(string Name, int Amount);

public record OfferDisplay(string Type, string Name, string? Image, int Points, double Price, double Energy, IEnumerable<SnackAmountDisplay> Snacks, IEnumerable<CategorieDisplay> Categories)
{
    public double EnergyValue => Energy / Points;
    public double PriceValue => Price / Points;
}

public record CatalogueDisplay(string Type, string Name, string? Image, double Price, double Energy, IEnumerable<SnackAmountDisplay> Snacks, IEnumerable<CategorieDisplay> Categories)
{
    public double EnergyValue => Energy / Price;
}

public record SnackProductDisplay(string Name, string? Image, int Amount, double Price, double Ratio)
{
    public double Value => Price * Ratio / Amount;
}

public record SnackDisplay(string Name, SnackProductDisplay[] Products);

public record BurgerMystereDisplay(string Id, string Name, string? Image, double Price, double Energy, double Chance);

public record BurgerMystereListDisplay(string Name, double Price, IList<BurgerMystereDisplay> Burgers)
{
    public double PriceExpectancy => Burgers.Sum(b => b.Chance * b.Price) / Burgers.Sum(b => b.Chance);

    public double EnergyExpectancy => Burgers.Sum(b => b.Chance * b.Energy) / Burgers.Sum(b => b.Chance);
}

public record RestaurantDisplay(string Id, string Name, string AddressFull, string Departement, double Lat, double Lng, DateTime? CatalogueUpdate)
{
    public string FullName => $"{Departement} - {Name}";
}

public record HeaderDisplay(RestaurantDisplay? Restaurant, RestaurantDisplay[] Restaurants, DateTime? OffersUpdate, bool IsAuthenticated, RestaurantDisplay? FavoriteRestaurant);