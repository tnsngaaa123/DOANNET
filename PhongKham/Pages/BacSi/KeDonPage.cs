using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.BacSi;
[PageInfo(PageKeys.KeDon, "Kê đơn", PageGroups.DangKham, 30, Roles.BacSi)]
public sealed class KeDonPage : BasePage
{
    protected override void BuildUI()
    {
        var form=Ui.Form();var drug=Ui.Text();drug.PlaceholderText="Gõ tên thuốc";
        Ui.Field(form,"Tên thuốc",drug);Ui.Field(form,"Số lượng",Ui.Number(10000));Ui.Field(form,"Liều dùng",Ui.Text());
        var grid=Ui.Grid(("c0","Tên thuốc"),("c1","Số lượng"),("c2","Liều dùng"),("c3","Thành tiền"));var data=new System.Data.DataTable();for(int i=0;i<4;i++)data.Columns.Add("c"+i);data.Rows.Add("Paracetamol","10","Sáng 1 viên","20000");((AppGrid)grid).BindRows(data.DefaultView);
        var del=new DataGridViewButtonColumn { Text="×",UseColumnTextForButtonValue=true,HeaderText="",Width=50,AutoSizeMode=DataGridViewAutoSizeColumnMode.None };grid.Columns.Add(del);
        Ui.Split(Content,Ui.Scroll(form),grid);Ui.Button(Toolbar,"Thêm thuốc",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});Ui.Button(Toolbar,"Trở lại",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");});
    }
}