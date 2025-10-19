namespace CestlheureduBK.Model;

public record Points(Level[] Levels, PointInfos PointInfos);

public record Offer(
    string[] Images,
    string LegalNotice,
    int Points,
    string PromotionId,
    string RouteId,
    string Title,
    string TransformationId,
    string Type
);

public record Level(string Color, int MinPoints, bool Mystere, string Title, Offer[] Offers);

public record PointInfos(int CurrentLevelIndex, DateTime ExpirationDate, int NbLevels, int Points);
