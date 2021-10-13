using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoanCNPM
{
    public partial class From_Trangchu : Form
    {
        public From_Trangchu()
        {
            InitializeComponent();
        }

        private void From_Trangchu_Load(object sender, EventArgs e)
        {
            if (Form1.pq == "KH")
            {
                button1.Enabled = false;
                button2.Enabled = false;

            }
        }
    }
}
