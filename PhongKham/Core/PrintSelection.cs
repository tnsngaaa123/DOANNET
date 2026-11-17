namespace PhongKham.Core;

public static class PrintSelection
{
    public static int[] Indices(int count, int selectedIndex)
    {
        if (count < 1) throw new NghiepVuException("Không có tài liệu để in.");
        if (selectedIndex >= 0 && selectedIndex < count) return new[] { selectedIndex };
        if (count > 1 && selectedIndex == count) return Enumerable.Range(0, count).ToArray();
        throw new NghiepVuException("Chọn tài liệu cần in.");
    }
}