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
    public partial class ChiTietNhap : Form
    {
        public ChiTietNhap()
        {
            InitializeComponent();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        private void LoaddgvXe()
        {
            
            try
            {
                DataClassesTestDataContext db = new DataClassesTestDataContext();
                var k = from s in db.PHUTUNGXEs
                        from a in db.LOAIPHUTUNGs
                        from b in db.NHACUNGCAPs
                        where s.MALOAI == a.MALOAI && s.MANCC == b.MANCC
                        select new
                        {
                            TENPT = s.TENPT,
                            DVT = s.DVT,
                            TENNCC = b.TENNCC,
                            TENPHUTUNG = a.TENPHUTUNG,
                            GIABAN = s.GIABAN,
                            SOLUONG = s.SOLUONG,
                            TINHTRANG = s.TINHTRANG
                        };

                dgvXE.DataSource = k;
            }
            catch(Exception )
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        private void ChiTietNhap_Load(object sender, EventArgs e)
        {
            try
            {
                LoaddgvXe();
                LoadChiTietXe();
                Loadcb();

            }
            catch (Exception )
            {
                MessageBox.Show("Lỗi");
            }

            
        }

        private void LoadChiTietXe()
        {
            try
            {
                DataClassesTestDataContext db = new DataClassesTestDataContext();
                var k = from s in db.CTNHAPHANGs
                        from a in db.PHUTUNGXEs

                        where s.MAPT == a.MAPT
                        select new
                        {
                            MANH = s.MANH,
                            TENPT = a.TENPT,
                            SOLUONG = s.SOLUONG,
                            THANHTIEN = s.THANHTIEN
                        };

                dgvChitietHDN.DataSource = k;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            

        }
        private void Loadcb()
        {

            comboBox1.DataSource = db.PHUTUNGXEs.Select(s => s.TENPT).ToList();


        }

        private void dgvChitietHDN_Click(object sender, EventArgs e)
        {
            try
            {
                if (btThem.Text == "Lưu")
                {
                    MessageBox.Show("Đang ở chế độ thêm mới", "Thông báo", MessageBoxButtons.OK);
                    txtMahdn.Focus();
                    return;
                }
                if (dgvChitietHDN.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ diệu", "thông báo", MessageBoxButtons.OK);
                    return;
                }
                txtMahdn.Text = dgvChitietHDN.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = dgvChitietHDN.CurrentRow.Cells[1].Value.ToString();
                txtDongia.Text = dgvChitietHDN.CurrentRow.Cells[2].Value.ToString();
                txtsoluong.Text = dgvChitietHDN.CurrentRow.Cells[3].Value.ToString();

            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        private void btThem_Click(object sender, EventArgs e)
        {

        


            if (comboBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa đủ thông tin", "Thông Báo");
                comboBox1.Focus();
            }
            else if (txtMahdn.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền mã hóa đơn", "Thông Báo");
                txtMahdn.Focus();
            }
            else if (txtsoluong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền số lượng", "Thông Báo");
                txtsoluong.Focus();
            }
            else if (txtDongia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa đủ thông tin", "Thông Báo");
                txtDongia.Focus();
            }
            else
            {
                try
                {
                    CTNHAPHANG ct = new CTNHAPHANG();
                    ct.MANH = int.Parse(txtMahdn.Text);

                    var k = from a in db.PHUTUNGXEs
                            where comboBox1.Text == a.TENPT.ToString()
                            select new
                            {
                                MAPT = a.MAPT

                            };
                    comboBox1.DataSource = k.Select(s => s.MAPT).ToList();

                    ct.MAPT = int.Parse(comboBox1.Text);
                    ct.THANHTIEN = Convert.ToInt32(txtDongia.Text);
                    ct.SOLUONG = Convert.ToInt32(txtsoluong.Text);

                    db.CTNHAPHANGs.InsertOnSubmit(ct);
                    db.SubmitChanges();
                    MessageBox.Show("Đã thêm chi tiết hóa đơn nhập", "Thông báo");

                    LoadChiTietXe();
                    Loadcb();
                }
                catch (Exception) { }
            }
            
        }

        private void btTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                DataClassesTestDataContext db = new DataClassesTestDataContext();
                var k = from s in db.PHUTUNGXEs
                        from a in db.LOAIPHUTUNGs
                        from b in db.NHACUNGCAPs
                        where s.MALOAI == a.MALOAI && s.MANCC == b.MANCC && s.TENPT.Contains(txttenxe.Text)
                        select new
                        {
                            TENPT = s.TENPT,
                            DVT = s.DVT,
                            TENNCC = b.TENNCC,
                            TENPHUTUNG = a.TENPHUTUNG,
                            GIABAN = s.GIABAN,
                            SOLUONG = s.SOLUONG,
                            TINHTRANG = s.TINHTRANG
                        };

                dgvXE.DataSource = k;

                if (k.Count() == 0)
                    MessageBox.Show("Không có dữ liệu", "Thông báo");
                else
                    dgvXE.DataSource = k.ToList();
                txttenxe.Text = "";
                dgvXE.DataSource = k;
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        

        private void bttrove_Click(object sender, EventArgs e)
        {

            this.Hide();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    for (int i = 0; i < dgvChitietHDN.SelectedRows.Count; i++)
                    {
                        string st = dgvChitietHDN.SelectedRows[i].Cells[0].Value.ToString();
                        var qr = from d in db.CTNHAPHANGs
                                 where d.MANH == int.Parse(st)
                                 select d;
                        db.CTNHAPHANGs.DeleteOnSubmit(qr.FirstOrDefault());
                    }
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    LoadChiTietXe();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi");
            }
            
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btInhoadonnhap_Click(object sender, EventArgs e)
        {
           
        }

        private void txtsoluong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMahdn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số !!!!!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtsoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số !!!!!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }











    }
}
