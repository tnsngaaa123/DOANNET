using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThuocSapHetHang, "Thuốc sắp hết hàng", PageGroups.DuocKho, 40, Roles.DuocSi)]
public sealed class ThuocSapHetHangPage : BasePage
{
    private readonly DataTable _table=new();
    private readonly TextBox _search=Ui.Text();
    private readonly ComboBox _filter=Ui.Combo();
    private DataGridView _grid=null!;
protected override void BuildUI()
    {
        _grid=Ui.Grid(("c0","Tên thuốc"),("c1","ĐVT"),("c2","Số lượng còn lại"));
        _table.Columns.Add("id",typeof(int));
        _table.Columns.Add("c0");
        _table.Columns.Add("c1");
        _table.Columns.Add("c2");
        _table.Rows.Add(1,"Paracetamol","Viên","4000");
        _table.Rows.Add(2,"Vitamin C","Viên","800");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _search.Width=270; _search.PlaceholderText="Nhập từ khóa tìm kiếm"; Toolbar.Controls.Add(_search);
        _filter.Items.AddRange(new object[]{"Tất cả","Số lượng dưới 5000","Số lượng dưới 3000","Số lượng dưới 1000"});_filter.SelectedIndex=0;
        Toolbar.Controls.Add(_filter);
        Ui.Button(Toolbar,"Tìm",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        Ui.Button(Toolbar,"In danh sách",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);
        Content.Controls.Add(_grid);
        _grid.DataBindingComplete+=(_,_)=>{foreach(DataGridViewRow row in _grid.Rows)row.DefaultCellStyle.BackColor=row.Index%2==0?Color.LightYellow:Color.MistyRose;};
    }
private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
}
