using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class themKeSach : Form
    {
        public themKeSach()
        {
            InitializeComponent();
        }
        void getMaKe()
        {
            string query;
            query = "select top (1) MaKe from Ke order by MaKe desc";
            string maKe = Form1.getStringFromDB(query);
            if (maKe == "")
            {
                txtMaKe.Text = "1";
            }
            else
            {
                maKe = (Int32.Parse(maKe) + 1).ToString();
                txtMaKe.Text = maKe;
            }
        }
        private void themKeSach_Load(object sender, EventArgs e)
        {
            getMaKe();
            clear();
        }
        private void clear()
        {
            
            txtSLSach.Clear();
            txtChatLieu.Clear();
            txtSucChua.Clear();
            txtMaKe.Text = (Int32.Parse(txtMaKe.Text) + 1).ToString();
        }
        private void btnThemMoiKeSach_Click(object sender, EventArgs e)
        {   
            
            if (txtMaKe.Text == "" || txtChatLieu.Text == "" || txtSucChua.Text == "" || txtSLSach.Text == "")
            {
                MessageBox.Show("Nhập thiếu dữ liệu!!!");
               
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtMaKe.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtChatLieu.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtSucChua.Text;
                dataGridView1.Rows[n].Cells[3].Value = txtSLSach.Text;
                clear();
            }
            
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                SqlCommand cmd = new SqlCommand(@"insert into Ke(MaKe,ChatLieu,SLChua,SLSach) values('" + dataGridView1.Rows[i].Cells[0].Value + "',  N'" + dataGridView1.Rows[i].Cells[1].Value + "','" + dataGridView1.Rows[i].Cells[2].Value + "','" + dataGridView1.Rows[i].Cells[3].Value + "')", Form1.conn);
                Form1.conn.Open();
                cmd.ExecuteNonQuery();
                Form1.conn.Close();
            }
            MessageBox.Show("Đã thêm mới thành công");
            dataGridView1.Rows.Clear();
        }
    }
}
