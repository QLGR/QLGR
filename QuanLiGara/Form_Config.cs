using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Runtime.InteropServices;
using System.IO;
namespace QuanLiGara
{
    public partial class Form_Config : DevComponents.DotNetBar.RibbonForm
    {
        public Form_Config()
        {
            InitializeComponent();
        }
      
        private void Form_Config_Load(object sender, EventArgs e)
        {

            if (!File.Exists("Server.txt"))//kiểm tra nếu chưa có file Pass.txt thì tạo ra file Pass.txt
            {
                FileStream fs;
                fs = new FileStream("Server.txt", FileMode.Create);//Tạo file mới tên là Pass.txt
                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);

                sWriter.WriteLine("IPHONE6");
                sWriter.Flush();
                fs.Close();
            }



            string[] lines = File.ReadAllLines("Server.txt");
            

                Text_tenserver.Text = lines[0];

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            FileStream fs;
            fs = new FileStream("Server.txt", FileMode.Create);//Tạo file mới tên là Pass.txt
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);

            sWriter.WriteLine(Text_tenserver.Text);
            sWriter.Flush();
            fs.Close();
            MessageBox.Show("Đã Lưu Thiết Lập");
             
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}