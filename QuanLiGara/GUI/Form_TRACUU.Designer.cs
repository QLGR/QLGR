namespace QuanLiGara
{
    partial class Form_TRACUU
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
            this.dtGV_tracuu = new System.Windows.Forms.DataGridView();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Text_Search = new System.Windows.Forms.TextBox();
            this.rbChuXe = new System.Windows.Forms.RadioButton();
            this.rbHieuXe = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.rbBienSo = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_tracuu)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(221, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(373, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH CÁC XE";
            // 
            // dtGV_tracuu
            // 
            this.dtGV_tracuu.AllowUserToAddRows = false;
            this.dtGV_tracuu.AllowUserToDeleteRows = false;
            this.dtGV_tracuu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_tracuu.Location = new System.Drawing.Point(12, 202);
            this.dtGV_tracuu.Name = "dtGV_tracuu";
            this.dtGV_tracuu.Size = new System.Drawing.Size(837, 257);
            this.dtGV_tracuu.TabIndex = 9;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.groupBox1);
            this.groupPanel1.Location = new System.Drawing.Point(12, 55);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(837, 131);
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
            this.groupPanel1.TabIndex = 10;
            this.groupPanel1.Text = "Thông tin tìm xe";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.Text_Search);
            this.groupBox1.Controls.Add(this.rbChuXe);
            this.groupBox1.Controls.Add(this.rbHieuXe);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Controls.Add(this.rbBienSo);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(24, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(782, 83);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Khung Tìm Kiếm";
            // 
            // Text_Search
            // 
            this.Text_Search.Location = new System.Drawing.Point(41, 21);
            this.Text_Search.Name = "Text_Search";
            this.Text_Search.Size = new System.Drawing.Size(713, 22);
            this.Text_Search.TabIndex = 28;
            this.Text_Search.TextChanged += new System.EventHandler(this.Search_Changed);
            // 
            // rbChuXe
            // 
            this.rbChuXe.AutoSize = true;
            this.rbChuXe.Location = new System.Drawing.Point(630, 53);
            this.rbChuXe.Name = "rbChuXe";
            this.rbChuXe.Size = new System.Drawing.Size(66, 19);
            this.rbChuXe.TabIndex = 33;
            this.rbChuXe.Text = "Chủ Xe";
            this.rbChuXe.UseVisualStyleBackColor = true;
            this.rbChuXe.CheckedChanged += new System.EventHandler(this.Checked_Change);
            // 
            // rbHieuXe
            // 
            this.rbHieuXe.AutoSize = true;
            this.rbHieuXe.Location = new System.Drawing.Point(454, 53);
            this.rbHieuXe.Name = "rbHieuXe";
            this.rbHieuXe.Size = new System.Drawing.Size(69, 19);
            this.rbHieuXe.TabIndex = 34;
            this.rbHieuXe.Text = "Hiệu Xe";
            this.rbHieuXe.UseVisualStyleBackColor = true;
            this.rbHieuXe.CheckedChanged += new System.EventHandler(this.Checked_Change);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(98, 53);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(58, 19);
            this.rbAll.TabIndex = 35;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "Tất cả";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.Checked_Change);
            // 
            // rbBienSo
            // 
            this.rbBienSo.AutoSize = true;
            this.rbBienSo.Location = new System.Drawing.Point(273, 53);
            this.rbBienSo.Name = "rbBienSo";
            this.rbBienSo.Size = new System.Drawing.Size(68, 19);
            this.rbBienSo.TabIndex = 35;
            this.rbBienSo.Text = "Biển Số";
            this.rbBienSo.UseVisualStyleBackColor = true;
            this.rbBienSo.CheckedChanged += new System.EventHandler(this.Checked_Change);
            // 
            // Form_TRACUU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(861, 471);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.dtGV_tracuu);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "Form_TRACUU";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tra Cứu";
            this.Load += new System.EventHandler(this.Form_TRACUU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_tracuu)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGV_tracuu;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Text_Search;
        private System.Windows.Forms.RadioButton rbChuXe;
        private System.Windows.Forms.RadioButton rbHieuXe;
        private System.Windows.Forms.RadioButton rbBienSo;
        private System.Windows.Forms.RadioButton rbAll;
    }
}