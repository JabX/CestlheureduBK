namespace CestlheureduBK.Model;

public record StoreLocator(Marker[] Markers);
public record Marker(string Id, decimal Lat, decimal Lng);

public record Restaurant(string Id, string OpeningCacHour, string ClosingCacHour, string OpeningHour, string ClosingHour, string Status, string DriveStatus, string CacStatus, string CagStatus, string CasStatus, string CapStatus, string Name, string AddressFull, decimal Lat, decimal Lng, string PageUrl, bool External, bool HasCoupons, string? DeliverooUrl, string? UberEatsUrl, string? JustEatUrl, string DlvStatus, string[] Services);

