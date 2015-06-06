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
    public partial class Form_TRACUU : Office2007Form
    {
        public Form_TRACUU()
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
        public void loadbang(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX   ";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_tracuu.DataSource = dt;
            CloseDatabase(sql);
        }
        private void Form_TRACUU_Load(object sender, EventArgs e)
        {
            loadbang(sql);
        }
        public void TimKiem()
        {
            
            //foreach(DataRow dr in dataGridView1.Rows)
            //{
            //    if (dr["BienSo"].ToString() == temp)
            //        dr.Delete();
            //}
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX WHERE BienSo=@BienSo OR TenHieuXe=@TenHieuXe OR TenChuXe=@TenChuXe ";
            command.Parameters.Add("@BienSo",SqlDbType.NChar).Value=Text_bienso.Text;
            command.Parameters.Add("@TenHieuXe", SqlDbType.NChar).Value = Text_hieuxe.Text;
            command.Parameters.Add("@TenChuXe", SqlDbType.NChar).Value = Text_chuxe.Text;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            
            dtGV_tracuu.DataSource = dt;
            CloseDatabase(sql);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGV_tracuu.CurrentRow.Index < dtGV_tracuu.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_tracuu[5, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_bienso.Text = dtGV_tracuu[3, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_hieuxe.Text = dtGV_tracuu[4, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_tienno.Text = dtGV_tracuu[2, dtGV_tracuu.CurrentRow.Index].Value.ToString();
            }
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGV_tracuu.CurrentRow.Index < dtGV_tracuu.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_tracuu[5, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_bienso.Text = dtGV_tracuu[3, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_hieuxe.Text = dtGV_tracuu[4, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_tienno.Text = dtGV_tracuu[2, dtGV_tracuu.CurrentRow.Index].Value.ToString();
            }
          
        }
    }
}
