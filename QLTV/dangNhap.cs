using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class dangNhap : Form
    {
        public dangNhap()
        {
            InitializeComponent();
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            userValidate();
        }

        private void userValidate()
        {
            string query;
            string userName = btnTK.Text;
            string passWord = btnMK.Text;
            if(userName == "" || passWord == "")
            {
                MessageBox.Show("Mời bạn nhập đủ tên đăng nhập và mật khẩu!!!");
                clear();
            }
            else
            {
                query = "Select MatKhau from TaiKhoan where TenDangNhap = '" + userName + "'";
                if(passWord == Form1.getStringFromDB(query))
                {
                    Form1 f = new Form1();
                    this.Visible = false;
                    f.ShowDialog();
                    this.Visible = true;
                    clear();
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!!");
                    clear();
                }
            }
        }

        private void clear()
        {
            btnMK.Clear();
            btnTK.Clear();
        }
    }
}
