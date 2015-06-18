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
        int choose = 0;
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
       
        
       

        private void Checked_Change(object sender, EventArgs e)
        {
            if (rbBienSo.Checked)
                choose = 1;
            if (rbHieuXe.Checked)
                choose = 2;
            if (rbChuXe.Checked)
                choose = 3;
            ChangeResult(choose);
        }

        private void Search_Changed(object sender, EventArgs e)
        {
            ChangeResult(choose);
        }

        private void ChangeResult(int index)
        {
            DataTable dt = new DataTable();

            switch (index)
            {
                case 1:
                    dt = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE BienSo like '%" + Text_Search.Text + "%'");
                    break;
                case 2:
                    dt = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenHieuXe like '%" + Text_Search.Text + "%'");
                    break;
                case 3:
                    dt = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenChuXe like '%" + Text_Search.Text + "%'");
                    break;

            }
            if (Text_Search.Text == "")
                loadbang(sql);
            else
                dtGV_tracuu.DataSource = dt;

            dtGV_tracuu.Update();
            dtGV_tracuu.Refresh();
        }
    }
}
