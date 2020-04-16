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
    public partial class formThemSach : Form
    {
        public formThemSach()
        {
            InitializeComponent();
        }

        private void btnThanhVien_Click(object sender, EventArgs e)
        {
            moveData();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            getMaSach();
            loadComboBox();
        }

        private void getMaSach()
        {
            string query;
            query = "select top (1) MaSach from Sach order by MaSach desc";
            string maSach = Form1.getStringFromDB(query);
            if (maSach == "")
            {
                txtMaS.Text = "1";
            }
            else
            {
                maSach = (Int32.Parse(maSach) + 1).ToString();
                txtMaS.Text = maSach;
            }
        }

        //Hàm load dữ liệu ra combobox
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            removeData();
        }

        private void moveData()
        {
            string maSach = txtMaS.Text;
            string tenSach = txtTenS.Text;
            string tacGia = txtTenTG.Text;
            string theLoai = cbTheLoai.Text;
            string tenNXB = cbNhaXB.Text;
            string namXB = txtNamXB.Text;
            string maKe = cbViTri.Text;
            string soTrang = txtST.Text;
            string soLuong = txtSL.Text;
            if(tenSach == "" || tacGia == "" || theLoai == "" || tenNXB == "" || namXB == "" || maKe == "" || soTrang == "" || soLuong == "")
            {
                MessageBox.Show("Nhập thiếu dữ liệu!!!");
            }
            else
            {
                int count = dataGridView1.RowCount;
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[count].Cells[0].Value = (count + 1).ToString();
                dataGridView1.Rows[count].Cells[1].Value = maSach;
                dataGridView1.Rows[count].Cells[2].Value = tenSach;
                dataGridView1.Rows[count].Cells[3].Value = tacGia;
                dataGridView1.Rows[count].Cells[4].Value = theLoai;
                dataGridView1.Rows[count].Cells[5].Value = tenNXB;
                dataGridView1.Rows[count].Cells[6].Value = namXB;
                dataGridView1.Rows[count].Cells[7].Value = maKe;
                dataGridView1.Rows[count].Cells[8].Value = soTrang;
                dataGridView1.Rows[count].Cells[9].Value = soLuong;
            }
        }

        //Hàm xóa dữ liệu khỏi gridview
        private void removeData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
            }
        }
    }
}
