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
    public partial class Form_PhieuSuaChua : Office2007Form
    {
        
        Connection db = new Connection();
        PhieuSuaChuasql pscsql = new PhieuSuaChuasql();
        phieusuachua PSC = new phieusuachua();
        dulieu dl = new dulieu();
        int choose = 0;
        int midsoluong;
        string no = "0";


        SqlConnection sql = new SqlConnection();
        public Form_PhieuSuaChua()
        {
            
            InitializeComponent();
            SetEnable(false);
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void loadbang(SqlConnection sql)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,VATTU.DonGia,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong");

            dtGV_danhsachSuaChua.DataSource = dt;


        }
        public void loadbienso(SqlConnection sql)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                cbBox_bienso.Items.Add(dr["BienSo"].ToString());
            }


        }
        public void loadvattu(SqlConnection sql)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU");
            foreach (DataRow dr in dt.Rows)
            {
                cbBoc_vattu.Items.Add(dr["TenVatTu"].ToString());
            }

        }
        public void loadtiencong(SqlConnection sql)
        {

            DataTable dt = new DataTable();
            dt = db.getDS("Select * from TIENCONG");
            foreach (DataRow dr in dt.Rows)
            {
                cbBox_tiencong.Items.Add(dr["TenCongViec"].ToString());
            }

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
            DataTable dt = new DataTable();
            dt = db.getDS("select * from HOSOSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["BienSo"].ToString() == cbBox_bienso.Text)
                    return dr["MaHSSC"].ToString();

            }


            return "";
        }
  
        public string bienso(SqlConnection sql, String MaHSSC)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("select * from HOSOSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MaHSSC"].ToString() == MaHSSC)
                    return dr["BienSo"].ToString();

            }

            return "";
        }
        public string mavt(SqlConnection sql, String ten)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU where TenVatTu like N'"+ten+"'");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["MaVatTu"].ToString();
            else
                return "";
        }
        public string matc(SqlConnection sql, String ten)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from TIENCONG");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenCongViec"].ToString() == ten)
                    return dr["MaTienCong"].ToString();

            }


            return "";
        }
        public double tienno(SqlConnection sql, string mahssc)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from DANHSACHXE");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MaHSSC"].ToString() == mahssc)
                    return Double.Parse(dr["TienNo"].ToString());
            }


            return 0;
        }
        public string loadngaytiepnhan(SqlConnection sql, string xe)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from HOSOSUACHUA");

            foreach (DataRow dr in dt.Rows)
            {
                if (dr["BienSo"].ToString() == xe)
                    return dr["NgayTiepNhan"].ToString();
            }


            return "";
        }


        public PhieuSuaChuasql GetData()
        {
            PhieuSuaChuasql sql1 = new PhieuSuaChuasql();
            sql1.MaPSC = tbxMaPhieu.Text;
            sql1.NoiDung = Text_noidung.Text;
            sql1.MaVatTu = mavt(sql, cbBoc_vattu.Text);
            sql1.SoLuong = Text_soluong.Text;
            sql1.MaTienCong = matc(sql, cbBox_tiencong.Text);
            sql1.ThanhTien = Text_thanhtien.Text;
            sql1.MaHSSC = mahssc(sql, cbBox_bienso.Text);
            sql1.NgaySuaChua = DateTime.Parse(Date_ngaysuachua.Text);
            return sql1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            choose = 0;            
            foreach (Control tb in this.groupPanel1.Controls)
            {
                if ((tb is ComboBox || tb is TextBox) && tb.Text == "")
                {
                    MessageBox.Show("Dữ liệu nhập không đầy đủ yêu cầu nhập lại!");
                    return;
                }
            }
            try
            {
                if (PSC.Sua(GetData()))
                {
                    MessageBox.Show("Cập Nhật phiếu sửa chữa thành công!");
                    db.getDS("update HOSOSUACHUA set TongCong = '" + PSC.Sum(mahssc(sql, cbBox_bienso.Text)) + "' where BienSo = '" + cbBox_bienso.Text + "'");
                }
                else
                    if (PSC.Them(GetData()))
                    {

                        db.getDS("update HOSOSUACHUA set TongCong = '" + PSC.Sum(mahssc(sql, cbBox_bienso.Text)) + "' where BienSo = '" + cbBox_bienso.Text + "'");
                        MessageBox.Show("Lập phiếu sửa chữa thành công!");
                    }
                UpdateSoLuong(choose,0);
                loadbang(sql);
                dtGV_danhsachSuaChua.Refresh();
                SetEnable(false);

            }
            catch { MessageBox.Show("Coi Lại Dữ Liệu Đã Nhập!"); }

        }
        private void vattu_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("select * from VATTU");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenVatTu"].ToString() == cbBoc_vattu.SelectedItem.ToString())
                {
                    double don = double.Parse(dr["DonGia"].ToString());
                    if(don != 0)
                        Text_dongia.Text = don.ToString("#,###,###.##");
                    else
                        Text_dongia.Text = don.ToString();
                }
            }


            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                if(sum != 0)
                    Text_thanhtien.Text = sum.ToString("#,###,###.##");
                else
                    Text_thanhtien.Text = sum.ToString();
            }
        }

        

        private void soluong_TextChanged(object sender, EventArgs e)
        {
            int i;
            string oldsoluong = Text_soluong.Text;
            if ((Text_dongia.Text != "") && Text_soluong.Text != "" && (Text_tiencong.Text != ""))
            {
                
                
                if (int.TryParse(Text_soluong.Text, out i) && int.Parse(Text_soluong.Text) > -1)
                {   
                    string temp = PSC.SLVatTu(mavt(sql,cbBoc_vattu.Text));
                    if (int.Parse(Text_soluong.Text) > int.Parse(temp) && choose != 0)
                    {
                        if (choose == 2 && (int.Parse(Text_soluong.Text) - int.Parse(oldsoluong) > int.Parse(temp)))
                        {
                            MessageBox.Show("Sồ lượng phụ tùng không được vượt quá số lượng vật tư còn trong kho.");
                            Text_soluong.Text = (int.Parse(oldsoluong) + int.Parse(temp)).ToString();
                            return;
                        }
                        MessageBox.Show("Sồ lượng phụ tùng không được vượt quá số lượng vật tư còn trong kho.");
                        Text_soluong.Text = temp;
                        return;
                    }
                        
                    double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                    if(sum != 0)
                        Text_thanhtien.Text = sum.ToString("#,###,###.##");
                    else
                        Text_thanhtien.Text = sum.ToString();
                    
                }
                else
                    MessageBox.Show("Số Lượng phải là số nguyên lớn hơn 0");
            }
            else
                if (Text_soluong.Text != "")
                    MessageBox.Show("Số Lượng phải là số nguyên lớn hơn 0");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string hssc = mahssc(sql, cbBox_bienso.Text);
            string postdelete = Text_soluong.Text;
            try
            {
                DialogResult dr = MessageBox.Show("Bạn muốn xóa phiếu sửa chữa náy!","Xác Nhận",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (PSC.Xoa(tbxMaPhieu.Text))
                    {
                        MessageBox.Show("Đã xóa thành công");

                        no = (tienno(sql, cbBox_bienso.Text) - double.Parse(no)).ToString();
                        db.getDS("update HOSOSUACHUA set TongCong = '" + PSC.Sum(cbBox_bienso.Text) + "' where BienSo = '" + cbBox_bienso.Text + "'");
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa. Vui lòng kiểm tra lại.");
                    }

                }

            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể xóa phiếu sửa chữa!");
            }
            loadbang(sql);
            dtGV_danhsachSuaChua.Update();
            dtGV_danhsachSuaChua.Refresh();
        }




        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int RowIndex = e.RowIndex;
            tbxMaPhieu.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["MaPhieuSC"].Value.ToString();
            Text_dongia.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["DonGia"].Value.ToString();
            cbBoc_vattu.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["TenVatTu"].Value.ToString();
            cbBox_tiencong.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["TenCongViec"].Value.ToString();
            Text_soluong.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["SoLuong"].Value.ToString();
            no = Text_thanhtien.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["ThanhTien"].Value.ToString();
            Text_tiencong.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["TienCong"].Value.ToString();
            cbBox_bienso.Text = bienso(sql,dtGV_danhsachSuaChua.Rows[RowIndex].Cells["MaHSSC"].Value.ToString());
            Text_noidung.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["NoiDung"].Value.ToString();
        }


        private void vattu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenVatTu"].ToString() == cbBoc_vattu.SelectedItem.ToString())
                {
                    double don = double.Parse(dr["DonGia"].ToString());
                    if (don != 0)
                    {

                        Text_soluong.ReadOnly = false;
                        Text_dongia.Text = don.ToString("#,###,###.##");
                    }
                    else
                    {
                        Text_soluong.Text = "0";
                        Text_soluong.ReadOnly = true;
                        Text_dongia.Text = don.ToString();
                    }
                }
            }


            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                if (sum != 0)
                {
                    Text_thanhtien.Text = sum.ToString("#,###,###.##");
                }
                else
                {
                   
                    Text_thanhtien.Text = sum.ToString();
                }
            }
        }

        private void tiencong_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM TIENCONG");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenCongViec"].ToString() == cbBox_tiencong.SelectedItem.ToString())
                {
                    double tien = double.Parse(dr["TienCong"].ToString());
                    if(tien !=0)
                        Text_tiencong.Text = tien.ToString("#,###,###.##");
                    else
                    {
                        Text_tiencong.Text = "0";
                    }
                }
            }

            if ((Text_dongia.Text != "") && (Text_soluong.Text != "") && (Text_tiencong.Text != ""))
            {
                double sum = (double.Parse(Text_dongia.Text) * double.Parse(Text_soluong.Text) + double.Parse(Text_tiencong.Text));
                if (sum != 0)
                {
                    Text_thanhtien.Text = sum.ToString("#,###,###.##");
                }
                else
                {
                    Text_thanhtien.Text = sum.ToString();
                }
            }
        }


        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            Text_dongia.Text = "0";
            Text_soluong.Text = "0";
            Text_thanhtien.Text = "0";
            Text_tiencong.Text = "0";
            Text_noidung.Text = "";
            cbBoc_vattu.SelectedIndex = 0;
            cbBox_tiencong.SelectedItem = 0;
            tbxMaPhieu.Text = PSC.SearchDaTaGrid();
            choose = 1;

        }


        public void SetEnable(bool a)
        {
            Text_noidung.ReadOnly = !a;
            Text_soluong.ReadOnly = !a;
            btnXoa.Enabled = !a;
            btnSua.Enabled = !a;
            btnLuu.Enabled = a;
            btnHuy.Enabled = a;
            btnThem.Enabled = !a;
            dtGV_danhsachSuaChua.Enabled = !a;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            choose = 2;
            midsoluong = int.Parse(Text_soluong.Text);
            GetData();
            SetEnable(true);

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            choose = 0;
            SetEnable(false);
        }

        public void UpdateSoLuong(int loai,int postdelete = 0)
        {
            DataTable dt, dt1 = new DataTable();
            string mavattu = PSC.MaVatTu(cbBoc_vattu.Text);
            int  soluong,oldsoluong;
            soluong = int.Parse(PSC.SLVatTuPN(tbxMaPhieu.Text));
            oldsoluong = int.Parse(PSC.SLVatTu(mavattu));

            switch (loai)
            {
                case 1:
                    oldsoluong -= soluong;
                    dl.SuaVT(mavattu, oldsoluong.ToString());
                    break;
                case 2:
                    oldsoluong += midsoluong;
                    oldsoluong -= soluong;
                    dl.SuaVT(mavattu, oldsoluong.ToString());
                    break;
            }
        }
    }
}
