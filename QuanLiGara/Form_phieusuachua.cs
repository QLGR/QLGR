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
    public partial class Form_PhieuSuaChua : Office2007Form
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

        SqlConnection sql = new SqlConnection();
        public Form_PhieuSuaChua()
        {
            InitializeComponent();
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
        public void CloseDatabase(SqlConnection sql)
        {
            sql.Close();
        }
        public void loadbang(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,VATTU.DonGia,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_danhsachSuaChua.DataSource = dt;
            CloseDatabase(sql);

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
                cbBox_bienso.Items.Add(dr["BienSo"].ToString());
            }
            CloseDatabase(sql);


        }
        public void loadvattu(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM VATTU";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbBoc_vattu.Items.Add(dr["TenVatTu"].ToString());
            }
            CloseDatabase(sql);


        }
        public void loadtiencong(SqlConnection sql)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM TIENCONG";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbBox_tiencong.Items.Add(dr["TenCongViec"].ToString());
            }
            CloseDatabase(sql);


        }
        private void Form_PhieuSuaChua_Load(object sender, EventArgs e)
        {
            loadbang(sql);
            loadbienso(sql);
            loadtiencong(sql);
            loadvattu(sql);
        }
        public string mahssc(SqlConnection sql, String bienso)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM HOSOSUACHUA";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseDatabase(sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["BienSo"].ToString() == bienso)
                    return dr["MaHSSC"].ToString();

            }


            return "";
        }
        public string mavt(SqlConnection sql, String ten)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM VATTU";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseDatabase(sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenVatTu"].ToString() == ten)
                    return dr["MaVatTu"].ToString();

            }


            return "";
        }
        public string matc(SqlConnection sql, String ten)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM TIENCONG";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            CloseDatabase(sql);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenCongViec"].ToString() == ten)
                    return dr["MaTienCong"].ToString();

            }


            return "";
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
        public string loadngaytiepnhan(SqlConnection sql, string xe)
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
                if (dr["BienSo"].ToString() == xe)
                    return dr["NgayTiepNhan"].ToString();
            }


            return "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string mhssc = mahssc(sql, cbBox_bienso.Text);
            MessageBox.Show(loadngaytiepnhan(sql, cbBox_bienso.Text));
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                if (Date_ngaysuachua.Value < DateTime.Parse(loadngaytiepnhan(sql, cbBox_bienso.Text)))
                {
                    MessageBox.Show("Ngày sữa chữa không thể trước ngày tiếp nhận xe");
                }
                else
                {
                    command.CommandText = "Insert INTO PHIEUSUACHUA (MaPhieuSC,NoiDung,MaVatTu,SoLuong,MaTienCong,ThanhTien,MaHSSC,NgaySuaChua) VALUES (@MaPhieuSC,@NoiDung,@MaVatTu,@SoLuong,@MaTienCong,@ThanhTien,@MaHSSC,@NgaySuaChua)";
                    command.Parameters.Add("@MaPhieuSC", SqlDbType.NChar).Value = Text_soluong.Text + mavt(sql, cbBoc_vattu.Text);
                    command.Parameters.Add("@NoiDung", SqlDbType.NChar).Value = Text_noidung.Text;
                    command.Parameters.Add("@MaVatTu", SqlDbType.NChar).Value = mavt(sql, cbBoc_vattu.Text);
                    command.Parameters.Add("@SoLuong", SqlDbType.Int).Value = Text_soluong.Text;
                    command.Parameters.Add("@MaTienCong", SqlDbType.VarChar).Value = matc(sql, cbBox_tiencong.Text);
                    command.Parameters.Add("@ThanhTien", SqlDbType.Money).Value = Text_thanhtien.Text;
                    command.Parameters.Add("@MaHSSC", SqlDbType.VarChar).Value = mhssc;
                    DateTime date = DateTime.Parse(Date_ngaysuachua.Text);
                    command.Parameters.Add("@NgaySuaChua", SqlDbType.Date).Value = date;

                    SqlCommand command1 = sql.CreateCommand();
                    command1.CommandText = "Update DANHSACHXE SET TienNo=@TienNo WHERE MaHSSC=@MaHSSC";
                    double sum = 0;
                    sum = Double.Parse(Text_thanhtien.Text) + tienno(sql, mhssc);
                    command1.Parameters.Add("@TienNo", SqlDbType.Money).Value = sum;
                    command1.Parameters.Add("@MaHSSC", SqlDbType.VarChar).Value = mhssc;
                    command1.ExecuteNonQuery();
                    command.ExecuteNonQuery();
                    CloseDatabase(sql);

                }

            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }

            loadbang(sql);
            dtGV_danhsachSuaChua.Update();
            dtGV_danhsachSuaChua.Refresh();
            CloseDatabase(sql);
        }

        private void vattu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM VATTU";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenVatTu"].ToString() == cbBoc_vattu.SelectedItem.ToString())
                {
                    double don = double.Parse(dr["DonGia"].ToString());
                    Text_dongia.Text = don.ToString("#,###,###.##");
                }
            }
            CloseDatabase(sql);

            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                Text_thanhtien.Text = sum.ToString("#,###,###.##");
            }
        }

        private void tiencong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM TIENCONG";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenCongViec"].ToString() == cbBox_tiencong.SelectedItem.ToString())
                {
                    double tien = double.Parse(dr["TienCong"].ToString());
                    Text_tiencong.Text = tien.ToString("#,###,###.##");
                }
            }
            CloseDatabase(sql);

            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                Text_thanhtien.Text = sum.ToString("#,###,###.##");
            }
        }

        private void txttiencong_TextChanged(object sender, EventArgs e)
        {

        }

        private void dongia_TextChanged(object sender, EventArgs e)
        {

        }

        private void soluong_TextChanged(object sender, EventArgs e)
        {
            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                Text_thanhtien.Text = sum.ToString("#,###,###.##");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hssc = mahssc(sql, cbBox_bienso.Text);
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "DELETE FROM PHIEUSUACHUA WHERE MaPhieuSC=@BienSo";
                command.Parameters.Add("@BienSo", SqlDbType.NChar).Value = dtGV_danhsachSuaChua[0, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                command.ExecuteNonQuery();
                SqlCommand command1 = sql.CreateCommand();
                command1.CommandText = "Update DANHSACHXE SET TienNo=@TienNo WHERE MaHSSC=@MaHSSC";
                double sum;
                sum = tienno(sql, dtGV_danhsachSuaChua[6, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString()) - Double.Parse(Text_thanhtien.Text);
                command1.Parameters.Add("@TienNo", SqlDbType.Money).Value = sum;
                command1.Parameters.Add("@MaHSSC", SqlDbType.VarChar).Value = dtGV_danhsachSuaChua[6, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                command1.ExecuteNonQuery();
                MessageBox.Show("Đã xóa thành công");



            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
            CloseDatabase(sql);
            loadbang(sql);
            dtGV_danhsachSuaChua.Update();
            dtGV_danhsachSuaChua.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            try
            {

                SqlCommand command = sql.CreateCommand();
                command.CommandText = "UPDATE PHIEUSUACHUA SET NoiDung=@NoiDung WHERE MaPhieuSC=@MaPhieuSC";
                command.Parameters.Add("@NoiDung", SqlDbType.VarChar).Value = Text_noidung.Text;
                command.Parameters.Add("@MaPhieuSC", SqlDbType.NChar).Value = dtGV_danhsachSuaChua[0, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                command.ExecuteNonQuery();
                CloseDatabase(sql);
                MessageBox.Show("Đã cập nhật phiếu sửa chữa cho xe - Bien so " + cbBox_bienso.Text);
                loadbang(sql);
                dtGV_danhsachSuaChua.Update();
                dtGV_danhsachSuaChua.Refresh();
            }
            catch (Exception c)
            {
                MessageBox.Show(c.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,VATTU.DonGia,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong WHERE MaHSSC=@MaHSSC ";
            command.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = mahssc(sql, cbBox_bienso.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_danhsachSuaChua.DataSource = dt;
            CloseDatabase(sql);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,VATTU.DonGia,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_danhsachSuaChua.CurrentRow.Index < dtGV_danhsachSuaChua.RowCount - 1)
            {
                Text_noidung.Text = dtGV_danhsachSuaChua[1, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_dongia.Text = dtGV_danhsachSuaChua[9, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                cbBoc_vattu.Text = dtGV_danhsachSuaChua[8, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                cbBox_tiencong.Text = dtGV_danhsachSuaChua[10, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_soluong.Text = dtGV_danhsachSuaChua[3, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_thanhtien.Text = dtGV_danhsachSuaChua[5, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_tiencong.Text = dtGV_danhsachSuaChua[11, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,VATTU.DonGia,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dtGV_danhsachSuaChua.CurrentRow.Index < dtGV_danhsachSuaChua.RowCount - 1)
            {
                Text_noidung.Text = dtGV_danhsachSuaChua[1, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_dongia.Text = dtGV_danhsachSuaChua[9, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                cbBoc_vattu.Text = dtGV_danhsachSuaChua[8, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                cbBox_tiencong.Text = dtGV_danhsachSuaChua[10, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_soluong.Text = dtGV_danhsachSuaChua[3, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_thanhtien.Text = dtGV_danhsachSuaChua[5, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
                Text_tiencong.Text = dtGV_danhsachSuaChua[11, dtGV_danhsachSuaChua.CurrentRow.Index].Value.ToString();
            }
            CloseDatabase(sql);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,VATTU.DonGia,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong WHERE MaHSSC=@MaHSSC ";
            command.Parameters.Add("@MaHSSC", SqlDbType.NChar).Value = mahssc(sql, cbBox_bienso.Text);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dtGV_danhsachSuaChua.DataSource = dt;
            CloseDatabase(sql);
        }

        private void vattu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM VATTU";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenVatTu"].ToString() == cbBoc_vattu.SelectedItem.ToString())
                {
                    double don = double.Parse(dr["DonGia"].ToString());
                    Text_dongia.Text = don.ToString("#,###,###.##");
                }
            }
            CloseDatabase(sql);

            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                Text_thanhtien.Text = sum.ToString("#,###,###.##");
            }
        }

        private void tiencong_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ConnectDatabase(sql);
            SqlCommand command = sql.CreateCommand();
            command.CommandText = "SELECT * FROM TIENCONG";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenCongViec"].ToString() == cbBox_tiencong.SelectedItem.ToString())
                {
                    double tien = double.Parse(dr["TienCong"].ToString());
                    Text_tiencong.Text = tien.ToString("#,###,###.##");
                }
            }
            CloseDatabase(sql);

            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                Text_thanhtien.Text = sum.ToString("#,###,###.##");
            }
        }

        private void soluong_TextChanged_1(object sender, EventArgs e)
        {
            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                Text_thanhtien.Text = sum.ToString("#,###,###.##");
            }
        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }
    }
}
