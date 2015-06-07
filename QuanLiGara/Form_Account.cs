using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiGara
{
    public partial class Form_Account : DevComponents.DotNetBar.Office2007Form
    {
        Connection db = new Connection();
        string use;
        public Form_Account()
        {
            InitializeComponent();
        }

        private void frmAccount_Load(object sender, EventArgs e)
        {
            grdt.DataSource = db.getDS("select UserName, Loai from Account");
        }

        private void grdt_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            txtUser.Text = grdt.Rows[RowIndex].Cells["Username"].Value.ToString();
            cboQuyen.Text = grdt.Rows[RowIndex].Cells["Loai"].Value.ToString();
            txtPass.Text = "";
            btnXoa.Enabled = true;
            try
            {
                if (Form1.username.ToUpper().Equals(txtUser.Text.ToUpper()))
                    btnXoa.Enabled = false;
            }
            catch {}
            for (int i = 0; i < grdt.SelectedRows.Count; i++)
                if (grdt.SelectedRows[i].Cells[0].Value.ToString().ToUpper().Equals(Form1.username.ToUpper()))
                {
                    btnXoa.Enabled = false;
                    break;
                }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            use = null;
            txtUser.Text = "";
            txtPass.Text = "";
            cboQuyen.SelectedItem = 1;
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
            if (txtUser.Text.ToUpper() == Form1.username.ToUpper())
                btnXoa.Enabled = false;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            enable(false);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            use = txtUser.Text;
            enable(true);
            if (txtUser.Text.ToUpper() == Form1.username.ToUpper())
                cboQuyen.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (grdt.SelectedRows.Count > 1)
            {
                if (MessageBox.Show("Bạn Có Chắc Muốn xóa các tài khoản đã chọn", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        for (int i = 0; i < grdt.SelectedRows.Count; i++)
                            db.getDS("delete Account where Username ='" + grdt.SelectedRows[i].Cells[0].Value.ToString() + "'");
                        MessageBox.Show("Xóa Thành Công!");
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message, "Không xóa được!");
                    }
                }
            }
            else
                if (MessageBox.Show("Bạn Có Chắc muốn xóa tài khoản " + txtUser.Text + " Không ?", "Xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        db.getDS("delete Account where Username ='" + txtUser.Text + "'");
                        MessageBox.Show("Xóa Thành Công!");
                    }
                    catch (Exception a)
                    {
                        MessageBox.Show(a.Message, "Không xóa được!");
                    }
                }
            grdt.DataSource = db.getDS("select Username, Loai from Account");
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (use != null)
                {
                    if ( txtPass.Text == "")
                        db.getDS("Update Account set Username='" + txtUser.Text + "', Loai = '" + cboQuyen.Text + "' where Username='" + use + "'");
                    else
                        db.getDS("Update Account set Username='" + txtUser.Text + "', Password ='" + txtPass.Text + "', Loai = '" + cboQuyen.Text + "' where Username='" + use + "'");
                    MessageBox.Show("Cập nhật thành công");
                }
                else
                {
                    db.getDS("Insert Account values ('" + txtUser.Text + "','" + txtPass.Text + "','" + cboQuyen.Text + "')");
                    MessageBox.Show("Thêm thành công !");
                }
            }
            catch
            {
                MessageBox.Show("Xem Lai Du Lieu Da Nhap");
            }
            grdt.DataSource = db.getDS("select Username, Loai from Account");
            enable(false);
        }

    }
}
