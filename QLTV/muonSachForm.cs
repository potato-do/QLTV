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
    public partial class muonSachForm : Form
    {
        public muonSachForm()
        {
            InitializeComponent();
        }


        //sự kiện ấn enter -> tìm kiếm
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cbTenSach.Items.Clear();
                searchBookName();
            }
        }

        private void muonSachForm_Load(object sender, EventArgs e)
        {
            DateTime NgayMuon = DateTime.Now;
            DateTime NgayTra = NgayMuon.AddMonths(6);
            dtNgayMuon.Value = NgayMuon;
            dtNgayTra.Value = NgayTra;
            this.dtNgayTra.Enabled = false;
            loadInfo();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            moveData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            removeData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            saveData();
        }

        //Load info ra form
        private void loadInfo()
        {
            string query;
            //Load ma phieu muon
            query = "Select Top (1) MaMuonTra from MuonTra order by MaMuonTra desc";
            string maMT = Form1.getStringFromDB(query);
            if(maMT == "")
            {
                maMT = "1";
                
            }
            else
            {
                maMT = (Int32.Parse(maMT) + 1).ToString();
            }
            txtMaPM.Text = maMT;

            //Load Nhan vien
            query = "Select HoTen from NhanVien";
            Form1.getComboboxString(query, cbNhanVien);

            query = "Select HoTen from DocGia";
            Form1.getComboboxString(query, cbMaDG);
        }

        //Tim kiem ten sach va do ra combobox
        private void searchBookName()
        {
            string query;
            query = "Select TenSach from Sach where TenSach like '%" + textBox1.Text + "%'";
            Form1.getComboboxString(query, cbTenSach);
        }

        private void cbTenSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query;
            query = "Select MaSach from Sach where TenSach = N'" + cbTenSach.Text + "'";
            txtMaS.Text = Form1.getStringFromDB(query);
        }

        
        //Chuyển data xuống view
        private void moveData()
        {
            string maSach = txtMaS.Text;
            string tenSach = cbTenSach.Text;
            string ngayMuon = dtNgayMuon.Value.ToString("yyyyMMdd");
            string ngayTra = dtNgayTra.Value.ToString("yyyyMMdd");
           
            
            if (maSach == "" || tenSach == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!");
            }
            else
            {
                int count = dataGridView1.RowCount;
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[count].Cells[0].Value = (count + 1).ToString();
                dataGridView1.Rows[count].Cells[1].Value = maSach;
                dataGridView1.Rows[count].Cells[2].Value = tenSach;
                dataGridView1.Rows[count].Cells[3].Value = ngayMuon;
                dataGridView1.Rows[count].Cells[4].Value = ngayTra;
                clear();
            }
        }

        private void clear()
        {
            textBox1.Clear();
            txtMaS.Clear();
            cbTenSach.Items.Clear();
            cbTenSach.Text = "";
        }

        private void removeData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
            }
        }
        private void saveData()
        {

            string query;
            string maMT = txtMaPM.Text;
            string tenNV = cbNhanVien.Text;
            string tenDG = cbMaDG.Text;
            string ngayMuon = dtNgayMuon.Value.ToString("yyyyMMdd");
            //Lay ma nhan vien tu ten nv
            query = "Select MaNV from NhanVien where HoTen = N'" + tenNV + "'";
            string maNV = Form1.getStringFromDB(query);
            //Lay ma doc gia tu ten doc gia
            query = "Select MaDG from DocGia where HoTen = N'" + tenDG + "'";
            string maDG = Form1.getStringFromDB(query);
            //Insert vao bang MuonTra
            query = "Insert into MuonTra values (" + maMT + "," + maDG + "," + maNV + ",'" + ngayMuon + "')";
            Form1.executeQuery(query);

            //Insert data tu view vao trong database
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string maSach = dataGridView1.Rows[i].Cells[1].Value.ToString();
                query = "Insert into CTMuonTra values (" + maMT + "," + maSach + ", 'muon', '" + ngayMuon + "')";
                Form1.executeQuery(query);
                query = "Select soLuong from Sach where MaSach = " + maSach;
                string soLuong = Form1.getStringFromDB(query);
                soLuong = (Int32.Parse(soLuong) - 1).ToString();
                query = "Update Sach set soLuong = " + soLuong + "where maSach = " + maSach;
                Form1.executeQuery(query);


                //trừ sách từ kệ 
                query = "select Ke.SLSach from Sach inner join Ke on Sach.MaKe = Ke.MaKe where MaSach  = '" + dataGridView1.Rows[i].Cells[1].Value + "'";
                int soLuongSach = (Int32.Parse(Form1.getStringFromDB(query)) - 1);
                query = "update Ke set SLSach = " + soLuongSach + " where MaKe = ( select Sach.MaKe from Sach inner join Ke on Sach.MaKe = Ke.MaKe where MaSach ='" + dataGridView1.Rows[i].Cells[1].Value + "' )";
                Form1.executeQuery(query);


            }
            MessageBox.Show("Thên dữ liệu thành công!!!");
        }

        
    }
}
