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
    public partial class formthemTG : Form
    {
        public formthemTG()
        {
            InitializeComponent();
        }

        private void formthemTG_Load(object sender, EventArgs e)
        {
            getMaDG(); 
        }

        private void btnThemMoiKeSach_Click(object sender, EventArgs e)
        {
            moveData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            removeData();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            addAuthor();
        }

        //Hàm tự sinh mã tác giả
        private void getMaDG()
        {
            string query;
            query = "Select TOP (1) MaTG from TacGia order by MaTG desc";
            string maTG = Form1.getStringFromDB(query);
            maTG = (Int32.Parse(maTG) + 1).ToString();
            txtMaTG.Text = maTG;
        }


        //Hàm lấy dữ liệu chuyển vào gridview
        private void moveData()
        {
            string maTG = txtMaTG.Text;
            string tenTG = txtTen.Text;
            string webSite = txtWebsite.Text;
            if (tenTG == "" || webSite == "")
            {
                MessageBox.Show("Bạn chưa nhập đủ thông tin!!");
            }
            else
            {
                int count = dataGridView1.RowCount;
                dataGridView1.Rows.Add(1);
                dataGridView1.Rows[count].Cells[0].Value = (count + 1).ToString();
                dataGridView1.Rows[count].Cells[1].Value = maTG;
                dataGridView1.Rows[count].Cells[2].Value = tenTG;
                dataGridView1.Rows[count].Cells[3].Value = webSite;
                clear();
            }
        }

        private void clear()
        {
            txtTen.Clear();
            txtWebsite.Clear();
            txtMaTG.Text = (Int32.Parse(txtMaTG.Text) + 1).ToString();
        }

        private void removeData()
        {
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows.Remove(dataGridView1.Rows[dataGridView1.CurrentRow.Index]);
            }
        }

        

        private void addAuthor()
        {
            string query;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string maTG = dataGridView1.Rows[i].Cells[1].Value.ToString();
                string tenTG = dataGridView1.Rows[i].Cells[2].Value.ToString();
                string webSite = dataGridView1.Rows[i].Cells[3].Value.ToString();
                query = "Insert into TacGia values (" + maTG + ", N'" + tenTG + "', '" + webSite + "')";
                Form1.executeQuery(query);
                MessageBox.Show("Thên dữ liệu thành công!!!");
            }
        }
    }
}
