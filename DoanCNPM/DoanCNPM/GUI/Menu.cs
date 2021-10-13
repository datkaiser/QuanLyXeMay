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
    public partial class Menu : DevExpress.XtraEditors.XtraForm
    {
        public Menu()
        {
            InitializeComponent();
        }
        private static string QL = "QL";
        private static string NVTN = "NVTN";
        private static string NVK = "NVK";
        public void Menu_Load(object sender, EventArgs e)
        {
            label2.Show();
                NHANVIEN a = Form1.nvdn;
            string Phanquyen = a.MAPQ.ToString().Trim();
            if ( Phanquyen == NVK)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;               
                button6.Enabled = false;
                button5.Enabled = false;
                button9.Enabled = false;

            }
            else if(Phanquyen == NVTN)
             {
                button4.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button8.Enabled = false;
                button10.Enabled = false;
            }

            
            loadlb();
        }
        public static NHANVIEN nvdn = new NHANVIEN();
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public NHANVIEN LayNV(string sdt)
        {
            NHANVIEN nv = db.NHANVIENs.SingleOrDefault(n => n.SDT.Equals(sdt) );
            if (nv != null)
                return nv;
            return null;
        }
        public void loadlb()
        {
            label1.Text = Form1.nvdn.TENNV;
        }
        

        

        

        

        

        

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private NHANVIEN LayNV(string sdt, string mk)
        {
            NHANVIEN nv = db.NHANVIENs.SingleOrDefault(n => n.SDT.Equals(sdt) && n.MatKhau.Equals(mk));
            if (nv != null)
                return nv;
            return null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            From_bán fr = new From_bán() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmNhanVien fr = new frmNhanVien() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmQLPT fr = new frmQLPT() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            QL_NhapHang fr = new QL_NhapHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            Form_BH fr = new Form_BH() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            this.Close();
            fr.Show();


        }

        private void button5_Click_1(object sender, EventArgs e)
        {


            report fr = new report() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            reportNH fr = new reportNH() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DuyetHang fr = new DuyetHang() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            rpLoai fr = new rpLoai() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panel2.Controls.Clear();
            this.panel2.Controls.Add(fr);
            fr.Show();
        }
    }
}
