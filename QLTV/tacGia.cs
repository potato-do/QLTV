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
    }
}
