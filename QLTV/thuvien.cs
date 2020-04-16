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
            query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                    + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                    + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe";
            Form1.renderData(query, dataGridView1);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //Đổ dữ liệu ra form
            string query;
            query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                    + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                    + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe";
            Form1.renderData(query, dataGridView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            moveDataToTextBox();
            loadComboBox();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            updateData();
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

        private void moveDataToTextBox()
        {
            txtMaS.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenS.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtTenTG.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbTheLoai.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbNhaXB.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbViTri.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSL.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtNamXB.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
        }

        private void loadComboBox()
        {
            string query;
            query = "Select TenNXB from NhaXuatBan";
            Form1.getComboboxString(query, cbNhaXB);
            query = "Select TenTL from TheLoai";
            Form1.getComboboxString(query, cbTheLoai);
            query = "Select MaKe from Ke";
            Form1.getComboboxInt(query, cbViTri);
        }

        //Cập nhật dữ liệu sách vào database
        private void updateData()
        {
            string query;
            string maSach = txtMaS.Text;
            string tenSach = txtTenS.Text;
            string tenTG = txtTenTG.Text;
            string tenTL = cbTheLoai.Text;
            string tenNXB = cbNhaXB.Text;
            string MaKe = cbViTri.Text;
            string soLuong = txtSL.Text;
            string namXB = txtNamXB.Text;

            //Giam so luong sach tren ke tuong ung 
            query = "Select SLSach from Ke where MaKe = " + MaKe;
            string soLuongSachTrenKe = Form1.getStringFromDB(query);
            soLuongSachTrenKe = (Int32.Parse(soLuongSachTrenKe) - Int32.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString())).ToString();
            //Lấy mã nhà xuất bản từ tên nxb
            query = "Select MaNXB from NhaXuatBan where TenNXB = N'" + tenNXB + "'";
            string maNXB = Form1.getStringFromDB(query);
            //Lấy mã tác giả từ tên tác giả
            query = "Select MaTG from TacGia where TenTG = N'" + tenTG + "'";
            string maTG = Form1.getStringFromDB(query);
            //Nếu tác giả chưa tồn tại trong cơ sơ dữ liệu -> insert thêm 
            if (maTG == "")
            {
                query = "Select top (1) MaTG from TacGia order by MaTG desc";
                maTG = (Int32.Parse(Form1.getStringFromDB(query)) + 1).ToString();
                query = "Insert into TacGia values (" + maTG + ", N'" + tenTG + "','')";
                Form1.executeQuery(query);
            }
            //Lấy mã thể loại từ tên thể loại
            query = "Select MaTL from TheLoai where TenTL = N'" + tenTL + "'";
            string maTL = Form1.getStringFromDB(query);
            
            query = "Update Sach set TenSach = N'" + tenSach + "', MaTG = " + maTG + ", MaTL = " + maTL + ", MaNXB = " + maNXB
                    + ", MaKe = " + MaKe + ", SoLuong = " + soLuong + ", NamXuatBan = '" + namXB + "' where MaSach = " + maSach;
            Form1.executeQuery(query);

            soLuongSachTrenKe = (Int32.Parse(soLuongSachTrenKe) + Int32.Parse(soLuong)).ToString();
            query = "Update Ke set SLSach = " + soLuongSachTrenKe + " where MaKe = " + MaKe;
            Form1.executeQuery(query);

            query = "Update Ke SLSach = ";
            MessageBox.Show("Cập nhật thông tin thành công!!");
        }

        
    }
}
