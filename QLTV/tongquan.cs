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
    public partial class tongquan : UserControl
    {
        public tongquan()
        {
            InitializeComponent();
        }

        private void tongquan_Load(object sender, EventArgs e)
        {
            SLCon();
            SLMuon();
            TongSL();
            SLNXB();
            SLKe();
            SLDG();
        }
        //đổ dữ liệu ra SL còn
        private void SLCon()
        {
            string query;
            query = "Select sum(soLuong) from sach";
            Form1.conn.Open();
            SqlCommand cmd = new SqlCommand(query, Form1.conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Form1.conn.Close();
            foreach (DataRow row in dt.Rows)
            {
                lbSachCL.Text = row[0].ToString();
            }
        }
        private void SLMuon()
        {
            string query;
            query = "select count(1) from CTMuonTra where TrangThai = 'Muon'";
            Form1.conn.Open();
            SqlCommand cmd = new SqlCommand(query, Form1.conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Form1.conn.Close();
            foreach (DataRow row in dt.Rows)
            {
                lbSachDM.Text = row[0].ToString();
            }
        }
        private void TongSL()
        {
            lbTongSS.Text = (Convert.ToInt32(lbSachDM.Text) + Convert.ToInt32(lbSachCL.Text)).ToString();
        }
        private void SLNXB()
        {
            string query;
            query = "select count(1) from NhaXuatBan ";
            Form1.conn.Open();
            SqlCommand cmd = new SqlCommand(query, Form1.conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Form1.conn.Close();
            foreach (DataRow row in dt.Rows)
            {
                lbTongNXB.Text = row[0].ToString();
            }
        }
        private void SLKe()
        {
            string query;
            query = "select count(1) from Ke ";
            Form1.conn.Open();
            SqlCommand cmd = new SqlCommand(query, Form1.conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Form1.conn.Close();
            foreach (DataRow row in dt.Rows)
            {
                lbSoK.Text = row[0].ToString();
            }
        }

        private void SLDG()
        {
            string query;
            query = "select count(1) from DocGia ";
            Form1.conn.Open();
            SqlCommand cmd = new SqlCommand(query, Form1.conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Form1.conn.Close();
            foreach (DataRow row in dt.Rows)
            {
                lbSoDG.Text = row[0].ToString();
            }
        }


    }
}
