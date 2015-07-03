using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLiGara.DAL;

namespace QuanLiGara.BLL
{
    class login
    {
        Connection db = new Connection();
        public DataTable getInfo(string user, string pass)
        {
            return db.getDS("Select * from Account where UserName = '" + user + "'" + " and PassWord = '" + pass + "'");
        }
    }
}
