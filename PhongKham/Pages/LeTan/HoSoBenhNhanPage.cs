using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.HoSoBenhNhan, "Hồ sơ bệnh nhân", PageGroups.TiepNhan, 30, Roles.LeTan, Roles.BacSi)]
public sealed partial class HoSoBenhNhanPage : BasePage
{
    private readonly DataTable _table=new();
    
    
    
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public HoSoBenhNhanPage()
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
        _table.Rows.Add(1,"HS001","Bệnh nhân minh họa 1","000000000001","01/01/1995","08/11/2026");
        _table.Rows.Add(2,"HS002","Bệnh nhân minh họa 2","000000000002","02/02/1990","07/11/2026");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _layout6_DateTimePicker.Format = DateTimePickerFormat.Short;
        _layout9_list = new RowActionList<DataRowView>(_grid,r=>Convert.ToInt32(r["id"]),"👁",r=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
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