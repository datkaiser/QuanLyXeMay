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
    public partial class QL_NhapHang : Form
    {
        public QL_NhapHang()
        {
            InitializeComponent();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        private void LoadHDN()
        {
            //dgvhoadonnhap.DataSource = db.NHAPHANGs.ToList();
            //dgvhoadonnhap.Columns[4].Visible = false;
            DataClassesTestDataContext db = new DataClassesTestDataContext();
            var k = from s in db.NHAPHANGs
                    from a in db.NHANVIENs
                    from b in db.NHACUNGCAPs
                    where s.MANV == a.MANV && s.MANCC == b.MANCC
                    select new
                    {
                        MANH = s.MANH,
                        TENNV = a.TENNV,
                        TENNCC = b.TENNCC,
                        NGAYNHAP = s.NGAYNHAP,
                        TONGTIEN = s.TONGTIEN
                    };
            dgvhoadonnhap.DataSource = k;
        }

        private void QL_NhapHang_Load(object sender, EventArgs e)
        {
            LoadHDN();
            LoadNCC();
            Loadcb();
            Loadcb2();
        }
            private void Loadcb()
        {

            cbManv.Text = Form1.nvdn.TENNV;
           
            
        }
        private void Loadcb2()
        {
            //comboBox1.DataSource = db.NHACUNGCAPs.Select(s => s.MANCC).ToList();
            comboBox1.DataSource = db.NHACUNGCAPs.Select(s => s.TENNCC).ToList();
        }
        private void LoadNCC()
        {
            dgv_dsncc.DataSource = db.NHACUNGCAPs.ToList();
            //dgv_dsncc.Columns[1].Visible = false;
            //dgv_dsncc.Columns[0].Visible = false;
            //dgv_dsncc.Columns[5].Visible = false;
            //dgv_dsncc.Columns[3].Visible = false;
        }
        private void vohieuhoa(bool kt)
        {
            comboBox1.Enabled = kt;
            txtmahdn.Enabled = kt;
            cbManv.Enabled = kt;
        }
        private void reset()
        {
            comboBox1.Text = "";
            txtmahdn.Text = "";
            txtngaynhap.Text = "";
            cbManv.Text = "";
        }

        private void btThem_Click(object sender, EventArgs e)
        {

           
              
            
        }

        private void btSua_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvhoadonnhap_Click(object sender, EventArgs e)
        {
            txtmahdn.Text = dgvhoadonnhap.CurrentRow.Cells[0].Value.ToString();
            cbManv.Text = dgvhoadonnhap.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dgvhoadonnhap.CurrentRow.Cells[2].Value.ToString();
            txtngaynhap.Text = dgvhoadonnhap.CurrentRow.Cells[3].Value.ToString();
            textBox1.Text = dgvhoadonnhap.CurrentRow.Cells[4].Value.ToString();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            
        }

        private void btTimkiem_Click_1(object sender, EventArgs e)
        {
            var qr = from d in db.NHACUNGCAPs
                     where d.TENNCC.Contains(txtten.Text)
                     select d;
            if (qr.Count() == 0)
                MessageBox.Show("Không có dữ liệu", "Thông báo");
            else
                dgv_dsncc.DataSource = qr.ToList();
            txtten.Text = "";
        }

        private void btLapchitietdonhang_Click(object sender, EventArgs e)
        {

            ChiTietNhap fr = new ChiTietNhap();
            fr.Show();

        
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btThem_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa đủ thông tin", "Thông Báo");
                comboBox1.Focus();
            }
            else if (txtngaynhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên nhà cung cấp", "Thông Báo");
                txtngaynhap.Focus();
            }
            else if (cbManv.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa điền tên nhân viên", "Thông Báo");
                cbManv.Focus();
            }
            else if (textBox1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa đủ thông tin", "Thông Báo");
                textBox1.Focus();
            }
            else
            {
                try
                {
                    NHAPHANG hdn = new NHAPHANG();
                    //hdn.MaHDN = txtmahdn.Text;
                    NHANVIEN nv = new NHANVIEN();

                    var k =

                        from a in db.NHANVIENs
                        where cbManv.Text == a.TENNV.ToString()
                        select new
                        {
                            MANV = a.MANV

                        };
                    cbManv.DataSource = k.Select(s => s.MANV).ToList();


                    hdn.MANV = int.Parse(cbManv.Text);
                    //hdn.MANV = int.Parse(db.NHANVIENs.Select(s => s.MANV).ToString());

                    var l =

                        from d in db.NHACUNGCAPs
                        where comboBox1.Text == d.TENNCC.ToString()
                        select new
                        {
                            MANCC = d.MANCC

                        };
                    comboBox1.DataSource = l.Select(t => t.MANCC).ToList();

                    hdn.MANCC = int.Parse(comboBox1.Text);
                    hdn.NGAYNHAP = DateTime.Now;
                    hdn.TONGTIEN = double.Parse(textBox1.Text);
                    db.NHAPHANGs.InsertOnSubmit(hdn);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    btSua.Enabled = true;
                    btXoa.Enabled = true;
                    LoadHDN();
                    Loadcb();
                    Loadcb2();
                }
                catch (Exception) { }
            }
        }

        private void btSua_Click_1(object sender, EventArgs e)
        {
                     if (comboBox1.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                        comboBox1.Focus();
                    }
                    else if (txtngaynhap.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                        txtngaynhap.Focus();
                    }
                    else if (cbManv.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("Bạn chưa điền tên khách hàng", "Thông Báo");
                        cbManv.Focus();
                    }
  
                    else
                    {
                        try
                        {
                            NHAPHANG hdn = db.NHAPHANGs.Single(s => s.MANH == int.Parse(txtmahdn.Text));
                            //hdn.MaHDN = txtmahdn.Text;
                            var k = from a in db.NHANVIENs
                                    where cbManv.Text == a.TENNV.ToString()
                                    select new
                                    {
                                        MANV = a.MANV

                                    };
                            cbManv.DataSource = k.Select(s => s.MANV).ToList();


                            hdn.MANV = int.Parse(cbManv.Text);

                            var l =

                                from d in db.NHACUNGCAPs
                                where comboBox1.Text == d.TENNCC.ToString()
                                select new
                                {
                                    MANCC = d.MANCC

                                };
                            comboBox1.DataSource = l.Select(t => t.MANCC).ToList();
                            hdn.MANCC = int.Parse(comboBox1.Text);
                            hdn.NGAYNHAP = DateTime.Now;
                            hdn.TONGTIEN = double.Parse(textBox1.Text);
                            db.SubmitChanges();
                            MessageBox.Show("Sửa thành công", "Thông báo");
                            reset();
                            LoadHDN();
                            Loadcb();
                            Loadcb2();
                        }
                        catch (Exception) { }
                    }
   
            
        }

        private void btXoa_Click_1(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Bạn có muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
            //    for (int i = 0; i < dgvhoadonnhap.SelectedRows.Count; i++)
            //    {
            //        string st = dgvhoadonnhap.SelectedRows[i].Cells[0].Value.ToString();
            //        var qr = from d in db.NHAPHANGs
            //                 where d.MANH == int.Parse(st)
            //                 select d;
            //        db.NHAPHANGs.DeleteOnSubmit(qr.FirstOrDefault());
            //    }
            //    db.SubmitChanges();
            //    MessageBox.Show("Xóa thành công", "Thông báo");

            //}
            if (dgvhoadonnhap.SelectedCells.Count > 0)
            {

                    int a = dgvhoadonnhap.CurrentRow.Index;
                    DataGridViewRow selectedRow = dgvhoadonnhap.Rows[a];
                    string cellValue = Convert.ToString(selectedRow.Cells[0].Value);


                    List<CTNHAPHANG> ctn = db.CTNHAPHANGs.Where(ct => ct.MANH == int.Parse(cellValue)).ToList();
                    foreach (var i in ctn)
                    {
                        db.CTNHAPHANGs.DeleteOnSubmit(i);
                        db.SubmitChanges();
                    }
                    NHAPHANG hd = db.NHAPHANGs.SingleOrDefault(t => t.MANH == int.Parse(cellValue));
                    db.NHAPHANGs.DeleteOnSubmit(hd);
                    db.Refresh(RefreshMode.OverwriteCurrentValues, hd);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa Thành Công", "Thông báo");
                    LoadHDN();              
            }
            else
            {
                MessageBox.Show("Hãy click vào một dòng trong bảng Hóa đơn để xóa hóa đơn", "Thông báo");
            }

        }

        private void dgv_dsncc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChiTietNhap ct = new ChiTietNhap();
            ct.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Chỉ được nhập số !!!!!", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
    }

