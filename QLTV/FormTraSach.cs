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
    public partial class FormTraSach : Form
    {
        public FormTraSach()
        {
            InitializeComponent();
        }

        //Su kien click button Trasach
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string query;
            var senderGrid = (DataGridView)sender;


            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
               e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells["TrangThai"].Value.ToString() == "muon")
            {
                MessageBox.Show("ok");
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
                    + " join Sach as s on s.MaSach = ct.MaSach";
            Form1.renderData(query, dataGridView1);
            
        }
    }
}
