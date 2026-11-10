using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.ThemThuoc, "Thêm thuốc", PageGroups.DuocKho, 25, Roles.DuocSi)]
public sealed class ThemThuocPage : BasePage
{
    protected override void BuildUI()
    {
        var tabs=new TabControl { Dock=DockStyle.Fill };var manual=new TabPage("Thêm thuốc thủ công");var form=Ui.Form();var name=Ui.Text();
        Ui.Field(form,"Tìm thuốc có sẵn",name);Ui.Field(form,"Mã thuốc",Ui.Text());Ui.Field(form,"Tên thuốc",Ui.Text());var group=Ui.Combo();group.Items.AddRange(new object[]{"Giảm đau","Vitamin"});group.SelectedIndex=0;Ui.Field(form,"Nhóm",group);Ui.Field(form,"Đơn vị tính",Ui.Text());Ui.Field(form,"Giá bán",Ui.Number());
        Ui.Field(form,"Số lượng",Ui.Number(1000000));Ui.Field(form,"Hạn dùng",Ui.Date(DateTime.Today.AddYears(1)));
        var footer=new FlowLayoutPanel { Dock=DockStyle.Bottom,Height=60,FlowDirection=FlowDirection.RightToLeft };Ui.Button(footer,"Thêm thuốc",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);manual.Controls.Add(Ui.Scroll(form));manual.Controls.Add(footer);tabs.TabPages.Add(manual);
        var automatic=new TabPage("Thêm thuốc tự động");var drop=new Label { Text="Kéo và thả file Excel .xlsx vào đây",Dock=DockStyle.Top,Height=130,TextAlign=ContentAlignment.MiddleCenter,BorderStyle=BorderStyle.FixedSingle,AllowDrop=true };
        var autoFooter=new FlowLayoutPanel { Dock=DockStyle.Bottom,Height=60,FlowDirection=FlowDirection.RightToLeft };Ui.Button(autoFooter,"Thêm thuốc",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);automatic.Controls.Add(drop);automatic.Controls.Add(autoFooter);tabs.TabPages.Add(automatic);
        Content.Controls.Add(tabs);Toolbar.Visible=false;
    }
}
