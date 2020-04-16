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
    public partial class thanhVien : UserControl
    {
        public thanhVien()
        {
            InitializeComponent();
        }

        private void btnThemMoiThanhVien_Click(object sender, EventArgs e)
        {
            themThanhVien themMoi = new themThanhVien();
            themMoi.Show();
        }

        private void bunifuCards1_Paint(object sender, PaintEventArgs e)
        {
            //Load du lieu ra form
            string query;
            query = "Select * from DocGia";
            Form1.renderData(query, dataGridView1);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            //Load du lieu ra form
            string query;
            query = "Select * from DocGia";
            Form1.renderData(query, dataGridView1);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        //Hàm xóa độc giả khỏi database
        private void deleteData()
        {
            string query;
            MessageBoxButtons btn = MessageBoxButtons.YesNo;
            string message = "Xác nhận xóa độc giả khỏi danh sách?";
            string title = "Validate";
            DialogResult result = MessageBox.Show(message, title, btn);
            if (result == DialogResult.Yes)
            {
                string maDG = dataGridView1.CurrentRow.Cells["MaDG"].Value.ToString();
                query = "delete DocGia Where MaDG = " + maDG;
                Form1.executeQuery(query);
                MessageBox.Show("Xóa dữ liệu thành công!!!");
            }
        }
    }
}
