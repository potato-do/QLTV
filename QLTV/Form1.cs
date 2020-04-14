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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            custombutton();
        }
//drop down button
    //ẩn hiện panel 
        private void custombutton()
        {
            panelTV.Visible = false;
            panelThuVien.Visible = false;
            panelQL.Visible = false;
        }
        private void hidebutton()
        {
            if (panelTV.Visible == true)
                panelTV.Visible = false;
            if (panelThuVien.Visible == true)
                panelThuVien.Visible = false;
            if (panelQL.Visible == true)
                panelQL.Visible = false;
        }
        private void showbutton(Panel showpanel)
        {
            if (showpanel.Visible == false)
            {
                hidebutton();
                showpanel.Visible = true;
            }
            else
            {
                showpanel.Visible = false;
            }
        }
    //kết thúc ẩn hiện panel
        //set nut mở
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            showbutton(panelThuVien);
        }
        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            showbutton(panelTV);
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            showbutton(panelQL);
        }
//kết thúc dropdown
//đóng mở panel menu
        //đóng
        private void btnCloseM_Click(object sender, EventArgs e)
        {
            if (panelSider.Width == 277)
            {
                btnCloseM.Visible = false;
                panelSider.Visible = true;
                panelSider.Width = 0;
                btnOpenM.Visible = true;

            }
        }
        //mở
        private void btnOpen_click(object sender, EventArgs e)
        {
            if (panelSider.Width == 0)
            {
                btnOpenM.Visible = false;
                panelSider.Visible = false;
                panelSider.Width = 277;
                transpanelMenu.ShowSync(panelSider);
                btnCloseM.Visible = true;
            }

        }
        //kết thúc đóng mở
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //sự kiện click btn
        private void btn_ThemMoiThuVien_click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            keSach keSach = new keSach();
            this.panelMain.Controls.Add(keSach);
            keSach.Show();
            btnCloseM_Click(sender, e);
            hidebutton();
        }

        private void btn_ChinhSuaThuVien_click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            tacGia tacGia = new tacGia();
            this.panelMain.Controls.Add(tacGia);
            tacGia.Show();
            btnCloseM_Click(sender, e);
            hidebutton();
        }

        private void btn_ThanhVien_click(object sender, EventArgs e)
        {
            hidebutton();
        }
        private void btn_NXB_click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            NXB nxb = new NXB();
            this.panelMain.Controls.Add(nxb);
            nxb.Show();
            btnCloseM_Click(sender, e);
            hidebutton();
        }
        private void btn_ThemMoiThanhVien_click(object sender, EventArgs e)
        {
            hidebutton();
        }

        private void btn_ChinhSuaThanhVien_click(object sender, EventArgs e)
        {
            hidebutton();
        }
        private void btn_NhanVien_click(object sender, EventArgs e)
        {
            hidebutton();
        }

        private void btn_MuonTra_click(object sender, EventArgs e)
        {
            hidebutton();
        }

        private void btnNCC_click(object sender, EventArgs e)
        {
            hidebutton();
        }
        private void btnMoRongQL_click(object sender, EventArgs e)
        {

        }

        private void btnTongQuan_Click(object sender, EventArgs e)
        {

        }

        private void btnThuVien_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            thuvien thuvien = new thuvien();
            this.panelMain.Controls.Add(thuvien);
            btnCloseM_Click(sender, e);
            thuvien.Show();
        }



        //btn thoát
        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
