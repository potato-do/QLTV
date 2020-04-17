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

namespace QLTV
{
    public partial class Form1 : Form
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=ADMIN;Initial Catalog=QLThuVien;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            custombutton();
        }
//drop down button
    //ẩn hiện panel 
        private void custombutton()
        {
            
            panelThuVien.Visible = false;
            panelQL.Visible = false;
        }
        private void hidebutton()
        {
           
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
      

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            
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
            this.panelMain.Controls.Clear();
            thanhVien tv = new thanhVien();
            this.panelMain.Controls.Add(tv);
            tv.Show();
            btnCloseM_Click(sender, e);
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
        

       
        private void btn_NhanVien_click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            nhanVien n = new nhanVien();
            this.panelMain.Controls.Add(n);
            n.Show();
            btnCloseM_Click(sender, e);
            hidebutton();
        }

        private void btn_MuonTra_click(object sender, EventArgs e)
        {
            muonSachForm muonSach = new muonSachForm();
            muonSach.Show();
            btnCloseM_Click(sender, e);
            hidebutton();
        }

        private void btnNCC_click(object sender, EventArgs e)
        {
            hidebutton();
        }
        private void btnTra_Click(object sender, EventArgs e)
        {
            FormTraSach traSach = new FormTraSach();
            traSach.Show();
            btnCloseM_Click(sender,e);
            hidebutton();
        }
        private void btnTheoDoi_Click(object sender, EventArgs e)
        {
            this.panelMain.Controls.Clear();
            theoDoiMuonTra theoDoi = new theoDoiMuonTra();
            this.panelMain.Controls.Add(theoDoi);
            btnCloseM_Click(sender, e);
            hidebutton();
        }
        private void btnMoRongQL_click(object sender, EventArgs e)
        {
            showbutton(panelQL);
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


        // Đổ dữ liệu ra datagridview
        public static void renderData(string query, DataGridView dgv)
        {
            Form1.conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Form1.conn.Close();
            dgv.DataSource = dt;
        }

        // Thực thi câu lệnh sql
        public static bool executeQuery(string query)
        {
            Form1.conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            com.CommandType = CommandType.Text;
            try
            {
                com.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                Form1.conn.Close();
            }
        }
        // 
        public static void getComboboxString(string query, ComboBox cb)
        {
            int count = 0;
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count != 0)
            {
                String[] ArrayData = new string[1000];
                foreach (DataRow row in dt.Rows)
                {
                    String a;
                    a = row[0].ToString();
                    ArrayData[count] = a;
                    count++;
                }
                for (int i = 0; i < count; i++)
                {
                    cb.Items.Add(ArrayData[i]);
                }
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        // 
        public static void getComboboxInt(string query, ComboBox cb)
        {
            int count = 0;
            conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string a;
                    a = row[0].ToString();
                    count = Int32.Parse(a);

                }
                for (int i = 0; i <= count; i++)
                {
                    cb.Items.Add(i);
                }
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }


        //Hàm lấy 1 string từ database
        public static string getStringFromDB(string query)
        {
            string stringOut = "";
            Form1.conn.Open();
            SqlCommand com = new SqlCommand(query, conn);
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            conn.Close();
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    stringOut = row[0].ToString();
                }
            }
            return stringOut;
        }
    }
}
