using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.PhongCho, "Phòng chờ", PageGroups.TiepNhan, 40, Roles.LeTan)]
public sealed partial class PhongChoForm : BaseForm
{
    private readonly DataTable _table=new();
    
    
    
    
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public PhongChoForm()
    {
        InitializeComponent();
        if (!PhongKham.Core.DesignTimeSupport.IsDesignMode(this)) InitializeRuntime();
    }
    private void InitializeRuntime()
    {
        Ui.ConfigureGridFormatting(_grid);
        _table.Columns.Add("id",typeof(int));
        _table.Columns.Add("c0");
        _table.Columns.Add("c1");
        _table.Columns.Add("c2");
        _table.Columns.Add("c3");
        _table.Rows.Add(1,"1","Bệnh nhân minh họa 1","01/01/1995","Không");
        _table.Rows.Add(2,"2","Bệnh nhân minh họa 2","02/02/1990","Có");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
    }


}