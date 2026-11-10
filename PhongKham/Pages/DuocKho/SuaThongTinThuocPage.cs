using PhongKham.Base;
using PhongKham.Core;
using PhongKham.Controls;
using PhongKham.Pages.Chung.Dialogs;
namespace PhongKham.Pages.DuocKho;
[PageInfo(PageKeys.SuaThongTinThuoc, "Sửa thông tin thuốc", PageGroups.DuocKho, 26, Roles.DuocSi)]
public sealed class SuaThongTinThuocPage : BasePage
{
    protected override void BuildUI()
    {
        var tabs=new TabControl { Dock=DockStyle.Fill };var manual=new TabPage("Thông tin thuốc");var form=Ui.Form();var name=Ui.Text();
        Ui.Field(form,"Tìm thuốc có sẵn",name);Ui.Field(form,"Mã thuốc",Ui.Text());Ui.Field(form,"Tên thuốc",Ui.Text());var group=Ui.Combo();group.Items.AddRange(new object[]{"Giảm đau","Vitamin"});group.SelectedIndex=0;Ui.Field(form,"Nhóm",group);Ui.Field(form,"Đơn vị tính",Ui.Text());Ui.Field(form,"Giá bán",Ui.Number());
        var footer=new FlowLayoutPanel { Dock=DockStyle.Bottom,Height=60,FlowDirection=FlowDirection.RightToLeft };Ui.Button(footer,"Cập nhật",()=>{MessageBox.Show("Chức năng đang được hoàn thiện.","Phòng khám");},AppButtonStyle.Primary);manual.Controls.Add(Ui.Scroll(form));manual.Controls.Add(footer);tabs.TabPages.Add(manual);
        Content.Controls.Add(tabs);Toolbar.Visible=false;
    }
}