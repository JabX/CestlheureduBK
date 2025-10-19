namespace CestlheureduBK.Common;

public static class Utils
{
    public static string ToLocalDisplay(this DateTime date)
    {
        return TimeZoneInfo
            .ConvertTimeFromUtc(date, TimeZoneInfo.FindSystemTimeZoneById("Europe/Paris"))
            .ToString("dd/MM/yyyy à HH:mm");
    }

    public static string ToLocalDisplay(this DateTime? date)
    {
        if (date == null)
        {
            return string.Empty;
        }

        return date.Value.ToLocalDisplay();
    }
}
