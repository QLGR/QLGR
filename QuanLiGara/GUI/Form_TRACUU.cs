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
using QuanLiGara.sql;
namespace QuanLiGara
{
    public partial class Form_TRACUU : Office2007Form
    {
        tracuu tcSql = new tracuu();
        public Form_TRACUU()
        {
            InitializeComponent();
        }

        int choose = 0;

        private void Form_TRACUU_Load(object sender, EventArgs e)
        {
            dtGV_tracuu.DataSource = tcSql.getInfo();
        }

        private void Checked_Change(object sender, EventArgs e)
        {
            if (rbBienSo.Checked)
                choose = 1;
            if (rbHieuXe.Checked)
                choose = 2;
            if (rbChuXe.Checked)
                choose = 3;
            if (rbAll.Checked)
                choose = 0;
        }

        private void Search_Changed(object sender, EventArgs e)
        {
            dtGV_tracuu.DataSource = tcSql.TraCuu(choose, Text_Search.Text);
        }
    }
}
