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
using System.Data.SqlClient;
namespace QuanLiGara
{
    public partial class Form_Config : DevComponents.DotNetBar.Office2007Form
    {
        public Form_Config()
        {
            InitializeComponent();
        }
      
        private void Form_Config_Load(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines("Server.txt");
                Text_tenserver.Text = lines[0];
                txtDatabase.Text = lines[1];
                checkBoxX1.Checked = lines[2].Equals("True");
                if (!checkBoxX1.Checked)
                {
                    txtUsername.Text = lines[3];
                    txtPass.Text = lines[4];
                }
            }
            catch
            {
                FileStream fs;
                fs = new FileStream("Server.txt", FileMode.Create);//Tạo file mới tên là Pass.txt
                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);
                sWriter.WriteLine(".\\SQLExpress");
                sWriter.WriteLine("QLGR");
                sWriter.WriteLine("True");
                sWriter.Flush();
                fs.Close();
            }            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {

            SqlConnection connect;
            if (checkBoxX1.Checked)
                connect = new SqlConnection("Data Source=" + Text_tenserver.Text + ";Initial Catalog=" + txtDatabase.Text + ";Integrated Security=True");
            else
                connect = new SqlConnection("Data Source=" + Text_tenserver.Text + ";Initial Catalog=" + txtDatabase.Text + ";uid=" + txtUsername.Text + ";pwd=" + txtPass.Text);
            try
            {
                connect.Open();
                connect.Close();
                FileStream fs;
                fs = new FileStream("Server.txt", FileMode.Create);//Tạo file mới tên là Pass.txt
                StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);

                sWriter.WriteLine(Text_tenserver.Text);
                sWriter.WriteLine(txtDatabase.Text);
                sWriter.WriteLine(checkBoxX1.Checked);
                if (!checkBoxX1.Checked)
                {
                    sWriter.WriteLine(txtUsername.Text);
                    sWriter.WriteLine(txtPass.Text);
                }
                sWriter.Flush();
                fs.Close();
                MessageBox.Show("Đã Lưu Thiết Lập");
                Application.Restart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ket Noi Khong Thanh Cong \n" + ex.Message, "Lỗi Kết Nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }             
        }

        private void checkBoxX1_CheckedChanged(object sender, EventArgs e)
        {
            txtUsername.Enabled = !checkBoxX1.Checked;
            txtPass.Enabled = !checkBoxX1.Checked;
        }

        private void Form_Config_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormCollection fc = Application.OpenForms;
            if (fc.Count == 0)
                Application.Exit();
        }
    }
}