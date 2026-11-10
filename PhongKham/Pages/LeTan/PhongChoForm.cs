

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
        content.Controls.Add(new Label { Text="Phòng chờ",Dock=DockStyle.Top,Height=90,Font=Theme.TitleFont });
    }
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
}
