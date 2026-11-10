using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.PhongCho, "Phòng chờ", PageGroups.TiepNhan, 40, Roles.LeTan)]
public sealed class PhongChoForm : BaseForm
{
    private readonly DataTable _table=new();
    private readonly TextBox _search=Ui.Text();
    private readonly ComboBox _filter=Ui.Combo();
    private DataGridView _grid=null!;
    public PhongChoForm()
    {
        ClientSize=new Size(1000,700);
        Text="Phòng chờ";
        var content=new Panel { Dock=DockStyle.Fill,Padding=new Padding(16) };
        Controls.Add(content);
        var toolbar=new FlowLayoutPanel { Dock=DockStyle.Top,Height=60 };
        var title=new Label { Text="Mời STT sau đây vào phòng khám: 1",Dock=DockStyle.Top,Height=100,Font=Theme.TitleFont };
        Controls.Add(title);
        _grid=Ui.Grid(("c0","STT"),("c1","Tên bệnh nhân"),("c2","Ngày sinh"),("c3","Ưu tiên"));
        _table.Columns.Add("id",typeof(int));
        _table.Columns.Add("c0");
        _table.Columns.Add("c1");
        _table.Columns.Add("c2");
        _table.Columns.Add("c3");
        _table.Rows.Add(1,"1","Bệnh nhân minh họa 1","01/01/1995","Không");
        _table.Rows.Add(2,"2","Bệnh nhân minh họa 2","02/02/1990","Có");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        content.Controls.Add(_grid);
    }
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
}