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

        private void btnLuu_Click(object sender, EventArgs e)
        {
            addBook();
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

        //Hàm thêm nhiều sách từ gridview vào database
        private void addBook()
        {
            string query;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string maSach = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string tenSach = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string tenTG = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string theLoai = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string tenNXB = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string namXB = dataGridView1.Rows[i].Cells[6].Value.ToString(); 
                string maKe = dataGridView1.Rows[i].Cells[7].Value.ToString();
                string soLuong = dataGridView1.Rows[i].Cells[9].Value.ToString();

                //Lấy mã nhà xuất bản từ tên nxb
                query = "Select MaNXB from NhaXuatBan where TenNXB = N'" + tenNXB + "'";
                string maNXB = Form1.getStringFromDB(query);
                //Lấy mã tác giả từ tên tác giả
                query = "Select MaTG from TacGia where TenTG = N'" + tenTG + "'";
                string maTG = Form1.getStringFromDB(query);
                //Nếu tác giả chưa tồn tại trong cơ sơ dữ liệu -> insert thêm 
                if(maTG == "")
                {
                    query = "Select top (1) MaTG from TacGia order by MaTG desc";
                    maTG = (Int32.Parse(Form1.getStringFromDB(query)) + 1).ToString();
                    query = "Insert into TacGia values (" + maTG + ", N'" + tenTG + "','')";
                    Form1.executeQuery(query);
                }
                //Lấy mã thể loại từ tên thể loại
                query = "Select MaTL from TheLoai where TenTL = N'" + theLoai + "'";
                string maTL = Form1.getStringFromDB(query);
                //Insert dòng tương ứng vào database
                query = "Insert into Sach values (" + maSach + ", N'" + tenSach + "'," + maTL + "," + maNXB + "," + maTG + "," + maKe + ",'" + namXB + "')";
                Form1.executeQuery(query);
                //Update số lượng sách vào kệ sách
                query = "Select SLSach from Ke where MaKe = " + maKe;
                string soLuongSach = (Int32.Parse(Form1.getStringFromDB(query)) + Int32.Parse(soLuong)).ToString();
                query = "Update Ke set SLSach = " + soLuongSach + "where MaKe = " + maKe;
                Form1.executeQuery(query);
            }
           

        }
    }
}
