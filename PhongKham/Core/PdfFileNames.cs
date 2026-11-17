using PhongKham.Models.Views;

namespace PhongKham.Core;

public static class PdfFileNames
{
    public static string Report(KyBaoCao period, DateTime periodStart, DateTime printedOn) =>
        "BAOCAOTHEO" + (period switch
        {
            KyBaoCao.Ngay => "NGAY-" + periodStart.ToString("dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
            KyBaoCao.Thang => "THANG-" + periodStart.ToString("MM-yyyy", System.Globalization.CultureInfo.InvariantCulture),
            KyBaoCao.Quy => "QUY-" + ((periodStart.Month - 1) / 3 + 1).ToString(System.Globalization.CultureInfo.InvariantCulture) + "-" + periodStart.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture),
            KyBaoCao.Nam => "NAM-" + periodStart.ToString("yyyy", System.Globalization.CultureInfo.InvariantCulture),
            _ => throw new NghiepVuException("Kỳ báo cáo không hợp lệ.")
        }) + "-" + printedOn.ToString("ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);

    public static string Document(MauBanIn data, DateTime printedOn)
    {
        if (data.KyBaoCao.HasValue)
            return Report(data.KyBaoCao.Value, data.TuNgayBaoCao ?? throw new NghiepVuException("Thiếu thời gian của kỳ báo cáo."), printedOn);
        string name = string.IsNullOrWhiteSpace(data.TenFilePdf) ? data.TieuDe.ToUpper(Formatters.Vietnamese) : data.TenFilePdf;
        return name + "-" + printedOn.ToString("ddMMyyyy", System.Globalization.CultureInfo.InvariantCulture);
    }

    public static string AvailablePath(string folder, string stem)
    {
        var invalid = Path.GetInvalidFileNameChars().Concat("<>:\"/\\|?*").ToHashSet();
        stem = new string(stem.Select(c => invalid.Contains(c) || char.IsControl(c) ? '_' : c).ToArray()).Trim(' ', '.');
        if (stem.Length == 0) stem = "TAILIEU";
        if (stem.Length > 100) stem = stem[..100];
        string path = Path.Combine(folder, stem + ".pdf");
        for (int copy = 2; File.Exists(path); copy++)
            path = Path.Combine(folder, stem + " (" + copy + ").pdf");
        return path;
    }
}
