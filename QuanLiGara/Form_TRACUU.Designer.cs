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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TRACUU));
            this.label1 = new System.Windows.Forms.Label();
            this.dtGV_tracuu = new System.Windows.Forms.DataGridView();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Button_timkiem = new System.Windows.Forms.Button();
            this.Text_tienno = new System.Windows.Forms.TextBox();
            this.Text_chuxe = new System.Windows.Forms.TextBox();
            this.Text_hieuxe = new System.Windows.Forms.TextBox();
            this.Text_bienso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_tracuu)).BeginInit();
            this.groupPanel1.SuspendLayout();
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
            this.dtGV_tracuu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_tracuu.Location = new System.Drawing.Point(12, 203);
            this.dtGV_tracuu.Name = "dtGV_tracuu";
            this.dtGV_tracuu.Size = new System.Drawing.Size(837, 256);
            this.dtGV_tracuu.TabIndex = 9;
            this.dtGV_tracuu.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dtGV_tracuu.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Button_timkiem);
            this.groupPanel1.Controls.Add(this.Text_tienno);
            this.groupPanel1.Controls.Add(this.Text_chuxe);
            this.groupPanel1.Controls.Add(this.Text_hieuxe);
            this.groupPanel1.Controls.Add(this.Text_bienso);
            this.groupPanel1.Controls.Add(this.label5);
            this.groupPanel1.Controls.Add(this.label4);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Location = new System.Drawing.Point(12, 55);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(837, 125);
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
            // Button_timkiem
            // 
            this.Button_timkiem.AutoSize = true;
            this.Button_timkiem.ForeColor = System.Drawing.Color.Red;
            this.Button_timkiem.Image = ((System.Drawing.Image)(resources.GetObject("Button_timkiem.Image")));
            this.Button_timkiem.Location = new System.Drawing.Point(681, 53);
            this.Button_timkiem.Name = "Button_timkiem";
            this.Button_timkiem.Size = new System.Drawing.Size(46, 46);
            this.Button_timkiem.TabIndex = 30;
            this.Button_timkiem.UseVisualStyleBackColor = true;
            this.Button_timkiem.Click += new System.EventHandler(this.button1_Click);
            // 
            // Text_tienno
            // 
            this.Text_tienno.Location = new System.Drawing.Point(442, 64);
            this.Text_tienno.Name = "Text_tienno";
            this.Text_tienno.Size = new System.Drawing.Size(221, 20);
            this.Text_tienno.TabIndex = 29;
            // 
            // Text_chuxe
            // 
            this.Text_chuxe.Location = new System.Drawing.Point(95, 64);
            this.Text_chuxe.Name = "Text_chuxe";
            this.Text_chuxe.Size = new System.Drawing.Size(242, 20);
            this.Text_chuxe.TabIndex = 28;
            // 
            // Text_hieuxe
            // 
            this.Text_hieuxe.Location = new System.Drawing.Point(442, 20);
            this.Text_hieuxe.Name = "Text_hieuxe";
            this.Text_hieuxe.Size = new System.Drawing.Size(221, 20);
            this.Text_hieuxe.TabIndex = 27;
            // 
            // Text_bienso
            // 
            this.Text_bienso.Location = new System.Drawing.Point(95, 20);
            this.Text_bienso.Name = "Text_bienso";
            this.Text_bienso.Size = new System.Drawing.Size(242, 20);
            this.Text_bienso.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(47, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Chủ Xe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(382, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tiền Nợ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(382, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Hiệu Xe";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(45, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Biển Số";
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
            this.Text = "Tra Cứu";
            this.Load += new System.EventHandler(this.Form_TRACUU_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_tracuu)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGV_tracuu;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Button Button_timkiem;
        private System.Windows.Forms.TextBox Text_tienno;
        private System.Windows.Forms.TextBox Text_chuxe;
        private System.Windows.Forms.TextBox Text_hieuxe;
        private System.Windows.Forms.TextBox Text_bienso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}