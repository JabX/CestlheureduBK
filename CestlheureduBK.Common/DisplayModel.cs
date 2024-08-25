namespace CestlheureduBK.Common;

public record CategorieDisplay(string Id, string Name, bool SubCategory);
public record SnackAmountDisplay(string Name, int Amount);

public record OfferDisplay(string Type, string Name, string? Image, int Points, decimal Price, IEnumerable<SnackAmountDisplay> Snacks, IEnumerable<CategorieDisplay> Categories)
{
    public decimal Value => Price / Points;
}

public record SnackProductDisplay(string Name, string? Image, int Amount, decimal Price, decimal Ratio)
{
    public decimal Value => Price * Ratio / Amount;
}

public record SnackDisplay(string Name, SnackProductDisplay[] Products);

public record RestaurantDisplay(string Id, string Name, string AddressFull, string Departement)
{
    public string FullName => $"{Departement} - {Name}";
}
public record UpdateDisplay(DateTime? Catalogue, DateTime? Offers);
