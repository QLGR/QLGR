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
    class doanhso
    {
        Connection db = new Connection();
        public DataTable getDoanhSo(string thang)
        {
            return db.getDS("execute BaoCaoDoanhThu '" + thang + "'");
        }
    }
}
