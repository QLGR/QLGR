namespace QuanLiGara
{
    partial class Form_Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Text_tenserver = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.Buttom_LuuServer = new DevComponents.DotNetBar.ButtonX();
            this.Buttom_ThoatServer = new DevComponents.DotNetBar.ButtonX();
            this.txtDatabase = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.checkBoxX1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.txtUsername = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.rdBtnTaoCSDL = new System.Windows.Forms.RadioButton();
            this.rdBtnSuaCSDL = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // Text_tenserver
            // 
            // 
            // 
            // 
            this.Text_tenserver.Border.Class = "TextBoxBorder";
            this.Text_tenserver.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text_tenserver.Location = new System.Drawing.Point(246, 18);
            this.Text_tenserver.Name = "Text_tenserver";
            this.Text_tenserver.PreventEnterBeep = true;
            this.Text_tenserver.Size = new System.Drawing.Size(190, 20);
            this.Text_tenserver.TabIndex = 0;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(134, 11);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(94, 31);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Tên Server SQL";
            // 
            // Buttom_LuuServer
            // 
            this.Buttom_LuuServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Buttom_LuuServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Buttom_LuuServer.Location = new System.Drawing.Point(199, 212);
            this.Buttom_LuuServer.Name = "Buttom_LuuServer";
            this.Buttom_LuuServer.Size = new System.Drawing.Size(77, 32);
            this.Buttom_LuuServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Buttom_LuuServer.TabIndex = 2;
            this.Buttom_LuuServer.Text = "Lưu";
            this.Buttom_LuuServer.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // Buttom_ThoatServer
            // 
            this.Buttom_ThoatServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Buttom_ThoatServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Buttom_ThoatServer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Buttom_ThoatServer.Location = new System.Drawing.Point(311, 212);
            this.Buttom_ThoatServer.Name = "Buttom_ThoatServer";
            this.Buttom_ThoatServer.Size = new System.Drawing.Size(77, 32);
            this.Buttom_ThoatServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.Buttom_ThoatServer.TabIndex = 3;
            this.Buttom_ThoatServer.Text = "Thoát";
            // 
            // txtDatabase
            // 
            // 
            // 
            // 
            this.txtDatabase.Border.Class = "TextBoxBorder";
            this.txtDatabase.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtDatabase.Location = new System.Drawing.Point(246, 55);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.PreventEnterBeep = true;
            this.txtDatabase.Size = new System.Drawing.Size(190, 20);
            this.txtDatabase.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(134, 48);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(94, 31);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "Database";
            // 
            // checkBoxX1
            // 
            // 
            // 
            // 
            this.checkBoxX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBoxX1.Location = new System.Drawing.Point(246, 91);
            this.checkBoxX1.Name = "checkBoxX1";
            this.checkBoxX1.Size = new System.Drawing.Size(190, 23);
            this.checkBoxX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBoxX1.TabIndex = 4;
            this.checkBoxX1.Text = "Đăng nhập bằng Windows";
            this.checkBoxX1.CheckedChanged += new System.EventHandler(this.checkBoxX1_CheckedChanged);
            // 
            // txtUsername
            // 
            // 
            // 
            // 
            this.txtUsername.Border.Class = "TextBoxBorder";
            this.txtUsername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUsername.Location = new System.Drawing.Point(246, 131);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PreventEnterBeep = true;
            this.txtUsername.Size = new System.Drawing.Size(190, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(134, 124);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(94, 31);
            this.labelX4.TabIndex = 1;
            this.labelX4.Text = "Username";
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.Location = new System.Drawing.Point(246, 168);
            this.txtPass.Name = "txtPass";
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(190, 20);
            this.txtPass.TabIndex = 0;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(134, 161);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(94, 31);
            this.labelX5.TabIndex = 1;
            this.labelX5.Text = "Password";
            // 
            // rdBtnTaoCSDL
            // 
            this.rdBtnTaoCSDL.AutoSize = true;
            this.rdBtnTaoCSDL.Location = new System.Drawing.Point(28, 95);
            this.rdBtnTaoCSDL.Name = "rdBtnTaoCSDL";
            this.rdBtnTaoCSDL.Size = new System.Drawing.Size(94, 17);
            this.rdBtnTaoCSDL.TabIndex = 18;
            this.rdBtnTaoCSDL.Text = "Tạo mới CSDL";
            this.rdBtnTaoCSDL.UseVisualStyleBackColor = true;
            // 
            // rdBtnSuaCSDL
            // 
            this.rdBtnSuaCSDL.AutoSize = true;
            this.rdBtnSuaCSDL.Checked = true;
            this.rdBtnSuaCSDL.Location = new System.Drawing.Point(28, 51);
            this.rdBtnSuaCSDL.Name = "rdBtnSuaCSDL";
            this.rdBtnSuaCSDL.Size = new System.Drawing.Size(75, 17);
            this.rdBtnSuaCSDL.TabIndex = 19;
            this.rdBtnSuaCSDL.TabStop = true;
            this.rdBtnSuaCSDL.Text = "Sửa CSDL";
            this.rdBtnSuaCSDL.UseVisualStyleBackColor = true;
            this.rdBtnSuaCSDL.CheckedChanged += new System.EventHandler(this.rdBtnSuaCSDL_CheckedChanged);
            // 
            // Form_Config
            // 
            this.AcceptButton = this.Buttom_LuuServer;
            this.CancelButton = this.Buttom_ThoatServer;
            this.ClientSize = new System.Drawing.Size(474, 265);
            this.Controls.Add(this.rdBtnTaoCSDL);
            this.Controls.Add(this.rdBtnSuaCSDL);
            this.Controls.Add(this.checkBoxX1);
            this.Controls.Add(this.Buttom_ThoatServer);
            this.Controls.Add(this.Buttom_LuuServer);
            this.Controls.Add(this.labelX5);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.Text_tenserver);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt CSDL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_Config_FormClosed);
            this.Load += new System.EventHandler(this.Form_Config_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX Text_tenserver;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX Buttom_LuuServer;
        private DevComponents.DotNetBar.ButtonX Buttom_ThoatServer;
        private DevComponents.DotNetBar.Controls.TextBoxX txtDatabase;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUsername;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.RadioButton rdBtnTaoCSDL;
        private System.Windows.Forms.RadioButton rdBtnSuaCSDL;
    }
}