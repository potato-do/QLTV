using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class NXB : UserControl
    {
        public NXB()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themNXB n = new themNXB();
            n.Show();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            //load dữ liệu ra form 
            string query;
            query = "Select * from NhaXuatBan";
            Form1.renderData(query, dataGridView1);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //load dữ liệu ra form 
            string query;
            query = "Select * from NhaXuatBan";
            Form1.renderData(query, dataGridView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            moveDataToTextBox();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            updateData();
        }

        //Xóa nhà xuất bản khỏi database
        private void deleteData()
        {
            string query;
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            string message = "Xác nhận xóa nhà xuất bản khỏi danh sách?";
            string title = "Validate";
            DialogResult result = MessageBox.Show(message, title, btn);
            if (result == DialogResult.Yes)
            {
                string maNXB = dataGridView1.CurrentRow.Cells["MaNXB"].Value.ToString();
                query = "delete NhaXuatBan Where MaNXB = " + maNXB;
                Form1.executeQuery(query);
                MessageBox.Show("Xóa dữ liệu thành công!!!");
            }
        }

        
        //Load data từ gridview sang textbox
        private void moveDataToTextBox()
        {
            txtMaNXB.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenNXB.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDC.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        

        //Cập nhật dữ liệu vào database
        private void updateData()
        {
            string query;
            string maNXB = txtMaNXB.Text;
            string tenNXB = txtTenNXB.Text;
            string diaChi = txtDC.Text;
            string mail = txtMail.Text;
            string sdt = txtSDT.Text;

            query = "Update NhaXuatBan set TenNXB = N'" + tenNXB + "', DiaChi = N'" + diaChi + "', Email = '" + mail + "', SDT =" + sdt + " where MaNXB = " + maNXB;
            Form1.executeQuery(query);
            MessageBox.Show("Cập nhật dữ liệu thành công!!");
        }
    }
}
