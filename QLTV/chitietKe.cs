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
    public partial class chitietKe : Form
    {
        public chitietKe()
        {
            InitializeComponent();
            
        }

        private void chitietKe_Load(object sender, EventArgs e)
        {
            cbBoLoc.Items.Add("Mã sách");
            cbBoLoc.Items.Add("Tên sách");
            cbBoLoc.Items.Add("Loại sách");
            cbBoLoc.Items.Add("Tác giả");
            cbBoLoc.Items.Add("Nhà xuất bản");
            cbBoLoc.Items.Add("Kệ");
            searchBook();
            
        }
        private void searchBook()
        {
            string query;
            string text = txtSearch.Text;
            if (cbBoLoc.SelectedIndex == 0)
            {
                query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                   + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                   + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe where s.MaSach like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedIndex == 1)
            {
                query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                   + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                   + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe where s.TenSach like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedIndex == 2)
            {
                query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                   + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                   + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe where tl.TenTL like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedIndex == 3)
            {
                query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                   + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                   + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe where tg.TenTG like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedIndex == 4)
            {
                query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                   + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                   + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe where nxb.TenNXB like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedIndex == 5)
            {
                query = "Select s.MaSach, s.TenSach, tg.TenTG, tl.TenTL, nxb.TenNXB, k.MaKe, s.soLuong, s.NamXuatBan from Sach as s "
                   + " join NhaXuatBan as nxb on s.MaNXB = nxb.MaNXB join TheLoai as tl on tl.MaTL = s.MaTL"
                   + " join TacGia as tg on tg.MaTG = s.MaTG join Ke as k on k.MaKe = s.MaKe where k.MaKe like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                searchBook();
            }
        }
    }
}
