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

namespace QuanLiGara
{
    public partial class Form_Main : Office2007RibbonForm
    {
        public static String username;
        public static String loai;
        public Form_Main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiGaraXeDataSet.BAOCAODOANHSO' table. You can move, or remove it, as needed.
            enable();
        }

        void enable()
        {
            if (loai == "admin")
            {
                buttonItem9.Enabled = true;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //SqlConnection connect = new SqlConnection();
            //connect.ConnectionString = @"Data Source=PHONGLEADER;Initial Catalog=QuanLiGaraXe;Integrated Security=True";
            //connect.Open();
            //SqlCommand command = connect.CreateCommand();
            //command.CommandText = "Select * from dbo.THONGTINXE";
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //adapter.SelectCommand = command;
            //DataTable dt = new DataTable();
            //adapter.Fill(dt);
            //DataView dv = new DataView(dt);

            //connect.Close();
            //dataGridView1.DataSource = dv;
            //dataGridView1.AutoResizeColumns();
            Form_TiepNhan frm = new Form_TiepNhan();
            frm.Show();
        }

        private void lậpPhiếuSửaChữaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PhieuSuaChua frm = new Form_PhieuSuaChua();
            frm.Show();
        }

        private void lậpPhiếuThuTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PHIEUTHUTIEN frm = new Form_PHIEUTHUTIEN();
            frm.Show();
        }

        private void traCứuXeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TRACUU frm = new Form_TRACUU();
            frm.Show();
        }

        private void lậpBáoCáoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void báoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_BaoCaoTon frm = new Form_BaoCaoTon();
            frm.Show();
        }

        private void doanhSốToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DoanhSo frm = new Form_DoanhSo();
            frm.Show();
        }

        

        private void chỉnhSửaDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DuLieu frm = new Form_DuLieu();
            frm.Show();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem7_Click(object sender, EventArgs e)
        {
            Form_Config frm = new Form_Config();
            frm.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát không ?", "Thoát", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void buttonItem8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không ?", "Đăng xuất", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Hide();
                Form_Login n = new Form_Login();
                n.Show();
            }
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            Form_Changepass n = new Form_Changepass();
            n.ShowDialog();
        }

        private void buttonItem9_Click(object sender, EventArgs e)
        {
            Form_Account form = new Form_Account();
            form.Show();
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            Form_About n = new Form_About();
            n.ShowDialog();
        }

        private void nhaphang_Click(object sender, EventArgs e)
        {
            Form_Nhaphang frm = new Form_Nhaphang();
            frm.Show();
        }

        private void buttonItem12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "help.pdf";
            proc.Start();
        }
    }
}
