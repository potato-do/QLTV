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
    public partial class thuvien : UserControl
    {
        public thuvien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            formThemSach themSach = new formThemSach();
            themSach.Show();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            //Đổ dữ liệu ra form
            string query;
            query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe from Sach as s "
                    + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                    + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe";
            Form1.renderData(query, dataGridView1);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //Đổ dữ liệu ra form
            string query;
            query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe from Sach as s "
                    + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                    + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe";
            Form1.renderData(query, dataGridView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        //Xóa sách khỏi database
        private void deleteData()
        {
            string query;
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            string message = "Xóa sách sẽ làm mất dũ liệu mượn trả liên quan. \n Xác nhận xóa Sách khỏi danh sách?";
            string title = "Validate";
            DialogResult result = MessageBox.Show(message, title, btn);
            if (result == DialogResult.Yes)
            {
                string maSach = dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString();
                query = "Delete CTMuonTra where MaSach = " + maSach;
                Form1.executeQuery(query);
                query = "Delete Sach where MaSach = " + maSach;
                Form1.executeQuery(query);
                //Update vào bảng kệ sách ->> thêm sau
                query = "Update vào bảng kệ sách ->> thêm sau";
                MessageBox.Show("Xóa dữ liệu thành công!!!");
            }
        }

        
    }
}
