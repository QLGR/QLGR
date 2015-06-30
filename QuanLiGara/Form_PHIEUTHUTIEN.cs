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
    public partial class Form_PHIEUTHUTIEN : Office2007Form
    {
        public Form_PHIEUTHUTIEN()
        {
            InitializeComponent();
        }
        Connection db = new Connection();
        phieuthusql ptsql = new phieuthusql();
        phieuthu pt = new phieuthu();
        public string hssc;

        public string mahssc(String bienso)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("select * from HOSOSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["BienSo"].ToString() == cbB_bienso.Text)
                    return dr["MaHSSC"].ToString();

            }
            return "";
        }

        public phieuthu getData()
        {
            phieuthu pt = new phieuthu();
            pt.MaHSSC = mahssc(cbB_bienso.Text);
            pt.SoTienThu = txt_Tongtien.Text;
            pt.NgayThuTien = DateTime.Parse(Date_ngaythutien.Text);
            pt.MaThuTien = txtMaPT.Text;
            return pt;
        }
        public void loadbienso()
        {
            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");
   
            foreach (DataRow dr in dt.Rows)
            {
                cbB_bienso.Items.Add(dr["BienSo"].ToString());
            }
            
        }
        private void Form_PHIEUTHUTIEN_Load(object sender, EventArgs e)
        {
            loadbienso();
            loadbang();
        }

        
        public void loadbang()
        {


            DataTable dt = new DataTable();
            dt = db.getDS("SELECT PHIEUTHUTIEN.MaThuTien,HOSOSUACHUA.TenChuXe,HOSOSUACHUA.BienSo,HOSOSUACHUA.DienThoai,PHIEUTHUTIEN.SoTienThu,PHIEUTHUTIEN.NgayThuTien"+
                            ",HOSOSUACHUA.MaHSSC FROM HOSOSUACHUA JOIN PHIEUTHUTIEN on HOSOSUACHUA.MaHSSC=PHIEUTHUTIEN.MaHSSC");
            dtGV_phieuthu.DataSource = dt;
            
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            if (Date_ngaythutien.Value > System.DateTime.Now)
            {
                MessageBox.Show("Ngày thu tiền không được lớn hơn ngày hiện tại");
                Date_ngaythutien.Text = DateTime.Now.ToString();
                return;
            }
            if(!CheckTienThu())
            {
                Text_sotienthu.Text = txt_Tongtien.Text;
                MessageBox.Show("Số tiền thu không được phép nhỏ hơn số tiền cần trả");
                return;
            }
            try
            {
                if(ptsql.SuaMaTT(getData()))
                {
                    MessageBox.Show("Cập nhật phiếu thu thành công thành công.");
                    
                    
                }
                else
                    
                    if (ptsql.ThemMaTT(getData()))
                    {
                        MessageBox.Show("Thêm phiếu thu thành công!");
                        
                    }

            }
            catch (Exception c)
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
            }
            setEnable(false);
            loadbang();
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
            
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            
            try
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc muốn xóa phiều thu này?","Xác Nhận",MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    if (ptsql.XoaMaTT(txtMaPT.Text))
                    {
                        MessageBox.Show("Xóa thành công phiếu thu!");

                    }
                }

            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể xóa do vẫn còn đang sửa hoặc chưa thanh toán!");
            }
            
            loadbang();
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
        }

       

        
        private void bienso_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt,dt1 = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");
          
            
            foreach (DataRow dr in dt.Rows)
            {
                if (cbB_bienso.Text == dr["BienSo"].ToString())
                {
                    hssc = dr["MaHSSC"].ToString();
                    txt_Tongtien.Text = dr["TongCong"].ToString();
                }
            }


        }

        private void SoTienThu_TextChanged(object sender, EventArgs e)
        {
            double i;
            if(double.TryParse(Text_sotienthu.Text,out i))
            {
                if (double.Parse(Text_sotienthu.Text) < 0)
                {
                    Text_sotienthu.Text = txt_Tongtien.Text;
                    MessageBox.Show("So tiền thu phải lớn hơn 0!");
                }
                else
                {
                    txt_TraLai.Text = (double.Parse(Text_sotienthu.Text) - double.Parse(txt_Tongtien.Text)).ToString();
                }
            }
            else
                if(Text_sotienthu.Text != "" && Text_sotienthu.Text != "-")
                {
                    MessageBox.Show("So tiền thu phải lớn hơn 0!");
                    Text_sotienthu.Text = txt_Tongtien.Text;
                }
               
        }

        private void EnterCellData(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            Date_ngaythutien.Text = dtGV_phieuthu.Rows[RowIndex].Cells["NgayThuTien"].Value.ToString();
            cbB_bienso.Text = dtGV_phieuthu.Rows[RowIndex].Cells["BienSo"].Value.ToString();
            Text_sotienthu.Text = dtGV_phieuthu.Rows[RowIndex].Cells["SoTienThu"].Value.ToString();
            txtMaPT.Text = dtGV_phieuthu.Rows[RowIndex].Cells["MaThuTien"].Value.ToString();
            hssc = dtGV_phieuthu.Rows[RowIndex].Cells["MaHSSC"].Value.ToString();
            txt_TraLai.Text = "0";
        }
        private void setEnable(bool a)
        {
            
            Text_sotienthu.ReadOnly = !a;
            btnXoa.Enabled = !a;
            btnSua.Enabled = !a;
            btnLuu.Enabled = a;
            btnHuy.Enabled = a;
            btnThem.Enabled = !a;
            dtGV_phieuthu.Enabled = !a;
        }
        private void Them_Click(object sender, EventArgs e)
        {
            
            setEnable(true);
            Text_sotienthu.Text = "0";
            txt_TraLai.Text = "0";
            txt_Tongtien.Text = "0";
            txtMaPT.Text = ptsql.SearchDaTaGrid();
            
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            setEnable(true);
            txt_TraLai.Text = "0";
            Text_sotienthu.Text = "0";


        }

        private void Huy_Click(object sender, EventArgs e)
        {
            setEnable(false);
            txt_Tongtien.Text = "0";
            Text_sotienthu.Text = "0";
            loadbang();
            cbB_bienso.SelectedIndex = 0;
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
        }

        private bool CheckTienThu()
        {
            if (double.Parse(txt_Tongtien.Text) > double.Parse(Text_sotienthu.Text))
                return false;
            return true;
        }
        
    }
}
