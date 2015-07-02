
using System.Collections.Generic;
using System.ComponentModel;
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
    class nhaphangsql
    {

        Connection db = new Connection();
        public bool ThemMaTT(nhaphang mtt)
        {

            string[] param = { "@MaNH", "@TenNCC", "@DiaChi", "@DienThoai", "@NgayNhapHang", "@TongCong", "@Email" };
            object[] value = { mtt.MaNH, mtt.NhaCC, mtt.DiaChi, mtt.DienThoai, mtt.NgayThuTien, mtt.TongTien, mtt.Email };
            string query = "Insert INTO HOSONHAPHANG (MaNH,TenNCC,DiaChi,DienThoai,NgayNhapHang,TongCong,Email) VALUES (@MaNH, @TenNCC, @DiaChi, @DienThoai,@NgayNhapHang,@TongCong,@Email)";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public DataTable GetAll(string table)
        {
            return db.getDS("SELECT * FROM " + table);
        }

        public String Vattu(string mavattu)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from VATTU where MaVatTu like N'" + mavattu + "'");
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["TenVatTu"].ToString();
            else
                return "";
        }

        public DataTable loadbangNH(string maNH)
        {
            return db.getDS("select * from HOSONHAPHANG where MaNH = '" + maNH + "'");
        }

        public DataTable loadbang(string mahosonh)
        {
            return db.getDS("Select * from PHIEUNHAPHANG where Manh = '" + mahosonh + "'");
        }

        public DataTable getVatTuTen(string tenVT)
        {
            return db.getDS("Select * From VATTU where TenVatTu like N'" + tenVT + "'");
        }

        public DataTable getVatTuMa(string maVT)
        {
            return db.getDS("Select * From VATTU where MaVatTu ='" + maVT + "'");
        }
        
        public bool SuaNH(nhaphang mtt)
        {
            string[] param = { "@MaNH", "@TenNCC", "@DiaChi", "@DienThoai", "@NgayNhapHang", "@TongCong", "@Email" };
            object[] value = { mtt.MaNH, mtt.NhaCC, mtt.DiaChi, mtt.DienThoai, mtt.NgayThuTien, mtt.TongTien, mtt.Email };
            string query = "Update HOSONHAPHANG set TongCong = @TongCong,TenNCC = @TenNCC," +
                                    "NgayNhapHang = @NgayNhapHang, DiaChi = @DiaChi, DienThoai = @DienThoai,Email = @Email" +
                                    " where MaNH = @MaNH";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool XoaNH(string MaNH)
        {
            string[] param = { "@MaNH" };
            object[] value = { MaNH };
            string query = "Delete from HOSONHAPHANG where MaNH=@MaNH";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool ThemPhieuNH(nhaphang mtt)
        {

            string[] param = { "@MaPhieuNhap", "@MaVatTu", "@SoLuong", "@ThanhTien", "@MaNH" };
            object[] value = { mtt.MaPN, mtt.MaVT, mtt.SoLuong, mtt.ThanhTien, mtt.MaNH };
            string query = "Insert INTO PHIEUNHAPHANG (MaPhieuNhap,MaVatTu,SoLuong,ThanhTien,MaNH) VALUES (@MaPhieuNhap,@MaVatTu,@SoLuong,@ThanhTien,@MaNH)";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public string SumThanhTien(String MaNH)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select SUM(ThanhTien)[TongCong] from PHIEUNHAPHANG where MaNH = '" + MaNH + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }

            return "0";
        }

        public DataTable SumVatTu(string manh)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select MaVatTu, SUM(SoLuong)[SoLuong] from PHIEUNHAPHANG where MaNH = '"+manh+"' Group by MaVatTu ");
            if (dt.Rows.Count > 0)
            {
                return dt;
            }

            return null;
        }

        public bool SuaPN(nhaphang mtt)
        {
            string[] param = { "@MaPhieuNhap", "@MaVatTu", "@SoLuong", "@ThanhTien", "@MaNH" };
            object[] value = { mtt.MaPN, mtt.MaVT, mtt.SoLuong, mtt.ThanhTien, mtt.MaNH };
            string query = "Update PHIEUNHAPHANG set MaVatTu = @MaVatTu ," +
                "SoLuong = @SoLuong , ThanhTien = @ThanhTien, MaNH = @MaNH where MaPhieuNhap = @MaPhieuNhap";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool XoaPN(string MaPhieuNhap)
        {
            string[] param = { "@MaPhieuNhap" };
            object[] value = { MaPhieuNhap };
            string query = "Delete from PHIEUNHAPHANG where MaPhieuNhap=@MaPhieuNhap";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public string SearchDaTaGridNH()
        {
            int Count = 0;
            string MaNH = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaNH From HOSONHAPHANG");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "HSNH" + i;
                    string spsc = dt.Rows[j]["MaNH"].ToString();
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
                    MaNH = "HSNH" + i;
                    break;
                }
            }
            return MaNH;
        }

        public string SearchDaTaGridPN()
        {
            int Count = 0;
            string MaPNH = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaPhieuNhap From PHIEUNHAPHANG");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "PNH" + i;
                    string spsc = dt.Rows[j]["MaPhieuNhap"].ToString();
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
                    MaPNH = "PNH" + i;
                    break;
                }
            }
            return MaPNH;
        }

    }


}

class nhaphang
{
    public string MaNH = "";
    public string NhaCC = "";
    public string DiaChi = "";
    public string DienThoai = "";
    public string Email = "";
    public string TongTien = "";
    public DateTime NgayThuTien = new DateTime(2015, 6, 6);


    public string MaPN = "";
    public string MaVT = "";
    public string SoLuong = "";
    public string ThanhTien = "";





}