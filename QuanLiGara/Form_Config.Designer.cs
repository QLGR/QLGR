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
            this.SuspendLayout();
            // 
            // Text_tenserver
            // 
            // 
            // 
            // 
            this.Text_tenserver.Border.Class = "TextBoxBorder";
            this.Text_tenserver.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Text_tenserver.ButtonCustom.Tooltip = "";
            this.Text_tenserver.ButtonCustom2.Tooltip = "";
            this.Text_tenserver.Location = new System.Drawing.Point(187, 93);
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
            this.labelX1.Location = new System.Drawing.Point(75, 86);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(94, 31);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "Tên Server SQL";
            // 
            // Buttom_LuuServer
            // 
            this.Buttom_LuuServer.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Buttom_LuuServer.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Buttom_LuuServer.Location = new System.Drawing.Point(162, 147);
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
            this.Buttom_ThoatServer.Location = new System.Drawing.Point(274, 147);
            this.Buttom_ThoatServer.Name = "Buttom_ThoatServer";
            this.Buttom_ThoatServer.Size = new System.Drawing.Size(77, 32);
            this.Buttom_ThoatServer.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.Buttom_ThoatServer.TabIndex = 3;
            this.Buttom_ThoatServer.Text = "Thoát";
            this.Buttom_ThoatServer.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // Form_Config
            // 
            this.ClientSize = new System.Drawing.Size(471, 240);
            this.Controls.Add(this.Buttom_ThoatServer);
            this.Controls.Add(this.Buttom_LuuServer);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.Text_tenserver);
            this.Name = "Form_Config";
            this.Text = "Form_Config";
            this.Load += new System.EventHandler(this.Form_Config_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.TextBoxX Text_tenserver;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX Buttom_LuuServer;
        private DevComponents.DotNetBar.ButtonX Buttom_ThoatServer;
    }
}