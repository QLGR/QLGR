using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLiGara.DAL;

namespace QuanLiGara.sql
{
    class tracuu
    {
        Connection db = new Connection();
        public DataTable getInfo()
        {
            return db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                            "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX");
        }

        public DataTable TraCuu(int choose, string keyword)
        {
            switch (choose)
            {
                case 1:
                    return db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE BienSo like '%" + keyword + "%'");
                    break;
                case 2:
                    return db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenHieuXe like '%" + keyword + "%'");
                    break;
                case 3:
                    return db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenChuXe like '%" + keyword + "%'");
                    break;
                default:
                    return db.getDS("SELECT DANHSACHXE.*,HOSOSUACHUA.BienSo,HIEUXE.TenHieuXe,HOSOSUACHUA.TenChuXe " +
                              "FROM HOSOSUACHUA INNER JOIN DANHSACHXE ON DANHSACHXE.MaHSSC=HOSOSUACHUA.MaHSSC INNER JOIN HIEUXE ON HOSOSUACHUA.MaHX= HIEUXE.MaHX" +
                              " WHERE TenChuXe like '%" + keyword + "%' or BienSo like '%" + keyword + "%' or TenHieuXe like '%" + keyword + "%'");
                    break;
            }
        }
    }
}
