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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataClassesTestDataContext db = new DataClassesTestDataContext();
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        public static NHANVIEN nvdn = new NHANVIEN();
        private NHANVIEN LayNV(string sdt,string mk)
        {
            NHANVIEN nv = db.NHANVIENs.SingleOrDefault(n => n.SDT.Equals(sdt) && n.MatKhau.Equals(mk));
            if(nv!=null)
                return nv;
            return null;
        }
        public void btnLogin_Click(object sender, EventArgs e)
        {
            string sdt = txtUser.Text;
            string mk = txtPassword.Text;
            NHANVIEN nv =  LayNV(sdt, mk);
            if (nv == null)
                MessageBox.Show("Số điện thoại hoặc mặt khẩu của không đúng", "Thông báo");
            else
            {
                nvdn = nv;
                this.Hide();
                Menu mn = new Menu();
                mn.Show();

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.Hide();
            //QuenMK fr=new QuenMK();
            //fr.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
