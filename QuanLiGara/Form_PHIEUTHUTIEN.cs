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
        SqlConnection sql = new SqlConnection();
        public string hssc;
        double no = 0;

        public string mahssc(SqlConnection sql, String bienso)
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
            pt.Email = Text_email.Text;
            pt.MaHSSC = mahssc(sql,cbB_bienso.Text);
            pt.SoTienThu = Text_sotienthu.Text;
            pt.NgayThuTien = DateTime.Parse(Date_ngaythutien.Text);
            pt.MaThuTien = txtMaPT.Text;
            return pt;
        }
        public void loadbienso(SqlConnection sql)
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
            loadbienso(sql);
            loadbang(sql);
        }

        
        public void loadbang(SqlConnection sql)
        {


            DataTable dt = new DataTable();
            dt = db.getDS("SELECT PHIEUTHUTIEN.MaThuTien,HOSOSUACHUA.TenChuXe,HOSOSUACHUA.BienSo,HOSOSUACHUA.DienThoai,PHIEUTHUTIEN.Email,PHIEUTHUTIEN.SoTienThu,PHIEUTHUTIEN.NgayThuTien"+
                            ",HOSOSUACHUA.MaHSSC FROM HOSOSUACHUA JOIN PHIEUTHUTIEN on HOSOSUACHUA.MaHSSC=PHIEUTHUTIEN.MaHSSC");
            dtGV_phieuthu.DataSource = dt;
            
        }
        public double tienno(SqlConnection sql, string mahssc)
        {
            
            
            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM DANHSACHXE");
            
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MaHSSC"].ToString() == mahssc)
                    return Double.Parse(dr["TienNo"].ToString());
            }


            return 0;
        }

        private void Luu_Click(object sender, EventArgs e)
        {
            
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
                no = (double.Parse(txt_conno.Text) - double.Parse(Text_sotienthu.Text));
                db.getDS("update DANHSACHXE set TienNo = '" + no + "' where MaHSSC = '" + hssc+ "'");

            }
            catch (Exception c)
            {
                MessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
            }
            setEnable(false);
            loadbang(sql);
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
            
        }


        private void Delete_Click(object sender, EventArgs e)
        {
            
            try
            {
                if(ptsql.XoaMaTT(txtMaPT.Text))
                {
                    MessageBox.Show("Xóa thành công phiếu thu!");
                    no = (double.Parse(txt_conno.Text) + double.Parse(Text_sotienthu.Text));
                    db.getDS("update DANHSACHXE set TienNo = '" + no + "' where MaHSSC = '" + hssc+ "'");
                }

            }
            catch (Exception c)
            {
                MessageBox.Show("Không thể xóa do vẫn còn đang sửa hoặc chưa thanh toán!");
            }
            
            loadbang(sql);
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
        }

       

        
        private void bienso_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt,dt1 = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");
            dt1 = db.getDS("Select * FROM DANHSACHXE");
            
            foreach (DataRow dr in dt.Rows)
            {
                if (cbB_bienso.Text == dr["BienSo"].ToString())
                {
                    Text_chuxe.Text = dr["TenChuXe"].ToString();
                    Text_dienthoai.Text = dr["DienThoai"].ToString();
                    hssc = dr["MaHSSC"].ToString();
                    txt_Tongtien.Text = dr["TongCong"].ToString();
                }
            }

            foreach (DataRow dr1 in dt1.Rows)
            {
                if (hssc == dr1["MaHSSC"].ToString())
                {
                    txt_conno.Text = dr1["TienNo"].ToString();
                }
            }
            


        }

        private void SoTienThu_TextChanged(object sender, EventArgs e)
        {
            double i;
            if(double.TryParse(Text_sotienthu.Text,out i))
            {
                if (double.Parse(Text_sotienthu.Text) < 0)
                    MessageBox.Show("So tiền thu phải lớn hơn 0!");
                else
                {

                    double tien = (double.Parse(txt_conno.Text) - double.Parse(Text_sotienthu.Text));
                    if (tien < 0 && btnLuu.Enabled == true)
                    {
                        MessageBox.Show("So tien thu không được vượt quá số tiền nợ!");
                    }
                }
            }
            else
                if(Text_sotienthu.Text != "" && Text_sotienthu.Text != "-")
                {
                    MessageBox.Show("So tiền thu phải lớn hơn 0!");
                }
               
        }

        private void EnterCellData(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            Text_chuxe.Text = dtGV_phieuthu.Rows[RowIndex].Cells["TenChuXe"].Value.ToString();
            Text_email.Text = dtGV_phieuthu.Rows[RowIndex].Cells["Email"].Value.ToString();
            Text_dienthoai.Text = dtGV_phieuthu.Rows[RowIndex].Cells["DienThoai"].Value.ToString();
            Date_ngaythutien.Text = dtGV_phieuthu.Rows[RowIndex].Cells["NgayThuTien"].Value.ToString();
            cbB_bienso.Text = dtGV_phieuthu.Rows[RowIndex].Cells["BienSo"].Value.ToString();
            no = double.Parse(Text_sotienthu.Text = dtGV_phieuthu.Rows[RowIndex].Cells["SoTienThu"].Value.ToString());
            txtMaPT.Text = dtGV_phieuthu.Rows[RowIndex].Cells["MaThuTien"].Value.ToString();
            hssc = dtGV_phieuthu.Rows[RowIndex].Cells["MaHSSC"].Value.ToString();
        }
        private void setEnable(bool a)
        {
            Text_chuxe.ReadOnly = !a;
            Text_email.ReadOnly = !a;
            Text_dienthoai.ReadOnly = !a;
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
            Text_chuxe.Text = "";
            Text_email.Text = "";
            Text_dienthoai.Text = "";
            Text_sotienthu.Text = "0";
            txt_conno.Text = "0";
            txt_Tongtien.Text = "0";
            txtMaPT.Text = ptsql.SearchDaTaGrid();
            
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            setEnable(true);
            txt_conno.Text = (tienno(sql, cbB_bienso.Text) + double.Parse(Text_sotienthu.Text)).ToString();
            Text_sotienthu.Text = "0";


        }

        private void Huy_Click(object sender, EventArgs e)
        {
            setEnable(false);
            txt_Tongtien.Text = "0";
            Text_sotienthu.Text = "0";
            loadbang(sql);
            cbB_bienso.SelectedIndex = 0;
            dtGV_phieuthu.Update();
            dtGV_phieuthu.Refresh();
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
