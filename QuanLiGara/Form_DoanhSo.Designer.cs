namespace QuanLiGara
{
    partial class Form_DoanhSo
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGV_danhthu = new System.Windows.Forms.DataGridView();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.Button_xemDTT = new System.Windows.Forms.Button();
            this.Text_thang = new System.Windows.Forms.TextBox();
            this.Text_tongdoanhthu = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet1 = new QuanLiGara.DataSet1();
            this.BaoCaoDoanhThuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_danhthu)).BeginInit();
            this.groupPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDoanhThuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(452, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "BÁO CÁO DOANH SỐ";
            // 
            // dtGV_danhthu
            // 
            this.dtGV_danhthu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_danhthu.Location = new System.Drawing.Point(12, 171);
            this.dtGV_danhthu.Name = "dtGV_danhthu";
            this.dtGV_danhthu.Size = new System.Drawing.Size(625, 414);
            this.dtGV_danhthu.TabIndex = 3;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.Button_xemDTT);
            this.groupPanel1.Controls.Add(this.Text_thang);
            this.groupPanel1.Controls.Add(this.Text_tongdoanhthu);
            this.groupPanel1.Controls.Add(this.label3);
            this.groupPanel1.Controls.Add(this.label2);
            this.groupPanel1.Location = new System.Drawing.Point(324, 39);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(627, 116);
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
            this.groupPanel1.TabIndex = 4;
            this.groupPanel1.Text = "Chức năng";
            // 
            // Button_xemDTT
            // 
            this.Button_xemDTT.AutoSize = true;
            this.Button_xemDTT.Image = global::QuanLiGara.Properties.Resources.arrow_up_icon1;
            this.Button_xemDTT.Location = new System.Drawing.Point(267, 7);
            this.Button_xemDTT.Name = "Button_xemDTT";
            this.Button_xemDTT.Size = new System.Drawing.Size(41, 41);
            this.Button_xemDTT.TabIndex = 11;
            this.Button_xemDTT.UseVisualStyleBackColor = true;
            this.Button_xemDTT.Click += new System.EventHandler(this.button1_Click);
            // 
            // Text_thang
            // 
            this.Text_thang.Location = new System.Drawing.Point(209, 18);
            this.Text_thang.Name = "Text_thang";
            this.Text_thang.Size = new System.Drawing.Size(52, 20);
            this.Text_thang.TabIndex = 10;
            this.Text_thang.Text = "12";
            // 
            // Text_tongdoanhthu
            // 
            this.Text_tongdoanhthu.Location = new System.Drawing.Point(207, 62);
            this.Text_tongdoanhthu.Name = "Text_tongdoanhthu";
            this.Text_tongdoanhthu.Size = new System.Drawing.Size(302, 20);
            this.Text_tongdoanhthu.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(112, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tổng Doanh Thu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(112, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tháng";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BaoCaoDoanhThuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLiGara.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(643, 171);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(618, 414);
            this.reportViewer1.TabIndex = 5;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BaoCaoDoanhThuBindingSource
            // 
            this.BaoCaoDoanhThuBindingSource.DataMember = "BaoCaoDoanhThu";
            this.BaoCaoDoanhThuBindingSource.DataSource = this.DataSet1;
            // 
            // Form_DoanhSo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1300, 621);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.dtGV_danhthu);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Name = "Form_DoanhSo";
            this.Text = "Báo Cáo Doanh Số";
            this.Load += new System.EventHandler(this.Form_DoanhSo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_danhthu)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoDoanhThuBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGV_danhthu;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private System.Windows.Forms.Button Button_xemDTT;
        private System.Windows.Forms.TextBox Text_thang;
        private System.Windows.Forms.TextBox Text_tongdoanhthu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BaoCaoDoanhThuBindingSource;
        private DataSet1 DataSet1;
    }
}