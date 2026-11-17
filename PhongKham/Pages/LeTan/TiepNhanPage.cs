using System.Data;
using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.LeTan;
[PageInfo(PageKeys.TiepNhan, "Tiếp nhận bệnh nhân", PageGroups.TiepNhan, 10, Roles.LeTan)]
public sealed partial class TiepNhanPage : BasePage
{
    private readonly DataTable _table=new();

    
    
    

    private void Find()
    {
        var rows=_table.DefaultView.Cast<DataRowView>().Where(row=>row.Row.ItemArray.Any(value=>Convert.ToString(value)?.Contains(_search.Text,StringComparison.CurrentCultureIgnoreCase)==true));
        
        var filtered=_table.Clone();
        foreach(var row in rows)filtered.ImportRow(row.Row);
        ((AppGrid)_grid).BindRows(filtered.DefaultView);
    }

    public TiepNhanPage()
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
        _table.Rows.Add(1,"Bệnh nhân minh họa 1","000000000001","01/01/1995","Bác sĩ minh họa","1","Không","Chờ khám");
        _table.Rows.Add(2,"Bệnh nhân minh họa 2","000000000002","02/02/1990","Bác sĩ minh họa","2","Có","Chờ khám");
        ((AppGrid)_grid).BindRows(_table.DefaultView);
        _layout10_list = new RowActionList<DataRowView>(_grid,r=>Convert.ToInt32(r["id"]),"Cấp và in số khám",r=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
        _layout11_RowActionsHost.Controls.Add(_layout10_list);
    }


    private void _layout8_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(Find);
    }

    private void _layout9_Button_Click(object? sender, EventArgs e)
    {
        Ui.Run(() =>
        {
            using var dialog=new TaoHoSoDialog(true);
            if(dialog.ShowDialog(this)!=DialogResult.OK)return;
            int id=_table.Rows.Count+1;
            _table.Rows.Add(id,dialog.HoTen,dialog.CanCuoc,"01/01/1995","Bác sĩ minh họa",id.ToString(),"Không","Chờ khám");
            Find();
        });
    }
    private RowActionList<DataRowView> _layout10_list = null!;
}