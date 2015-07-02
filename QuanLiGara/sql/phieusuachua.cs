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
namespace QuanLiGara.sql
{

    public class phieusuachua
    {
        Connection db = new Connection();

        public int ChenhLech()
        {
            DataTable dt = db.getDS("SELECT * FROM THAMSO");
            return Int32.Parse(dt.Rows[0]["ChenhLech"].ToString());
        }

        public DataTable loadbang()
        {
            return db.getDS("SELECT PHIEUSUACHUA.*,VATTU.TenVatTu,TIENCONG.TenCongViec,TIENCONG.TienCong FROM PHIEUSUACHUA INNER JOIN VATTU ON PHIEUSUACHUA.MaVatTu=VATTU.MaVatTu INNER JOIN TIENCONG ON PHIEUSUACHUA.MaTienCong=TIENCONG.MaTienCong");
        }

        public DataTable GetAll(string table)
        {
            return db.getDS("SELECT * FROM " + table);
        }

        public void setTongCong(string sum, string bienso)
        {
            db.getDS("update HOSOSUACHUA set TongCong = '" + sum + "' where BienSo = '" + bienso + "'");
        }

        public string mavt(String ten)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU where TenVatTu like N'" + ten + "'");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["MaVatTu"].ToString();
            else
                return "";
        }

        public bool Them(PhieuSuaChuasql psc)
        {
            
            string[] param = {"@MaPhieuSC", "@NoiDung", "@MaVatTu", "@SoLuong", "@MaTienCong", "@ThanhTien", "@MaHSSC", "@NgaySuaChua"};
            object[] value = { psc.MaPSC, psc.NoiDung, psc.MaVatTu, psc.SoLuong, psc.MaTienCong, psc.ThanhTien, psc.MaHSSC, psc.NgaySuaChua};
            string query = "Insert INTO PHIEUSUACHUA (MaPhieuSC,NoiDung,MaVatTu,SoLuong,MaTienCong,ThanhTien,MaHSSC,NgaySuaChua) " +
                                                "VALUES (@MaPhieuSC,@NoiDung,@MaVatTu,@SoLuong,@MaTienCong,@ThanhTien,@MaHSSC,@NgaySuaChua)";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public string Sum(String hssc)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select SUM(ThanhTien)[TongCong] from PHIEUSUACHUA where MaHSSC = '"+hssc+"'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
                
            return "0";
        }

        public bool Sua(PhieuSuaChuasql psc)
        {
            string[] param = { "@MaPhieuSC", "@NoiDung", "@MaVatTu", "@SoLuong", "@MaTienCong", "@ThanhTien", "@MaHSSC", "@NgaySuaChua" };
            object[] value = { psc.MaPSC, psc.NoiDung, psc.MaVatTu, psc.SoLuong, psc.MaTienCong, psc.ThanhTien, psc.MaHSSC, psc.NgaySuaChua };
            string query = "Update PHIEUSUACHUA set NoiDung = @NoiDung,MaVatTu = @MaVatTu,SoLuong = @SoLuong,"+
                                    "MaTienCong = @MaTienCong,ThanhTien = @ThanhTien,MaHSSC = @MaHSSC,NgaySuaChua = @NgaySuaChua"+
                                    " where MaPhieuSC = @MaPhieuSC";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool Xoa(string MaPSC)
        {
            string[] param = { "@MaPhieuSC" };
            object[] value = { MaPSC };
            string query = "Delete from PHIEUSUACHUA where MaPhieuSC=@MaPhieuSC";
            return db.ExecuteNonQueryPara(query, param, value);
        }
        public string MaVatTu(string tenvattu)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU");
            foreach (DataRow dr in dt.Rows)
            {
                if (tenvattu == dr["TenVatTu"].ToString())
                {
                    return dr["MaVatTu"].ToString();
                }
            }
            return "";
        }
        public string SLVatTuPN(string mapn)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from PHIEUSUACHUA where MaPhieuSC = '"+mapn+"'");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["SoLuong"].ToString();
            return "0";
        }

        public string SLVatTu(string mavt)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU where MaVatTu = '" + mavt + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["SoLuong"].ToString();
            }
            return "0";
        }
        public string SearchDaTaGrid()
        {
            int Count = 0;
            string MaPSC = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaPhieuSC From PHIEUSUACHUA");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "PSC" + i;
                    string spsc = dt.Rows[j]["MaPhieuSC"].ToString();
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
                    MaPSC = "PSC" + i;
                    break;
                }
            }
            return MaPSC;
        }
    }

}
public class PhieuSuaChuasql
{
    public string MaPSC = "";
    public string NoiDung = "";
    public string MaVatTu = "";
    public string SoLuong = "";
    public string MaTienCong = "";
    public string ThanhTien = "";
    public string MaHSSC = "";
    public DateTime NgaySuaChua = new DateTime(2015,6,6);
}