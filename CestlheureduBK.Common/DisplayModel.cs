namespace CestlheureduBK.Common;

public record OfferCriteria
{
    public string SortBy { get; set; } = "value";

    public bool Asc { get; set; }

    public string Name { get; set; } = "";

    public List<int>? Points { get; set; }

    public List<CategorieDisplay>? Categories { get; set; }
}

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

public record RestaurantDisplay(string Id, string Name, string AddressFull, string Departement);
public record UpdateDisplay(DateTime? Catalogue, DateTime? Offers);
