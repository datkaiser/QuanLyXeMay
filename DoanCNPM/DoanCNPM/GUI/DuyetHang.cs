using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoanCNPM.DAL;

namespace DoanCNPM
{
    public partial class DuyetHang : Form
    {
        public DuyetHang()
        {
            InitializeComponent();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        private void LoadData(string txt)
        {
                    
            //-------------------------///
            var load_hoadon = new List<HOADON>();
            if (txt.Trim() == "Đang chờ duyệt".Trim())
            {
                load_hoadon = db.HOADONs.Where(t => t.Tinhtrang == false).ToList();
                btnDatHang.Enabled = true;
            }

            else
            {
                load_hoadon = db.HOADONs.Where(t => t.Tinhtrang == true).ToList();
                btnDatHang.Enabled = false;
            }
                
            dataGridViewGioHang.DataSource = load_hoadon;
            dataGridViewGioHang.Columns[6].Visible = false;
            dataGridViewGioHang.Columns[7].Visible = false;
            if (dataGridViewGioHang.Rows.Count >= 1)
            {
                dataGridViewGioHang.Rows[0].Selected = true;
            }
            else return;
             
   
            //----
            LoadThongtintxt();
            
        }
        private void LoadThongtintxt()
        {
            if (dataGridViewGioHang.Rows.Count >= 1)
            {
                HOADON x = dataGridViewGioHang.CurrentRow.DataBoundItem as HOADON;
                txtSDT.Text = x.SDT;

                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(k => k.SDT == x.SDT);
                txtHoten.Text = kh.TENKH;
                if (kh.GIOITINH == null)
                    rdonam.Checked = true;
                else if (kh.GIOITINH.Trim() == "Nam")
                    rdonam.Checked = true;
                else
                    tdoNu.Checked = true;
                Diachi.Text = kh.DIACHI;
            }
            else {
                txtSDT.Clear();
                txtHoten.Clear();
                Diachi.Clear();
                rdonam.Checked = true;
            }
            
        }
        private void DuyetHang_Load(object sender, EventArgs e)
        {
            string[] a = { "Đang chờ duyệt", "Đã duyệt" };
            comboTinhtrang.DataSource = a; 
            LoadData(comboTinhtrang.Text);
            LoadThongtintxt();
        }

        private void btnKtra_Click(object sender, EventArgs e)
        {
            string sdt = txtSDT.Text;
            string name = txtHoten.Text;
            string diachi = Diachi.Text;
            string gt = "";
            if (sdt == "")
            {
                MessageBox.Show("Hãy click vào một dòng trong bảng Hóa đơn để cập nhật thông tin khách hàng", "Thông báo");
            }
            else
            {
                KHACHHANG kh = db.KHACHHANGs.SingleOrDefault(k => k.SDT == sdt);
                if (rdonam.Checked)
                    gt = rdonam.Text;
                else
                    gt = tdoNu.Text;
                kh.TENKH = name;
                kh.GIOITINH = gt;
                kh.DIACHI = diachi;
                db.SubmitChanges();
                MessageBox.Show("Cập nhật thành công", "Thông báo");
            }
        }

        private void dataGridViewGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoadThongtintxt();
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            if (dataGridViewGioHang.Rows.Count >= 1)
            {
                HOADON x = dataGridViewGioHang.CurrentRow.DataBoundItem as HOADON;
                x.Tinhtrang = true;
                x.MANV = Form1.nvdn.MANV;
                db.SubmitChanges();
                MessageBox.Show("Duyệt đơn thành công", "Thông báo");
                LoadData(comboTinhtrang.Text);
            }
            else return;
            
            
        }

        private void btnXoaGio_Click(object sender, EventArgs e)
        {
            if (dataGridViewGioHang.SelectedCells.Count > 0)
            {                
                    HOADON x = dataGridViewGioHang.CurrentRow.DataBoundItem as HOADON;
                    var cthd = db.CTHDs.Where(ct => ct.MAHD == x.MAHD).ToList();
                    foreach (var i in cthd)
                    {                                           
                        db.CTHDs.DeleteOnSubmit(i);
                        db.SubmitChanges();
                    }
                    HOADON hd = db.HOADONs.SingleOrDefault(t => t.MAHD == x.MAHD);
                    db.HOADONs.DeleteOnSubmit(hd);
                    db.Refresh(RefreshMode.OverwriteCurrentValues, hd);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa Thành Công", "Thông báo");
                    LoadData(comboTinhtrang.Text);
                
            }
            else
            {
                MessageBox.Show("Hãy click vào một dòng trong bảng Hóa đơn để xóa hóa đơn", "Thông báo");
            }
        }

        private void comboTinhtrang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(comboTinhtrang.Text);
            LoadThongtintxt();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }     
    }
}
