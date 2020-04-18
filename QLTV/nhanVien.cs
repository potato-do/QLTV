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
    public partial class nhanVien : UserControl
    {
        public nhanVien()
        {
            InitializeComponent();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themNhanVien n = new themNhanVien();
            n.Show();
        }

        private void bunifuCards1_Paint_1(object sender, PaintEventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            moveData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteEmployment();
        }

        //Load data
        private void loadData()
        {
            string query;
            query = "Select * from NhanVien";
            Form1.renderData(query, dataGridView1);
        }

        //Chuyen data tu view len textbox
        private void moveData()
        {
            txtMaNV.Text = dataGridView1.CurrentRow.Cells["MaNV"].Value.ToString();
            txtTen.Text = dataGridView1.CurrentRow.Cells["HoTen"].Value.ToString();
            cbGioiTinh.Text = dataGridView1.CurrentRow.Cells["GT"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
            txtTenDN.Text = dataGridView1.CurrentRow.Cells["TenDangNhap"].Value.ToString();
        }

        //Update data vào database
        private void updateData()
        {
            string query;
            string maNV = txtMaNV.Text;
            string tenNV = txtTen.Text;
            string gTinh = cbGioiTinh.Text;
            string sdt = txtSDT.Text;
            string tenDN = txtTenDN.Text;
            string ngaySinh = dateTimePicker1.Value.ToString("yyyyMMdd");

            query = "Update NhanVien set HoTen = N'" + tenNV + "', GT = N'" + gTinh + "', SDT = '" + sdt + "', NgaySinh = '" + ngaySinh + "', TenDangNhap = '" + tenDN + "' where MaNV = " + maNV;
            Form1.executeQuery(query);
            MessageBox.Show(query);
            MessageBox.Show("Sửa dữ liệu nhân viên thành công!!");
        }

        private void deleteEmployment()
        {
            string query;
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            string message = "Xóa nhân viên sẽ xóa các phiếu mượn trả liên quan đến nhân viên.\n  Xác nhận xóa nhân viên khỏi danh sách?";
            string title = "Validate";
            DialogResult result = MessageBox.Show(message, title, btn);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Tính năng đang được cập nhật");
            }
        }

       
    }
}
