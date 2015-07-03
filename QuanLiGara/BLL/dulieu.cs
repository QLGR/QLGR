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
using QuanLiGara.DAL;

namespace QuanLiGara.sql
{

    public class dulieusql
    {
        public string MaVT = "";
        public string TenVT = "";
        public string DonGia = "";
        public string MaTC = "";
        public string TenCV = "";
        public string TienCong = "";
        public string MaHX = "";
        public string TenHX = "";
        public string Soluong = "";
        Connection db = new Connection();
        public bool ThemVT(dulieusql dl)
        {

            string[] param = { "@MaVatTu", "@TenVatTu", "@DonGia", "@SoLuong"};
            object[] value = {dl.MaVT,dl.TenVT,dl.DonGia,dl.Soluong};
            string query = "Insert INTO VATTU (MaVatTu,TenVatTu,DonGia,SoLuong) VALUES (@MaVatTu,@TenVatTu,@DonGia,@SoLuong)";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public DataTable GetAll(string table)
        {
            return db.getDS("SELECT * FROM " + table);
        }

        public void CapNhat(string max, string chenhlech)
        {
            db.getDS("UPDATE THAMSO SET SuaChuaToiDa='" + max + "', ChenhLech='" + chenhlech + "'");
        }

        public bool SuaVT(dulieusql dl)
        {
            string[] param = { "@MaVatTu", "@TenVatTu", "@DonGia", "@SoLuong"};
            object[] value = { dl.MaVT, dl.TenVT, dl.DonGia, dl.Soluong};
            string query = "UPDATE VATTU SET TenVatTu=@TenVatTu,DonGia=@DonGia,SoLuong=@SoLuong WHERE MaVatTu=@MaVatTu";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool SuaVT(string maVT,string soluong)
        {
            string[] param = { "@MaVatTu", "@SoLuong",};
            object[] value = { maVT,soluong };
            string query = "UPDATE VATTU SET SoLuong = @SoLuong WHERE MaVatTu=@MaVatTu";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool XoaVT(string MaVT)
        {
            string[] param = { "@MaVatTu" };
            object[] value = { MaVT };
            string query = "DELETE FROM VATTU WHERE MaVatTu=@MaVatTu";
            return db.ExecuteNonQueryPara(query, param, value);
        }


        /// <summary>
        /// /Tiền Công
        public bool ThemTC(dulieusql dl)
        {

            string[] param = { "@MaTienCong", "@TenCongViec", "@TienCong"};
            object[] value = { dl.MaTC, dl.TenCV, dl.TienCong};
            string query = "Insert INTO TIENCONG (MaTienCong,TenCongViec,TienCong) VALUES (@MaTienCong,@TenCongViec,@TienCong)";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool SuaTC(dulieusql dl)
        {
            string[] param = { "@MaTienCong", "@TenCongViec", "@TienCong" };
            object[] value = { dl.MaTC, dl.TenCV, dl.TienCong };
            string query = "UPDATE TIENCONG SET TenCongViec=@TenCongViec,TienCong=@TienCong WHERE MaTienCong=@MaTienCong";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool XoaTC(string MaTC)
        {
            string[] param = { "@MaTienCong" };
            object[] value = { MaTC };
            string query = "DELETE FROM TIENCONG WHERE MaTienCong=@MaTienCong";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        /* phần xử lý thêm xóa sửa cho hiệu xe 
         *
         * */
        public bool ThemHX(dulieusql dl)
        {

            string[] param = { "@MaHX","@TenHieuXe"};
            object[] value = { dl.MaHX,dl.TenHX};
            string query = "Insert INTO HIEUXE (MaHX,TenHieuXe) VALUES (@MaHX,@TenHieuXe)";
            return db.ExecuteNonQueryPara(query, param, value);
        }


        public bool SuaHX(dulieusql dl)
        {
            string[] param = { "@MaHX", "@TenHieuXe" };
            object[] value = { dl.MaHX, dl.TenHX };
            string query = "UPDATE HIEUXE SET MaHX=@MaHX,TenHieuXe=@TenHieuXe WHERE MaHX=@MaHX";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool XoaHX(string MaHX)
        {
            string[] param = { "@MaHX" };
            object[] value = { MaHX };
            string query = "DELETE FROM HIEUXE WHERE MaHX=@MaHX";
            return db.ExecuteNonQueryPara(query, param, value);
        }
        /// </summary>
        /// 
        //kiem tra coi phieu sua chua co su dung cong việc này hay không
        public bool CheckExistReference(String MaVT)
        {

            if (db.getDS("SELECT * FROM PHIEUSUACHUA where MaVatTu ='" + MaVT + "'").Rows.Count > 0)
                return true;
            if (db.getDS("SELECT * FROM PHIEUNHAPHANG where MaVatTu ='" + MaVT + "'").Rows.Count > 0)
                return true;
            return false;
        }


        //kiểm tra phiều sửa chữa cò sử dụng công việc này hay không
        public bool CheckExistReferenceTC(String MaTC)
        {

            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM PHIEUSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MaTienCong"].ToString().Equals(MaTC))
                    return true;

            }
            return false;
        }


        public bool CheckExistReferenceHieuXe(String MaHX)
        {

            DataTable dt = new DataTable();
            dt = db.getDS("SELECT * FROM HOSOSUACHUA");
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["MaHX"].ToString().Equals(MaHX))
                    return true;

            }
            return false;
        }

        public string SearchDaTaGrid()
        {
            int Count = 0;
            string MaVT = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaVatTu From VATTU");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "VT" + i;
                    string spsc = dt.Rows[j]["MaVatTu"].ToString();
                    if (!spsc.Equals(s))
                    {
                        Count++;//dem so lan khac
                    }
                    else
                    {
                        Count = 0;
                        break;
                    }
                }
                if (Count == dt.Rows.Count)// new so lan khac bang so hang cua bang, nghia la khong co dong nao trung thi tu dong add
                {
                    MaVT = "VT" + i;
                    break;
                }
            }
            return MaVT;
        }


        // tu dong tao ma cho tien công
        public string SearchDaTaGridTC()
        {
            int Count = 0;
            string MaTC = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaTienCong From TIENCONG");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "TC" + i;
                    string spsc = dt.Rows[j]["MaTienCong"].ToString();
                    if (!spsc.Equals(s))
                    {
                        Count++;//dem so lan khac
                    }
                    else
                    {
                        Count = 0;
                        break;
                    }
                }
                if (Count == dt.Rows.Count)// new so lan khac bang so hang cua bang, nghia la khong co dong nao trung thi tu dong add
                {
                    MaTC = "TC" + i;
                    break;
                }
            }
            return MaTC;
        }
    }

}
