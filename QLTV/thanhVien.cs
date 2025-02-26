﻿using System;
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
    public partial class thanhVien : UserControl
    {
        public thanhVien()
        {
            InitializeComponent();
        }

        private void btnThemMoiThanhVien_Click(object sender, EventArgs e)
        {
            themThanhVien themMoi = new themThanhVien();
            themMoi.Show();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            //Load du lieu ra form
            string query;
            query = "Select * from DocGia";
            Form1.renderData(query, dataGridView1);

            cbBoLoc.Items.Add("Mã độc giả");
            cbBoLoc.Items.Add("Tên độc giả");
            cbBoLoc.Items.Add("Số điện thoại");

        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //Load du lieu ra form
            string query;
            query = "Select * from DocGia";
            Form1.renderData(query, dataGridView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            searchCustomer();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            moveData();
        }

        private void btnSuaThanhVien_Click(object sender, EventArgs e)
        {
            updateData();
        }

        //Hàm xóa độc giả khỏi database
        private void deleteData()
        {
            string query;
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            string message = "Xác nhận xóa độc giả khỏi danh sách?";
            string title = "Validate";
            DialogResult result = MessageBox.Show(message, title, btn);
            if (result == DialogResult.Yes)
            {
                string maDG = dataGridView1.CurrentRow.Cells["MaDG"].Value.ToString();
                query = "delete DocGia Where MaDG = " + maDG;
                Form1.executeQuery(query);
                MessageBox.Show("Xóa dữ liệu thành công!!!");
            }
        }

        //hàm tìm kiếm độc giả theo bộ lọc
        private void searchCustomer()
        {
            string query;
            string text = txtSearch.Text;
            if(cbBoLoc.SelectedIndex == 0)
            {
                query = "Select * from DocGia where MaDG like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedIndex == 1)
            {
                query = "Select * from DocGia where HoTen like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedIndex == 2)
            {
                query = "Select * from DocGia where SDT like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
        }

        
        //Chuyển data từ view lên textbox
        private void moveData()
        {
            txtMaDG.Text = dataGridView1.CurrentRow.Cells["MaDG"].Value.ToString();
            txtHoTen.Text = dataGridView1.CurrentRow.Cells["HoTen"].Value.ToString();
            txtDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            cbGioiTinh.Text = dataGridView1.CurrentRow.Cells["GT"].Value.ToString();
            txtSDT.Text = dataGridView1.CurrentRow.Cells["SDT"].Value.ToString();
        }

        
        //Update data vào database
        private void updateData()
        {
            string query;
            string maDG = txtMaDG.Text;
            string tenDG = txtHoTen.Text;
            string diaChi = txtDiaChi.Text;
            string gTinh = cbGioiTinh.Text;
            string sdt = txtSDT.Text;
            string ngaySinh = dateTimePicker1.Value.ToString("yyyyMMdd");

            query = "update DocGia set HoTen = N'" + tenDG + "', DiaChi = N'" + diaChi + "', GT = N'" + gTinh + "', SDT = '" + sdt + "', NgaySinh = '" + ngaySinh + "' where MaDG = " + maDG;
            Form1.executeQuery(query);
            MessageBox.Show("Cập nhật thông tin thành công");
        }
    }
}
