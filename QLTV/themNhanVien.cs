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
    public partial class themNhanVien : Form
    {
        public themNhanVien()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnThemMoiNV_Click(object sender, EventArgs e)
        {
            moveDataToView();
        }

        private void themNhanVien_Load(object sender, EventArgs e)
        {
            getMaNV();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            removeData();
        }

        //Hàm lấy mã nhân viên vào form thêm mới
        private void getMaNV()
        {
            string query;
            query = "Select TOP (1) MaNV from NhanVien order by MaNV desc";
            string maNV = Form1.getStringFromDB(query);
            if (maNV == "")
            {
                maNV = "1";
            }
            else
            {
                maNV = (Int32.Parse(maNV) + 1).ToString();
            }
            txtMaNV.Text = maNV;
            cbGioiTinh.Text = "Nam";
        }

        //Hàm chuyển data xuống view
        private void moveDataToView()
        {
            string query;
            string MaNV = txtMaNV.Text;
            string tenNV = txtTen.Text;
            string gTinh = cbGioiTinh.Text;
            string ngaySinh = dateTimePicker1.Value.ToString("yyyyMMdd");
            string sdt = txtSDT.Text;
            string tenDangNhap = txtTenDN.Text;
            string matKhau = txtMatKhau.Text;
            if(tenNV == "" || gTinh == "" || sdt == "" || tenDangNhap == "" || matKhau == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!!");
            }
            else if(checkUserName() == false)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại");
            }
            else
            {
                int count = dataGridView1.RowCount;
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[count].Cells[0].Value = MaNV;
                dataGridView1.Rows[count].Cells[1].Value = tenNV;
                dataGridView1.Rows[count].Cells[2].Value = gTinh;
                dataGridView1.Rows[count].Cells[3].Value = ngaySinh;
                dataGridView1.Rows[count].Cells[4].Value = sdt;
                dataGridView1.Rows[count].Cells[5].Value = tenDangNhap;
                dataGridView1.Rows[count].Cells[6].Value = matKhau;
                clear();
            }
        }

        //Ham xóa data khỏi view
        private void removeData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
            }
        }

        private void clear()
        {
            txtTen.Clear();
            txtSDT.Clear();
            txtMatKhau.Clear();
            txtTenDN.Clear();
            cbGioiTinh.Text = "Nam";
            txtMaNV.Text = (Int32.Parse(txtMaNV.Text) + 1).ToString();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            addEmployment();
        }

        //Hàm thêm nhân viên vào database
        private void addEmployment()
        {
            string query;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string maNV = dataGridView1.Rows[i].Cells[0].Value.ToString();
                string tenNV = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string gTinh = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string ngaySinh = dataGridView1.Rows[i].Cells[3].Value.ToString();
                string sdt = dataGridView1.Rows[i].Cells[4].Value.ToString();
                string tenDN = dataGridView1.Rows[i].Cells[5].Value.ToString();
                string matKhau = dataGridView1.Rows[i].Cells[6].Value.ToString();

                query = "Insert into TaiKhoan values ('" + tenDN + "','" + matKhau + "')";
                Form1.executeQuery(query);
                query = "Insert into NhanVien values (" + maNV + ", N'" + tenNV + "', '" + ngaySinh + "', N'" + gTinh + "', '" + sdt + "', '" + tenDN + "')";
                Form1.executeQuery(query);
            }
            MessageBox.Show("Thêm nhân viên mới thành công!!");
        }

        //Check ten dang nhap
        private bool checkUserName()
        {
            string query;
            query = "Select MatKhau from TaiKhoan where TenDangNhap = '" + txtTenDN.Text + "'";
            if(Form1.getStringFromDB(query) == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
