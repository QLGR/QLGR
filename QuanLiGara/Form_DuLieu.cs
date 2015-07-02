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
    public partial class Form_DuLieu : Office2007Form
    {
        public Form_DuLieu()
        {
            InitializeComponent();
            SetEnable(true);
        }
       

        int Choose = 0;
        DuLieusql dlsql = new DuLieusql();
        dulieu DL = new dulieu();


        public void loadvattu()
        {
            DataTable dt = new DataTable();
            dt = DL.GetAll("VATTU");
            dtGV_vattu.DataSource = dt;
        }
        public void loadtiencong()
        {
            DataTable dt = new DataTable();
            dt = DL.GetAll("TIENCONG");
            dtGV_tiencong.DataSource = dt;
        }
        public void loadhieuxe()
        {
            DataTable dt = new DataTable();
            dt = DL.GetAll("HIEUXE");
            dtGV_hieuxe.DataSource = dt;
        }
        public void loadmaxxe()
        {
            DataTable dt = new DataTable();
            dt = DL.GetAll("THAMSO");
            foreach (DataRow dr in dt.Rows)
            {
                Text_soxemax.Text = dr["SuaChuaToiDa"].ToString();
                Text_Chenhlech.Text = dr["ChenhLech"].ToString();
            }
        }
        private void Form_DuLieu_Load(object sender, EventArgs e)
        {
            loadvattu();
            loadtiencong();
            loadhieuxe();
            loadmaxxe();
        }

        public DuLieusql Getdata()
        {
            DuLieusql dl = new DuLieusql();
            dl.MaVT = Text_maVT.Text;
            dl.TenVT = Text_tenVT.Text;
            dl.DonGia = Text_dongia.Text;
            dl.Soluong = text_SoLuong.Text;

            dl.MaTC = Text_matiencong.Text;
            dl.TenCV = Text_tentiencong.Text;
            dl.TienCong = Text_tiencong.Text;

            dl.MaHX = Text_mahieuxe.Text;
            dl.TenHX = Text_tenhieuxe.Text;

            return dl;
        }

        private void dtGV_vattu_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int RowIndex = e.RowIndex;
            Text_maVT.Text = dtGV_vattu.Rows[RowIndex].Cells["MaVatTu"].Value.ToString();
            Text_tenVT.Text = dtGV_vattu.Rows[RowIndex].Cells["TenVatTu"].Value.ToString();
            Text_dongia.Text = dtGV_vattu.Rows[RowIndex].Cells["DonGia"].Value.ToString();
            text_SoLuong.Text = dtGV_vattu.Rows[RowIndex].Cells["SoLuong"].Value.ToString();

        }

        private void dtGV_tiencong_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            int RowIndex = e.RowIndex;
            Text_matiencong.Text = dtGV_tiencong.Rows[RowIndex].Cells["MaTienCong"].Value.ToString();
            Text_tentiencong.Text = dtGV_tiencong.Rows[RowIndex].Cells["TenCongViec"].Value.ToString();
            Text_tiencong.Text = dtGV_tiencong.Rows[RowIndex].Cells["TienCong"].Value.ToString();
        }

        private void dtGV_hieuxe_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;

            Text_mahieuxe.Text = dtGV_hieuxe.Rows[RowIndex].Cells["MaHX"].Value.ToString();
            Text_tenhieuxe.Text = dtGV_hieuxe.Rows[RowIndex].Cells["TenHieuXe"].Value.ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            switch (Choose)
            {
                //thêm vật tư vào csdl
                case 1:
                    if (Text_maVT.Text == "" || Text_tenVT.Text == "" || Text_dongia.Text == "" || text_SoLuong.Text == "")
                    {
                        MessageBox.Show("Dữ liệu chưa được nhập đầy đủ. Yêu cầu nhập lại.");
                    }
                    try
                    {
                        if (DL.SuaVT(Getdata()))
                        {
                            MessageBox.Show("Cập nhật vật tư thành công");
                        }
                        else
                            if (DL.ThemVT(Getdata()))
                            {
                                MessageBox.Show("Đã thêm vật tư vào danh sách");
                            }
                        SetEnable(true);
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Không thể chỉnh sửa hoặc thêm mới.\nVui lòng kiểm tra lại dữ liệu đã nhập");
                    }

                    loadvattu();
                    dtGV_vattu.Update();
                    dtGV_vattu.Refresh();

                    break;

                case 2://thêm tên công việc vào csdl
                    if (Text_matiencong.Text == "" || Text_tiencong.Text == "" || Text_tiencong.Text == "")
                    {
                        MessageBox.Show("Dữ liệu chưa được nhập đầy đủ. Yêu cầu nhập lại.");
                    }
                    try
                    {
                        if (DL.SuaTC(Getdata()))
                        {
                            MessageBox.Show("Cập nhật công việc thành công");
                        }
                        else
                            if (DL.ThemTC(Getdata()))
                            {
                                MessageBox.Show("Đã thêm công việc vào danh sách");
                            }
                        SetEnable(true);
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Không thể chỉnh sửa hoặc thêm mới.\nVui lòng kiểm tra lại dữ liệu đã nhập");
                    }
                    loadtiencong();
                    dtGV_tiencong.Update();
                    dtGV_tiencong.Refresh();
                    break;
                case 3:
                    if (Text_mahieuxe.Text == "" || Text_tenhieuxe.Text == "")
                    {
                        MessageBox.Show("Dữ liệu chưa được nhập đầy đủ. Yêu cầu nhập lại.");
                    }
                    try
                    {
                        if (DL.SuaHX(Getdata()))
                        {
                            MessageBox.Show("Cập nhật Hiệu xe thành công");
                        }
                        else
                            if (DL.ThemHX(Getdata()))
                            {
                                MessageBox.Show("Đã thêm xe mới vào danh sách");
                            }
                        SetEnable(true);
                    }
                    catch (Exception c)
                    {
                        MessageBox.Show("Không thể chỉnh sửa hoặc thêm mới.\nVui lòng kiểm tra lại dữ liệu đã nhập");
                    }
                    loadhieuxe();
                    dtGV_hieuxe.Update();
                    dtGV_hieuxe.Refresh();
                    break;
            }



        }



        private void btnXoaVT_Click(object sender, EventArgs e)
        {
            try
            {
                if (DL.CheckExistReference(Text_maVT.Text))
                    MessageBox.Show("Không thể xóa do vật tư " + Text_tenVT.Text + " do còn liên quan đến phiếu sửa chữa hoặc phiếu nhập hàng", "Không thể xóa");
                else
                {
                    if (DL.XoaVT(Text_maVT.Text))
                        MessageBox.Show("Xóa vật tư thành công.");
                }


            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể xóa vật tư.");
            }
            loadvattu();
            dtGV_vattu.Update();
            dtGV_vattu.Refresh();
        }





        private void btnXoaTC(object sender, EventArgs e)
        {
            try
            {
                if (DL.CheckExistReferenceTC(Text_matiencong.Text))
                    MessageBox.Show("Không thể xóa công việc " + Text_tentiencong.Text +" do còn liên quan đến phiếu sửa chữa", "Không thể xóa");
                else
                {
                    if (DL.XoaTC(Text_matiencong.Text))
                        MessageBox.Show("Xóa công việc thành công.");
                }


            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể xóa công việc.");
            }
            loadtiencong();
            dtGV_tiencong.Update();
            dtGV_tiencong.Refresh();
        }





        private void btnXoaHX(object sender, EventArgs e)
        {
            try
            {
                if (DL.CheckExistReferenceHieuXe(Text_mahieuxe.Text))
                    MessageBox.Show("Không thể xóa hiệu xe " + Text_tenhieuxe.Text + " do còn liên quan đến hồ sơ sửa chữa", "Không Thể Xóa Xe ");
                else
                {
                    if (DL.XoaHX(Text_mahieuxe.Text))
                        MessageBox.Show("Xóa hiệu xe thành công.");
                }


            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể xóa hiệu xe.");
            }
            loadhieuxe();
            dtGV_hieuxe.Update();
            dtGV_hieuxe.Refresh();
        }

        private void btnThemThamSo(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = new DataTable();
                DL.CapNhat(Text_soxemax.Text, Text_Chenhlech.Text);
                MessageBox.Show("Chỉnh sửa tham số thành công!");
                loadmaxxe();
            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể cập nhật tham số. Vui lòng kiểm tra lại dữ liệu");
            }
        }

        void SetEnable(bool a)
        {
            Button_themhx.Enabled = Button_themtc.Enabled = Button_themvt.Enabled = a;
            Button_suahx.Enabled = Button_suatc.Enabled = Button_suavt.Enabled = a;
            Button_xoatc.Enabled = Button_xoahx.Enabled = Button_xoavt.Enabled = a;
            btnLuu.Enabled = btnHuy.Enabled = !a;
            switch (Choose)
            {
                case 1:
                    Text_tenVT.ReadOnly = a;
                    Text_dongia.ReadOnly = a;
                    text_SoLuong.ReadOnly = a;
                    break;
                case 2:
                    Text_tentiencong.ReadOnly = a;
                    Text_tiencong.ReadOnly = a;

                    break;
                case 3:
                    Text_mahieuxe.ReadOnly = a;
                    Text_tenhieuxe.ReadOnly = a;
                    break;
                default:
                     Text_tenVT.ReadOnly = a;
                    Text_dongia.ReadOnly = a;
                    text_SoLuong.ReadOnly = a;
                    Text_mahieuxe.ReadOnly = a;
                    Text_tenhieuxe.ReadOnly = a;
                    Text_tentiencong.ReadOnly = a;
                    Text_tiencong.ReadOnly = a;
                    break;
            }


        }

        private void btnThemVL(object sender, EventArgs e)
        {
            Choose = 1;
            Text_maVT.Text = DL.SearchDaTaGrid();
            SetEnable(false);
            Text_tenVT.Text = "";
            Text_dongia.Text = "0";
            text_SoLuong.Text = "0";
        }
        private void btnSuaVT(object sender, EventArgs e)
        {
            Choose = 1;
            SetEnable(false);
        }

        private void btnThemTC(object sender, EventArgs e)
        {
            Choose = 2;
            Text_matiencong.Text = DL.SearchDaTaGridTC();
            SetEnable(false);
            Text_tentiencong.Text = "";
            Text_tiencong.Text = "0";
        }

        private void btnSuaTC(object sender, EventArgs e)
        {
            Choose = 2;
            SetEnable(false);
        }

        private void btnThemHX(object sender, EventArgs e)
        {
            Choose = 3;
            SetEnable(false);
            Text_mahieuxe.Text = "";
            Text_tenhieuxe.Text = "";
        }

        private void btnSuaHX(object sender, EventArgs e)
        {
            Choose = 3;
            SetEnable(false);
        }

        private void btnHuyAll_Click(object sender, EventArgs e)
        {
            Choose = 0;
            SetEnable(true);
            switch (Choose)
            {
                case 1:
                    loadvattu();
                    dtGV_vattu.Update();
                    dtGV_vattu.Refresh();
                    break;
                case 2:
                    loadtiencong();
                    dtGV_tiencong.Update();
                    dtGV_tiencong.Refresh();
                    break;
                case 3:
                    loadhieuxe();
                    dtGV_hieuxe.Update();
                    dtGV_hieuxe.Refresh();
                    break;
            }
        }

        private void SoLuong_TextChange(object sender, EventArgs e)
        {
            double i;
            if ((!Double.TryParse(Text_dongia.Text, out i) || double.Parse(Text_dongia.Text) < 0) && Text_dongia.Text != "")
            {
                MessageBox.Show("đon giá phải là số lớn hơn 0");
            }
            if ((!Double.TryParse(Text_tiencong.Text, out i) || double.Parse(Text_tiencong.Text) < 0) && Text_tiencong.Text != "")
            {
                MessageBox.Show("Tiền công phải là số lớn hơn 0");
            }
            if ((!Double.TryParse(text_SoLuong.Text, out i) || double.Parse(text_SoLuong.Text) < 0) && text_SoLuong.Text != "")
            {
                MessageBox.Show("Số lượng phải là số lớn hơn 0");
            }
            if ((!Double.TryParse(Text_Chenhlech.Text, out i) || double.Parse(Text_Chenhlech.Text) < 0) && Text_Chenhlech.Text != "")
            {
                MessageBox.Show("Chênh lệch phải là số lớn hơn 0");
            }
            if ((!Double.TryParse(Text_soxemax.Text, out i) || double.Parse(Text_soxemax.Text) < 0) && Text_soxemax.Text != "")
            {
                MessageBox.Show("Số xe sửa chữa tối đa phải là số lớn hơn 0");
            }
        }
    }
}
