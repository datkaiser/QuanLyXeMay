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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            loadNV();
            resetForm();
            this.ActiveControl = txtTenNV;
            dataGridView1.Columns[8].Visible = false;
        }
        public void loadNV()
        {
            var nv = from n in db.NHANVIENs select n;
            dataGridView1.DataSource = nv;
        }
        public void resetForm()
        {
            txtTenNV.ResetText();
            txtGioiTinh.ResetText();
            txtSDT.ResetText();
            txtDiaChi.ResetText();
            txtTenNV.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            NHANVIEN nv = dataGridView1.CurrentRow.DataBoundItem as NHANVIEN;
            txtTenNV.Text = nv.TENNV;
            txtGioiTinh.Text = nv.GIOITINH;
            txtDiaChi.Text = nv.DIACHI;
            txtSDT.Text = nv.SDT;
            dtpkNVL.Value = DateTime.Parse(nv.NGAYVAOLAM.ToString());
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtTenNV.Focus();
            }
            else if (txtGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtGioiTinh.Focus();
            }
            else if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtSDT.Focus();
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtDiaChi.Focus();
            }
            else
            {
                try
                {

                    NHANVIEN nv = new NHANVIEN();
                    nv.TENNV = txtTenNV.Text;
                    nv.GIOITINH = txtGioiTinh.Text;
                    nv.SDT = txtSDT.Text;
                    nv.DIACHI = txtDiaChi.Text;
                    nv.NGAYVAOLAM = dtpkNVL.Value;
                    nv.MAPQ = comboBox1.Text;
                    nv.MatKhau = textBox1.Text;
                    db.NHANVIENs.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm Nhân Viên Thành Công", "Thông Báo");
                    resetForm();
                    loadNV();
                }
                catch (Exception) { }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {


            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtTenNV.Focus();
            }
            else if (txtGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtGioiTinh.Focus();
            }
            else if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtSDT.Focus();
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtDiaChi.Focus();
            }
            else
            {
                try
                {
                    NHANVIEN nvOld = dataGridView1.CurrentRow.DataBoundItem as NHANVIEN;
                    NHANVIEN nvNew = db.NHANVIENs.Where(t => t.MANV.Equals(nvOld.MANV)).FirstOrDefault();
                    db.NHANVIENs.DeleteOnSubmit(nvNew);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa Nhân Viên Thành Công", "Thông Báo");
                    loadNV();
                }
                catch (Exception) { }
            }

            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtTenNV.Focus();
            }
            else if (txtGioiTinh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtGioiTinh.Focus();
            }
            else if (txtSDT.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtSDT.Focus();
            }
            else if (txtDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                txtDiaChi.Focus();
            }
            else
            {
                try
                {
                    NHANVIEN nvOld = dataGridView1.CurrentRow.DataBoundItem as NHANVIEN;
                    NHANVIEN nvNew = db.NHANVIENs.Where(t => t.MANV.Equals(nvOld.MANV)).FirstOrDefault();
                    nvNew.TENNV = txtTenNV.Text;
                    nvNew.GIOITINH = txtGioiTinh.Text;
                    nvNew.SDT = txtSDT.Text;
                    nvNew.DIACHI = txtDiaChi.Text;
                    nvNew.NGAYVAOLAM = dtpkNVL.Value;
                    nvNew.MAPQ = comboBox1.Text;
                    nvNew.MatKhau = textBox1.Text;
                    db.SubmitChanges();
                    MessageBox.Show("Sửa Nhân Viên Thành Công", "Thông Báo");
                    resetForm();
                    loadNV();
                }
                catch (Exception) { }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            var result = db.NHANVIENs.Where(t => t.TENNV.Contains(txtSearch.Text) || t.DIACHI.Contains(txtSearch.Text) || t.NGAYVAOLAM.ToString().Contains(txtSearch.Text));
            dataGridView1.DataSource = result;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
