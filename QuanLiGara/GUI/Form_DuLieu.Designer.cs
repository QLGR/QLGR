namespace QuanLiGara
{
    partial class Form_DuLieu
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
            this.dtGV_vattu = new System.Windows.Forms.DataGridView();
            this.dtGV_tiencong = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtGV_hieuxe = new System.Windows.Forms.DataGridView();
            this.Text_soxemax = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Text_maVT = new System.Windows.Forms.TextBox();
            this.Text_tenVT = new System.Windows.Forms.TextBox();
            this.Text_dongia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Text_matiencong = new System.Windows.Forms.TextBox();
            this.Text_tentiencong = new System.Windows.Forms.TextBox();
            this.Text_tiencong = new System.Windows.Forms.TextBox();
            this.Text_mahieuxe = new System.Windows.Forms.TextBox();
            this.Text_tenhieuxe = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnHuy = new DevComponents.DotNetBar.ButtonX();
            this.btnLuu = new DevComponents.DotNetBar.ButtonX();
            this.Button_suamax = new System.Windows.Forms.Button();
            this.Button_xoahx = new System.Windows.Forms.Button();
            this.Button_suahx = new System.Windows.Forms.Button();
            this.Button_themhx = new System.Windows.Forms.Button();
            this.Button_xoatc = new System.Windows.Forms.Button();
            this.Button_suatc = new System.Windows.Forms.Button();
            this.Button_themtc = new System.Windows.Forms.Button();
            this.Button_xoavt = new System.Windows.Forms.Button();
            this.Button_suavt = new System.Windows.Forms.Button();
            this.Button_themvt = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.Text_Chenhlech = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.text_SoLuong = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_vattu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_tiencong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_hieuxe)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGV_vattu
            // 
            this.dtGV_vattu.AllowUserToAddRows = false;
            this.dtGV_vattu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_vattu.Location = new System.Drawing.Point(3, 122);
            this.dtGV_vattu.Name = "dtGV_vattu";
            this.dtGV_vattu.ReadOnly = true;
            this.dtGV_vattu.Size = new System.Drawing.Size(450, 336);
            this.dtGV_vattu.TabIndex = 0;
            this.dtGV_vattu.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGV_vattu_RowEnter);
            // 
            // dtGV_tiencong
            // 
            this.dtGV_tiencong.AllowUserToAddRows = false;
            this.dtGV_tiencong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_tiencong.Location = new System.Drawing.Point(459, 122);
            this.dtGV_tiencong.Name = "dtGV_tiencong";
            this.dtGV_tiencong.ReadOnly = true;
            this.dtGV_tiencong.Size = new System.Drawing.Size(352, 336);
            this.dtGV_tiencong.TabIndex = 1;
            this.dtGV_tiencong.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGV_tiencong_RowEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(452, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "CHỈNH SỬA DỮ LIỆU";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(197, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "VẬT TƯ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(666, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TIỀN CÔNG";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1066, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 26);
            this.label4.TabIndex = 5;
            this.label4.Text = "Số xe sửa chữa tối đa\r\ntrong ngày";
            // 
            // dtGV_hieuxe
            // 
            this.dtGV_hieuxe.AllowUserToAddRows = false;
            this.dtGV_hieuxe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_hieuxe.Location = new System.Drawing.Point(818, 122);
            this.dtGV_hieuxe.Name = "dtGV_hieuxe";
            this.dtGV_hieuxe.ReadOnly = true;
            this.dtGV_hieuxe.Size = new System.Drawing.Size(243, 336);
            this.dtGV_hieuxe.TabIndex = 6;
            this.dtGV_hieuxe.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGV_hieuxe_RowEnter);
            // 
            // Text_soxemax
            // 
            this.Text_soxemax.Location = new System.Drawing.Point(1086, 120);
            this.Text_soxemax.Name = "Text_soxemax";
            this.Text_soxemax.Size = new System.Drawing.Size(91, 20);
            this.Text_soxemax.TabIndex = 7;
            this.Text_soxemax.TextChanged += new System.EventHandler(this.SoLuong_TextChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(33, 479);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Mã VT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(182, 479);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Tên Vật Tư";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 524);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Đơn giá";
            // 
            // Text_maVT
            // 
            this.Text_maVT.Location = new System.Drawing.Point(78, 476);
            this.Text_maVT.Name = "Text_maVT";
            this.Text_maVT.ReadOnly = true;
            this.Text_maVT.Size = new System.Drawing.Size(98, 20);
            this.Text_maVT.TabIndex = 11;
            // 
            // Text_tenVT
            // 
            this.Text_tenVT.Location = new System.Drawing.Point(249, 476);
            this.Text_tenVT.Name = "Text_tenVT";
            this.Text_tenVT.ReadOnly = true;
            this.Text_tenVT.Size = new System.Drawing.Size(186, 20);
            this.Text_tenVT.TabIndex = 12;
            // 
            // Text_dongia
            // 
            this.Text_dongia.Location = new System.Drawing.Point(78, 521);
            this.Text_dongia.Name = "Text_dongia";
            this.Text_dongia.ReadOnly = true;
            this.Text_dongia.Size = new System.Drawing.Size(98, 20);
            this.Text_dongia.TabIndex = 13;
            this.Text_dongia.TextChanged += new System.EventHandler(this.SoLuong_TextChange);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(452, 479);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Mã Tiền Công";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(617, 479);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Tên Tiền Công";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(452, 524);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Tiền Công";
            // 
            // Text_matiencong
            // 
            this.Text_matiencong.Location = new System.Drawing.Point(532, 476);
            this.Text_matiencong.Name = "Text_matiencong";
            this.Text_matiencong.ReadOnly = true;
            this.Text_matiencong.Size = new System.Drawing.Size(79, 20);
            this.Text_matiencong.TabIndex = 17;
            // 
            // Text_tentiencong
            // 
            this.Text_tentiencong.Location = new System.Drawing.Point(701, 476);
            this.Text_tentiencong.Name = "Text_tentiencong";
            this.Text_tentiencong.ReadOnly = true;
            this.Text_tentiencong.Size = new System.Drawing.Size(108, 20);
            this.Text_tentiencong.TabIndex = 18;
            // 
            // Text_tiencong
            // 
            this.Text_tiencong.Location = new System.Drawing.Point(532, 524);
            this.Text_tiencong.Name = "Text_tiencong";
            this.Text_tiencong.ReadOnly = true;
            this.Text_tiencong.Size = new System.Drawing.Size(139, 20);
            this.Text_tiencong.TabIndex = 19;
            this.Text_tiencong.TextChanged += new System.EventHandler(this.SoLuong_TextChange);
            // 
            // Text_mahieuxe
            // 
            this.Text_mahieuxe.Location = new System.Drawing.Point(884, 479);
            this.Text_mahieuxe.Name = "Text_mahieuxe";
            this.Text_mahieuxe.ReadOnly = true;
            this.Text_mahieuxe.Size = new System.Drawing.Size(177, 20);
            this.Text_mahieuxe.TabIndex = 20;
            // 
            // Text_tenhieuxe
            // 
            this.Text_tenhieuxe.Location = new System.Drawing.Point(884, 521);
            this.Text_tenhieuxe.Name = "Text_tenhieuxe";
            this.Text_tenhieuxe.ReadOnly = true;
            this.Text_tenhieuxe.Size = new System.Drawing.Size(177, 20);
            this.Text_tenhieuxe.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(815, 479);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 13);
            this.label11.TabIndex = 22;
            this.label11.Text = "Mã Hiệu Xe";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(815, 524);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Tên Hiệu Xe";
            // 
            // btnHuy
            // 
            this.btnHuy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnHuy.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnHuy.Image = global::QuanLiGara.Properties.Resources.undo;
            this.btnHuy.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnHuy.Location = new System.Drawing.Point(1131, 476);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(46, 46);
            this.btnHuy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnHuy.TabIndex = 35;
            this.btnHuy.Click += new System.EventHandler(this.btnHuyAll_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLuu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLuu.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLuu.Image = global::QuanLiGara.Properties.Resources.Save;
            this.btnLuu.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLuu.Location = new System.Drawing.Point(1077, 476);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(46, 46);
            this.btnLuu.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLuu.TabIndex = 35;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // Button_suamax
            // 
            this.Button_suamax.AutoSize = true;
            this.Button_suamax.Image = global::QuanLiGara.Properties.Resources.arrow_up_icon1;
            this.Button_suamax.Location = new System.Drawing.Point(1110, 226);
            this.Button_suamax.Name = "Button_suamax";
            this.Button_suamax.Size = new System.Drawing.Size(41, 41);
            this.Button_suamax.TabIndex = 34;
            this.Button_suamax.UseVisualStyleBackColor = true;
            this.Button_suamax.Click += new System.EventHandler(this.btnThemThamSo);
            // 
            // Button_xoahx
            // 
            this.Button_xoahx.AutoSize = true;
            this.Button_xoahx.Image = global::QuanLiGara.Properties.Resources.xoa;
            this.Button_xoahx.Location = new System.Drawing.Point(974, 565);
            this.Button_xoahx.Name = "Button_xoahx";
            this.Button_xoahx.Size = new System.Drawing.Size(46, 46);
            this.Button_xoahx.TabIndex = 32;
            this.Button_xoahx.UseVisualStyleBackColor = true;
            this.Button_xoahx.Click += new System.EventHandler(this.btnXoaHX);
            // 
            // Button_suahx
            // 
            this.Button_suahx.AutoSize = true;
            this.Button_suahx.Image = global::QuanLiGara.Properties.Resources.sua;
            this.Button_suahx.Location = new System.Drawing.Point(900, 565);
            this.Button_suahx.Name = "Button_suahx";
            this.Button_suahx.Size = new System.Drawing.Size(46, 46);
            this.Button_suahx.TabIndex = 31;
            this.Button_suahx.UseVisualStyleBackColor = true;
            this.Button_suahx.Click += new System.EventHandler(this.btnSuaHX);
            // 
            // Button_themhx
            // 
            this.Button_themhx.AutoSize = true;
            this.Button_themhx.Image = global::QuanLiGara.Properties.Resources.them;
            this.Button_themhx.Location = new System.Drawing.Point(828, 565);
            this.Button_themhx.Name = "Button_themhx";
            this.Button_themhx.Size = new System.Drawing.Size(46, 46);
            this.Button_themhx.TabIndex = 30;
            this.Button_themhx.UseVisualStyleBackColor = true;
            this.Button_themhx.Click += new System.EventHandler(this.btnThemHX);
            // 
            // Button_xoatc
            // 
            this.Button_xoatc.AutoSize = true;
            this.Button_xoatc.Image = global::QuanLiGara.Properties.Resources.xoa;
            this.Button_xoatc.Location = new System.Drawing.Point(690, 565);
            this.Button_xoatc.Name = "Button_xoatc";
            this.Button_xoatc.Size = new System.Drawing.Size(46, 46);
            this.Button_xoatc.TabIndex = 29;
            this.Button_xoatc.UseVisualStyleBackColor = true;
            this.Button_xoatc.Click += new System.EventHandler(this.btnXoaTC);
            // 
            // Button_suatc
            // 
            this.Button_suatc.AutoSize = true;
            this.Button_suatc.Image = global::QuanLiGara.Properties.Resources.sua;
            this.Button_suatc.Location = new System.Drawing.Point(616, 565);
            this.Button_suatc.Name = "Button_suatc";
            this.Button_suatc.Size = new System.Drawing.Size(46, 46);
            this.Button_suatc.TabIndex = 28;
            this.Button_suatc.UseVisualStyleBackColor = true;
            this.Button_suatc.Click += new System.EventHandler(this.btnSuaTC);
            // 
            // Button_themtc
            // 
            this.Button_themtc.AutoSize = true;
            this.Button_themtc.Image = global::QuanLiGara.Properties.Resources.them;
            this.Button_themtc.Location = new System.Drawing.Point(544, 565);
            this.Button_themtc.Name = "Button_themtc";
            this.Button_themtc.Size = new System.Drawing.Size(46, 46);
            this.Button_themtc.TabIndex = 27;
            this.Button_themtc.UseVisualStyleBackColor = true;
            this.Button_themtc.Click += new System.EventHandler(this.btnThemTC);
            // 
            // Button_xoavt
            // 
            this.Button_xoavt.AutoSize = true;
            this.Button_xoavt.Image = global::QuanLiGara.Properties.Resources.xoa;
            this.Button_xoavt.Location = new System.Drawing.Point(259, 565);
            this.Button_xoavt.Name = "Button_xoavt";
            this.Button_xoavt.Size = new System.Drawing.Size(46, 46);
            this.Button_xoavt.TabIndex = 26;
            this.Button_xoavt.UseVisualStyleBackColor = true;
            this.Button_xoavt.Click += new System.EventHandler(this.btnXoaVT_Click);
            // 
            // Button_suavt
            // 
            this.Button_suavt.AutoSize = true;
            this.Button_suavt.Image = global::QuanLiGara.Properties.Resources.sua;
            this.Button_suavt.Location = new System.Drawing.Point(185, 565);
            this.Button_suavt.Name = "Button_suavt";
            this.Button_suavt.Size = new System.Drawing.Size(46, 46);
            this.Button_suavt.TabIndex = 25;
            this.Button_suavt.UseVisualStyleBackColor = true;
            this.Button_suavt.Click += new System.EventHandler(this.btnSuaVT);
            // 
            // Button_themvt
            // 
            this.Button_themvt.AutoSize = true;
            this.Button_themvt.Image = global::QuanLiGara.Properties.Resources.them;
            this.Button_themvt.Location = new System.Drawing.Point(113, 565);
            this.Button_themvt.Name = "Button_themvt";
            this.Button_themvt.Size = new System.Drawing.Size(46, 46);
            this.Button_themvt.TabIndex = 24;
            this.Button_themvt.UseVisualStyleBackColor = true;
            this.Button_themvt.Click += new System.EventHandler(this.btnThemVL);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1069, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "Chênh lệch";
            // 
            // Text_Chenhlech
            // 
            this.Text_Chenhlech.Location = new System.Drawing.Point(1086, 189);
            this.Text_Chenhlech.Name = "Text_Chenhlech";
            this.Text_Chenhlech.Size = new System.Drawing.Size(91, 20);
            this.Text_Chenhlech.TabIndex = 37;
            this.Text_Chenhlech.TextChanged += new System.EventHandler(this.SoLuong_TextChange);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(185, 524);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Số lượng";
            // 
            // text_SoLuong
            // 
            this.text_SoLuong.Location = new System.Drawing.Point(249, 521);
            this.text_SoLuong.Name = "text_SoLuong";
            this.text_SoLuong.ReadOnly = true;
            this.text_SoLuong.Size = new System.Drawing.Size(186, 20);
            this.text_SoLuong.TabIndex = 13;
            this.text_SoLuong.TextChanged += new System.EventHandler(this.SoLuong_TextChange);
            // 
            // Form_DuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 639);
            this.Controls.Add(this.Text_Chenhlech);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.Button_suamax);
            this.Controls.Add(this.Button_xoahx);
            this.Controls.Add(this.Button_suahx);
            this.Controls.Add(this.Button_themhx);
            this.Controls.Add(this.Button_xoatc);
            this.Controls.Add(this.Button_suatc);
            this.Controls.Add(this.Button_themtc);
            this.Controls.Add(this.Button_xoavt);
            this.Controls.Add(this.Button_suavt);
            this.Controls.Add(this.Button_themvt);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Text_tenhieuxe);
            this.Controls.Add(this.Text_mahieuxe);
            this.Controls.Add(this.Text_tiencong);
            this.Controls.Add(this.Text_tentiencong);
            this.Controls.Add(this.Text_matiencong);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.text_SoLuong);
            this.Controls.Add(this.Text_dongia);
            this.Controls.Add(this.Text_tenVT);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Text_maVT);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Text_soxemax);
            this.Controls.Add(this.dtGV_hieuxe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGV_tiencong);
            this.Controls.Add(this.dtGV_vattu);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DuLieu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dữ Liệu";
            this.Load += new System.EventHandler(this.Form_DuLieu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_vattu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_tiencong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_hieuxe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGV_vattu;
        private System.Windows.Forms.DataGridView dtGV_tiencong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dtGV_hieuxe;
        private System.Windows.Forms.TextBox Text_soxemax;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Text_maVT;
        private System.Windows.Forms.TextBox Text_tenVT;
        private System.Windows.Forms.TextBox Text_dongia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Text_matiencong;
        private System.Windows.Forms.TextBox Text_tentiencong;
        private System.Windows.Forms.TextBox Text_tiencong;
        private System.Windows.Forms.TextBox Text_mahieuxe;
        private System.Windows.Forms.TextBox Text_tenhieuxe;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button Button_themvt;
        private System.Windows.Forms.Button Button_suavt;
        private System.Windows.Forms.Button Button_xoavt;
        private System.Windows.Forms.Button Button_xoatc;
        private System.Windows.Forms.Button Button_suatc;
        private System.Windows.Forms.Button Button_themtc;
        private System.Windows.Forms.Button Button_xoahx;
        private System.Windows.Forms.Button Button_suahx;
        private System.Windows.Forms.Button Button_themhx;
        private System.Windows.Forms.Button Button_suamax;
        private DevComponents.DotNetBar.ButtonX btnHuy;
        private DevComponents.DotNetBar.ButtonX btnLuu;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Text_Chenhlech;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox text_SoLuong;
    }
}