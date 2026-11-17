using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.HangDoi, "Hàng đợi", PageGroups.TiepNhan, 20, Roles.LeTan)]
public sealed partial class HangDoiPage : BasePage
{
    private readonly DataTable _table=new();
    
    
    

    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public HangDoiPage()
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
        _table.Columns.Add("c4");
        _table.Columns.Add("c5");
        _table.Rows.Add(1,"1","Bệnh nhân minh họa 1","000000000001","Bác sĩ minh họa","Không","Chờ khám");
        _table.Rows.Add(2,"2","Bệnh nhân minh họa 2","000000000002","Bác sĩ minh họa","Có","Chờ khám");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _layout9_list = new RowActionList<DataRowView>(_grid,r=>Convert.ToInt32(r["id"]),"Cấp và in số khám",r=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        _layout10_RowActionsHost.Controls.Add(_layout9_list);
    }

    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private RowActionList<DataRowView> _layout9_list = null!;
}