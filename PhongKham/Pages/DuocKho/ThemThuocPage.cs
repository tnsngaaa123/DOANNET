using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThemThuoc, "Thêm thuốc", PageGroups.DuocKho, 25, Roles.DuocSi)]
public sealed partial class ThemThuocPage : BasePage
{
    
    public ThemThuocPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
    {

        _layout18_DateTimePicker.Value = DateTime.Today.AddYears(1);
    }

    private void _layout21_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            if(string.IsNullOrWhiteSpace(_layout6_TextBox.Text) || string.IsNullOrWhiteSpace(_layout8_TextBox.Text)) throw new NghiepVuException("Nhập mã và tên thuốc.");
            if(_layout16_NumericUpDown.Value<=0) throw new NghiepVuException("Số lượng phải lớn hơn 0.");
            PhongKham.Core.Dialogs.Info("Thông tin nhập hợp lệ.");
        });
    }
    private void _layout26_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            using var choose=new OpenFileDialog { Filter="Excel (*.xlsx)|*.xlsx" };
            if(choose.ShowDialog()==DialogResult.OK) _layout24_drop.Text=Path.GetFileName(choose.FileName);
        });
    }
}