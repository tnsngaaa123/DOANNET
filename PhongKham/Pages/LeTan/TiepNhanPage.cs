using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.TiepNhan, "Tiếp nhận bệnh nhân", PageGroups.TiepNhan, 10, Roles.LeTan)]
public sealed class TiepNhanPage : BasePage
{
    private readonly DataTable _table=new();
    private readonly TextBox _search=Ui.Text();
    private readonly ComboBox _filter=Ui.Combo();
    private DataGridView _grid=null!;
protected override void BuildUI()
    {
        _grid=Ui.Grid(("c0","Tên bệnh nhân"),("c1","CCCD"),("c2","Ngày sinh"),("c3","Bác sĩ"),("c4","STT"),("c5","Ưu tiên"),("c6","Trạng thái"));
        _table.Columns.Add("id",typeof(int));
        _table.Columns.Add("c0");
        _table.Columns.Add("c1");
        _table.Columns.Add("c2");
        _table.Columns.Add("c3");
        _table.Columns.Add("c4");
        _table.Columns.Add("c5");
        _table.Columns.Add("c6");
        _table.Rows.Add(1,"Bệnh nhân minh họa 1","000000000001","01/01/1995","Bác sĩ minh họa","1","Không","Chờ khám");
        _table.Rows.Add(2,"Bệnh nhân minh họa 2","000000000002","02/02/1990","Bác sĩ minh họa","2","Có","Chờ khám");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _search.Width=270; _search.PlaceholderText="Nhập từ khóa tìm kiếm"; Toolbar.Controls.Add(_search);
        Ui.Button(Toolbar,"Tìm",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        Ui.Button(Toolbar,"Bệnh nhân mới",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);
        var list=new RowActionList<DataRowView>(_grid,r=>Convert.ToInt32(r["id"]),"Cấp và in số khám",r=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
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
