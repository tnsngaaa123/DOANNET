namespace PhongKham.Core;

public static class AppPaths
{
    public static string DatabaseFile => Path.Combine(AppContext.BaseDirectory, "phongkham.db");
    public static string LogDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PhongKham", "logs");
    public const string PdfDirectory = @"D:\PDF";
}