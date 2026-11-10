using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.XuatThuoc, "Danh sách chờ lấy thuốc", PageGroups.DuocKho, 10, Roles.DuocSi)]
public sealed class DanhSachChoLayThuocPage : BasePage
{
    private readonly DataTable _table=new();
    private readonly TextBox _search=Ui.Text();
    private readonly ComboBox _filter=Ui.Combo();
    private DataGridView _grid=null!;
    protected override void BuildUI()
    {
        _grid=Ui.Grid(("c0","Tên bệnh nhân"),("c1","CCCD"),("c2","Ngày sinh"),("c3","Bác sĩ"));
        _table.Columns.Add("id",typeof(int));
        _table.Columns.Add("c0");
        _table.Columns.Add("c1");
        _table.Columns.Add("c2");
        _table.Columns.Add("c3");
        _table.Rows.Add(1,"Bệnh nhân minh họa 1","000000000001","01/01/1995","Bác sĩ minh họa");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        var list=new RowActionList<DataRowView>(_grid,r=>Convert.ToInt32(r["id"]),"Xuất thuốc",r=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        Content.Controls.Add(list);
    }
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
}