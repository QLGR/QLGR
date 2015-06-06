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
    public partial class Form1 : Office2007RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLiGaraXeDataSet.BAOCAODOANHSO' table. You can move, or remove it, as needed.
            


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
            frm.Show();
        }

        private void buttonItem7_Click_1(object sender, EventArgs e)
        {
            Form_Config frm = new Form_Config();
            frm.Show();
        }
    }
}
