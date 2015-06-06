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
    public partial class Form_PHIEUTHUTIEN : Office2007Form
    {
        public Form_PHIEUTHUTIEN()
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
        public string hssc;
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
        public void loadbienso(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbB_bienso.Items.Add(dr["BienSo"].ToString());
            }
            CloseDatabase(sql);
        }
        private void Form_PHIEUTHUTIEN_Load(object sender, EventArgs e)
        {
            loadbienso(sql);
            loadbang(sql);
        }

        private void bienso_SelectedIndexChanged(object sender, EventArgs e)
        {

            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (cbB_bienso.Text == dr["BienSo"].ToString())
                {
                    Text_chuxe.Text = dr["TenChuXe"].ToString();
                    Text_dienthoai.Text = dr["DienThoai"].ToString();
                    hssc = dr["MaHSSC"].ToString();
                }
            }
            CloseDatabase(sql);



        }
        public void loadbang(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUTHUTIEN.MaThuTien,HOSOSUACHUA.TenChuXe,HOSOSUACHUA.BienSo,HOSOSUACHUA.DienThoai,PHIEUTHUTIEN.Email,PHIEUTHUTIEN.SoTienThu,PHIEUTHUTIEN.NgayThuTien,HOSOSUACHUA.MaHSSC FROM HOSOSUACHUA JOIN PHIEUTHUTIEN on HOSOSUACHUA.MaHSSC=PHIEUTHUTIEN.MaHSSC";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_phieuthu.DataSource = dt;
            CloseDatabase(sql);
        }
        public double tienno(SqlConnection sql, string mahssc)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM DANHSACHXE";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MaHSSC"].ToString() == mahssc)
                    return Double.Parse(dr["TienNo"].ToString());
            }


            return 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {
                if (Double.Parse(Text_sotienthu.Text) > tienno(sql, hssc))
                {
                    MessageBox.Show("Số tiền thu không được lớn hơn số tiền nợ của xe ");
                }
                else
                {
                    SqlCommand command = sql.CreateCommand();
                    int ma;
                    Random rd = new Random();
                    ma = rd.Next(1, 1000000000);
                    command.CommandText = "Insert INTO PHIEUTHUTIEN (MaThuTien,Email,SoTienThu,MaHSSC,NgayThuTien) VALUES (@MaThuTien,@Email,@SoTienThu,@MaHSSC,@NgayThuTien)";
                    command.Parameters.Add("@MaThuTien", SqlDbType.NChar).Value = ma;
                    command.Parameters.Add("@Email", SqlDbType.NChar).Value = Text_email.Text;
                    command.Parameters.Add("@SoTienThu", SqlDbType.Money).Value = Double.Parse(Text_sotienthu.Text);
                    command.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = hssc;
                    DateTime date = DateTime.Parse(Date_ngaythutien.Text);
                    command.Parameters.Add("@NgayThuTien", SqlDbType.Date).Value = date;

                    SqlCommand command1 = sql.CreateCommand();
                    command1.CommandText = "Update DANHSACHXE SET TienNo=@TienNo WHERE MaHSSC=@MaHSSC";
                    double sum = 0;
                    sum = tienno(sql, hssc) - Double.Parse(Text_sotienthu.Text);
                    command1.Parameters.Add("@TienNo", SqlDbType.Money).Value = sum;
                    command1.Parameters.Add("@MaHSSC", SqlDbType.VarChar).Value = hssc;
                    command1.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                }
                CloseDatabase(sql);



            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }

            loadbang(sql);
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
            CloseDatabase(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
        
            try
            {
                SqlCommand command1 = sql.CreateCommand();
                command1.CommandText = "DELETE FROM PHIEUTHUTIEN WHERE MaThuTien=@MaThuTien";
                command1.Parameters.Add("@MaThuTien", SqlDbType.NChar).Value = dtGV_phieuthu[0, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                command1.ExecuteNonQuery();
                SqlCommand command = sql.CreateCommand();
                command.CommandText = "Update DANHSACHXE SET TienNo=@TienNo WHERE MaHSSC=@MaHSSC";
                double sum = 0;
                sum = tienno(sql, dtGV_phieuthu[7, dtGV_phieuthu.CurrentRow.Index].Value.ToString()) + double.Parse(dtGV_phieuthu[5, dtGV_phieuthu.CurrentRow.Index].Value.ToString());
                command.Parameters.Add("@TienNo", SqlDbType.Money).Value = sum;
                command.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = dtGV_phieuthu[7, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                command.ExecuteNonQuery();




            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
            CloseDatabase(sql);
            loadbang(sql);
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUTHUTIEN.MaThuTien,HOSOSUACHUA.TenChuXe,HOSOSUACHUA.BienSo,HOSOSUACHUA.DienThoai,PHIEUTHUTIEN.Email,PHIEUTHUTIEN.SoTienThu,PHIEUTHUTIEN.NgayThuTien,HOSOSUACHUA.MaHSSC FROM HOSOSUACHUA JOIN PHIEUTHUTIEN on HOSOSUACHUA.MaHSSC=PHIEUTHUTIEN.MaHSSC";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_phieuthu.CurrentRow.Index < dtGV_phieuthu.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_phieuthu[1, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                cbB_bienso.Text = dtGV_phieuthu[2, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                Text_dienthoai.Text = dtGV_phieuthu[3, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                Text_email.Text = dtGV_phieuthu[4, dtGV_phieuthu.CurrentRow.Index].Value.ToString();

                Text_sotienthu.Text = dtGV_phieuthu[5, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUTHUTIEN.MaThuTien,HOSOSUACHUA.TenChuXe,HOSOSUACHUA.BienSo,HOSOSUACHUA.DienThoai,PHIEUTHUTIEN.Email,PHIEUTHUTIEN.SoTienThu,PHIEUTHUTIEN.NgayThuTien,HOSOSUACHUA.MaHSSC FROM HOSOSUACHUA JOIN PHIEUTHUTIEN on HOSOSUACHUA.MaHSSC=PHIEUTHUTIEN.MaHSSC";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_phieuthu.CurrentRow.Index < dtGV_phieuthu.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_phieuthu[1, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                cbB_bienso.Text = dtGV_phieuthu[2, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                Text_dienthoai.Text = dtGV_phieuthu[3, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
                Text_email.Text = dtGV_phieuthu[4, dtGV_phieuthu.CurrentRow.Index].Value.ToString();

                Text_sotienthu.Text = dtGV_phieuthu[5, dtGV_phieuthu.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);
        }

        private void bienso_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (cbB_bienso.Text == dr["BienSo"].ToString())
                {
                    Text_chuxe.Text = dr["TenChuXe"].ToString();
                    Text_dienthoai.Text = dr["DienThoai"].ToString();
                    hssc = dr["MaHSSC"].ToString();
                }
            }
            CloseDatabase(sql);


        }
    }
}
