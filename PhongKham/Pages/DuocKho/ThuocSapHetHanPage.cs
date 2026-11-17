using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThuocSapHetHan, "Thuốc sắp hết hạn", PageGroups.DuocKho, 30, Roles.DuocSi)]
public sealed partial class ThuocSapHetHanPage : BasePage
{
    private readonly DataTable _table=new();
    
    
    

    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }
    public ThuocSapHetHanPage()
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
        _table.Rows.Add(1,"Paracetamol","Giảm đau","01/01/2026","Hết hạn","200");
        _table.Rows.Add(2,"Vitamin C","Vitamin","01/01/2027","60","800");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _grid.DataBindingComplete+=(_,_)=>{foreach(DataGridViewRow row in _grid.Rows)row.DefaultCellStyle.BackColor=row.Index%2==0?Color.LightYellow:Color.MistyRose;};
    }

    private void _layout6_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout7_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}