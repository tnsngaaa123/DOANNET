using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.DsChoKham, "Danh sách chờ khám", PageGroups.KhamBenh, 10, Roles.BacSi)]
public sealed partial class DanhSachChoKhamPage : BasePage
{
    private readonly DataTable _table=new();
    
    
    
    
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public DanhSachChoKhamPage()
    {
        InitializeComponent();
    }
    protected override void BuildUI()
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

    private void _layout5_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}