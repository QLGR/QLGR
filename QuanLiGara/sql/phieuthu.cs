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

    public class phieuthusql
    {
        Connection db = new Connection();
        public bool ThemMaTT(phieuthu mtt)
        {

            string[] param = { "@MaThuTien", "@Email", "@SoTienThu", "@MaHSSC","@NgayThuTien" };
            object[] value = { mtt.MaThuTien, mtt.Email, mtt.SoTienThu, mtt.MaHSSC,mtt.NgayThuTien };
            string query = "Insert INTO PHIEUTHUTIEN (MaThuTien,Email,SoTienThu,MaHSSC,NgayThuTien) VALUES (@MaThuTien,@Email,@SoTienThu,@MaHSSC,@NgayThuTien)";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public string Sum(String bienso)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select SUM(ThanhTien)[TongCong] from phieuthu where MaHSSC = '" + bienso + "'");
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }

            return "0";
        }

        public bool SuaMaTT(phieuthu mtt)
        {
            string[] param = { "@MaThuTien", "@Email", "@SoTienThu", "@MaHSSC", "@NgayThuTien" };
            object[] value = { mtt.MaThuTien, mtt.Email, mtt.SoTienThu,mtt.MaHSSC, mtt.NgayThuTien };
            string query = "Update PHIEUTHUTIEN set Email = @Email,SoTienThu = @SoTienThu,MaHSSC = @MaHSSC," +
                                    "NgayThuTien = @NgayThuTien" +
                                    " where MaThuTien = @MaThuTien";
            return db.ExecuteNonQueryPara(query, param, value);
        }

        public bool XoaMaTT(string MaThuTien)
        {
            string[] param = { "@MaThuTien" };
            object[] value = { MaThuTien };
            string query = "Delete from PHIEUTHUTIEN where MaThuTien=@MaThuTien";
            return db.ExecuteNonQueryPara(query, param, value);
        }


        public bool checkBienSo(String bienso)
        {
            DataTable dt = new DataTable();
            dt = db.getDS("Select * from PHIEUTHUTIEN where MaHSSC = '" + bienso + "'");
            if (dt.Rows.Count > 0)
                return true;
            return false;
        }

        public string SearchDaTaGrid()
        {
            int Count = 0;
            string MaPT = "";
            DataTable dt = new DataTable();//tao bang tam de luu
            dt = db.getDS("Select MaThuTien From PHIEUTHUTIEN");
            for (int i = 1; true; i++)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    string s = "PTT" + i;
                    string spsc = dt.Rows[j]["MaThuTien"].ToString();
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
                    MaPT = "PTT" + i;
                    break;
                }
            }
            return MaPT;
        }
    }

}
public class phieuthu
{
    public string MaThuTien = "";
    public string Email = "";
    public string SoTienThu = "";
    public string MaHSSC = "";
    public DateTime NgayThuTien = new DateTime(2015, 6, 6);
}