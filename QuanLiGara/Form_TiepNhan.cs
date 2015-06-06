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
    public partial class Form_TiepNhan : Office2007Form
    {
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
        SqlConnection sql = new SqlConnection();
        public Form_TiepNhan()
        {
            InitializeComponent();
        }
     
        public void CloseDatabase(SqlConnection sql)
        {
            sql.Close();
        }
        public int SuaChuaToiDa(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM THAMSO";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int max = Int32.Parse(dr["SuaChuaToiDa"].ToString());
                return max;

            }
            CloseDatabase(sql);
            return 0;

        }

        public void loadbang(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_danhsachTN.DataSource = dt;
            CloseDatabase(sql);

        }
        public void loadhieuxe(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HIEUXE";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbBox_hieuxe.Items.Add(dr["TenHieuXe"].ToString());
            }
            CloseDatabase(sql);
        }
        public bool Check(SqlConnection sql, String date)
        {
            int count = 0;
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {

                if (dr["NgayTiepNhan"].ToString() == date + " 12:00:00 AM")
                {

                    count++;
                }
            }
            CloseDatabase(sql);
            if (SuaChuaToiDa(sql) <= count)
                return false;
            else
            {
                return true;
            }

        }
        public bool kiemtra(SqlConnection sql, string mhss)
        {
            int check =0;
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM PHIEUSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if(dr["MaHSSC"].ToString()== mhss)
                    check=1;
                
            }
            CloseDatabase(sql);
            ConnectDatabase(sql);
            SqlCommand command1 = sql.CreateCommand();
            command1.CommandText = "SELECT * FROM PHIEUTHUTIEN";
            SqlDataAdapter adapter1 = new SqlDataAdapter();
            adapter1.SelectCommand = command1;
            DataTable dt1 = new DataTable();
            adapter1.Fill(dt1);
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["MaHSSC"].ToString() == mhss)
                    check = 1;

            }
            CloseDatabase(sql);
            if (check == 0)
                return true;
            return false;
        }
        public void Them(SqlConnection sql)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                
                command.CommandText = "Insert INTO HOSOSUACHUA (MaHSSC,TenChuXe,BienSo,MaHX,DiaChi,DienThoai,NgayTiepNhan) VALUES (@MaHSSC," + "N'" + Text_chuxe.Text + "',@BienSo,@MaHX,N'" + Text_diachi.Text + "',@DienThoai,@NgayTiepNhan)";
                command.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = Text_bienso.Text;
                command.Parameters.Add("@BienSo", SqlDbType.NChar).Value = Text_bienso.Text;
                command.Parameters.Add("@MaHX", SqlDbType.NChar).Value = hieuxe.Text;
                command.Parameters.Add("@TenChuXe", SqlDbType.VarChar).Value = Text_chuxe.Text;
                command.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = Text_diachi.Text;
                command.Parameters.Add("@DienThoai", SqlDbType.VarChar).Value = Text_dienthoai.Text;
                DateTime date = DateTime.Parse(Date_ngaytiepnhan.Text);
                command.Parameters.Add("@NgayTiepNhan", SqlDbType.Date).Value = date;


                if (Date_ngaytiepnhan.Value > System.DateTime.Now)
                    MessageBox.Show("Ngày tiếp nhận không được lớn hơn ngày hiện tại");
                else
                {

                    if (Check(sql, Date_ngaytiepnhan.Value.ToShortDateString().ToString()) == false)
                        MessageBox.Show("Đã tiếp nhận sửa chữa đủ xe vào ngày " + Date_ngaytiepnhan.Text);
                    else
                    {
                        command.ExecuteNonQuery();
                        SqlCommand command1 = sql.CreateCommand();
                        command1.CommandText = "Insert INTO DANHSACHXE (MaXe,MaHSSC,TienNo) VALUES (@MaXe,@MaHSSC,@TienNo)";
                        command1.Parameters.Add("@MaXe", SqlDbType.NChar).Value = Text_bienso.Text;
                        command1.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = Text_bienso.Text;
                        command1.Parameters.Add("@TienNo", SqlDbType.Money).Value = 0;
                        command1.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm phiếu sửa chữa cho xe " + hieuxe.Text + " - Bien so " + Text_bienso.Text);
                    }
                }



            }
            catch (SqlException e)
            {

                MessageBox.Show("Xe có biển số " + Text_bienso.Text + " đã được thêm vào danh sách");
            }
            CloseDatabase(sql);
            loadbang(sql);
            dtGV_danhsachTN.Update();
            dtGV_danhsachTN.Refresh();

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form_TiepNhan_Load(object sender, EventArgs e)
        {

            loadbang(sql);
            loadhieuxe(sql);
            //MessageBox.Show(SuaChuaToiDa(sql).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Them(sql);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_danhsachTN.CurrentRow.Index < dtGV_danhsachTN.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_danhsachTN[1, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                Text_bienso.Text = dtGV_danhsachTN[2, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                cbBox_hieuxe.Text = dtGV_danhsachTN[3, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                Text_diachi.Text = dtGV_danhsachTN[4, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                Text_dienthoai.Text = dtGV_danhsachTN[5, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                //ngaytiepnhan.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_danhsachTN.CurrentRow.Index < dtGV_danhsachTN.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_danhsachTN[1, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                Text_bienso.Text = dtGV_danhsachTN[2, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                cbBox_hieuxe.Text = dtGV_danhsachTN[3, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                Text_diachi.Text = dtGV_danhsachTN[4, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                Text_dienthoai.Text = dtGV_danhsachTN[5, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                //ngaytiepnhan.Text = dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
       
            try
            {
                if (kiemtra(sql, Text_bienso.Text) == true)
                {
                    ConnectDatabase(sql);
                    SqlCommand command1 = sql.CreateCommand();
                    command1.CommandText = "DELETE FROM DANHSACHXE WHERE MaHSSC=@MaHSSC";
                    command1.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = Text_bienso.Text;
                    command1.ExecuteNonQuery();
                    CloseDatabase(sql);
                }
                ConnectDatabase(sql);
                SqlCommand command = sql.CreateCommand();
                command.CommandText = "DELETE FROM HOSOSUACHUA WHERE BienSo=@BienSo";
                command.Parameters.Add("@BienSo", SqlDbType.NChar).Value = Text_bienso.Text;
                command.ExecuteNonQuery();
                CloseDatabase(sql);
                MessageBox.Show("Đã xóa phiếu sửa chữa cho xe " + hieuxe.Text + " - Bien so " + Text_bienso.Text);



            }
            catch (SqlException c)
            {
               
                MessageBox.Show("Không thể xóa xe " + Text_bienso.Text + " vì vẫn còn phiếu sữa chữa hoặc phiếu thu tiền của xe này đã được lập");
               
               
            }
            
          
            CloseDatabase(sql);
            loadbang(sql);
            dtGV_danhsachTN.Update();
            dtGV_danhsachTN.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "UPDATE HOSOSUACHUA SET TenChuXe=@TenChuXe,BienSo=@BienSo,MaHX=@MaHX,DiaChi=@DiaChi,DienThoai=@DienThoai,NgayTiepNhan=@NgayTiepNhan WHERE MaHSSC=@MaHSSC ";
                command.Parameters.Add("@TenChuXe", SqlDbType.VarChar).Value = Text_chuxe.Text;
                command.Parameters.Add("@BienSo", SqlDbType.NChar).Value = Text_bienso.Text;
                command.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = dtGV_danhsachTN[0, dtGV_danhsachTN.CurrentRow.Index].Value.ToString();
                command.Parameters.Add("@MaHX", SqlDbType.NChar).Value = hieuxe.Text;

                command.Parameters.Add("@DiaChi", SqlDbType.VarChar).Value = Text_diachi.Text;
                command.Parameters.Add("@DienThoai", SqlDbType.VarChar).Value = Text_dienthoai.Text;
                DateTime date = DateTime.Parse(Date_ngaytiepnhan.Text);
                command.Parameters.Add("@NgayTiepNhan", SqlDbType.Date).Value = date;
                command.ExecuteNonQuery();
                CloseDatabase(sql);
                MessageBox.Show("Đã cập nhật phiếu sửa chữa cho xe " + hieuxe.Text + " - Bien so " + Text_bienso.Text);
                loadbang(sql);
                dtGV_danhsachTN.Update();
                dtGV_danhsachTN.Refresh();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void hieuxe_TextChanged(object sender, EventArgs e)
        {
            SqlConnection _sql = new SqlConnection();
            ConnectDatabase(_sql);
            SqlCommand command = _sql.CreateCommand();
            command.CommandText = "SELECT * FROM HIEUXE";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (hieuxe.Text == dr["MaHX"].ToString())
                {
                    cbBox_hieuxe.Text = dr["TenHieuXe"].ToString();
                }
            }
            CloseDatabase(_sql);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Text_chuxe.Text = "";
            Text_bienso.Text = "";
            hieuxe.Text = "";
            Text_diachi.Text = "";
            Date_ngaytiepnhan.Text = "";
            Text_dienthoai.Text = "";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HIEUXE";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenHieuXe"].ToString() == cbBox_hieuxe.Text)
                    hieuxe.Text = dr["MaHX"].ToString();

            }
            CloseDatabase(sql);

        }

        private void ngaytiepnhan_ValueChanged(object sender, EventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HIEUXE";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenHieuXe"].ToString() == cbBox_hieuxe.Text)
                    hieuxe.Text = dr["MaHX"].ToString();

            }
            CloseDatabase(sql);
        }
    }
}