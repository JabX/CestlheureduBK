namespace CestlheureduBK.Model;

public record Nutrition(string Item, string Portion, string Share, string Unit);

public record ProductApi(Nutrition[] Nutrition);

public record ProductResult(ProductApi Product);
