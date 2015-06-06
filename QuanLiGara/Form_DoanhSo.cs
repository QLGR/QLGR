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
        public class INI
        {
            [DllImport("kernel32")]
            private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
            [DllImport("kernel32")]
            private static extern long GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);
            public static string READ(string szFile, string szSection, string szKey)
            {
                StringBuilder tmp = new StringBuilder(255);
                long i = GetPrivateProfileString(szSection, szKey, "", tmp, 255, szFile);
                return tmp.ToString();
            }
            public static void WRITE(string szFile, string szSection, string szKey, string szData)
            {
                WritePrivateProfileString(szSection, szKey, szData, szFile);
            }

        }
        SqlConnection sql = new SqlConnection();
          public void ConnectDatabase(SqlConnection sql)
        {

            string[] lines = File.ReadAllLines("Server.txt");

            string s = lines[0];
            if (sql.State != ConnectionState.Open)
            {
                sql.ConnectionString = "Data Source=" + s + ";Initial Catalog=QLGR;Integrated Security=True";
                sql.Open();
            }
        }
        public void CloseDatabase(SqlConnection sql)
        {
            sql.Close();
        }
        public void loadthang(SqlConnection sql)
        {
            try
            {
                double sum = 0;
                ConnectDatabase(sql);
                SqlCommand cmd = sql.CreateCommand(); ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Int));
                cmd.CommandText = "BaoCaoDoanhThu";
                cmd.Parameters["@Thang"].Value = Int32.Parse(Text_thang.Text);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();


                adapter.Fill(dt);

                dtGV_danhthu.DataSource = dt;
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["DoanhSo"].ToString() != "")
                        sum += Double.Parse(dr["DoanhSo"].ToString());
                }
                reportViewer1.LocalReport.DataSources.Clear();
                Microsoft.Reporting.WinForms.ReportDataSource rp = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt);
                Microsoft.Reporting.WinForms.ReportParameter[] parameter = new Microsoft.Reporting.WinForms.ReportParameter[1];

                parameter[0] = new Microsoft.Reporting.WinForms.ReportParameter("Thang");
                parameter[0].Values.Add(Text_thang.Text);
                reportViewer1.LocalReport.SetParameters(parameter);
                reportViewer1.LocalReport.DataSources.Add(rp);
                reportViewer1.RefreshReport();
                CloseDatabase(sql);
                Text_tongdoanhthu.Text = sum.ToString("#,###,###.##");
            }
            //catch(Exception e)
            //{
            //    MessageBox.Show(e.ToString());
            //}
            catch (SqlException c)
            {
                MessageBox.Show("Tháng này không có dữ liệu");
            }
        }
        private void Form_DoanhSo_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text_thang.Text != "")
                loadthang(sql);
            else
                MessageBox.Show("Vui lòng nhập tháng cần xem");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }
    }
}
