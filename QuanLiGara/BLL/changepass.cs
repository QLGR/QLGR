using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLiGara.DAL;

namespace QuanLiGara.BLL
{
    
    class changepass
    {
        Connection db = new Connection();
        public DataTable getPass()
        {
            return db.getDS("select PassWord from Account where UserName ='" + Form_Main.username + "'");
        }

        public DataTable setPass(string pass)
        {
            return db.getDS("update Account set PassWord = '" + pass + "' where UserName = '" + Form_Main.username + "'");
        }
    }
}
