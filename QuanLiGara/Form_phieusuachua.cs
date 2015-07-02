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
        int midsoluong;
        string no = "0";

        public Form_PhieuSuaChua()
        {
            
            InitializeComponent();
            SetEnable(false);
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public int ChenhLech()
        {
            DataTable dt = db.getDS("SELECT * FROM THAMSO");
            return Int32.Parse(dt.Rows[0]["ChenhLech"].ToString());
        }
        public void loadbang()
        {
            DataTable dt = new DataTable();
            dt = db.getDS("SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong");

            dtGV_danhsachSuaChua.DataSource = dt;


        }
        public void loadbienso()
        {
            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                cbBox_bienso.Items.Add(dr["BienSo"].ToString());
            }


        }
        public void loadvattu()
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU");
            foreach (DataRow dr in dt.Rows)
            {
                cbBoc_vattu.Items.Add(dr["TenVatTu"].ToString());
            }

        }
        public void loadtiencong()
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
            loadbang();
            loadbienso();
            loadtiencong();
            loadvattu();
        }
        public string mahssc(String bienso)
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
  
        public string bienso(String MaHSSC)
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
        public string mavt(String ten)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU where TenVatTu like N'"+ten+"'");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["MaVatTu"].ToString();
            else
                return "";
        }
        public string matc(String ten)
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
        public double tienno(string mahssc)
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
        public string loadngaytiepnhan(string xe)
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
            sql1.MaVatTu = mavt(cbBoc_vattu.Text);
            sql1.SoLuong = Text_soluong.Text;
            sql1.MaTienCong = matc(cbBox_tiencong.Text);
            sql1.ThanhTien = Text_thanhtien.Text;
            sql1.MaHSSC = mahssc(cbBox_bienso.Text);
            sql1.NgaySuaChua = DateTime.Parse(Date_ngaysuachua.Text);
            return sql1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (Date_ngaysuachua.Value > System.DateTime.Now)
            {
                MessageBox.Show("Ngày sửa chữa không được lớn hơn ngày hiện tại");
                Date_ngaysuachua.Text = DateTime.Now.ToString();
                return;
            }
            foreach (Control tb in this.groupPanel1.Controls)
            {
                if ((tb is ComboBox || tb is TextBox) && tb.Text == "")
                {
                    MessageBox.Show("Dữ liệu nhập không đầy đủ yêu cầu nhập lại!");
                    return;
                }
            }

            int soluong = int.Parse(PSC.SLVatTuPN(tbxMaPhieu.Text)) - int.Parse(Text_soluong.Text);
            try
            {
                if (PSC.Sua(GetData()))
                {
                    MessageBox.Show("Cập Nhật phiếu sửa chữa thành công!");
                    db.getDS("update HOSOSUACHUA set TongCong = '" + PSC.Sum(mahssc(cbBox_bienso.Text)) + "' where BienSo = '" + cbBox_bienso.Text + "'");
                }
                else
                    if (PSC.Them(GetData()))
                    {
                        db.getDS("update HOSOSUACHUA set TongCong = '" + PSC.Sum(mahssc(cbBox_bienso.Text)) + "' where BienSo = '" + cbBox_bienso.Text + "'");
                        MessageBox.Show("Lập phiếu sửa chữa thành công!");
                    }
                UpdateSoLuong(soluong);
                loadbang();
                dtGV_danhsachSuaChua.Refresh();
                SetEnable(false);
            }
            catch { MessageBox.Show("Coi Lại Dữ Liệu Đã Nhập!"); }

        }        

        private void soluong_TextChanged(object sender, EventArgs e)
        {
            int i;
            string oldsoluong = Text_soluong.Text;
            if ((Text_dongia.Text != "") && Text_soluong.Text != "" && (Text_tiencong.Text != ""))
            {
                
                
                if (int.TryParse(Text_soluong.Text, out i) && int.Parse(Text_soluong.Text) > -1)
                {
                    int soluong = int.Parse(Text_soluong.Text) - int.Parse(PSC.SLVatTuPN(tbxMaPhieu.Text));
                    if (soluong > int.Parse(PSC.SLVatTu(mavt(cbBoc_vattu.Text))))
                    {
                        MessageBox.Show("Sồ lượng phụ tùng không được vượt quá số lượng vật tư còn trong kho.");
                        Text_soluong.Text = int.Parse(PSC.SLVatTu(mavt(cbBoc_vattu.Text))) + int.Parse(PSC.SLVatTuPN(tbxMaPhieu.Text)) + "";
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
            string hssc = mahssc(cbBox_bienso.Text);
            string postdelete = Text_soluong.Text;
            try
            {
                DialogResult dr = MessageBox.Show("Bạn muốn xóa phiếu sửa chữa náy!","Xác Nhận",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    int soluong = int.Parse(PSC.SLVatTuPN(tbxMaPhieu.Text));
                    if (PSC.Xoa(tbxMaPhieu.Text))
                    {
                        MessageBox.Show("Đã xóa thành công");

                        no = (tienno(cbBox_bienso.Text) - double.Parse(no)).ToString();
                        db.getDS("update HOSOSUACHUA set TongCong = '" + PSC.Sum(cbBox_bienso.Text) + "' where BienSo = '" + cbBox_bienso.Text + "'");
                        UpdateSoLuong(soluong);
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
            loadbang();
            dtGV_danhsachSuaChua.Update();
            dtGV_danhsachSuaChua.Refresh();
        }




        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int RowIndex = e.RowIndex;
            tbxMaPhieu.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["MaPhieuSC"].Value.ToString();
            cbBoc_vattu.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["TenVatTu"].Value.ToString();
            cbBox_tiencong.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["TenCongViec"].Value.ToString();
            Text_soluong.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["SoLuong"].Value.ToString();
            no = Text_thanhtien.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["ThanhTien"].Value.ToString();
            Text_tiencong.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["TienCong"].Value.ToString();
            cbBox_bienso.Text = bienso(dtGV_danhsachSuaChua.Rows[RowIndex].Cells["MaHSSC"].Value.ToString());
            Text_noidung.Text = dtGV_danhsachSuaChua.Rows[RowIndex].Cells["NoiDung"].Value.ToString();
            Date_ngaysuachua.Value = DateTime.Parse(dtGV_danhsachSuaChua.Rows[RowIndex].Cells["NgaySuaChua"].Value.ToString());
        }


        private void vattu_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["TenVatTu"].ToString() == cbBoc_vattu.SelectedItem.ToString())
                {
                    int a = ChenhLech();
                    double don = double.Parse(dr["DonGia"].ToString()) * (1.0 + ChenhLech()/100.0);
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            SetEnable(true);
            Text_soluong.Text = "0";
            Text_thanhtien.Text = "0";
            Text_tiencong.Text = "0";
            Text_noidung.Text = "";
            cbBoc_vattu.SelectedIndex = 3;
            cbBox_tiencong.SelectedIndex = 5;
            tbxMaPhieu.Text = PSC.SearchDaTaGrid();
            Date_ngaysuachua.Value = DateTime.Now;
        }


        public void SetEnable(bool a)
        {
            Text_noidung.Enabled = a;
            Text_soluong.Enabled = a;
            cbBoc_vattu.Enabled = a;
            cbBox_bienso.Enabled = a;
            cbBox_tiencong.Enabled = a;
            Date_ngaysuachua.Enabled = a;
            btnXoa.Enabled = !a;
            btnSua.Enabled = !a;
            btnLuu.Enabled = a;
            btnHuy.Enabled = a;
            btnThem.Enabled = !a;
            dtGV_danhsachSuaChua.Enabled = !a;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            midsoluong = int.Parse(Text_soluong.Text);
            GetData();
            SetEnable(true);

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SetEnable(false);
        }

        public void UpdateSoLuong(int thaydoi)
        {
            string mavattu = PSC.MaVatTu(cbBoc_vattu.Text);
            int soluong;
            soluong = int.Parse(PSC.SLVatTu(mavattu)) + thaydoi;
            dl.SuaVT(mavattu, soluong.ToString());
        }
    }
}
