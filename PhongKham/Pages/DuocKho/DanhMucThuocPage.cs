using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.DanhMucThuoc, "Danh mục thuốc", PageGroups.DuocKho, 20, Roles.DuocSi)]
public sealed partial class DanhMucThuocPage : BasePage
{
    private readonly DataTable _table=new();
    
    
    

    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public DanhMucThuocPage()
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
        _table.Rows.Add(1,"T001","Paracetamol","Giảm đau","Viên","2000","4000");
        _table.Rows.Add(2,"T002","Vitamin C","Vitamin","Viên","1500","800");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
    }

    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}