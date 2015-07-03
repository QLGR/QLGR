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

    public class tiepnhansql
    {
        public string MaHSSC = "";
        public string TenChuXe = "";
        public string Email = "";
        public string BienSo = "";
        public string MaHieuXe = "";
        public string DiaChi = "";
        public string DienThoai = "";
        public DateTime NgayTiepNhan = new DateTime(2015, 6, 6);
        Connection db = new Connection();
        public bool ThemTN(tiepnhansql mtt)
        {

            string[] param = { "@MaHSSC", "@TenChuXe", "@BienSo", "@MaHX", "@DiaChi", "@DienThoai", "@NgayTiepNhan","@TongCong","@Email" };
            object[] value = { mtt.MaHSSC, mtt.TenChuXe, mtt.BienSo, mtt.MaHieuXe, mtt.DiaChi, mtt.DienThoai, mtt.NgayTiepNhan,"0",mtt.Email };
            string query = "Insert INTO HOSOSUACHUA (MaHSSC,TenChuXe,BienSo,MaHX,DiaChi,DienThoai,NgayTiepNhan,TongCong,Email) VALUES (@MaHSSC,@TenChuXe,@BienSo,@MaHX,@DiaChi,@DienThoai,@NgayTiepNhan,@TongCong,@Email)";
            return db.ExecuteNonQueryPara(query, param, value);

        }

        public string Sum(String bienso)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select SUM(ThanhTien)[TongCong] from tiepnhan where MaHSSC = '" + bienso + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }

            return "0";
        }

        public bool SuaTN(tiepnhansql mtt)
        {
            string[] param = { "@MaHSSC", "@TenChuXe", "@BienSo", "@MaHX", "@DiaChi", "@DienThoai", "@NgayTiepNhan","@Email" };
            object[] value = { mtt.MaHSSC, mtt.TenChuXe, mtt.BienSo, mtt.MaHieuXe, mtt.DiaChi, mtt.DienThoai, mtt.NgayTiepNhan,mtt.Email };
            string query = "UPDATE HOSOSUACHUA SET TenChuXe=@TenChuXe,BienSo=@BienSo,MaHX=@MaHX," +
                            "DiaChi=@DiaChi,DienThoai=@DienThoai,NgayTiepNhan=@NgayTiepNhan, Email = @Email WHERE MaHSSC=@MaHSSC";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool XoaTN(string MaHSSC)
        {
            string[] param = { "@MaHSSC" };
            object[] value = { MaHSSC };
            string query = "DELETE FROM HOSOSUACHUA WHERE MaHSSC=@MaHSSC";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool ThemDSX(tiepnhansql mtt)
        {

            string[] param = { "@MaXe", "@MaHSSC", "@TienNo" };
            object[] value = { SearchDaTaGridMX(), mtt.MaHSSC, "0" };
            string query = "Insert INTO DANHSACHXE (MaXe,MaHSSC,TienNo) VALUES (@MaXe,@MaHSSC,@TienNo)";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        
        public bool XoaDSX(string MaHSSC)
        {
            string[] param = { "@MaHSSC" };
            object[] value = { MaHSSC };
            string query = "DELETE FROM DANHSACHXE WHERE MaHSSC=@MaHSSC";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public string SearchDaTaGrid()
        {
            int Count = 0;
            string MaTN = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaHSSC From HOSOSUACHUA");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "HSSC" + i;
                    string spsc = dt.Rows[j]["MaHSSC"].ToString();
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
                    MaTN = "HSSC" + i;
                    break;
                }
            }
            return MaTN;
        }

        public int GetSuaChuaToiDa()
        {
            DataTable dt = db.getDS("SELECT * FROM THAMSO");
            return Int32.Parse(dt.Rows[0]["SuaChuaToiDa"].ToString());
        }

        public DataTable GetAll(string table)
        {
            return db.getDS("SELECT * FROM " + table);
        }

        public string GetTenHieuXE(string MaHX)
        {
            return db.getDS("SELECT TenHieuXe FROM HieuXe where MaHX = '" + MaHX + "'").Rows[0][0].ToString();
        }

        public bool checkBienso(string bienso)
        {
            if (db.getDS("Select * from HOSOSUACHUA where BienSo = '" + bienso + "'").Rows.Count > 0)
                return true;
            return false;
        }

        public string SearchDaTaGridMX()
        {
            int Count = 0;
            string MaTN = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaXe From DanhSachXe");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "MX" + i;
                    string spsc = dt.Rows[j]["MaXe"].ToString();
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
                    MaTN = "MX" + i;
                    break;
                }
            }
            return MaTN;
        }
    }
}