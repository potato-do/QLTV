using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV
{
    public partial class lichsumuon : Form
    {
        public lichsumuon()
        {
            InitializeComponent();
        }

       public static string a;

        private void lichsumuon_Load(object sender, EventArgs e)
        {
            
            var adap = new SqlDataAdapter(@"Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai from MuonTra as mt join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra join Sach as s on s.MaSach = ct.MaSach  ", Form1.conn);
            var table = new DataTable();
            adap.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            string query = "Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai from MuonTra as mt join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra join Sach as s on s.MaSach = ct.MaSach  where NgayMuon between '" + dtNgayMuon.Value.ToString("yyyyMMdd") + "' and '" + dtNgayTra.Value.ToString("yyyyMMdd") + "'  ";
            Form1.renderData(query, dataGridView1);
        }

        private void timKiem()
        {
            var adap = new SqlDataAdapter(@"Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai from MuonTra as mt join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra join Sach as s on s.MaSach = ct.MaSach where mt.MaMuonTra ='" + textBox1.Text + "' ", Form1.conn);
            var table = new DataTable();
            adap.Fill(table);
            comboBox1.DisplayMember = "TenSach";
            comboBox1.ValueMember = "TenSach";
            comboBox1.DataSource = table;
            comboBox1.SelectedIndex = -1;
            textBox2.DataBindings.Clear();
            textBox2.DataBindings.Add("Text", comboBox1.DataSource, "TenDG");
            int sum = 0;
            
                sum = sum + dataGridView1.Rows.Count;
            
            textBox3.Text = sum.ToString();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                timKiem();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == -1)
            {
                var adap = new SqlDataAdapter(@"Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai from MuonTra as mt join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra join Sach as s on s.MaSach = ct.MaSach where mt.MaMuonTra = '"+textBox1.Text+"' ", Form1.conn);
                var table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
            }
            else
            {
                var adap = new SqlDataAdapter(@"Select mt.MaMuonTra, dg.HoTen as TenDG,nv.HoTen as TenNV, mt.NgayMuon, s.MaSach, s.TenSach, ct.TrangThai from MuonTra as mt join DocGia as dg on dg.MaDG = mt.MaDG join NhanVien as nv on mt.MaNV = nv.MaNV join CTMuonTra as ct on mt.MaMuonTra = ct.MaMuonTra join Sach as s on s.MaSach = ct.MaSach where mt.MaMuonTra = '" + textBox1.Text + "' and TenSach = '"+comboBox1.Text+"' ", Form1.conn);
                var table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            textBox3.Clear();
            lichsumuon_Load(sender, e);
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if(txtRP.Text == "")
            {
                MessageBox.Show("vui lòng chọn mã phiếu!!");
            }
            else
            {
                a = txtRP.Text;
                reportform reportform = new reportform();
                reportform.ShowDialog();
            }
        }

        //create drop
        
        private void txtRP_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
