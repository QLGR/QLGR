using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using QuanLiGara.BLL;

namespace QuanLiGara
{
    public partial class Form_Login : Office2007Form
    {
        login l = new login();
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable a = l.getInfo(txtUser.Text, txtPass.Text);
            if (a.Rows.Count == 1)
            {
                Form_Main.username = a.Rows[0]["Username"].ToString();
                Form_Main.loai = a.Rows[0]["Loai"].ToString();
                Form_Main form = new Form_Main();
                form.Show();
                Hide();
            }
            else
                MessageBox.Show("Sai Tên Đăng Nhập Hoặc Mật Khẩu!", "ĐĂNG NHẬP", MessageBoxButtons.OK);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
