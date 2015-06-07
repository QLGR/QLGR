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
    public partial class Form_DoanhSo : Office2007Form
    {
        public Form_DoanhSo()
        {
            InitializeComponent();
        }

        Connection db = new Connection();

        public void loadthang()
        {
            try
            {
                double sum = 0;
                DataTable dt = db.getDS("execute BaoCaoDoanhThu '" + comboBoxEx1.SelectedItem.ToString() + "'");

                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["DoanhSo"].ToString() != "")
                        sum += Double.Parse(dr["DoanhSo"].ToString());
                }
                reportViewer1.LocalReport.DataSources.Clear();
                Microsoft.Reporting.WinForms.ReportDataSource rp = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt);
                Microsoft.Reporting.WinForms.ReportParameter[] parameter = new Microsoft.Reporting.WinForms.ReportParameter[1];

                parameter[0] = new Microsoft.Reporting.WinForms.ReportParameter("Thang");
                parameter[0].Values.Add(comboBoxEx1.SelectedItem.ToString());
                reportViewer1.LocalReport.SetParameters(parameter);
                reportViewer1.LocalReport.DataSources.Add(rp);
                reportViewer1.RefreshReport();
                Text_tongdoanhthu.Text = sum.ToString("#,###,###.##");
            }
            catch (SqlException c)
            {
                MessageBox.Show("Tháng này không có dữ liệu");
            }
        }

        private void Form_DoanhSo_Load(object sender, EventArgs e)
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
