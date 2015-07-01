namespace QuanLiGara
{
    partial class Form_BaoCaoTon
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
            this.BaoCaoTonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSet1 = new QuanLiGara.DataSet1();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem13 = new DevComponents.Editors.ComboItem();
            this.comboItem14 = new DevComponents.Editors.ComboItem();
            this.comboItem15 = new DevComponents.Editors.ComboItem();
            this.comboItem16 = new DevComponents.Editors.ComboItem();
            this.comboItem17 = new DevComponents.Editors.ComboItem();
            this.comboItem18 = new DevComponents.Editors.ComboItem();
            this.comboItem19 = new DevComponents.Editors.ComboItem();
            this.comboItem20 = new DevComponents.Editors.ComboItem();
            this.comboItem21 = new DevComponents.Editors.ComboItem();
            this.comboItem22 = new DevComponents.Editors.ComboItem();
            this.comboItem23 = new DevComponents.Editors.ComboItem();
            this.comboItem24 = new DevComponents.Editors.ComboItem();
            this.comboItem12 = new DevComponents.Editors.ComboItem();
            this.comboItem11 = new DevComponents.Editors.ComboItem();
            this.comboItem10 = new DevComponents.Editors.ComboItem();
            this.comboItem9 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoTonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BaoCaoTonBindingSource
            // 
            this.BaoCaoTonBindingSource.DataMember = "BaoCaoTon";
            this.BaoCaoTonBindingSource.DataSource = this.DataSet1;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(235, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tháng";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(219, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "BÁO CÁO TỒN KHO";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BaoCaoTonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLiGara.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(31, 138);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(689, 387);
            this.reportViewer1.TabIndex = 6;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 14;
            this.comboBoxEx1.Items.AddRange(new object[] {
            this.comboItem13,
            this.comboItem14,
            this.comboItem15,
            this.comboItem16,
            this.comboItem17,
            this.comboItem18,
            this.comboItem19,
            this.comboItem20,
            this.comboItem21,
            this.comboItem22,
            this.comboItem23,
            this.comboItem24});
            this.comboBoxEx1.Location = new System.Drawing.Point(279, 22);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(62, 20);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 7;
            this.comboBoxEx1.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            // 
            // comboItem13
            // 
            this.comboItem13.Text = "1";
            // 
            // comboItem14
            // 
            this.comboItem14.Text = "2";
            // 
            // comboItem15
            // 
            this.comboItem15.Text = "3";
            // 
            // comboItem16
            // 
            this.comboItem16.Text = "4";
            // 
            // comboItem17
            // 
            this.comboItem17.Text = "5";
            // 
            // comboItem18
            // 
            this.comboItem18.Text = "6";
            // 
            // comboItem19
            // 
            this.comboItem19.Text = "7";
            // 
            // comboItem20
            // 
            this.comboItem20.Text = "8";
            // 
            // comboItem21
            // 
            this.comboItem21.Text = "9";
            // 
            // comboItem22
            // 
            this.comboItem22.Text = "10";
            // 
            // comboItem23
            // 
            this.comboItem23.Text = "11";
            // 
            // comboItem24
            // 
            this.comboItem24.Text = "12";
            // 
            // comboItem12
            // 
            this.comboItem12.Text = "12";
            // 
            // comboItem11
            // 
            this.comboItem11.Text = "11";
            // 
            // comboItem10
            // 
            this.comboItem10.Text = "10";
            // 
            // comboItem9
            // 
            this.comboItem9.Text = "9";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "8";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "7";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "6";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "5";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "4";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "3";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "2";
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "1";
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.comboBoxEx1);
            this.groupPanel1.Controls.Add(this.label1);
            this.groupPanel1.Location = new System.Drawing.Point(63, 48);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(627, 73);
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
            this.groupPanel1.TabIndex = 8;
            // 
            // Form_BaoCaoTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 528);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "Form_BaoCaoTon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo Cáo Tồn Kho";
            this.Load += new System.EventHandler(this.Form_BaoCaoTon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoTonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.groupPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BaoCaoTonBindingSource;
        private DataSet1 DataSet1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.Editors.ComboItem comboItem13;
        private DevComponents.Editors.ComboItem comboItem14;
        private DevComponents.Editors.ComboItem comboItem15;
        private DevComponents.Editors.ComboItem comboItem16;
        private DevComponents.Editors.ComboItem comboItem17;
        private DevComponents.Editors.ComboItem comboItem18;
        private DevComponents.Editors.ComboItem comboItem19;
        private DevComponents.Editors.ComboItem comboItem20;
        private DevComponents.Editors.ComboItem comboItem21;
        private DevComponents.Editors.ComboItem comboItem22;
        private DevComponents.Editors.ComboItem comboItem23;
        private DevComponents.Editors.ComboItem comboItem24;
        private DevComponents.Editors.ComboItem comboItem12;
        private DevComponents.Editors.ComboItem comboItem11;
        private DevComponents.Editors.ComboItem comboItem10;
        private DevComponents.Editors.ComboItem comboItem9;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
    }
}