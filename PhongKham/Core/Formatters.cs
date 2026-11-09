using System.Globalization;

namespace PhongKham.Core;

public static class Formatters
{
    public static readonly CultureInfo Vietnamese = CultureInfo.GetCultureInfo("vi-VN");
    public static string Tien(long value) => value.ToString("N0", Vietnamese) + " đ";
    public static string Ngay(DateTime? value) => value?.ToString("dd/MM/yyyy") ?? "";
    public static string Gio(DateTime? value) => value?.ToString("HH:mm") ?? "";
    public static int? Tuoi(DateTime? birth, DateTime? today = null)
    {
        if (birth is null)
            return null;
        var date = (today ?? DateTime.Today).Date;
        int age = date.Year - birth.Value.Year;
        if (birth.Value.Date > date.AddYears(-age))
            age--;
        return age;
    }

    public static string CheTen(string name)
    {
        var parts = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length < 3)
            return parts.Length == 2 ? parts[0] + " " + parts[1][0] + "." : name;
        return parts[0] + " " + string.Join(" ", parts.Skip(1).SkipLast(1).Select(x => x[0] + ".")) + " " + parts[^1];
    }

    public static string CsvSeparator { get; } = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
}