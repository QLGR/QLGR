namespace QuanLiGara
{
    partial class Form_PhieuSuaChua
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
            this.dtGV_danhsachSuaChua = new System.Windows.Forms.DataGridView();
            this.Button_themSuaChua = new System.Windows.Forms.Button();
            this.Button_xoaSuaChua = new System.Windows.Forms.Button();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Text_tiencong = new System.Windows.Forms.TextBox();
            this.Date_ngaysuachua = new System.Windows.Forms.DateTimePicker();
            this.cbBox_tiencong = new System.Windows.Forms.ComboBox();
            this.cbBoc_vattu = new System.Windows.Forms.ComboBox();
            this.cbBox_bienso = new System.Windows.Forms.ComboBox();
            this.Text_thanhtien = new System.Windows.Forms.TextBox();
            this.Text_dongia = new System.Windows.Forms.TextBox();
            this.Text_soluong = new System.Windows.Forms.TextBox();
            this.Text_noidung = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_danhsachSuaChua)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(299, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "PHIẾU SỬA CHỮA";
            // 
            // dtGV_danhsachSuaChua
            // 
            this.dtGV_danhsachSuaChua.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_danhsachSuaChua.Location = new System.Drawing.Point(30, 282);
            this.dtGV_danhsachSuaChua.Name = "dtGV_danhsachSuaChua";
            this.dtGV_danhsachSuaChua.Size = new System.Drawing.Size(870, 260);
            this.dtGV_danhsachSuaChua.TabIndex = 17;
            this.dtGV_danhsachSuaChua.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dtGV_danhsachSuaChua.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Button_themSuaChua
            // 
            this.Button_themSuaChua.AutoSize = true;
            this.Button_themSuaChua.Image = global::QuanLiGara.Properties.Resources.lap_phieu_sua_chua;
            this.Button_themSuaChua.Location = new System.Drawing.Point(372, 560);
            this.Button_themSuaChua.Name = "Button_themSuaChua";
            this.Button_themSuaChua.Size = new System.Drawing.Size(46, 46);
            this.Button_themSuaChua.TabIndex = 18;
            this.Button_themSuaChua.UseVisualStyleBackColor = true;
            this.Button_themSuaChua.Click += new System.EventHandler(this.button1_Click);
            // 
            // Button_xoaSuaChua
            // 
            this.Button_xoaSuaChua.AutoSize = true;
            this.Button_xoaSuaChua.Image = global::QuanLiGara.Properties.Resources.xoa;
            this.Button_xoaSuaChua.Location = new System.Drawing.Point(467, 560);
            this.Button_xoaSuaChua.Name = "Button_xoaSuaChua";
            this.Button_xoaSuaChua.Size = new System.Drawing.Size(46, 46);
            this.Button_xoaSuaChua.TabIndex = 20;
            this.Button_xoaSuaChua.UseVisualStyleBackColor = true;
            this.Button_xoaSuaChua.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Text_tiencong);
            this.groupPanel1.Controls.Add(this.Date_ngaysuachua);
            this.groupPanel1.Controls.Add(this.cbBox_tiencong);
            this.groupPanel1.Controls.Add(this.cbBoc_vattu);
            this.groupPanel1.Controls.Add(this.cbBox_bienso);
            this.groupPanel1.Controls.Add(this.Text_thanhtien);
            this.groupPanel1.Controls.Add(this.Text_dongia);
            this.groupPanel1.Controls.Add(this.Text_soluong);
            this.groupPanel1.Controls.Add(this.Text_noidung);
            this.groupPanel1.Controls.Add(this.label9);
            this.groupPanel1.Controls.Add(this.label8);
            this.groupPanel1.Controls.Add(this.label7);
            this.groupPanel1.Controls.Add(this.label6);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Location = new System.Drawing.Point(29, 59);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(871, 191);
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
            this.groupPanel1.TabIndex = 21;
            this.groupPanel1.Text = "Thông tin phiếu sửa";
            this.groupPanel1.Click += new System.EventHandler(this.groupPanel1_Click);
            // 
            // Text_tiencong
            // 
            this.Text_tiencong.Location = new System.Drawing.Point(665, 94);
            this.Text_tiencong.Name = "Text_tiencong";
            this.Text_tiencong.Size = new System.Drawing.Size(136, 20);
            this.Text_tiencong.TabIndex = 43;
            // 
            // Date_ngaysuachua
            // 
            this.Date_ngaysuachua.Location = new System.Drawing.Point(597, 5);
            this.Date_ngaysuachua.Name = "Date_ngaysuachua";
            this.Date_ngaysuachua.Size = new System.Drawing.Size(188, 20);
            this.Date_ngaysuachua.TabIndex = 42;
            // 
            // cbBox_tiencong
            // 
            this.cbBox_tiencong.FormattingEnabled = true;
            this.cbBox_tiencong.Location = new System.Drawing.Point(532, 93);
            this.cbBox_tiencong.Name = "cbBox_tiencong";
            this.cbBox_tiencong.Size = new System.Drawing.Size(127, 21);
            this.cbBox_tiencong.TabIndex = 41;
            this.cbBox_tiencong.SelectedIndexChanged += new System.EventHandler(this.tiencong_SelectedIndexChanged_1);
            // 
            // cbBoc_vattu
            // 
            this.cbBoc_vattu.FormattingEnabled = true;
            this.cbBoc_vattu.Location = new System.Drawing.Point(188, 93);
            this.cbBoc_vattu.Name = "cbBoc_vattu";
            this.cbBoc_vattu.Size = new System.Drawing.Size(246, 21);
            this.cbBoc_vattu.TabIndex = 40;
            this.cbBoc_vattu.SelectedIndexChanged += new System.EventHandler(this.vattu_SelectedIndexChanged_1);
            // 
            // cbBox_bienso
            // 
            this.cbBox_bienso.FormattingEnabled = true;
            this.cbBox_bienso.Location = new System.Drawing.Point(188, 8);
            this.cbBox_bienso.Name = "cbBox_bienso";
            this.cbBox_bienso.Size = new System.Drawing.Size(246, 21);
            this.cbBox_bienso.TabIndex = 39;
            this.cbBox_bienso.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged_1);
            // 
            // Text_thanhtien
            // 
            this.Text_thanhtien.Location = new System.Drawing.Point(532, 139);
            this.Text_thanhtien.Name = "Text_thanhtien";
            this.Text_thanhtien.Size = new System.Drawing.Size(270, 20);
            this.Text_thanhtien.TabIndex = 38;
            // 
            // Text_dongia
            // 
            this.Text_dongia.Location = new System.Drawing.Point(532, 55);
            this.Text_dongia.Name = "Text_dongia";
            this.Text_dongia.Size = new System.Drawing.Size(270, 20);
            this.Text_dongia.TabIndex = 37;
            // 
            // Text_soluong
            // 
            this.Text_soluong.Location = new System.Drawing.Point(188, 139);
            this.Text_soluong.Name = "Text_soluong";
            this.Text_soluong.Size = new System.Drawing.Size(246, 20);
            this.Text_soluong.TabIndex = 36;
            this.Text_soluong.TextChanged += new System.EventHandler(this.soluong_TextChanged_1);
            // 
            // Text_noidung
            // 
            this.Text_noidung.Location = new System.Drawing.Point(188, 55);
            this.Text_noidung.Name = "Text_noidung";
            this.Text_noidung.Size = new System.Drawing.Size(246, 20);
            this.Text_noidung.TabIndex = 35;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(462, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 34;
            this.label9.Text = "Thành Tiền";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(462, 96);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Tiền Công";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(462, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Đơn giá";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(62, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(62, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Vật tư Phụ Tùng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(62, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Nội Dung";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(509, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Ngày Sửa Chữa";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(126, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Biển số xe";
            // 
            // Form_PhieuSuaChua
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 614);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.Button_xoaSuaChua);
            this.Controls.Add(this.Button_themSuaChua);
            this.Controls.Add(this.dtGV_danhsachSuaChua);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "Form_PhieuSuaChua";
            this.Text = "Lập Phiếu Sửa Chữa";
            this.Load += new System.EventHandler(this.Form_PhieuSuaChua_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_danhsachSuaChua)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGV_danhsachSuaChua;
        private System.Windows.Forms.Button Button_themSuaChua;
        private System.Windows.Forms.Button Button_xoaSuaChua;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.TextBox Text_tiencong;
        private System.Windows.Forms.DateTimePicker Date_ngaysuachua;
        private System.Windows.Forms.ComboBox cbBox_tiencong;
        private System.Windows.Forms.ComboBox cbBoc_vattu;
        private System.Windows.Forms.ComboBox cbBox_bienso;
        private System.Windows.Forms.TextBox Text_thanhtien;
        private System.Windows.Forms.TextBox Text_dongia;
        private System.Windows.Forms.TextBox Text_soluong;
        private System.Windows.Forms.TextBox Text_noidung;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}