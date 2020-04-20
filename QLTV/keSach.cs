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
    public partial class keSach : UserControl
    {
        public keSach()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            themKeSach n = new themKeSach();
            n.Show();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            keSach_Load(sender, e);
        }

        private void keSach_Load(object sender, EventArgs e)
        {

            var dap = new SqlDataAdapter(@"select DISTINCT SLChua from Ke", Form1.conn);
            var tb = new DataTable();
            dap.Fill(tb);
            toolStripComboBox1.ComboBox.DisplayMember = "SLChua";
            toolStripComboBox1.ComboBox.ValueMember = "SLChua";
            toolStripComboBox1.ComboBox.DataSource = tb;
            toolStripComboBox1.SelectedIndex = -1;

            //đổ dữ liệu ra bảng
            var adap = new SqlDataAdapter(@"select * from Ke", Form1.conn);
            var table = new DataTable();
            adap.Fill(table);
            dataGridView1.DataSource = table;
            
          

            //đổ dữ liệu ra box
            txtMaKe.DataBindings.Clear();
            txtMaKe.DataBindings.Add("text", dataGridView1.DataSource, "MaKe");
            txtChatLieu.DataBindings.Clear();
            txtChatLieu.DataBindings.Add("text", dataGridView1.DataSource, "ChatLieu");
            txtSucChua.DataBindings.Clear();
            txtSucChua.DataBindings.Add("text", dataGridView1.DataSource, "SLChua");
            txtSLSach.DataBindings.Clear();
            txtSLSach.DataBindings.Add("text", dataGridView1.DataSource, "SLSach");



        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string Q1 = "Bạn có muốn thay đổi dữ liệu này";
            DialogResult result = MessageBox.Show(Q1,"Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(@"update Ke set MaKe = '" + txtMaKe.Text + "',ChatLieu = N'" + txtChatLieu.Text + "',SLChua='" + txtSucChua.Text + "',SLSach='" + txtSLSach.Text + "' where MaKe='"+txtMaKe.Text+"'", Form1.conn);
                Form1.conn.Open();
                cmd.ExecuteNonQuery();
                Form1.conn.Close();
                MessageBox.Show("Đã cập nhật mới!!");
            }
            keSach_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string Q1 = "Bạn có muốn xóa";
            DialogResult result = MessageBox.Show(Q1, "Question", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                SqlCommand cmd = new SqlCommand(@"delete from Ke where MaKe = '"+txtMaKe.Text+"'", Form1.conn);
                Form1.conn.Open();
                cmd.ExecuteNonQuery();
                Form1.conn.Close();
                MessageBox.Show("Đã xóa!!");
                
            }
            keSach_Load(sender, e);
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            
            
            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var da = new SqlDataAdapter(@"select * from Ke where SLChua = '" + toolStripComboBox1.ComboBox.Text + "'", Form1.conn);
            var tb = new DataTable();
            da.Fill(tb);
            dataGridView1.DataSource = tb;
        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                var adap = new SqlDataAdapter(@"select * from Ke where MaKe = '" + toolStripTextBox1.TextBox.Text + "'", Form1.conn);
                var table = new DataTable();
                adap.Fill(table);
                dataGridView1.DataSource = table;
            }
            toolStripTextBox1.TextBox.Clear();
        }
        // đẩy dữ liệu ra form chitietke
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            chitietKe chitietKe = new chitietKe();
            var adap = new SqlDataAdapter("select Ke.MaKe,Sach.MaSach,Sach.TenSach,TheLoai.TenTL,TacGia.TenTG,Sach.NamXuatBan,NhaXuatBan.TenNXB,Sach.soLuong from Sach inner join TacGia on Sach.MaTG = TacGia.MaTG inner join NhaXuatBan on NhaXuatBan.MaNXB = Sach.MaNXB inner join Ke on Sach.MaKe = Ke.MaKe inner join TheLoai on Sach.MaTL = TheLoai.MaTL where Ke.MaKe = '" + txtMaKe.Text + "'", Form1.conn);
            var ta = new DataTable();
            adap.Fill(ta);
            chitietKe.dataGridView1.DataSource = ta;
            chitietKe.ShowDialog();
        }
    }
}
