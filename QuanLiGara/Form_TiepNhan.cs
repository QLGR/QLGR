
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
using QuanLiGara.sql;
namespace QuanLiGara
{
    public partial class Form_TiepNhan : Office2007Form
    {

        SqlConnection sql = new SqlConnection();
        Connection db = new Connection();
        tiepnhansql tnsql = new tiepnhansql();
        int choose = 0;
        public Form_TiepNhan()
        {
            InitializeComponent();
        }
        public tiepnhan getData()
        {
            tiepnhan tn = new tiepnhan();
            tn.Email = Text_email.Text;
            tn.MaHSSC = maHSSC.Text;
            tn.TenChuXe = Text_chuxe.Text;
            tn.BienSo = Text_bienso.Text;
            tn.MaHieuXe = hieuxe.Text;
            tn.DiaChi = Text_diachi.Text;
            tn.DienThoai = Text_dienthoai.Text;
            tn.NgayTiepNhan = DateTime.Parse(Date_ngaytiepnhan.Text);
            return tn;
        }
        public int SuaChuaToiDa(SqlConnection sql)
        {

            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM THAMSO");

            foreach (DataRow dr in dt.Rows)
            {
                int max = Int32.Parse(dr["SuaChuaToiDa"].ToString());
                return max;

            }

            return 0;

        }

        public void loadbang(SqlConnection sql)
        {

            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");
            dtGV_danhsachTN.DataSource = dt;


        }
        public void loadhieuxe(SqlConnection sql)
        {


            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HIEUXE");
            foreach (DataRow dr in dt.Rows)
            {
                cbBox_hieuxe.Items.Add(dr["TenHieuXe"].ToString());
            }

        }
        public bool Check(SqlConnection sql, String date)
        {
            int count = 0;


            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");

            foreach (DataRow dr in dt.Rows)
            {

                if (dr["NgayTiepNhan"].ToString() == date + " 12:00:00 AM")
                {

                    count++;
                }
            }

            if (SuaChuaToiDa(sql) <= count)
                return false;
            else
            {
                return true;
            }

        }
        public bool kiemtra(SqlConnection sql, string mhss)
        {
            int check = 0;


            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM PHIEUSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MaHSSC"].ToString() == mhss)
                    check = 1;

            }

            

