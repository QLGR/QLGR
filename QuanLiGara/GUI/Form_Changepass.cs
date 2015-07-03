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
    public partial class Form_Changepass : DevComponents.DotNetBar.Office2007Form
    {
        changepass cp = new changepass();
        public Form_Changepass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable nv = new DataTable();
            nv = cp.getPass();
            string mk = nv.Rows[0]["PassWord"].ToString();
            string mkc = txtold.Text;
            string mkm = txtnew.Text;
            string xn = txtconfirm.Text;
            if (mkc.Equals(mk))
            {
                if (mkm.Equals(xn))
                {
                    cp.setPass(mkm);
                    MessageBox.Show("Mật khẩu của bạn đã được thay đổi thành công !");
                    Hide();
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không đồng nhất vui long kiểm tra lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Sai mật khẩu, vui lòng kiểm tra lại mật khẩu cũ của bạn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
