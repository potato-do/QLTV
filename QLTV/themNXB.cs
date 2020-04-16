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
    public partial class themNXB : Form
    {
        public themNXB()
        {
            InitializeComponent();
        }

        private void themNXB_Load(object sender, EventArgs e)
        {
            getMaNXB();
        }

        private void btnThemMoiNXB_Click(object sender, EventArgs e)
        {
            moveData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            addNXB();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            removeData();
        }

        //Hàm tự sinh mã nhà xuất bản
        private void getMaNXB()
        {
            string query;
            query = "Select TOP (1) MaNXB from NhaXuatBan order by MaNXB desc";
            string maDG = Form1.getStringFromDB(query);
            maDG = (Int32.Parse(maDG) + 1).ToString();
            txtMaNXB.Text = maDG;
        }


        //Hàm lấy dữ liệu chuyển vào gridview
        private void moveData()
        {
            string maNXB = txtMaNXB.Text;
            string tenNXB = txtTenNXB.Text;
            string diaChi = txtDC.Text;
            string email = txtMail.Text;
            string soDT = txtSDT.Text;
            if (tenNXB == "" || diaChi == "" || email == "" || soDT == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!");
            }
            else
            {
                int count = dataGridView1.RowCount;
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[count].Cells[0].Value = (count + 1).ToString();
                dataGridView1.Rows[count].Cells[1].Value = maNXB;
                dataGridView1.Rows[count].Cells[2].Value = tenNXB;
                dataGridView1.Rows[count].Cells[3].Value = diaChi;
                dataGridView1.Rows[count].Cells[4].Value = email;
                dataGridView1.Rows[count].Cells[5].Value = soDT;
                clear();
            }
        }

        //Hàm clear sau khi thêm NXB vào
        private void clear()
        {
            txtTenNXB.Clear();
            txtDC.Clear();
            txtMail.Clear();
            txtSDT.Clear();
            txtMaNXB.Text = (Int32.Parse(txtMaNXB.Text) + 1).ToString();
        }

        //Hàm remove data khỏi gridview
        private void removeData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
            }
        }

        //Hàm thêm nhiều nhà xuất bản vào database trong datagridview
        private void addNXB()
        {
            string query;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string maNXB = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string tenNXB = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string diaChi = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string email = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string soDT = dataGridView1.Rows[i].Cells[1].Value.ToString();
                query = "Insert into NhaXuatBan values (" + maNXB + ", N'" + tenNXB + "', N'" + diaChi + "', '" + email + "', " + soDT + ")";
                Form1.executeQuery(query);
                MessageBox.Show("Thên dữ liệu thành công!!!");
            }
        }

        
    }
}
