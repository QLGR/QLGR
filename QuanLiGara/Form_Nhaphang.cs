using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiGara.sql;

namespace QuanLiGara
{
    public partial class Form_Nhaphang : DevComponents.DotNetBar.Office2007Form
    {
        bool isNew;
        dulieu dls = new dulieu();
        Connection db = new Connection();
        nhaphang nh = new nhaphang();
        nhaphangsql nhsql = new nhaphangsql();
        public Form_Nhaphang()
        {
            InitializeComponent();
           
            
        }

        public string MaVatTu()
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU");
            foreach (DataRow dr in dt.Rows)
            {
                if (cbBox_VatTu.Text == dr["TenVatTu"].ToString())
                {
                    return dr["MaVatTu"].ToString();
                }
            }
            return "";
        }
        public void loadbang()
        {
            dtGV_danhsachPN.DataSource = db.getDS("Select * from PHIEUNHAPHANG");
        }

        public DataTable loadbangNH(string maNH)
        {
            return db.getDS("select * from HOSONHAPHANG where MaNH = '" + maNH + "'");
        }

        public String Vattu(string mavattu)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU where MaVatTu like N'" + mavattu + "'");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["TenVatTu"].ToString();
            else
                return "";
        }
        public void loadVatTu()
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * From VATTU");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cbBox_VatTu.Items.Add(dr["TenVatTu"]);
                }
            }
        }



        public void loadbang(string mahosonh)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from PHIEUNHAPHANG where Manh = '" + mahosonh + "'");
            dtGV_danhsachPN.DataSource = dt;
           
        }

        private nhaphang getData()
        {
            nhaphang nht = new nhaphang();
            nht.MaNH = maNH.Text;
            nht.MaPN = text_phieunhap.Text;
            nht.NhaCC = Text_NCC.Text;
            nht.DiaChi = Text_diachi.Text;
            nht.DienThoai = Text_dienthoai.Text;
            nht.Email = Text_email.Text;
            nht.NgayThuTien = DateTime.Parse(Date_ngaytiepnhan.Text);
            nht.MaVT = MaVatTu();
            nht.SoLuong = txt_Soluong.Text;
            nht.ThanhTien = txt_Thanhtien.Text;
            nht.TongTien = txtTongCong.Text;
            return nht;
        }

        public DuLieusql getDataVatTu()
        {
            dulieu dl = new dulieu();
            DuLieusql dlsql = new DuLieusql();
            dlsql.MaVT = dl.SearchDaTaGrid();
            dlsql.TenVT = cbBox_VatTu.Text;
            dlsql.DonGia = txt_Dongia.Text;
            dlsql.Soluong = txt_Soluong.Text;
            return dlsql;
        }

        private void Text_chuxe_TextChanged(object sender, EventArgs e)
        {

        }

        private void TaoHoaDon_Click(object sender, EventArgs e)
        {
            SetenableNH(true);
            maNH.Text = nhsql.SearchDaTaGridNH();
            txtTongCong.Text = "0";
            loadbang(maNH.Text);
            try
            {
                nhsql.ThemMaTT(getData());
            }

            catch { MessageBox.Show("Không thể lập hóa đơn mới!"); }

        }

        private void ThanhToan_Click(object sender, EventArgs e)
        {
            if (Date_ngaytiepnhan.Value > System.DateTime.Now)
            {
                MessageBox.Show("Ngày nhập hàng không được lớn hơn ngày hiện tại");
                Date_ngaytiepnhan.Text = DateTime.Now.ToString();
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
            try
            {

                if (nhsql.SuaNH(getData()))
                {
                    MessageBox.Show("Phiếu nhập hàng đã được lập, thanh toán thành công!");
                    
                }
            }
            catch { MessageBox.Show("Không thể tạo Phiếu nhập hàng, việc thanh tón thất bại!");nhsql.XoaNH(maNH.Text); }
            UpdateQuantity();
            SetEnablePN(false);
            SetenableNH(false);
            loadbang();
            dtGV_danhsachPN.Update();
            dtGV_danhsachPN.Refresh();
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            foreach (Control tb in this.groupPanel2.Controls)
            {
                if ((tb is ComboBox || tb is TextBox) && tb.Text == "")
                {
                    MessageBox.Show("Dữ liệu nhập không đầy đủ yêu cầu nhập lại!");
                    return;
                }
            }
            try
            {
                if(isNew)
                {
                    dls.ThemVT(getDataVatTu());
                }
                if (nhsql.SuaPN(getData()))
                {
                    MessageBox.Show("Cập Nhật phiếu nhập hàng thành công!");

                }
                else
                    if (nhsql.ThemPhieuNH(getData()))
                    {

                        MessageBox.Show("Lập phiếu chi tiết nhập thành công!");
                    }

               
            }
            catch { MessageBox.Show("Coi Lại Dữ Liệu Đã Nhập!"); }
            SetEnablePN(false); 
            loadbang(maNH.Text);
            dtGV_danhsachPN.Update();
            dtGV_danhsachPN.Refresh();
            txtTongCong.Text = nhsql.SumThanhTien(maNH.Text);
        }

        private void Them_Click(object sender, EventArgs e)
        {
            SetEnablePN(true);
            cbBox_VatTu.Text = "";
            text_phieunhap.Text = nhsql.SearchDaTaGridPN();
        }
        private void Sua_Click(object sender, EventArgs e)
        {
            SetEnablePN(true);
        }
        private void Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (nhsql.XoaPN(text_phieunhap.Text))
                {
                    MessageBox.Show("Xóa thành công chi tiết phiều nhập "+text_phieunhap.Text+"!");

                }

            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể xóa được phiếu chi tiết nhập hiện tại!");
            }

            loadbang(maNH.Text);
            dtGV_danhsachPN.Update();
            dtGV_danhsachPN.Refresh();
            txtTongCong.Text = nhsql.SumThanhTien(maNH.Text);
        }
        private void Huy_Click(object sender, EventArgs e)
        {
            SetEnablePN(false);
            loadbang(maNH.Text);
        }

        private void HuyGD_Click(object sender, EventArgs e)
        {
            nhsql.XoaNH(maNH.Text);
            SetenableNH(false);
            loadbang();
        }


        public void SetEnablePN(bool a)
        {
            txt_Soluong.ReadOnly = !a;
            btnXoa.Enabled = !a;
            btnSua.Enabled = !a;
            btnLuu.Enabled = a;
            btnHuy.Enabled = a;
            btnThem.Enabled = !a;
            dtGV_danhsachPN.Enabled = !a;
        }

        public void SetenableNH(bool a)
        {
            btnXoa.Enabled = a;
            btnSua.Enabled = a;
            btnThem.Enabled = a;
            Text_NCC.ReadOnly = !a;
            Text_diachi.ReadOnly = !a;
            Text_dienthoai.ReadOnly = !a;
            Text_email.ReadOnly = !a;
            btn_ThanhToan.Enabled = a;
            btnHuyGiaoDich.Enabled = a;
            btn_TaoHoaDon.Enabled = !a;

            if(a)
            {
                Text_NCC.Text = "";
                Text_diachi.Text = "";
                Text_dienthoai.Text = "";
                Text_email.Text = "";
            }
        }

        private void cbBox_VatTu_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * From VATTU where TenVatTu like N'" + cbBox_VatTu.Text + "'");
            if (dt.Rows.Count > 0)
            {
                txt_Dongia.Text = dt.Rows[0]["DonGia"].ToString();
                txt_Dongia.ReadOnly = true;
                isNew = false;
            }
            else
            {
                txt_Soluong.Text = "0";
                txt_Dongia.Text = "0";
                txt_Dongia.ReadOnly = false;
                isNew = true;
            }
        }

        private void SoLuong_Changed(object sender, EventArgs e)
        {
            double i;
            if (double.TryParse(txt_Soluong.Text, out i) && int.Parse(txt_Soluong.Text) > -1 && double.TryParse(txt_Dongia.Text, out i) && double.Parse(txt_Dongia.Text) > -1)
                {
                    double sum = (double.Parse(txt_Dongia.Text) * double.Parse(txt_Soluong.Text));
                    if(sum != 0)
                        txt_Thanhtien.Text = sum.ToString("#,###,###.##");
                    else
                        txt_Thanhtien.Text = sum.ToString();
                    
                }
                else
                if (txt_Dongia.Text != "" && txt_Soluong.Text != "")
                {
                    MessageBox.Show("Số Lượng phải là số nguyên lớn hơn 0");
                    if (!double.TryParse(txt_Soluong.Text, out i))
                        txt_Soluong.Text = "0";
                    else
                        txt_Dongia.Text = "0";
                }
        }

        private void Form_Nhaphang_Load(object sender, EventArgs e)
        {
            loadbang();
            loadVatTu();
            SetenableNH(false);
            btn_TaoHoaDon.Enabled = true;
            cbBox_VatTu.SelectedIndex = 1;
        }

        private void dtNhapHangRowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            cbBox_VatTu.Text = Vattu(dtGV_danhsachPN.Rows[RowIndex].Cells["MaVatTu"].Value.ToString());
            text_phieunhap.Text = dtGV_danhsachPN.Rows[RowIndex].Cells["MaPhieuNhap"].Value.ToString();
            txt_Soluong.Text = dtGV_danhsachPN.Rows[RowIndex].Cells["SoLuong"].Value.ToString();
            maNH.Text = dtGV_danhsachPN.Rows[RowIndex].Cells["MaNH"].Value.ToString();
            txt_Thanhtien.Text = dtGV_danhsachPN.Rows[RowIndex].Cells["ThanhTien"].Value.ToString();
            txtTongCong.Text = nhsql.SumThanhTien(maNH.Text);
           
        }

        private void Closing_Form(object sender, FormClosingEventArgs e)
        {
            if (btn_TaoHoaDon.Enabled == false)
            {
                nhsql.XoaNH(maNH.Text);
            }
        }

        public void DeleteAllPN(string manh)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("select * from PHIEUNHAPHANG where MaNH like '" + manh + "'");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    nhsql.XoaPN(dr["MaPhieuNhap"].ToString());
                }
            }
        }

        public void UpdateQuantity()
        {
            DataTable dt,dt1 = new DataTable();
            dt = nhsql.SumVatTu(maNH.Text);
            foreach (DataRow dr in dt.Rows)
            {

                dt1 = db.getDS("Select * from VATTU where MaVatTu = '" + dr["MaVatTu"].ToString() + "'");
                int soluong1 = int.Parse(dt1.Rows[0]["SoLuong"].ToString());
                soluong1 += int.Parse(dr["SoLuong"].ToString());
                dls.SuaVT(dr["MaVatTu"].ToString(), soluong1.ToString());
            }
            
        }

        private void DienThoai_Changed(object sender, EventArgs e)
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

        private void SuaHD_Click(object sender, EventArgs e)
        {
            btnLuu_HD.Enabled = true;
            btnSua_HD.Enabled = false;
            btnXoa_HD.Enabled = false;
            Text_NCC.ReadOnly = false;
            Text_diachi.ReadOnly = false;
            Text_dienthoai.ReadOnly = false;
            Text_email.ReadOnly = false;
        }

        private void XoaHD_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn muốn xóa hồ sơ " + maNH.Text + "?Nó có thể xóa tất cả những giao dịch liên quan đế hồ sơ này.", "Xác Nhận", MessageBoxButtons.YesNo);
            try
            {
                if (dr == DialogResult.Yes)
                {
                    if (nhsql.XoaNH(maNH.Text))
                    {
                        MessageBox.Show("Hồ sơ nhập hành " + maNH.Text + " thành công.");
                    }
                    else
                        MessageBox.Show("Việc xóa hồ sơ không hoàn thành.");
                }
            }
            catch { MessageBox.Show("Việc xóa hồ sơ không hoàn thành."); }
            
            loadbang();
            dtGV_danhsachPN.Update();
            dtGV_danhsachPN.Refresh();
        }

        private void LuuHD_Click(object sender, System.EventArgs e)
        {
            if (Date_ngaytiepnhan.Value > System.DateTime.Now)
            {
                MessageBox.Show("Ngày nhập hàng không được lớn hơn ngày hiện tại");
                Date_ngaytiepnhan.Text = DateTime.Now.ToString();
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

            try
            {
                if(nhsql.SuaNH(getData()))
                {
                    MessageBox.Show("Cập nhật hồ sơ nhập hàng thành công.");
                }
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công. Vui lòng kiểm tra lại dữ liệu.");
            }
            btnLuu_HD.Enabled = false;
            btnSua_HD.Enabled = true;
            btnXoa_HD.Enabled = true;
            Text_NCC.ReadOnly = true;
            Text_diachi.ReadOnly = true;
            Text_dienthoai.ReadOnly = true;
            Text_email.ReadOnly = true;

            loadbang();
            dtGV_danhsachPN.Update();
            dtGV_danhsachPN.Refresh();
        }

    }
}
    
