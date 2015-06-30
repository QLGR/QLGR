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

        Connection db = new Connection();
        int choose = 0;

        private void Form_TRACUU_Load(object sender, EventArgs e)
        {
            dtGV_tracuu.DataSource = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                            "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX"); ;
        }

        private void Checked_Change(object sender, EventArgs e)
        {
            if (rbBienSo.Checked)
                choose = 1;
            if (rbHieuXe.Checked)
                choose = 2;
            if (rbChuXe.Checked)
                choose = 3;
            if (rbAll.Checked)
                choose = 0;
        }

        private void Search_Changed(object sender, EventArgs e)
        {
            switch (choose)
            {
                case 1:
                    dtGV_tracuu.DataSource = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE BienSo like '%" + Text_Search.Text + "%'");
                    break;
                case 2:
                    dtGV_tracuu.DataSource = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenHieuXe like '%" + Text_Search.Text + "%'");
                    break;
                case 3:
                    dtGV_tracuu.DataSource = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenChuXe like '%" + Text_Search.Text + "%'");
                    break;
                default:
                    dtGV_tracuu.DataSource = db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenChuXe like '%" + Text_Search.Text + "%' or BienSo like '%" + Text_Search.Text + "%' or TenHieuXe like '%" + Text_Search.Text + "%'");
                    break;
            }
        }
    }
}
