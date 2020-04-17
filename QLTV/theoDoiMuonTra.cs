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
            var adap = new SqlDataAdapter(@"select * from TheoDoi", Form1.conn);
            var table = new DataTable();
            adap.Fill(table);
            dataGridView1.DataSource = table;
           
        }
    }
}
