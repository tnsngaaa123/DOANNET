using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.ThuNgan;
[PageInfo(PageKeys.DaThanhToan, "Danh sách bệnh nhân đã thanh toán", PageGroups.ThuNgan, 20, Roles.ThuNgan)]
public sealed partial class DanhSachDaThanhToanPage : BasePage
{
    private readonly DataTable _table=new();
    
    
    
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public DanhSachDaThanhToanPage()
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
        _table.Columns.Add("c6");
        _table.Rows.Add(1,"BL001","Bệnh nhân minh họa 1","000000000001","08/11/2026","150000","20000","170000");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _layout8_DateTimePicker.Format = DateTimePickerFormat.Short;
        _layout11_list = new RowActionList<DataRowView>(_grid,r=>Convert.ToInt32(r["id"]),"👁",r=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        _layout12_RowActionsHost.Controls.Add(_layout11_list);
    }

    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout10_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private RowActionList<DataRowView> _layout11_list = null!;
}