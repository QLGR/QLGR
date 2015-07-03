using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using QuanLiGara.DAL;

namespace QuanLiGara.BLL
{
    class account
    {
        Connection db = new Connection();
        public DataTable getInfo()
        {
            return db.getDS("select UserName, Loai from Account");
        }

        public void deleteAcount(string username)
        {
            db.getDS("delete Account where Username ='" + username + "'");
        }

        public void setLoai(string usenew, string loai, string userold)
        {
           db.getDS("Update Account set Username='" + usenew + "', Loai = '" + loai + "' where Username='" + userold + "'");
        }

        public void setAll(string usenew, string pass, string loai, string userold)
        {
            db.getDS("Update Account set Username='" + usenew + "', Password ='" + pass + "', Loai = '" + loai + "' where Username='" + userold + "'");
        }

        public void Insert(string user, string pass, string loai)
        {
            db.getDS("Insert Account values ('" + user + "','" + pass + "','" + loai + "')");
        }
        
    }
}
