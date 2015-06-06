namespace QuanLiGara
{
    partial class Form_PHIEUTHUTIEN
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
            this.label1 = new System.Windows.Forms.Label();
            this.dtGV_phieuthu = new System.Windows.Forms.DataGridView();
            this.Button_lapphieu = new System.Windows.Forms.Button();
            this.Button_xoa = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Date_ngaythutien = new System.Windows.Forms.DateTimePicker();
            this.cbB_bienso = new System.Windows.Forms.ComboBox();
            this.Text_sotienthu = new System.Windows.Forms.TextBox();
            this.Text_email = new System.Windows.Forms.TextBox();
            this.Text_dienthoai = new System.Windows.Forms.TextBox();
            this.Text_chuxe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_phieuthu)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(243, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 44);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHIẾU THU TIỀN";
            // 
            // dtGV_phieuthu
            // 
            this.dtGV_phieuthu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_phieuthu.Location = new System.Drawing.Point(22, 214);
            this.dtGV_phieuthu.Name = "dtGV_phieuthu";
            this.dtGV_phieuthu.Size = new System.Drawing.Size(799, 259);
            this.dtGV_phieuthu.TabIndex = 13;
            this.dtGV_phieuthu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dtGV_phieuthu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Button_lapphieu
            // 
            this.Button_lapphieu.AutoSize = true;
            this.Button_lapphieu.Image = global::QuanLiGara.Properties.Resources.lap_phieu_thu_tien;
            this.Button_lapphieu.Location = new System.Drawing.Point(346, 479);
            this.Button_lapphieu.Name = "Button_lapphieu";
            this.Button_lapphieu.Size = new System.Drawing.Size(46, 46);
            this.Button_lapphieu.TabIndex = 16;
            this.Button_lapphieu.UseVisualStyleBackColor = true;
            this.Button_lapphieu.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button_xoa
            // 
            this.Button_xoa.AutoSize = true;
            this.Button_xoa.Image = global::QuanLiGara.Properties.Resources.xoa;
            this.Button_xoa.Location = new System.Drawing.Point(432, 479);
            this.Button_xoa.Name = "Button_xoa";
            this.Button_xoa.Size = new System.Drawing.Size(46, 46);
            this.Button_xoa.TabIndex = 18;
            this.Button_xoa.UseVisualStyleBackColor = true;
            this.Button_xoa.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Date_ngaythutien);
            this.groupPanel1.Controls.Add(this.cbB_bienso);
            this.groupPanel1.Controls.Add(this.Text_sotienthu);
            this.groupPanel1.Controls.Add(this.Text_email);
            this.groupPanel1.Controls.Add(this.Text_dienthoai);
            this.groupPanel1.Controls.Add(this.Text_chuxe);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(22, 52);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(798, 156);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 19;
            this.groupPanel1.Text = "Thông tin phiếu thu tiền";
            // 
            // Date_ngaythutien
            // 
            this.Date_ngaythutien.Location = new System.Drawing.Point(196, 104);
            this.Date_ngaythutien.Name = "Date_ngaythutien";
            this.Date_ngaythutien.Size = new System.Drawing.Size(190, 20);
            this.Date_ngaythutien.TabIndex = 27;
            // 
            // cbB_bienso
            // 
            this.cbB_bienso.FormattingEnabled = true;
            this.cbB_bienso.Location = new System.Drawing.Point(497, 11);
            this.cbB_bienso.Name = "cbB_bienso";
            this.cbB_bienso.Size = new System.Drawing.Size(199, 21);
            this.cbB_bienso.TabIndex = 26;
            this.cbB_bienso.SelectedIndexChanged += new System.EventHandler(this.bienso_SelectedIndexChanged_1);
            // 
            // Text_sotienthu
            // 
            this.Text_sotienthu.Location = new System.Drawing.Point(497, 107);
            this.Text_sotienthu.Name = "Text_sotienthu";
            this.Text_sotienthu.Size = new System.Drawing.Size(199, 20);
            this.Text_sotienthu.TabIndex = 25;
            // 
            // Text_email
            // 
            this.Text_email.Location = new System.Drawing.Point(497, 56);
            this.Text_email.Name = "Text_email";
            this.Text_email.Size = new System.Drawing.Size(199, 20);
            this.Text_email.TabIndex = 24;
            // 
            // Text_dienthoai
            // 
            this.Text_dienthoai.Location = new System.Drawing.Point(196, 56);
            this.Text_dienthoai.Name = "Text_dienthoai";
            this.Text_dienthoai.Size = new System.Drawing.Size(190, 20);
            this.Text_dienthoai.TabIndex = 23;
            // 
            // Text_chuxe
            // 
            this.Text_chuxe.Location = new System.Drawing.Point(196, 8);
            this.Text_chuxe.Name = "Text_chuxe";
            this.Text_chuxe.Size = new System.Drawing.Size(190, 20);
            this.Text_chuxe.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(421, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Số Tiền Thu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(96, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Ngày Thu Tiền";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(421, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(96, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Điện Thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(421, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Biển Số";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(96, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Họ Tên Chủ Xe";
            // 
            // Form_PHIEUTHUTIEN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 529);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.Button_xoa);
            this.Controls.Add(this.Button_lapphieu);
            this.Controls.Add(this.dtGV_phieuthu);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "Form_PHIEUTHUTIEN";
            this.Text = "Lập Phiếu Thu Tiền";
            this.Load += new System.EventHandler(this.Form_PHIEUTHUTIEN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_phieuthu)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGV_phieuthu;
        private System.Windows.Forms.Button Button_lapphieu;
        private System.Windows.Forms.Button Button_xoa;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.DateTimePicker Date_ngaythutien;
        private System.Windows.Forms.ComboBox cbB_bienso;
        private System.Windows.Forms.TextBox Text_sotienthu;
        private System.Windows.Forms.TextBox Text_email;
        private System.Windows.Forms.TextBox Text_dienthoai;
        private System.Windows.Forms.TextBox Text_chuxe;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}