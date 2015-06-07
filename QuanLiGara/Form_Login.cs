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

namespace QuanLiGara
{
    public partial class Form_Login : Office2007Form
    {
        Connection db = new Connection();
        public Form_Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable a = db.getDS("Select * from Account where UserName = '" + txtUser.Text + "'" + " and PassWord = '" + txtPass.Text + "'");
            if (a.Rows.Count == 1)
            {
                Form1.username = a.Rows[0]["Username"].ToString();
                Form1.loai = a.Rows[0]["Loai"].ToString();
                Form1 form = new Form1();
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
