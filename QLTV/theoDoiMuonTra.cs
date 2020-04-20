using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLTV
{
    public partial class theoDoiMuonTra : UserControl
    {
        public theoDoiMuonTra()
        {
            InitializeComponent();
        }
        public static string a;
        private void theoDoiMuonTra_Load(object sender, EventArgs e)
        {
            /*string query;
            createView();
            query = "Select * from TheoDoi";
            Form1.renderData(query, dataGridView1);*/

            var adap = new SqlDataAdapter(@"select distinct Sach.MaSach,Sach.TenSach,Sach.soLuong,count(1) as sl,soLuong + count(1) as TSL from Sach inner join CTMuonTra on CTMuonTra.MaSach = Sach.MaSach where TrangThai = 'muon' group by Sach.MaSach,TenSach,soLuong", Form1.conn);
            var ta = new DataTable();
            adap.Fill(ta);
            dataGridView1.DataSource = ta;

           

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            lichsumuon lichsumuon = new lichsumuon();
            lichsumuon.ShowDialog();
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var adap = new SqlDataAdapter(@"select Sach.MaSach,Sach.TenSach,Sach.soLuong,count(1) as sl,soLuong + count(1) as TSL from Sach inner join CTMuonTra on CTMuonTra.MaSach = Sach.MaSach where TrangThai = 'muon' and TenSach like '%" + txtTK.Text + "%' group by Sach.MaSach,TenSach,soLuong", Form1.conn);
                var ta = new DataTable();
                adap.Fill(ta);
                dataGridView1.DataSource = ta;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            chitietDangMuon chitietDangMuon = new chitietDangMuon();
            var adap = new SqlDataAdapter(@"Select MuonTra.MaMuonTra, DocGia.HoTen as TenDG, MuonTra.NgayMuon, Sach.MaSach, Sach.TenSach,TheLoai.TenTL, CTMuonTra.TrangThai from MuonTra join DocGia  on DocGia.MaDG = MuonTra.MaDG join CTMuonTra  on MuonTra.MaMuonTra = CTMuonTra.MaMuonTra join Sach  on Sach.MaSach = CTMuonTra.MaSach join TheLoai on TheLoai.MaTL = Sach.MaTL where Sach.MaSach ='" + dataGridView1.CurrentRow.Cells["MaSach"].Value.ToString() + "' and CTMuonTra.TrangThai = 'muon'", Form1.conn);
            var ta = new DataTable();
            adap.Fill(ta);
            chitietDangMuon.dataGridView1.DataSource = ta;
            chitietDangMuon.ShowDialog();
        }
    }
}
