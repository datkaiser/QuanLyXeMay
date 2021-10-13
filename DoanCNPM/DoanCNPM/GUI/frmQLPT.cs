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
    public partial class frmQLPT : Form
    {
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public frmQLPT()
        {
            InitializeComponent();
        }

        private void frmQLPT_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtTenPT;
            loadPT();
            loadCBO();
        }
        public void loadPT()
        {
            var pt = from d in db.PHUTUNGXEs select d;
            dataGridView1.DataSource = pt;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
        }
        public void resetForm()
        {
            txtTenPT.ResetText();
            txtDVT.ResetText();
            txtGiaBan.ResetText();
            txtMoTa.ResetText();
            txtTinhTrang.ResetText();
            txtTenPT.Focus();
        }
        public void loadCBO()
        {
            var loaiPT = from lpt in db.LOAIPHUTUNGs select lpt.TENPHUTUNG;
            cboLoaiPT.DataSource = loaiPT;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PHUTUNGXE x = dataGridView1.CurrentRow.DataBoundItem as PHUTUNGXE;
            txtTenPT.Text = x.TENPT;
            txtDVT.Text = x.DVT;
            txtGiaBan.Text = x.GIABAN.ToString();

            txtMoTa.Text = x.MOTA;
            if (x.SOLUONG > 0)
            {
                txtTinhTrang.Text = "Còn hàng";
            }
            else
            {
                txtTinhTrang.Text = "Hết hàng";
            }
            if (dataGridView1.SelectedCells.Count > 0)
            {
                btnXoaPT.Enabled = true;
                btnSuaPT.Enabled = true;
            }
        }

        private void cboLoaiPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = cboLoaiPT.SelectedItem.ToString();
            var b = db.LOAIPHUTUNGs.Where(t => t.TENPHUTUNG == a).FirstOrDefault();
            string c = b.MALOAI.ToString();
            var loc = db.PHUTUNGXEs.Where(r => r.MALOAI.Equals(c)).ToList();
            dataGridView1.DataSource = loc;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            var result = db.PHUTUNGXEs.Where(t => t.TENPT.Contains(txtSearch.Text) || t.GIABAN.ToString().Contains(txtSearch.Text) || t.MOTA.Contains(txtSearch.Text));
            dataGridView1.DataSource = result;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
        }

        private void btnSuaPT_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count >= 1)
            {
                string tenPT = txtTenPT.Text;
                string dvt = txtDVT.Text;
                string giaBan = txtGiaBan.Text;
                string moTa = txtMoTa.Text;
                try
                {

                    if (tenPT.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtTenPT.Focus();
                    }
                    else if (dvt.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtDVT.Focus();
                    }
                    else if (giaBan.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtGiaBan.Focus();
                    }
                    else if (moTa.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtMoTa.Focus();
                    }
                    else
                    {
                        PHUTUNGXE ptOld = dataGridView1.CurrentRow.DataBoundItem as PHUTUNGXE;
                        PHUTUNGXE ptNew = db.PHUTUNGXEs.Where(t => t.MAPT.Equals(ptOld.MAPT)).First();
                        ptNew.TENPT = txtTenPT.Text;
                        ptNew.DVT = txtDVT.Text;
                        ptNew.GIABAN = float.Parse(txtGiaBan.Text);
                        ptNew.SOLUONG = (int)numSL.Value;
                        ptNew.MOTA = txtMoTa.Text;
                        if (ptNew.SOLUONG > 0)
                        {
                            ptNew.TINHTRANG = "Còn hàng";
                            txtTinhTrang.Text = "Còn hàng";
                        }
                        else
                        {
                            ptNew.TINHTRANG = "Hết hàng";
                            txtTinhTrang.Text = "Hết hàng";
                        }
                        db.SubmitChanges();
                        MessageBox.Show("Sửa phụ tùng thành công", "Thông Báo");
                        resetForm();
                        loadPT();
                    }
                }
                catch (Exception) { }
            }
            else return;
        }

        private void btnXoaPT_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count >= 1)
            {
                string tenPT = txtTenPT.Text;
                string dvt = txtDVT.Text;
                string giaBan = txtGiaBan.Text;
                string moTa = txtMoTa.Text;
                try
                {

                    if (tenPT.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtTenPT.Focus();
                    }
                    else if (dvt.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtDVT.Focus();
                    }
                    else if (giaBan.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtGiaBan.Focus();
                    }
                    else if (moTa.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên phụ tùng", "Thông Báo");
                        txtMoTa.Focus();
                    }
                    else
                    {
                        PHUTUNGXE ptOld = dataGridView1.CurrentRow.DataBoundItem as PHUTUNGXE;
                        PHUTUNGXE ptNew = db.PHUTUNGXEs.Where(t => t.MAPT.Equals(ptOld.MAPT)).First();
                        db.PHUTUNGXEs.DeleteOnSubmit(ptNew);
                        db.SubmitChanges();
                        MessageBox.Show("Xóa thành công", "Thông Báo");
                        loadPT();
                    }
                }
                catch (Exception) { }

            }

        }
    }
}