            DataTable dt1 = new DataTable();
            dt1 = db.getDS("SELECT * FROM PHIEUTHUTIEN");
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["MaHSSC"].ToString() == mhss)
                    check = 1;

            }

            if (check == 0)
                return true;
            return false;
        }


        public void Them(SqlConnection sql)
        {



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
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            switch(choose)
            {
                case 1:
                    try
                    {
                        if (Date_ngaytiepnhan.Value > System.DateTime.Now)
                        {
                            MessageBox.Show("Ngày tiếp nhận không được lớn hơn ngày hiện tại");
                            return;
                        }
                        else
                        {

                            if (Check(sql, Date_ngaytiepnhan.Value.ToShortDateString().ToString()) == false)
                            {
                                MessageBox.Show("Đã tiếp nhận sửa chữa đủ xe vào ngày " + Date_ngaytiepnhan.Text);
                                return;
                            }
                            else
                            {
                                try
                                {
                                    if (checkBienso(Text_bienso.Text))
                                    {
                                        if (tnsql.ThemTN(getData()))
                                        {
                                            tnsql.ThemDSX(getData());
                                            MessageBox.Show("Đã thêm phiếu sửa chữa cho xe " + hieuxe.Text + " - Bien so " + Text_bienso.Text);
                                        }
                                    }
                                    else
                                        MessageBox.Show("Bien so " + Text_bienso.Text + " đã tồn tại trong hồ sơ.");

                                }
                                catch
                                { MessageBox.Show("Không thể thêm hồ sơ sử chữa. Yêu cầu kiểm tra lại thông tin!"); }
                            }
                        }
                    }
                    catch
                    {

                        MessageBox.Show("Không thể thêm hồ sơ!");
                    }
                    break;
                case 2:
                    try
                    {
                        if(tnsql.SuaTN(getData()))
                        {
                            
                            MessageBox.Show("Đã cập nhật hờ sơ của xe mang biển số " + Text_bienso.Text);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Không thể cập nhật hồ sơ sửa chữa!");
                    }
                    break;
            }
            loadbang(sql);
            dtGV_danhsachTN.Update();
            dtGV_danhsachTN.Refresh();
            SetEnable(false);
        }

        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa hồ sơ này. \nNó có thể xóa tất cả phiếu thu tiền và phiều sửa chữa có liên quan!", "Xác nhận xóa hồ sơ.", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (tnsql.XoaTN(maHSSC.Text))
                        MessageBox.Show("Đã xóa phiếu sửa chữa cho xe " + hieuxe.Text + " - Bien so " + Text_bienso.Text);
                    else
                        MessageBox.Show("Không thể xóa hồ sơ sửa chữa do chưa thanh toán hoặc vẫn đang sửa chữa!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa xe " + Text_bienso.Text + " vì vẫn còn phiếu sữa chữa hoặc phiếu thu tiền của xe này đã được lập");
            }



            loadbang(sql);
            dtGV_danhsachTN.Update();
            dtGV_danhsachTN.Refresh();
        }

        

        private void hieuxe_TextChanged(object sender, EventArgs e)
        {
            SqlConnection _sql = new SqlConnection();
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


        }

        private void Sua_Click(object sender, EventArgs e)
        {
            choose = 2;
            SetEnable(true);
        }

        

        private void ngaytiepnhan_ValueChanged(object sender, EventArgs e)
        {


        }

        private void HieuXe_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); 
            dt = db.getDS("SELECT * FROM HIEUXE");
            
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenHieuXe"].ToString() == cbBox_hieuxe.Text)
                    hieuxe.Text = dr["MaHX"].ToString();

            }

        }

        private void dtGV_danhsachTN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            maHSSC.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["MaHSSC"].Value.ToString();
            Text_chuxe.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["TenChuXe"].Value.ToString();
            Text_bienso.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["Bienso"].Value.ToString();
            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HIEUXE");
            foreach (DataRow dr in dt.Rows)
            {
                if (dtGV_danhsachTN.Rows[RowIndex].Cells["MaHX"].Value.ToString() == dr["MaHX"].ToString())
                    cbBox_hieuxe.Text = dr["TenHieuXe"].ToString();
            }
            Text_diachi.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["DiaChi"].Value.ToString();
            Text_dienthoai.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["DienThoai"].Value.ToString();
            Date_ngaytiepnhan.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["NgayTiepNhan"].Value.ToString();
            Text_email.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["Email"].Value.ToString();
        }

        private bool checkBienso(string bienso)
        {
            DataTable dt2 = new DataTable();
            dt2 = db.getDS("SELECT * FROM HOSOSUACHUA");
            foreach (DataRow dr in dt2.Rows)
            {
                if (dr["MaHSSC"].ToString() == bienso)
                {
                    return false;
                }
            }
            return true;
        }

        private void Them_Click(object sender, EventArgs e)
        {
            choose = 1;
            SetEnable(true);
            Text_chuxe.Text = "";
            Text_bienso.Text = "";
            Text_email.Text = "";
            Text_diachi.Text = "";
            Text_dienthoai.Text ="000";
            maHSSC.Text = tnsql.SearchDaTaGrid();

        }



        private void Huy_Click(object sender, EventArgs e)
        {
            loadbang(sql);
            dtGV_danhsachTN.Update();
            dtGV_danhsachTN.Refresh();
            SetEnable(false);
        }

        public void SetEnable(bool a)
        {
            Text_chuxe.ReadOnly = !a;
            Text_bienso.ReadOnly = !a;
            Text_diachi.ReadOnly = !a;
            Text_email.ReadOnly = !a;
            Text_dienthoai.ReadOnly = !a;
            btnXoa.Enabled = !a;
            btnSua.Enabled = !a;
            btnLuu.Enabled = a;
            btnHuy.Enabled = a;
            btnThem.Enabled = !a;
            dtGV_danhsachTN.Enabled = !a;
        }

        private void Text_dienthoai_TextChanged(object sender, EventArgs e)
        {
            int i;
            try
            {


                if (int.TryParse(Text_dienthoai.Text, out i))
                {
                    if (int.Parse(Text_dienthoai.Text) < 0)
                        MessageBox.Show("Số điện thoại phải là dãy số nguyên dương");
                }
                else
                    if (Text_dienthoai.Text != "")
                    {
                        MessageBox.Show("Số điện thoại phải là số nguyên");
                    }
            }
            catch
            {
                MessageBox.Show("Số điện thoại phải là dãy số nguyên.");
            }
        }
    }
}