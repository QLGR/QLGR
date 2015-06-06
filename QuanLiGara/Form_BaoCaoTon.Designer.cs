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
            this.dtGV_danhsach = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Text_thang = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Button_xemBC = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataSet1 = new QuanLiGara.DataSet1();
            this.BaoCaoTonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_danhsach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoTonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGV_danhsach
            // 
            this.dtGV_danhsach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGV_danhsach.Location = new System.Drawing.Point(12, 125);
            this.dtGV_danhsach.Name = "dtGV_danhsach";
            this.dtGV_danhsach.Size = new System.Drawing.Size(531, 421);
            this.dtGV_danhsach.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(479, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tháng";
            // 
            // Text_thang
            // 
            this.Text_thang.Location = new System.Drawing.Point(523, 74);
            this.Text_thang.Name = "Text_thang";
            this.Text_thang.Size = new System.Drawing.Size(114, 20);
            this.Text_thang.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(421, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(320, 37);
            this.label2.TabIndex = 5;
            this.label2.Text = "BÁO CÁO TỒN KHO";
            // 
            // Button_xemBC
            // 
            this.Button_xemBC.AutoSize = true;
            this.Button_xemBC.Image = global::QuanLiGara.Properties.Resources.arrow_up_icon1;
            this.Button_xemBC.Location = new System.Drawing.Point(643, 66);
            this.Button_xemBC.Name = "Button_xemBC";
            this.Button_xemBC.Size = new System.Drawing.Size(41, 41);
            this.Button_xemBC.TabIndex = 3;
            this.Button_xemBC.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Button_xemBC.UseVisualStyleBackColor = true;
            this.Button_xemBC.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.BaoCaoTonBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLiGara.Report3.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(549, 125);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(531, 421);
            this.reportViewer1.TabIndex = 6;
            // 
            // DataSet1
            // 
            this.DataSet1.DataSetName = "DataSet1";
            this.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // BaoCaoTonBindingSource
            // 
            this.BaoCaoTonBindingSource.DataMember = "BaoCaoTon";
            this.BaoCaoTonBindingSource.DataSource = this.DataSet1;
            // 
            // Form_BaoCaoTon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 558);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Text_thang);
            this.Controls.Add(this.Button_xemBC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtGV_danhsach);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Name = "Form_BaoCaoTon";
            this.Text = "Báo Cáo Tồn Kho";
            this.Load += new System.EventHandler(this.Form_BaoCaoTon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGV_danhsach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BaoCaoTonBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGV_danhsach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_xemBC;
        private System.Windows.Forms.TextBox Text_thang;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource BaoCaoTonBindingSource;
        private DataSet1 DataSet1;
    }
}