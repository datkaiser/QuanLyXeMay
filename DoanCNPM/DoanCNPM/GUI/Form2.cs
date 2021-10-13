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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        DataClassesTestDataContext dt = new DataClassesTestDataContext();

        private void Form2_Load(object sender, EventArgs e)
        {
            loadPT();
            loadCBO();
        }

        public void loadPT()
        {
            var pt = from d in dt.PHUTUNGXEs select d;
            dataGridView1.DataSource = pt;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
            dataGridView1.Columns[11].Visible = false;
        }
        public void loadCBO()
        {
            var loaiPT = from lpt in dt.LOAIPHUTUNGs select lpt.TENPHUTUNG;
            cboLoaiPT.DataSource = loaiPT;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            PHUTUNGXE x = dataGridView1.CurrentRow.DataBoundItem as PHUTUNGXE;
            txtTenPT.Text = x.TENPT;
            txtDVT.Text = x.DVT;
            txtGiaBan.Text = x.GIABAN.ToString();
            numSL.Value = int.Parse(x.SOLUONG.ToString());
            txtMoTa.Text = x.MOTA;
            if (x.SOLUONG > 0)
            {
                txtTinhTrang.Text = "Còn hàng";
            }
            else
            {
                txtTinhTrang.Text = "Hết hàng";
            }
            }
            catch (Exception) { }
            
        }

        private void cboLoaiPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = cboLoaiPT.SelectedItem.ToString();
            var b = dt.LOAIPHUTUNGs.Where(t => t.TENPHUTUNG == a).FirstOrDefault();
            string c = b.MALOAI.ToString();
            var loc = dt.PHUTUNGXEs.Where(r => r.MALOAI.Equals(c)).ToList();
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
            var result = dt.PHUTUNGXEs.Where(t => t.TENPT.Contains(txtSearch.Text) || t.GIABAN.ToString().Contains(txtSearch.Text) || t.MOTA.Contains(txtSearch.Text));
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
            string tenPT = txtTenPT.Text;
            string dvt = txtDVT.Text;
            string giaBan = txtGiaBan.Text;
            string moTa = txtMoTa.Text;
            try
            {

                if (tenPT.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                    txtTenPT.Focus();
                }
                else if (dvt.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                    txtDVT.Focus();
                }
                else if (giaBan.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                    txtGiaBan.Focus();
                }
                else if (moTa.Trim().Length == 0)
                {
                    MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                    txtMoTa.Focus();
                }
                else
                {
                    PHUTUNGXE ptOld = dataGridView1.CurrentRow.DataBoundItem as PHUTUNGXE;
                    PHUTUNGXE ptNew = dt.PHUTUNGXEs.Where(t => t.MAPT.Equals(ptOld.MAPT)).First();
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
                    dt.SubmitChanges();
                    MessageBox.Show("Sửa phụ tùng thành công", "Thông Báo");
                    loadPT();
                }
            }
            catch (Exception) { }
        }

        private void btnXoaPT_Click(object sender, EventArgs e)
        {
            PHUTUNGXE ptOld = dataGridView1.CurrentRow.DataBoundItem as PHUTUNGXE;
            PHUTUNGXE ptNew = dt.PHUTUNGXEs.Where(t => t.MAPT.Equals(ptOld.MAPT)).First();
            dt.PHUTUNGXEs.DeleteOnSubmit(ptNew);
            dt.SubmitChanges();
            MessageBox.Show("Xóa thành công", "Thông Báo");
            loadPT();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu fr = new Menu();
            fr.ShowDialog();
            this.Close();
        }








    }
}
