using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLiGara.DAL;
using QuanLiGara.BLL;

namespace QuanLiGara
{
    public partial class Form_Account : DevComponents.DotNetBar.Office2007Form
    {
        account a = new account();
        string use;
        public Form_Account()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            grdt.DataSource = a.getInfo();
        }

        private void grdt_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            txtUser.Text = grdt.Rows[RowIndex].Cells["Username"].Value.ToString();
            cboQuyen.Text = grdt.Rows[RowIndex].Cells["Loai"].Value.ToString();
            txtPass.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            use = null;
            txtUser.Text = "";
            txtPass.Text = "";
            cboQuyen.Text = "nv";
            enable(true);
        }

        void enable(bool a)
        {
            grdt.Enabled = !a;
            btnThem.Enabled = !a;
            btnSua.Enabled = !a;
            btnXoa.Enabled = !a;
            btnLuu.Enabled = a;
            btnHuy.Enabled = a;
            txtUser.Enabled = a;
            txtPass.Enabled = a;
            cboQuyen.Enabled = a;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enable(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            use = txtUser.Text;
            enable(true);
            if (txtUser.Text.ToUpper() == Form_Main.username.ToUpper())
                cboQuyen.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (Form_Main.username.ToUpper().Equals(txtUser.Text.ToUpper()))
            {
                MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Error");
                return;
            }
            for (int i = 0; i < grdt.SelectedRows.Count; i++)
                if (grdt.SelectedRows[i].Cells[0].Value.ToString().ToUpper().Equals(Form_Main.username.ToUpper()))
                {
                    MessageBox.Show("Không thể xóa tài khoản đang đăng nhập!", "Error");
                    return;
                }
            if (grdt.SelectedRows.Count > 1)
            {
                if (MessageBox.Show("Bạn Có Chắc Muốn xóa các tài khoản đã chọn", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < grdt.SelectedRows.Count; i++)
                            a.deleteAcount(grdt.SelectedRows[i].Cells[0].Value.ToString());
                        MessageBox.Show("Xóa Thành Công!");
                    }
                    catch (Exception b)
                    {
                        MessageBox.Show(b.Message, "Không xóa được!");
                    }
                }
            }
            else
                if (MessageBox.Show("Bạn Có Chắc muốn xóa tài khoản " + txtUser.Text + " Không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        a.deleteAcount(txtUser.Text);
                        MessageBox.Show("Xóa Thành Công!");
                    }
                    catch (Exception b)
                    {
                        MessageBox.Show(b.Message, "Không xóa được!");
                    }
                }
            grdt.DataSource = a.getInfo();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (use != null)
                {
                    if ( txtPass.Text == "")
                        a.setLoai(txtUser.Text, cboQuyen.SelectedItem.ToString(), use);
                    else
                        a.setAll(txtUser.Text, txtPass.Text, cboQuyen.SelectedItem.ToString(), use);
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    a.Insert(txtUser.Text, txtPass.Text, cboQuyen.SelectedItem.ToString());
                    MessageBox.Show("Thêm thành công !");
                }
            }
            catch
            {
                MessageBox.Show("Xem Lai Du Lieu Da Nhap");
            }
            grdt.DataSource = a.getInfo();
            enable(false);
        }

    }
}
