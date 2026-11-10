using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.DanhMucThuoc, "Danh mục thuốc", PageGroups.DuocKho, 20, Roles.DuocSi)]
public sealed class DanhMucThuocPage : BasePage
{
    private readonly DataTable _table=new();
    private readonly TextBox _search=Ui.Text();
    private readonly ComboBox _filter=Ui.Combo();
    private DataGridView _grid=null!;
protected override void BuildUI()
    {
        _grid=Ui.Grid(("c0","Mã thuốc"),("c1","Tên thuốc"),("c2","Nhóm"),("c3","ĐVT"),("c4","Giá bán"),("c5","Số lượng còn"));
        _table.Columns.Add("id",typeof(int));
        _table.Columns.Add("c0");
        _table.Columns.Add("c1");
        _table.Columns.Add("c2");
        _table.Columns.Add("c3");
        _table.Columns.Add("c4");
        _table.Columns.Add("c5");
        _table.Rows.Add(1,"T001","Paracetamol","Giảm đau","Viên","2000","4000");
        _table.Rows.Add(2,"T002","Vitamin C","Vitamin","Viên","1500","800");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _search.Width=270; _search.PlaceholderText="Nhập từ khóa tìm kiếm"; Toolbar.Controls.Add(_search);
        Ui.Button(Toolbar,"Tìm",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        Ui.Button(Toolbar,"Thêm thuốc",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);
        Ui.Button(Toolbar,"Sửa thông tin thuốc",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);
        Content.Controls.Add(_grid);
    }
private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
}
