using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;
using System.IO;
namespace QuanLiGara
{
    public partial class Form_BaoCaoTon : Office2007Form
    {
        public Form_BaoCaoTon()
        {
            InitializeComponent();
        }

        Connection db = new Connection();

        public void loadthang()
        {
            try
            {
                DataTable dt = db.getDS("execute BaoCaoTon '" + comboBoxEx1.SelectedItem.ToString() + "'");
                reportViewer1.LocalReport.DataSources.Clear();
                Microsoft.Reporting.WinForms.ReportDataSource rp = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt);

                reportViewer1.LocalReport.DataSources.Add(rp);
                reportViewer1.RefreshReport();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }


        private void Form_BaoCaoTon_Load(object sender, EventArgs e)
        {
            comboBoxEx1.Text = DateTime.Now.Month + "";
            this.reportViewer1.RefreshReport();
        }

        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadthang();
        }
    }
}
