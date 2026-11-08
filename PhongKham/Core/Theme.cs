namespace PhongKham.Core;

public static class Theme
{
    public static readonly Color Primary = Color.FromArgb(22, 163, 74), PrimaryDark = Color.FromArgb(21, 128, 61), Background = Color.FromArgb(241, 245, 249), Surface = Color.White, Text = Color.FromArgb(15, 23, 42), Muted = Color.FromArgb(100, 116, 139), Sidebar = Color.FromArgb(15, 23, 42), Border = Color.FromArgb(226, 232, 240), Danger = Color.FromArgb(220, 38, 38);
    public static readonly Font BodyFont = new("Segoe UI", 10), SmallFont = new("Segoe UI", 9), TitleFont = new("Segoe UI", 18, FontStyle.Bold);
    public const int SidebarWidth = 300;
}