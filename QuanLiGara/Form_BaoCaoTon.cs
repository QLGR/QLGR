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
                ConnectDatabase(sql);
                SqlCommand cmd = sql.CreateCommand(); ;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Thang", SqlDbType.Int));
                cmd.CommandText = "BaoCaoTon";
                cmd.Parameters["@Thang"].Value = Int32.Parse(Text_thang.Text);
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();


                adapter.Fill(dt);

                dtGV_danhsach.DataSource = dt;

                reportViewer1.LocalReport.DataSources.Clear();
                Microsoft.Reporting.WinForms.ReportDataSource rp = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt);

                reportViewer1.LocalReport.DataSources.Add(rp);
                reportViewer1.RefreshReport();
                CloseDatabase(sql);

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Text_thang.Text != "")

                loadthang(sql);
            else
                MessageBox.Show("Vui lòng nhập tháng cần xem");
        }

        private void Form_BaoCaoTon_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
