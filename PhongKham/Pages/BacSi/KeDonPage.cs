using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.KeDon, "Kê đơn", PageGroups.DangKham, 30, Roles.BacSi)]
public sealed partial class KeDonPage : BasePage
{
    
    public KeDonPage()
    {
        InitializeComponent();
    }
    
    protected override void BuildUI()
    {
        Ui.ConfigureGridFormatting(_layout8_grid);
        var data=new System.Data.DataTable();
        for(int i=0;i<4;i++)data.Columns.Add("c"+i);
        data.Rows.Add("Paracetamol","10","Sáng 1 viên","20000");
        ((AppGrid)_layout8_grid).BindRows(data.DefaultView);
        _layout8_grid.CellContentClick += (_,e) =>
        {
            if(e.RowIndex>=0 && e.ColumnIndex==_layout8_grid.Columns.Count-1 && _layout8_grid.Rows[e.RowIndex].DataBoundItem is System.Data.DataRowView row)
                row.Row.Delete();
        };
    }

    private void _layout16_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
    private void _layout17_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}