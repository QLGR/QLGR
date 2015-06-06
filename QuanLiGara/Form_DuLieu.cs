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
    public partial class Form_DuLieu : Office2007Form
    {
        public Form_DuLieu()
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
        public void loadvattu(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "Select * FROm VATTU";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_vattu.DataSource = dt;
            CloseDatabase(sql);
        }
        public void loadtiencong(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "Select * FROm TIENCONG";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_tiencong.DataSource = dt;
            CloseDatabase(sql);
        }
        public void loadhieuxe(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "Select * FROm HIEUXE";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_hieuxe.DataSource = dt;
            CloseDatabase(sql);
        }
        public void loadmaxxe(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "Select * FROm THAMSO";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                Text_soxemax.Text = dr["SuaChuaToiDa"].ToString();
            }
            CloseDatabase(sql);
        }
        private void Form_DuLieu_Load(object sender, EventArgs e)
        {
            loadvattu(sql);
            loadtiencong(sql);
            loadhieuxe(sql);
            loadmaxxe(sql);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM VATTU";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_vattu.CurrentRow.Index < dtGV_vattu.RowCount - 1)
            {
                Text_maVT.Text = dtGV_vattu[0, dtGV_vattu.CurrentRow.Index].Value.ToString();
                Text_tenVT.Text = dtGV_vattu[1, dtGV_vattu.CurrentRow.Index].Value.ToString();
                Text_dongia.Text = dtGV_vattu[2, dtGV_vattu.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM TIENCONG";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_tiencong.CurrentRow.Index < dtGV_tiencong.RowCount - 1)
            {
                Text_matiencong.Text = dtGV_tiencong[0, dtGV_tiencong.CurrentRow.Index].Value.ToString();
                Text_tentiencong.Text = dtGV_tiencong[1, dtGV_tiencong.CurrentRow.Index].Value.ToString();
                Text_tiencong.Text = dtGV_tiencong[2, dtGV_tiencong.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HIEUXE";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_hieuxe.CurrentRow.Index < dtGV_hieuxe.RowCount - 1)
            {
                Text_mahieuxe.Text = dtGV_hieuxe[0, dtGV_hieuxe.CurrentRow.Index].Value.ToString();
                Text_tenhieuxe.Text = dtGV_hieuxe[1, dtGV_hieuxe.CurrentRow.Index].Value.ToString();
            }

            CloseDatabase(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();

                command.CommandText = "Insert INTO VATTU (MaVatTu,TenVatTu,DonGia,SoLuong) VALUES (@MaVatTu,@TenVatTu,@DonGia,@SoLuong)";
                command.Parameters.Add("@MaVatTu", SqlDbType.NChar).Value = Text_maVT.Text;
                command.Parameters.Add("@TenVatTu", SqlDbType.NChar).Value = Text_tenVT.Text;
                command.Parameters.Add("@DonGia", SqlDbType.Money).Value = double.Parse(Text_dongia.Text);
                command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = 100;
               

                command.ExecuteNonQuery();
                CloseDatabase(sql);



            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }

            loadvattu(sql);
            dtGV_vattu.Update();
            dtGV_vattu.Refresh();
            CloseDatabase(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "UPDATE VATTU SET TenVatTu=@TenVatTu,DonGia=@DonGia WHERE MaVatTu=@MaVatTu";
                command.Parameters.Add("@MaVatTu", SqlDbType.VarChar).Value = Text_maVT.Text;
                command.Parameters.Add("@TenVatTu", SqlDbType.NChar).Value =Text_tenVT.Text ;
                command.Parameters.Add("@DonGia", SqlDbType.Money).Value = Text_dongia.Text;
                command.ExecuteNonQuery();
                CloseDatabase(sql);               
                loadvattu(sql);
                dtGV_vattu.Update();
                dtGV_vattu.Refresh();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "DELETE FROM VATTU WHERE MaVatTu=@MaVatTu";
                command.Parameters.Add("@MaVatTu", SqlDbType.NChar).Value = Text_maVT.Text;
                command.ExecuteNonQuery();

                



            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
            CloseDatabase(sql);
            loadvattu(sql);
            dtGV_vattu.Update();
            dtGV_vattu.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();

                command.CommandText = "Insert INTO TIENCONG (MaTienCong,TenCongViec,TienCong) VALUES (@MaTienCong,@TenCongViec,@TienCong)";
                command.Parameters.Add("@MaTienCong", SqlDbType.NChar).Value = Text_matiencong.Text;
                command.Parameters.Add("@TenCongViec", SqlDbType.NChar).Value = Text_tentiencong.Text;
                command.Parameters.Add("@TienCong", SqlDbType.Money).Value = double.Parse(Text_tiencong.Text);
              

                command.ExecuteNonQuery();
                CloseDatabase(sql);



            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }

            loadtiencong(sql);
            dtGV_tiencong.Update();
            dtGV_tiencong.Refresh();
            CloseDatabase(sql);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "UPDATE TIENCONG SET TenCongViec=@TenCongViec,TienCong=@TienCong WHERE MaTienCong=@MaTienCong";
                command.Parameters.Add("@MaTienCong", SqlDbType.NChar).Value = Text_matiencong.Text;
                command.Parameters.Add("@TenCongViec", SqlDbType.NChar).Value = Text_tentiencong.Text;
                command.Parameters.Add("@TienCong", SqlDbType.Money).Value = double.Parse(Text_tiencong.Text);
                command.ExecuteNonQuery();
                CloseDatabase(sql);
                loadtiencong(sql);
                dtGV_tiencong.Update();
                dtGV_tiencong.Refresh();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "DELETE FROM TIENCONG WHERE MaTienCong=@MaTienCong";
                command.Parameters.Add("@MaTienCong", SqlDbType.NChar).Value = Text_matiencong.Text;
                command.ExecuteNonQuery();





            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
            CloseDatabase(sql);
            loadtiencong(sql);
            dtGV_tiencong.Update();
            dtGV_tiencong.Refresh();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();

                command.CommandText = "Insert INTO HIEUXE (MaHX,TenHieuXe) VALUES (@MaHX,@TenHieuXe)";
                command.Parameters.Add("@MaHX", SqlDbType.NChar).Value = Text_mahieuxe.Text;
                command.Parameters.Add("@TenHieuXe", SqlDbType.NChar).Value = Text_tenhieuxe.Text;            
                command.ExecuteNonQuery();
                CloseDatabase(sql);
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }

            loadhieuxe(sql);
            dtGV_hieuxe.Update();
            dtGV_hieuxe.Refresh();
            CloseDatabase(sql);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "UPDATE HIEUXE SET MaHX=@MaHX,TenHieuXe=@TenHieuXe WHERE MaHX=@MaHX";
                command.Parameters.Add("@MaHX", SqlDbType.NChar).Value = Text_mahieuxe.Text;
                command.Parameters.Add("@TenHieuXe", SqlDbType.NChar).Value = Text_tenhieuxe.Text;            
                command.ExecuteNonQuery();
                CloseDatabase(sql);
                loadhieuxe(sql);
                dtGV_hieuxe.Update();
                dtGV_hieuxe.Refresh();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "DELETE FROM HIEUXE WHERE MaHX=@MaHX";
                command.Parameters.Add("@MaHX", SqlDbType.NChar).Value = Text_mahieuxe.Text;
                command.ExecuteNonQuery();





            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
            CloseDatabase(sql);
            loadhieuxe(sql);
            dtGV_hieuxe.Update();
            dtGV_hieuxe.Refresh();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "UPDATE THAMSO SET SuaChuaToiDa=@SuaChuaToiDa";
                command.Parameters.Add("@SuaChuaToiDa", SqlDbType.NChar).Value = Text_soxemax.Text;
              
                command.ExecuteNonQuery();
                CloseDatabase(sql);
                loadmaxxe(sql);
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }
    }
}
