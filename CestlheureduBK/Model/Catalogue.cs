namespace CestlheureduBK.Model;

public record CategorieCategorie(string Id, int DisplayOrder);

public record Catalogue(
    Allergen[] Allergens,
    Categorie[] Categories,
    Game[] Games,
    Ingredient[] Ingredients,
    Menu[] Menus,
    Product[] Products,
    Promotion[] Promotions,
    Categorie[] SubCategories
);

public record Allergen(string Id, string Name, string Description, string Image);

public record Categorie(
    string Id,
    string Code,
    string Name,
    string? Description,
    string? Image,
    bool? InHeaders,
    bool? AcceptFilters,
    CategorieCategorie[]? Categories
);

public record Game(
    int Id,
    int Algo,
    double Price,
    string SysName,
    bool Available,
    bool Active,
    bool EarnPoints,
    int Vatpc
);

public record Ingredient(
    string Id,
    string Name,
    string Description,
    bool CampaignItem,
    bool WithPrice,
    string Plu,
    double Price,
    string Image,
    bool Available,
    bool Active,
    string[]? Allergens
);

public record MenuStep(
    Dictionary<string, string> Name,
    string[] ProductIds,
    string[]? ProductLIds,
    string[]? ProductXLIds,
    string DefaultId,
    int StepType
);

public record Menu(
    bool Active,
    string? AirshipTagInApp,
    bool Available,
    bool CampaignItem,
    CategorieCategorie[]? Categories,
    bool Customizable,
    string Description,
    bool EarnPoints,
    bool ExistsInL,
    bool ExistsInS,
    bool ExistsInXL,
    bool HasBacon,
    string Id,
    string Image,
    bool KidsMenu,
    int? MaxQuantity,
    string Name,
    string Plu,
    string PluL,
    string? PluS,
    string PluXL,
    double Price,
    double? PriceL,
    double? PriceS,
    double? PriceXL,
    string RouteId,
    string[] SubCategories,
    string[] SuggestionsIds,
    MenuStep[] Steps
);

public record ProductIngredient(
    int AmountType,
    bool CanModify,
    string GroupType,
    string IngredientDefaultId,
    string[] IngredientIds,
    int InitialAmount,
    int InitialQuantity,
    int MaxQty,
    int MinQty
);

public record ProductOption(int OptionType, string[] ProductIds);

public record Product(
    bool Active,
    string? AirshipTagInApp,
    string[] Allergens,
    bool Available,
    bool CampaignItem,
    CategorieCategorie[]? Categories,
    bool Composable,
    bool Configurable,
    string Description,
    bool EarnPoints,
    bool HasBacon,
    bool HasIce,
    string Id,
    string Image,
    ProductIngredient[] Ingredients,
    bool IsComposable,
    bool IsProductGroup,
    Dictionary<int, int> MaxCountByOptionType,
    int? MaxQuantity,
    double MenuExtraPriceTTC,
    string Name,
    bool NoWeb,
    ProductOption[] Options,
    bool PickupLater,
    string Plu,
    double Price,
    bool ProductGroup,
    string? ProductGroupId,
    string RouteId,
    string[]? SubCategories,
    string[] SuggestionsIds,
    string? UpperSizeProductId
);

public record Promotion(
    string Code,
    string Description,
    string Id,
    string IdReboot,
    string Label,
    double? MaxPriceToApply,
    string[] MenuIds,
    double? MinPriceToApply,
    string Name,
    string[] ProductIds,
    string? PromoRuleClassname,
    string? PromoRuleScript,
    string PromoType,
    double? PromoValue,
    string[] RequiredMenuIds,
    string[] RequiredProductIds,
    double? Threshold
);
