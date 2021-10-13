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
    public partial class From_HoaDon : Form
    {
        public From_HoaDon()
        {
            InitializeComponent();

            var q = db.LOAIPHUTUNGs.ToList();

            comboBox1.ValueMember = "MALOAI";
            comboBox1.DisplayMember = "TENPHUTUNG";
            comboBox1.DataSource = q;

            
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var q = db.PHUTUNGXEs.Where(x => x.MALOAI == Convert.ToInt32(comboBox1.SelectedValue)).ToList();
            comboBox2.ValueMember = "MAPT";
            comboBox2.DisplayMember = "TENPT";
            comboBox2.DataSource = q;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void From_HoaDon_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
