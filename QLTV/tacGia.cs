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
    public partial class tacGia : UserControl
    {
        public tacGia()
        {
            InitializeComponent();
        }

        private void cbNhaXB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            formthemTG formthemTG = new formthemTG();
            formthemTG.Show();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            //load dữ liệu ra form
            string query;
            query = "select * from TacGia";
            Form1.renderData(query, dataGridView1);

            cbBoLoc.Items.Add("Mã tác giả");
            cbBoLoc.Items.Add("Tên tác giả");
            cbBoLoc.Items.Add("website");
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //load dữ liệu ra form
            string query;
            query = "select * from TacGia";
            Form1.renderData(query, dataGridView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteData();
            btnReload_Click(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            updateData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            moveDataToTextBox();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            search();
        }

        private void cbBoLoc_Click(object sender, EventArgs e)
        {
            
        }

        //Hàm xóa tác giả khỏi database
        private void deleteData()
        {
            string query;
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            string message = "Xác nhận xóa tác giả khỏi danh sách?";
            string title = "Validate";
            DialogResult result = MessageBox.Show(message, title, btn);
            if (result == DialogResult.Yes)
            {
                string maDG = dataGridView1.CurrentRow.Cells["MaTG"].Value.ToString();
                query = "delete TacGia Where MaTG = " + maDG;
                Form1.executeQuery(query);
                MessageBox.Show("Xóa dữ liệu thành công!!!");
            }
        }

        private void moveDataToTextBox()
        {
            txtMaTG.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtWebsite.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void updateData()
        {
            string query;
            string maTG = txtMaTG.Text;
            string tenTG = txtTen.Text;
            string website = txtWebsite.Text;

            //Update data
            query = "Update TacGia set TenTG = N'" + tenTG + "', website = '" + website + "' where MaTG = " + maTG ;
            Form1.executeQuery(query);
            MessageBox.Show("Cập nhật dữ liệu thành công!!");
        }

        
        //Hàm search theo bộ lọc
        private void search()
        {
            string query;
            string text = txtSearch.Text;
            if(cbBoLoc.SelectedItem.ToString() == "Mã tác giả")
            {
                query = "Select * from TacGia where MaTG like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedItem.ToString() == "Tên tác giả")
            {
                query = "Select * from TacGia where TenTG like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
            if (cbBoLoc.SelectedItem.ToString() == "website")
            {
                query = "Select * from TacGia where Website like '%" + text + "%'";
                Form1.renderData(query, dataGridView1);
            }
        }

        
    }
}
