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
namespace QuanLiGara
{
    public partial class Form_TRACUU : Office2007Form
    {
        public Form_TRACUU()
        {
            InitializeComponent();
        }
        
        SqlConnection sql = new SqlConnection();
        Connection db = new Connection();
        
        public void loadbang(SqlConnection sql)
        {
            DataTable dt = new DataTable();
            dt  = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe "+
                            "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX");  
            dtGV_tracuu.DataSource = dt;
           
        }
        private void Form_TRACUU_Load(object sender, EventArgs e)
        {
            loadbang(sql);
        }
        public void TimKiem()
        {

            DataTable dt = new DataTable();  
            dt = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                             "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                             " WHERE BienSo like '%" + Text_bienso.Text + "%' OR TenHieuXe like '%" + Text_hieuxe.Text + "%' OR TenChuXe like '%" + Text_chuxe.Text + "%' ");
            
            dtGV_tracuu.DataSource = dt;
            dtGV_tracuu.Update();
            dtGV_tracuu.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGV_tracuu.CurrentRow.Index < dtGV_tracuu.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_tracuu[5, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_bienso.Text = dtGV_tracuu[3, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_hieuxe.Text = dtGV_tracuu[4, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_tienno.Text = dtGV_tracuu[2, dtGV_tracuu.CurrentRow.Index].Value.ToString();
            }
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGV_tracuu.CurrentRow.Index < dtGV_tracuu.RowCount - 1)
            {
                Text_chuxe.Text = dtGV_tracuu[5, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_bienso.Text = dtGV_tracuu[3, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_hieuxe.Text = dtGV_tracuu[4, dtGV_tracuu.CurrentRow.Index].Value.ToString();
                Text_tienno.Text = dtGV_tracuu[2, dtGV_tracuu.CurrentRow.Index].Value.ToString();
            }
          
        }
    }
}
