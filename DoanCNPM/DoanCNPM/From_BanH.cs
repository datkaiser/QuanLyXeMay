using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Text.RegularExpressions;

namespace DoanCNPM
{
    public partial class From_BanH : DevExpress.XtraEditors.XtraForm
    {
        public From_BanH()
        {
            InitializeComponent();
            loadcombox();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có muốn lấy mã hóa đơn đã có rồi không !", "Thông báo!", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None);
            if (r == DialogResult.OK)
            {
                 var q = (from p in db.HOADONs
                     orderby p.MAHD descending
                     select new
                     {
                         namw = p.MAHD

                     }).First();
                string somestring = txtMaKH.Text;
                string newstring = somestring.Substring(2, somestring.Length - 2);
                DateTime aDateTime = DateTime.Now;
                HOADON hd = new HOADON();
                //hd.MAKH = int.Parse(newstring);
                hd.MANV = (int)1;
                hd.NGAYBAN = aDateTime;
                hd.TONGTIEN = (int)90;
                db.HOADONs.InsertOnSubmit(hd);
                db.SubmitChanges();
                
                CTHD ct = new CTHD();
                ct.MAHD =int.Parse(q.namw.ToString());
                ct.MAPT = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAPT").ToString().Trim());
                ct.SOLUONG = int.Parse(lbgia.Text);
                ct.DONGIA = double.Parse(lbthanhtien.Text);
                ct.GIAMGIA = (int)0;
                ct.THANHTIEN = double.Parse(lbthanhtien.Text) - 0;
                db.CTHDs.InsertOnSubmit(ct);
                db.SubmitChanges();
                loddulieu();

            }
            else if (r == DialogResult.No)
            {

            }
            else
            {

 
            }

        }

        public void laydualieu()
        {
            var q = (from p in db.HOADONs
                     orderby p.MAHD descending
                     select new
                     {
                         namw = p.MAHD

                     }).First();


        }





        
        private void From_BanH_Load(object sender, EventArgs e)
        {
            loddulieu();
            btnKH.Enabled = false;
        
        }

        public void loddulieu()
        {
            var q = db.PHUTUNGXEs.ToList();
            gridControl1.DataSource = q;

        }
        public void themhd()
        {
            string somestring = txtMaKH.Text;
            string newstring = somestring.Substring(2, somestring.Length - 2);
            DateTime aDateTime = DateTime.Now;
            HOADON hd = new HOADON();
            //hd.MAKH = int.Parse(newstring);
            hd.MANV = (int)1;
            hd.NGAYBAN = aDateTime;
            hd.TONGTIEN = (int)90;
            db.HOADONs.InsertOnSubmit(hd);
            db.SubmitChanges();
            loddulieu();
            CTHD ct = new CTHD();
        }

        public void loadcombox()
        {
            var q = db.LOAIPHUTUNGs.ToList();

            comboBox1.ValueMember = "MALOAI";
            comboBox1.DisplayMember = "TENPHUTUNG";
            comboBox1.DataSource = q;
        }

        public void loadtimkiem(int loai)
        {
            //var q = from s  in db.PHUTUNGXEs
            //        where s.TENPT
            //gridControl1.DataSource = q;
        }

        public void loadtimkiem11(string loai)
        {
            var q = db.PHUTUNGXEs.Where(x => x.TENPT == loai).ToList();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

            txtten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "TENPT").ToString().Trim();
            lbgia.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "GIABAN").ToString().Trim();
            string mg = @"C:\Users\Admin\Desktop\DoanCNPM\DoanCNPM\AnhPhuTungXe\" + gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "HINH").ToString();
            pictureBox1.ImageLocation = mg;
            Console.Write(mg);

           
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void numSoLuong_ValueChanged(object sender, EventArgs e)
        {

           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int a = (int)numericUpDown1.Value;
            int b = 100000;
            int kq = a * b;
            lbthanhtien.Text = kq.ToString();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string check = txtNumberPhone.Text;
            Regex result = new Regex(@"0([0-9]\d{8})");
            Match math = result.Match(check);
            if (math.Success)
            {
                lbCheckPhone.ForeColor = Color.Red;
                lbCheckPhone.Text = "Số điện thoại sai!";

            }
            if (math.ToString() == "")
            {
                lbCheckPhone.Text = "";
            }
            else
            {
                lbCheckPhone.ForeColor = Color.Green;
                lbCheckPhone.Text = "Số điện thoại đúng!";
            }

        }

        public void checkKH()
        {
            var q = db.ADMINs.Where(x => x.TAIKHOAN == txtMaKH.Text.ToUpper() ).ToList();

            if (q.Any())
            {
                lbthongbao.ForeColor = Color.Green;
                lbthongbao.Text = "Khách hàng đã có !";
                btnKH.Enabled = false;
                return;

            }
            if (txtMaKH.Text == "")
            {
                lbthongbao.Text = "";
                btnKH.Enabled = false;
                return;
            }
            else
            {
                lbthongbao.ForeColor = Color.Red;
                lbthongbao.Text = "Khách hàng chưa có !";
                btnKH.Enabled = true;
                return;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = (int)comboBox1.SelectedValue;
            loadtimkiem(a);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //int a= txtTimKiem
            //loadtimkiem(a);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            checkKH();
            

        }

  
        
  
    }
}