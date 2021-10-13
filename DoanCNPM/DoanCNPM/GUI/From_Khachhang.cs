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
using DoanCNPM.DAL;

namespace DoanCNPM
{
    public partial class From_Khachhang : DevExpress.XtraEditors.XtraForm
    {
        public From_Khachhang()
        {
            InitializeComponent();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public static string makh = "";
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (codexuly.kiemtraSDTKH(textEdit1.Text) == true)
            {
                MessageBox.Show("Số điện thoại đã tồn tại rồi!!!", "THÔNG BÁO");
                return;
            }
            else if (codexuly.kiemtraSDTKH(textEdit1.Text) == false)
            {

                makh = textEdit1.Text;
                KHACHHANG kh = new KHACHHANG();
                kh.SDT = makh;
                kh.TENKH = textEdit2.Text;
                kh.GIOITINH = comboBox1.Text;
                kh.EMAIL = textEdit3.Text;
                kh.NGAYTAO = DateTime.Now;
                if (textBox1.Text == null)
                {
                    kh.DIACHI = "";
                }
                else
                {
                    kh.DIACHI = textBox1.Text;
                }
               
                db.KHACHHANGs.InsertOnSubmit(kh);
                db.SubmitChanges();
                MessageBox.Show("Tạo tài khoản thành công!!!!", "Thông báo");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }

        private void From_Khachhang_Load(object sender, EventArgs e)
        {

        }
    }
}