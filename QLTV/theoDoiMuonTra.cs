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
    public partial class theoDoiMuonTra : UserControl
    {
        public theoDoiMuonTra()
        {
            InitializeComponent();
        }

        private void theoDoiMuonTra_Load(object sender, EventArgs e)
        {
            string query;
            createView();
            query = "select * from TheoDoi";
            Form1.renderData(query, dataGridView1);
        }

        private void createView()
        {
            string query;
            query = "Create view SLMuon as SELECT dbo.Sach.MaSach, dbo.Sach.TenSach, dbo.Sach.soLuong"
                    + " FROM dbo.Sach INNER JOIN  dbo.CTMuonTra ON dbo.Sach.MaSach = dbo.CTMuonTra.MaSach";
            try
            {
                Form1.executeQuery(query);
                query = "create view TheoDoi as  SELECT MaSach, TenSach, soLuong, COUNT(1) AS SL, (soLuong - COUNT(1)) as SLcon  FROM dbo.SLMuon GROUP BY MaSach, TenSach, soLuong";
                Form1.executeQuery(query);
            }
            catch(Exception e)
            {
                
            }
        }
    }
}
