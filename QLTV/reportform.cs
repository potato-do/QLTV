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
    public partial class reportform : Form
    {
        public reportform()
        {
            InitializeComponent();
        }

        private void reportform_Load(object sender, EventArgs e)
        {
            lichsumuon lichsumuon = new lichsumuon();
            
            // TODO: This line of code loads data into the 'DataSet1.chiTietBaoCao' table. You can move, or remove it, as needed.
            this.chiTietBaoCaoTableAdapter.Fill(this.DataSet1.chiTietBaoCao,lichsumuon.a);

            this.reportViewer1.RefreshReport();
        }
    }
}
