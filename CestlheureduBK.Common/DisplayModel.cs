namespace CestlheureduBK.Common;

public record CategorieDisplay(string Id, string Name, bool SubCategory);

public record SnackAmountDisplay(string Name, int Amount);

public enum ItemType
{
    Product,
    Menu,
    ProductAsMenu,
}

public record OfferDisplay(
    ItemType Type,
    string Name,
    string? Image,
    int Points,
    double Price,
    double Energy,
    IEnumerable<SnackAmountDisplay> Snacks,
    IEnumerable<CategorieDisplay> Categories
)
{
    public double EnergyValue => Energy / Points;
    public double PriceValue => Price / Points;
}

public record CatalogueDisplay(
    ItemType Type,
    string Id,
    string Name,
    string? Image,
    double Price,
    double Energy,
    IEnumerable<SnackAmountDisplay> Snacks,
    IEnumerable<CategorieDisplay> Categories
)
{
    public double EnergyValue => Energy / Price;
}

public record CatalogueEnergyUpdate(ItemType Type, string Id, double Energy);

public record SnackProductDisplay(string Name, string? Image, int Amount, double Price, double Ratio)
{
    public double Value => Price * Ratio / Amount;
}

public record SnackDisplay(string Name, SnackProductDisplay[] Products);

public record BurgerMystereDisplay(
    int Id,
    string Name,
    string? Image,
    string? Name2,
    string? Image2,
    double Price1,
    double Energy1,
    double Price2,
    double Energy2,
    double Chance,
    int MyCount,
    int TotalCount
)
{
    public double Price => Price1 + Price2;

    public double Energy => Energy1 + Energy2;
}

public record BurgerMystereListDisplay(string Name, double Price, IList<BurgerMystereDisplay> Burgers)
{
    public double PriceExpectancy => Burgers.Sum(b => b.Chance * b.Price) / Burgers.Sum(b => b.Chance);

    public double PriceGain => PriceExpectancy / Price;

    public double EnergyExpectancy => Burgers.Sum(b => b.Chance * b.Energy) / Burgers.Sum(b => b.Chance);

    public double EnergyGain => EnergyExpectancy / Price;

    public int MyCount => Burgers.Sum(b => b.MyCount);

    public int TotalCount => Burgers.Sum(b => b.TotalCount);
}

public record MysteryRollDisplay(
    int Id,
    string UserName,
    string Month,
    string ProductName,
    double ProductPrice,
    double CampaignPrice,
    string RestaurantName,
    DateTime RollTime
)
{
    public double Gain => ProductPrice - CampaignPrice;
}

public record RestaurantDisplay(
    string Id,
    string Name,
    string AddressFull,
    string Departement,
    double Lat,
    double Lng,
    DateTime? CatalogueUpdate
)
{
    public string FullName => $"{Departement} - {Name}";
}

public record HeaderDisplay(
    RestaurantDisplay? Restaurant,
    RestaurantDisplay[] Restaurants,
    DateTime? OffersUpdate,
    bool IsAuthenticated,
    RestaurantDisplay? FavoriteRestaurant
);
