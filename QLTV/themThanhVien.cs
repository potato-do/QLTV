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
    public partial class themThanhVien : Form
    {
        public themThanhVien()
        {
            InitializeComponent();
        }

        private void themThanhVien_Load(object sender, EventArgs e)
        {
            getMaDG();
        }

        private void btnThanhVien_Click(object sender, EventArgs e)
        {
            moveData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            removeData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            addCustomer();
        }

        //Hàm tự sinh mã độc giả
        private void getMaDG()
        {
            string query;
            query = "Select TOP (1) MaDG from DocGia order by MaDG desc";
            string maDG = Form1.getStringFromDB(query);
            maDG = (Int32.Parse(maDG) + 1).ToString();
            txtMaDG.Text = maDG;
        }


        //Hàm lấy dữ liệu chuyển vào gridview
        private void moveData()
        {
            string maDG = txtMaDG.Text;
            string tenDG = txtHoTen.Text;
            string gioiTinh = cbGioiTinh.Text;
            string diaChi = txtDiaChi.Text;
            string ngaySinh = dateTimePicker1.Value.ToString("yyyyMMdd");
            string soDT = txtSDT.Text;
            if(tenDG == "" || gioiTinh == "" || diaChi == "" || soDT == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!");
            }
            else
            {
                int count = dataGridView1.RowCount;
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[count].Cells[0].Value = (count + 1).ToString();
                dataGridView1.Rows[count].Cells[1].Value = maDG;
                dataGridView1.Rows[count].Cells[2].Value = tenDG;
                dataGridView1.Rows[count].Cells[3].Value = gioiTinh;
                dataGridView1.Rows[count].Cells[4].Value = ngaySinh;
                dataGridView1.Rows[count].Cells[5].Value = diaChi;
                dataGridView1.Rows[count].Cells[6].Value = soDT;
                clear();
            }
        }
       
        //Hàm clear sau khi thêm độc giả vào
        private void clear()
        {
            txtHoTen.Clear();
            cbGioiTinh.Text = "Nam";
            txtDiaChi.Clear();
            txtSDT.Clear();
            dataGridView1.ClearSelection();
            txtMaDG.Text = (Int32.Parse(txtMaDG.Text) + 1).ToString();
        }

        //Hàm remove data khỏi gridview
        private void removeData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
            }
        }

        //Hàm thêm nhiều khách hàng trong datagridview
        private void addCustomer()
        {
            string query;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string maDG = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string tenDG = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string gioiTinh = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string ngaySinh = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string diaChi = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string soDT = dataGridView1.Rows[i].Cells[1].Value.ToString();
                query = "Insert into DocGia values (" + maDG + ",N'" + tenDG + "', N'" + gioiTinh + "', '" + ngaySinh + "', N'" + diaChi + "', " + soDT + ")";
                Form1.executeQuery(query);
                MessageBox.Show("Thên dữ liệu thành công!!!");
            }
        }
    }
}
