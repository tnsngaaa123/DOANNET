#nullable disable
using PhongKham.Controls;

namespace PhongKham.Pages.QuanTri;
public sealed partial class QuanTriPage
{
    private System.ComponentModel.IContainer components;
    private FlowLayoutPanel Toolbar;
    private Panel Content;
    private FlowLayoutPanel Footer;
    private Label _pageTitle;
    private AppButton _createUser;
    private AppButton _editUser;
    private AppButton _resetPassword;
    private TabControl _tabs;
    private TabPage _usersTab;
    private TabPage _settingsTab;
    private PhongKham.Controls.AppGrid _grid;
    private System.Windows.Forms.DataGridViewTextBoxColumn _userLoginColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn _userNameColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn _userRoleColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn _userActiveColumn;
    private System.Windows.Forms.TextBox _clinic;
    private System.Windows.Forms.TextBox _address;
    private System.Windows.Forms.TextBox _phone;
    private System.Windows.Forms.NumericUpDown _fee;
    private System.Windows.Forms.TableLayoutPanel _settingsForm;
    private System.Windows.Forms.Label _fieldLabel0;
    private System.Windows.Forms.Label _fieldLabel1;
    private System.Windows.Forms.Label _fieldLabel2;
    private System.Windows.Forms.Label _fieldLabel3;
    private System.Windows.Forms.Panel _settingsScroll;
    private System.Windows.Forms.FlowLayoutPanel _settingsFooter;
    private PhongKham.Controls.AppButton _saveSettings;
    protected override void Dispose(bool disposing)
    {
        if (disposing)
            this.components?.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        Toolbar = new System.Windows.Forms.FlowLayoutPanel();
        _createUser = new PhongKham.Controls.AppButton();
        _editUser = new PhongKham.Controls.AppButton();
        _resetPassword = new PhongKham.Controls.AppButton();
        Content = new System.Windows.Forms.Panel();
        _tabs = new System.Windows.Forms.TabControl();
        _usersTab = new System.Windows.Forms.TabPage();
        _grid = new PhongKham.Controls.AppGrid();
        _settingsTab = new System.Windows.Forms.TabPage();
        _settingsScroll = new System.Windows.Forms.Panel();
        _settingsForm = new System.Windows.Forms.TableLayoutPanel();
        _fieldLabel0 = new System.Windows.Forms.Label();
        _clinic = new System.Windows.Forms.TextBox();
        _fieldLabel1 = new System.Windows.Forms.Label();
        _address = new System.Windows.Forms.TextBox();
        _fieldLabel2 = new System.Windows.Forms.Label();
        _phone = new System.Windows.Forms.TextBox();
        _fieldLabel3 = new System.Windows.Forms.Label();
        _fee = new System.Windows.Forms.NumericUpDown();
        _settingsFooter = new System.Windows.Forms.FlowLayoutPanel();
        _saveSettings = new PhongKham.Controls.AppButton();
        Footer = new System.Windows.Forms.FlowLayoutPanel();
        _pageTitle = new System.Windows.Forms.Label();
        Toolbar.SuspendLayout();
        Content.SuspendLayout();
        _tabs.SuspendLayout();
        _usersTab.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_grid).BeginInit();
        _settingsTab.SuspendLayout();
        _settingsScroll.SuspendLayout();
        _settingsForm.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)_fee).BeginInit();
        _settingsFooter.SuspendLayout();
        SuspendLayout();
        // 
        // Toolbar
        // 
        Toolbar.AutoScroll = true;
        Toolbar.BackColor = System.Drawing.Color.White;
        Toolbar.Controls.Add(_createUser);
        Toolbar.Controls.Add(_editUser);
        Toolbar.Controls.Add(_resetPassword);
        Toolbar.Dock = System.Windows.Forms.DockStyle.Top;
        Toolbar.Location = new System.Drawing.Point(0, 58);
        Toolbar.Name = "Toolbar";
        Toolbar.Padding = new System.Windows.Forms.Padding(12, 5, 12, 5);
        Toolbar.Size = new System.Drawing.Size(1100, 56);
        Toolbar.TabIndex = 1;
        Toolbar.WrapContents = false;
        // 
        // _createUser
        // 
        _createUser.AutoSize = true;
        _createUser.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _createUser.Cursor = System.Windows.Forms.Cursors.Hand;
        _createUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _createUser.ForeColor = System.Drawing.Color.White;
        _createUser.Location = new System.Drawing.Point(15, 8);
        _createUser.MinimumSize = new System.Drawing.Size(75, 36);
        _createUser.Name = "_createUser";
        _createUser.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _createUser.Size = new System.Drawing.Size(146, 41);
        _createUser.TabIndex = 0;
        _createUser.Text = "Tạo tài khoản";
        _createUser.UseVisualStyleBackColor = false;
        _createUser.Click += _createUser_Click;
        // 
        // _editUser
        // 
        _editUser.AutoSize = true;
        _editUser.BackColor = System.Drawing.Color.White;
        _editUser.Cursor = System.Windows.Forms.Cursors.Hand;
        _editUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _editUser.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _editUser.Location = new System.Drawing.Point(167, 8);
        _editUser.MinimumSize = new System.Drawing.Size(75, 36);
        _editUser.Name = "_editUser";
        _editUser.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _editUser.Size = new System.Drawing.Size(146, 41);
        _editUser.TabIndex = 1;
        _editUser.Text = "Sửa tài khoản";
        _editUser.UseVisualStyleBackColor = false;
        _editUser.Click += _editUser_Click;
        // 
        // _resetPassword
        // 
        _resetPassword.AutoSize = true;
        _resetPassword.BackColor = System.Drawing.Color.White;
        _resetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
        _resetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _resetPassword.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        _resetPassword.Location = new System.Drawing.Point(319, 8);
        _resetPassword.MinimumSize = new System.Drawing.Size(75, 36);
        _resetPassword.Name = "_resetPassword";
        _resetPassword.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _resetPassword.Size = new System.Drawing.Size(168, 41);
        _resetPassword.TabIndex = 2;
        _resetPassword.Text = "Đặt lại mật khẩu";
        _resetPassword.UseVisualStyleBackColor = false;
        _resetPassword.Click += _resetPassword_Click;
        // 
        // Content
        // 
        Content.Controls.Add(_tabs);
        Content.Dock = System.Windows.Forms.DockStyle.Fill;
        Content.Location = new System.Drawing.Point(0, 114);
        Content.Name = "Content";
        Content.Padding = new System.Windows.Forms.Padding(12);
        Content.Size = new System.Drawing.Size(1100, 542);
        Content.TabIndex = 0;
        // 
        // _tabs
        // 
        _tabs.Controls.Add(_usersTab);
        _tabs.Controls.Add(_settingsTab);
        _tabs.Dock = System.Windows.Forms.DockStyle.Fill;
        _tabs.Location = new System.Drawing.Point(12, 12);
        _tabs.Name = "_tabs";
        _tabs.SelectedIndex = 0;
        _tabs.Size = new System.Drawing.Size(1076, 518);
        _tabs.TabIndex = 0;
        // 
        // _usersTab
        // 
        _usersTab.Controls.Add(_grid);
        _usersTab.Location = new System.Drawing.Point(4, 32);
        _usersTab.Name = "_usersTab";
        _usersTab.Size = new System.Drawing.Size(1068, 482);
        _usersTab.TabIndex = 0;
        _usersTab.Text = "Tài khoản";
        // 
        // _grid
        // 
        _grid.AllowUserToAddRows = false;
        _grid.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)248)), ((int)((byte)250)), ((int)((byte)252)));
        _grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        _grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        _grid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
        _grid.BackgroundColor = System.Drawing.Color.White;
        _grid.BorderStyle = System.Windows.Forms.BorderStyle.None;
        dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)((byte)226)), ((int)((byte)232)), ((int)((byte)240)));
        dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
        dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
        dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
        _grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
        dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 10F);
        dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
        dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(6);
        dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)((byte)204)), ((int)((byte)251)), ((int)((byte)241)));
        dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)((byte)15)), ((int)((byte)23)), ((int)((byte)42)));
        dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        _grid.DefaultCellStyle = dataGridViewCellStyle3;
        _grid.Dock = System.Windows.Forms.DockStyle.Fill;
        _grid.EnableHeadersVisualStyles = false;
        _grid.Location = new System.Drawing.Point(0, 0);
        _grid.MultiSelect = false;
        _grid.Name = "_grid";
        _grid.ReadOnly = true;
        _grid.RowHeadersVisible = false;
        _grid.RowHeadersWidth = 51;
        _grid.RowTemplate.Height = 38;
        _grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        _grid.Size = new System.Drawing.Size(1068, 482);
        _grid.TabIndex = 0;
        // 
        // _settingsTab
        // 
        _settingsTab.Controls.Add(_settingsScroll);
        _settingsTab.Controls.Add(_settingsFooter);
        _settingsTab.Location = new System.Drawing.Point(4, 32);
        _settingsTab.Name = "_settingsTab";
        _settingsTab.Size = new System.Drawing.Size(1068, 482);
        _settingsTab.TabIndex = 1;
        _settingsTab.Text = "Cấu hình phòng khám";
        // 
        // _settingsScroll
        // 
        _settingsScroll.AutoScroll = true;
        _settingsScroll.Controls.Add(_settingsForm);
        _settingsScroll.Dock = System.Windows.Forms.DockStyle.Fill;
        _settingsScroll.Location = new System.Drawing.Point(0, 0);
        _settingsScroll.Name = "_settingsScroll";
        _settingsScroll.Size = new System.Drawing.Size(1068, 415);
        _settingsScroll.TabIndex = 0;
        // 
        // _settingsForm
        // 
        _settingsForm.AutoSize = true;
        _settingsForm.BackColor = System.Drawing.Color.White;
        _settingsForm.ColumnCount = 2;
        _settingsForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
        _settingsForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
        _settingsForm.Controls.Add(_fieldLabel0, 0, 0);
        _settingsForm.Controls.Add(_clinic, 1, 0);
        _settingsForm.Controls.Add(_fieldLabel1, 0, 1);
        _settingsForm.Controls.Add(_address, 1, 1);
        _settingsForm.Controls.Add(_fieldLabel2, 0, 2);
        _settingsForm.Controls.Add(_phone, 1, 2);
        _settingsForm.Controls.Add(_fieldLabel3, 0, 3);
        _settingsForm.Controls.Add(_fee, 1, 3);
        _settingsForm.Dock = System.Windows.Forms.DockStyle.Top;
        _settingsForm.Location = new System.Drawing.Point(0, 0);
        _settingsForm.Name = "_settingsForm";
        _settingsForm.Padding = new System.Windows.Forms.Padding(16);
        _settingsForm.RowCount = 4;
        _settingsForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _settingsForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _settingsForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _settingsForm.RowStyles.Add(new System.Windows.Forms.RowStyle());
        _settingsForm.Size = new System.Drawing.Size(1068, 279);
        _settingsForm.TabIndex = 0;
        // 
        // _fieldLabel0
        // 
        _fieldLabel0.AutoSize = true;
        _fieldLabel0.Location = new System.Drawing.Point(20, 26);
        _fieldLabel0.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _fieldLabel0.Name = "_fieldLabel0";
        _fieldLabel0.Size = new System.Drawing.Size(138, 23);
        _fieldLabel0.TabIndex = 0;
        _fieldLabel0.Text = "Tên phòng khám";
        // 
        // _clinic
        // 
        _clinic.Dock = System.Windows.Forms.DockStyle.Top;
        _clinic.Location = new System.Drawing.Point(350, 22);
        _clinic.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _clinic.Multiline = true;
        _clinic.Name = "_clinic";
        _clinic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        _clinic.Size = new System.Drawing.Size(699, 56);
        _clinic.TabIndex = 1;
        // 
        // _fieldLabel1
        // 
        _fieldLabel1.AutoSize = true;
        _fieldLabel1.Location = new System.Drawing.Point(20, 96);
        _fieldLabel1.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _fieldLabel1.Name = "_fieldLabel1";
        _fieldLabel1.Size = new System.Drawing.Size(62, 23);
        _fieldLabel1.TabIndex = 2;
        _fieldLabel1.Text = "Địa chỉ";
        // 
        // _address
        // 
        _address.Dock = System.Windows.Forms.DockStyle.Top;
        _address.Location = new System.Drawing.Point(350, 92);
        _address.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _address.Multiline = true;
        _address.Name = "_address";
        _address.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        _address.Size = new System.Drawing.Size(699, 75);
        _address.TabIndex = 3;
        // 
        // _fieldLabel2
        // 
        _fieldLabel2.AutoSize = true;
        _fieldLabel2.Location = new System.Drawing.Point(20, 185);
        _fieldLabel2.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _fieldLabel2.Name = "_fieldLabel2";
        _fieldLabel2.Size = new System.Drawing.Size(111, 23);
        _fieldLabel2.TabIndex = 4;
        _fieldLabel2.Text = "Số điện thoại";
        // 
        // _phone
        // 
        _phone.Dock = System.Windows.Forms.DockStyle.Top;
        _phone.Location = new System.Drawing.Point(350, 181);
        _phone.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _phone.Name = "_phone";
        _phone.Size = new System.Drawing.Size(699, 30);
        _phone.TabIndex = 5;
        // 
        // _fieldLabel3
        // 
        _fieldLabel3.AutoSize = true;
        _fieldLabel3.Location = new System.Drawing.Point(20, 229);
        _fieldLabel3.Margin = new System.Windows.Forms.Padding(4, 10, 8, 4);
        _fieldLabel3.Name = "_fieldLabel3";
        _fieldLabel3.Size = new System.Drawing.Size(216, 23);
        _fieldLabel3.TabIndex = 6;
        _fieldLabel3.Text = "Tiền khám mặc định (VNĐ)";
        // 
        // _fee
        // 
        _fee.Dock = System.Windows.Forms.DockStyle.Top;
        _fee.Location = new System.Drawing.Point(350, 225);
        _fee.Margin = new System.Windows.Forms.Padding(3, 6, 3, 8);
        _fee.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
        _fee.Name = "_fee";
        _fee.Size = new System.Drawing.Size(699, 30);
        _fee.TabIndex = 7;
        _fee.ThousandsSeparator = true;
        // 
        // _settingsFooter
        // 
        _settingsFooter.AutoSize = true;
        _settingsFooter.Controls.Add(_saveSettings);
        _settingsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
        _settingsFooter.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        _settingsFooter.Location = new System.Drawing.Point(0, 415);
        _settingsFooter.MinimumSize = new System.Drawing.Size(0, 64);
        _settingsFooter.Name = "_settingsFooter";
        _settingsFooter.Padding = new System.Windows.Forms.Padding(10);
        _settingsFooter.Size = new System.Drawing.Size(1068, 67);
        _settingsFooter.TabIndex = 1;
        // 
        // _saveSettings
        // 
        _saveSettings.AutoSize = true;
        _saveSettings.BackColor = System.Drawing.Color.FromArgb(((int)((byte)22)), ((int)((byte)163)), ((int)((byte)74)));
        _saveSettings.Cursor = System.Windows.Forms.Cursors.Hand;
        _saveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        _saveSettings.ForeColor = System.Drawing.Color.White;
        _saveSettings.Location = new System.Drawing.Point(904, 13);
        _saveSettings.MinimumSize = new System.Drawing.Size(75, 36);
        _saveSettings.Name = "_saveSettings";
        _saveSettings.Padding = new System.Windows.Forms.Padding(10, 3, 10, 3);
        _saveSettings.Size = new System.Drawing.Size(141, 41);
        _saveSettings.TabIndex = 0;
        _saveSettings.Text = "Lưu cấu hình";
        _saveSettings.UseVisualStyleBackColor = false;
        _saveSettings.Click += _saveSettings_Click;
        // 
        // Footer
        // 
        Footer.AutoScroll = true;
        Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
        Footer.Location = new System.Drawing.Point(0, 656);
        Footer.Name = "Footer";
        Footer.Padding = new System.Windows.Forms.Padding(12, 6, 12, 6);
        Footer.Size = new System.Drawing.Size(1100, 64);
        Footer.TabIndex = 3;
        Footer.Visible = false;
        Footer.WrapContents = false;
        // 
        // _pageTitle
        // 
        _pageTitle.Dock = System.Windows.Forms.DockStyle.Top;
        _pageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        _pageTitle.Location = new System.Drawing.Point(0, 0);
        _pageTitle.Name = "_pageTitle";
        _pageTitle.Padding = new System.Windows.Forms.Padding(16, 10, 0, 0);
        _pageTitle.Size = new System.Drawing.Size(1100, 58);
        _pageTitle.TabIndex = 2;
        _pageTitle.Text = "Quản trị hệ thống";
        // 
        // QuanTriPage
        // 
        Controls.Add(Content);
        Controls.Add(Toolbar);
        Controls.Add(_pageTitle);
        Controls.Add(Footer);
        Toolbar.ResumeLayout(false);
        Toolbar.PerformLayout();
        Content.ResumeLayout(false);
        _tabs.ResumeLayout(false);
        _usersTab.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)_grid).EndInit();
        _settingsTab.ResumeLayout(false);
        _settingsTab.PerformLayout();
        _settingsScroll.ResumeLayout(false);
        _settingsScroll.PerformLayout();
        _settingsForm.ResumeLayout(false);
        _settingsForm.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)_fee).EndInit();
        _settingsFooter.ResumeLayout(false);
        _settingsFooter.PerformLayout();
        ResumeLayout(false);
    }
}
