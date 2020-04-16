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
    public partial class muonSachForm : Form
    {
        public muonSachForm()
        {
            InitializeComponent();
        }


        //sự kiện ấn enter -> tìm kiếm
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                //code
            }
        }
    }
}
