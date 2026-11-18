using System.ComponentModel;

namespace PhongKham.Core;
public static class DesignTimeSupport
{
    public static bool IsDesignMode(Control? control = null)
    {
        if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            return true;
        for (var current = control; current is not null; current = current.Parent)
            if (current.Site?.DesignMode == true)
                return true;
        return false;
    }
}