using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.ThuNgan;
[PageInfo(PageKeys.ChoThanhToan, "Danh sách chờ thanh toán", PageGroups.ThuNgan, 10, Roles.ThuNgan)]
public sealed partial class DanhSachChoThanhToanPage : BasePage
{
    private readonly DataTable _table=new();
    
    
    
    
    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public DanhSachChoThanhToanPage()
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
        _table.Rows.Add(1,"Bệnh nhân minh họa 1","000000000001","01/01/1995","Bác sĩ minh họa","PK001");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _layout6_list = new RowActionList<DataRowView>(_grid,r=>Convert.ToInt32(r["id"]),"Thanh toán",r=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        _layout7_RowActionsHost.Controls.Add(_layout6_list);
    }


    private RowActionList<DataRowView> _layout6_list = null!;
}