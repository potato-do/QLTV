using System;
using System.CodeDom;
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
    public partial class FormTraSach : Form
    {
        public FormTraSach()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query;
            var senderGrid = (DataGridView)sender;


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString() == "muon")
            {
                MessageBox.Show("ok");
                ThemS();
                dataGridView1.Rows[e.RowIndex].Cells[7].Value = "tra";
                string maMT = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string maS = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                query = "Update CTMuonTra set TrangThai = 'tra', NgayTra = '" + DateTime.Now.ToString("yyyyMMdd") + "' where MaMuonTra = " + maMT + " and MaSach = " + maS;
                Form1.executeQuery(query);
                query = "Select soLuong from Sach where MaSach = " + maS;
                string soLuong = Form1.getStringFromDB(query);
                soLuong = (Int32.Parse(soLuong) + 1).ToString();
                query = "Update Sach set soLuong = " + soLuong + " where MaSach = " + maS;
                Form1.executeQuery(query);
                MessageBox.Show("Cập nhật trả sách thành công!!");
                loadView();
            }
        }

        private void FormTraSach_Load(object sender, EventArgs e)
        {
            loadView();
        }

        private void loadView()
        {
            string query;
            query = "Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai  from MuonTra as mt "
                    + " join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra"
                    + " join Sach as s on s.MaSach = ct.MaSach where ct.TrangThai = 'muon'";
            Form1.renderData(query, dataGridView1);

        }
        private void ThemS()
        {
            string query;
            query = "select Ke.SLSach from Sach inner join Ke on Sach.MaKe = Ke.MaKe where MaSach  = '" + dataGridView1.CurrentRow.Cells[5].Value + "'";
            int soLuongSach = (Int32.Parse(Form1.getStringFromDB(query)) + 1);
            query = "update Ke set SLSach = " + soLuongSach + " where MaKe = ( select Sach.MaKe from Sach inner join Ke on Sach.MaKe = Ke.MaKe where MaSach ='" + dataGridView1.CurrentRow.Cells[5].Value + "' )";
            Form1.executeQuery(query);
        }

        private void timkiem()
        {
            var adap = new SqlDataAdapter(@"select TenSach,HoTen from Sach join CTMuonTra on Sach.MaSach = CTMuonTra.MaSach join MuonTra on MuonTra.MaMuonTra = CTMuonTra.MaMuonTra join DocGia on DocGia.MaDG = MuonTra.MaDG where MuonTra.MaMuonTra = '" + textBox1.Text + "'  ", Form1.conn);
            var table = new DataTable();
            adap.Fill(table);
            comboBox1.DisplayMember = "TenSach";
            comboBox1.ValueMember = "TenSach";
            comboBox1.DataSource = table;
            comboBox1.SelectedIndex = -1 ;
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", comboBox1.DataSource, "HoTen");
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                
                timkiem();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                var adap = new SqlDataAdapter(@"Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai  from MuonTra as mt "
                        + " join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra"
                        + " join Sach as s on s.MaSach = ct.MaSach where ct.TrangThai = 'muon' and mt.MaMuonTra = '" + textBox1.Text + "'  ", Form1.conn);
                var table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
            }
            else
            {
                var adap = new SqlDataAdapter(@"Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai  from MuonTra as mt "
                        + " join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra"
                        + " join Sach as s on s.MaSach = ct.MaSach where ct.TrangThai = 'muon' and mt.MaMuonTra = '" + textBox1.Text + "' and TenSach = '" + comboBox1.Text + "'  ", Form1.conn);
                var table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {

        }
    }
}
