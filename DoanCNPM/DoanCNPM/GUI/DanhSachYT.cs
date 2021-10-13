using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoanCNPM.DAL;

namespace DoanCNPM
{
    public partial class DanhSachYT : Form
    {
        public DanhSachYT()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void loadDSYT()
        {
            DataClassesTestDataContext db = new DataClassesTestDataContext();
             var k =       from s in db.DANHSACHYEUTHICHes
                    from b in db.PHUTUNGXEs
                    where s.MAPT == b.MAPT 
                    select new
                    {
                        SDT = s.SDT,
                        TENPT= b.TENPT,
                        NGAYLAP = s.NGAYLAP,
                        SOLUONG_DS = s.SOLUONG_DS,
                    };

            dataGridView1.DataSource = k;
        }

        private void DanhSachYT_Load(object sender, EventArgs e)
        {
            loadDSYT();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataClassesTestDataContext db = new DataClassesTestDataContext();
            var k = from s in db.DANHSACHYEUTHICHes
                    from a in db.KHACHHANGs
                    from b in db.PHUTUNGXEs
                    where s.SDT == a.SDT && s.MAPT == b.MAPT && s.SDT.Contains(textBox1.Text)
                    select new
                    {
                        SDT = s.SDT,
                        TENPT = b.TENPT,
                        NGAYLAP=s.NGAYLAP,
                        SOLUONG_DS=s.SOLUONG_DS
                    };

            dataGridView1.DataSource = k;

            if (k.Count() == 0)
                MessageBox.Show("Không có dữ liệu", "Thông báo");
            else
                dataGridView1.DataSource = k.ToList();
            textBox1.Text = "";
            dataGridView1.DataSource = k;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
