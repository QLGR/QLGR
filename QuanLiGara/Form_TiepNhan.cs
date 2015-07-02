
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
            tn.MaHieuXe = cbBox_hieuxe.SelectedValue.ToString();
            tn.DiaChi = Text_diachi.Text;
            tn.DienThoai = Text_dienthoai.Text;
            tn.NgayTiepNhan = DateTime.Parse(Date_ngaytiepnhan.Text);
            return tn;
        }

        public void loadbang()
        {
            dtGV_danhsachTN.DataSource = tnsql.GetAll("HOSOSUACHUA");
        }

        public void loadhieuxe()
        {
            cbBox_hieuxe.DataSource = tnsql.GetAll("HIEUXE");
            cbBox_hieuxe.ValueMember = "MaHX";
            cbBox_hieuxe.DisplayMember = "TenHieuXe";
        }
        public bool Check(String date)
        {
            int count = 0;


            DataTable dt = tnsql.GetAll("HOSOSUACHUA");

            foreach (DataRow dr in dt.Rows)
            {

                if (dr["NgayTiepNhan"].ToString() == date + " 12:00:00 AM")
                {

                    count++;
                }
            }

            if (tnsql.GetSuaChuaToiDa() <= count)
                return false;
            else
            {
                return true;
            }

        }

        private void Form_TiepNhan_Load(object sender, EventArgs e)
        {
            loadbang();
            loadhieuxe();
        }

        private void Luu_Click(object sender, EventArgs e)
        {

            if (Date_ngaytiepnhan.Value > System.DateTime.Now)
            {
                MessageBox.Show("Ngày tiếp nhận không được lớn hơn ngày hiện tại");
                Date_ngaytiepnhan.Text = DateTime.Now.ToString();
                return;
            }
            if (Check(Date_ngaytiepnhan.Value.ToShortDateString().ToString()) == false)
            {
                MessageBox.Show("Đã tiếp nhận sửa chữa đủ xe vào ngày " + Date_ngaytiepnhan.Text);
                return;
            }
            switch (choose)
            {
                case 1:

                    try
                    {
                        if (!tnsql.checkBienso(Text_bienso.Text))
                        {
                            if (tnsql.ThemTN(getData()))
                            {
                                tnsql.ThemDSX(getData());
                                MessageBox.Show("Đã thêm phiếu sửa chữa cho xe " + cbBox_hieuxe.Text + " - Bien so " + Text_bienso.Text);
                            }
                        }
                        else
                            MessageBox.Show("Bien so " + Text_bienso.Text + " đã tồn tại trong hồ sơ.");

                    }
                    catch
                    { MessageBox.Show("Không thể thêm hồ sơ sử chữa. Yêu cầu kiểm tra lại thông tin!"); }



                    break;
                case 2:
                    try
                    {
                        if (tnsql.SuaTN(getData()))
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
            loadbang();
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
                        MessageBox.Show("Đã xóa phiếu sửa chữa cho xe " + cbBox_hieuxe.Text + " - Bien so " + Text_bienso.Text);
                    else
                        MessageBox.Show("Không thể xóa hồ sơ sửa chữa do chưa thanh toán hoặc vẫn đang sửa chữa!");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể xóa xe " + Text_bienso.Text + " vì vẫn còn phiếu sữa chữa hoặc phiếu thu tiền của xe này đã được lập");
            }



            loadbang();
            dtGV_danhsachTN.Update();
            dtGV_danhsachTN.Refresh();
        }


        private void Sua_Click(object sender, EventArgs e)
        {
            choose = 2;
            SetEnable(true);
        }

        private void dtGV_danhsachTN_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            maHSSC.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["MaHSSC"].Value.ToString();
            Text_chuxe.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["TenChuXe"].Value.ToString();
            Text_bienso.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["Bienso"].Value.ToString();
            cbBox_hieuxe.Text = tnsql.GetTenHieuXE(dtGV_danhsachTN.Rows[RowIndex].Cells["MaHX"].Value.ToString());
            Text_diachi.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["DiaChi"].Value.ToString();
            Text_dienthoai.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["DienThoai"].Value.ToString();
            Date_ngaytiepnhan.Value = DateTime.Parse(dtGV_danhsachTN.Rows[RowIndex].Cells["NgayTiepNhan"].Value.ToString());
            Text_email.Text = dtGV_danhsachTN.Rows[RowIndex].Cells["Email"].Value.ToString();
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
            Date_ngaytiepnhan.Value = DateTime.Now;

        }


        private void Huy_Click(object sender, EventArgs e)
        {
            loadbang();
            dtGV_danhsachTN.Update();
            dtGV_danhsachTN.Refresh();
            SetEnable(false);
        }

        public void SetEnable(bool a)
        {
            Text_chuxe.Enabled = a;
            Text_bienso.Enabled = a;
            Text_diachi.Enabled = a;
            Text_email.Enabled = a;
            Text_dienthoai.Enabled = a;
            cbBox_hieuxe.Enabled = a;
            Date_ngaytiepnhan.Enabled = a;
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
                    {
                        MessageBox.Show("Số điện thoại phải là dãy số nguyên dương");
                        Text_dienthoai.Text = "000";
                    }
                }
                else
                    if (Text_dienthoai.Text != "")
                    {
                        MessageBox.Show("Số điện thoại phải là số nguyên");
                        Text_dienthoai.Text = "000";
                    
                    }
            }
            catch
            {
                MessageBox.Show("Số điện thoại phải là dãy số nguyên.");
                Text_dienthoai.Text = "000";
            }
        }
    }
}