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
    public partial class Form_BH : DevExpress.XtraEditors.XtraForm
    {
        public Form_BH()
        {
            InitializeComponent();
        }

        DataClassesTestDataContext db = new DataClassesTestDataContext();

        public void loadcomboasa(string sdt, int ma)
        {
            var kk = from ll in db.PHUTUNGXEs
                     join ss in db.CTHDs on ll.MAPT equals ss.MAPT
                     join dds in db.HOADONs on ss.MAHD equals dds.MAHD
                     where dds.SDT == sdt && dds.MAHD == ma
                     select new
                     {
                         ll.MAPT,
                         ll.TENPT,
                         ss.SOLUONG,
                         dds.NGAYBAN
                     };

            timmm.Properties.DataSource = kk;
            timmm.Properties.DisplayMember = "MAPT";
            timmm.Properties.ValueMember = "MAPT";
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (textEdit1.Text != "")
                {
                    loadcomboasa(textEdit2.Text.Trim(), int.Parse(textEdit1.Text.Trim()));
                    
                    return;
                }
                else
                {
                    loadcomboasa(textEdit2.Text.Trim(), 0);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Lỗi r");
                return;
            }
        }
        string kcheckBox1 = "";
        string kcheckBox2 = "";
        string kcheckBox3 = "";
        string kcheckBox4 = "";

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var kk = (from ll in db.PHUTUNGXEs
                      join ss in db.CTHDs on ll.MAPT equals ss.MAPT
                      join dds in db.HOADONs on ss.MAHD equals dds.MAHD
                      where dds.SDT == textEdit2.Text.Trim() && dds.MAHD == int.Parse(textEdit1.Text.Trim()) && ss.MAPT == int.Parse(timmm.Text)
                      select new
                      {
                          sl = dds.NGAYBAN
                      }).First();
            string format = "M/dd/yyyy 12:00:00";
            string haha = kk.sl.ToString();
            string hihi = DateTime.Now.ToString(format) + " AM";

            if (haha == hihi && numericUpDown1.Value != 0)
            {
                var jj = db.NHANVIENs.SingleOrDefault(x => x.SDT == Form1.nvdn.SDT);
                BAOHANH bh = new BAOHANH();
                bh.MAHD = int.Parse(textEdit1.Text);
                bh.MAPT = int.Parse(timmm.Text);
                bh.MANV = Form1.nvdn.MANV;
                bh.SOLUONG_DOI = (int)numericUpDown1.Value;
                bh.NGAYMUA = kk.sl;
                bh.NGAYTRA = DateTime.Now;
                bh.TINHTRANG = kcheckBox1 + kcheckBox2 + kcheckBox3 + kcheckBox4;

                db.BAOHANHs.InsertOnSubmit(bh);
                 db.SubmitChanges();
                MessageBox.Show("Bảo hành thành công !!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else
            {
                MessageBox.Show("Dịch vụ bảo hành thất bại do sản phẩm chỉ bảo hành trong ngày!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (textEdit1.Text != "" && textEdit2.Text != "" && timmm.Text != "")
                {
                    var kk = (from ll in db.PHUTUNGXEs
                              join ss in db.CTHDs on ll.MAPT equals ss.MAPT
                              join dds in db.HOADONs on ss.MAHD equals dds.MAHD
                              where dds.SDT == textEdit2.Text.Trim() && dds.MAHD == int.Parse(textEdit1.Text.Trim()) && ss.MAPT == int.Parse(timmm.Text)
                              select new
                              {
                                  sl = ss.SOLUONG
                              }).First();

                    if (numericUpDown1.Value > kk.sl)
                    {
                        MessageBox.Show("Bạn không được nhập giá trị lớn hơn số lượng trong hóa đơn !!!!", "THÔNG BÁO");
                        numericUpDown1.Value = 0;
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn cần nhập đầy đủ thông tin ở trên");
                }
            }
            catch
            {
                MessageBox.Show("Bạn cần nhập đầy đủ thông tin ở trên");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            kcheckBox1 = "Trầy xước";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            kcheckBox2 = "Không hoạt động ổn định";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            kcheckBox3 = "Hư hỏng";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            kcheckBox4 = "Vấn đề khác";
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            checkKH();
        }
        public void checkKH()
        {
            var q = db.KHACHHANGs.Where(x => x.SDT == textEdit2.Text).ToList();

            if (q.Any())
            {

                label1.ForeColor = Color.Green;
                label1.Text = "Khách hàng đã có !";
                return;

            }
            if (label1.Text == "")
            {
                label1.Text = "";
                return;
            }
            else
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Khách hàng chưa có !";
                return;
            }

        }

        private void textEdit2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textEdit1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form_BH_Load(object sender, EventArgs e)
        {
            loadhd();
        }
        public void loadhd()
        {
            dataGridView1.DataSource = db.HOADONs.ToList();
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}