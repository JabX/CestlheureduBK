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

public record RestaurantDisplay(string Id, string Name, string AddressFull, string Departement)
{
    public string FullName => $"{Departement} - {Name}";
}
public record UpdateDisplay(DateTime? Catalogue, DateTime? Offers);
