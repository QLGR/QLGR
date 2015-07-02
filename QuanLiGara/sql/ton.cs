using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QuanLiGara.sql
{
    class ton
    {
        Connection db = new Connection();
        public DataTable getTon(string thang)
        {
            return db.getDS("execute BaoCaoTon '" + thang + "'");
        }
    }
}
