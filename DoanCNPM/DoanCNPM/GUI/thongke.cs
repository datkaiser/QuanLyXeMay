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
    public partial class thongke : Form
    {
        public thongke()
        {
            InitializeComponent();
        }
        DataClassesTestDataContext dt = new DataClassesTestDataContext();
        public int ThongKeTheoNgay()
        {
            DateTime fromDate = dtpkFromDate.Value;
            DateTime toDate = dtpkToDate.Value;
            var ngay = dt.HOADONs.Where(t => fromDate <= t.NGAYBAN && t.NGAYBAN <= toDate).Count();
            return ngay;
        }
        private void radPT_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = dtpkFromDate.Value;
                DateTime toDate = dtpkToDate.Value;
                cboItemNV.Hide();
                cboItemLoaiPT.Hide();
                var loc = from hd in dt.HOADONs
                          where fromDate <= hd.NGAYBAN && hd.NGAYBAN <= toDate
                          join cthd in dt.CTHDs on hd.MAHD equals cthd.MAHD
                          join pt in dt.PHUTUNGXEs on cthd.MAPT equals pt.MAPT
                          select new
                          {
                              MãPT = pt.MAPT,
                              TênPT = pt.TENPT,
                              SốLượngMua = dt.CTHDs.Sum(t => t.SOLUONG),
                              GiáBán = pt.GIABAN,
                              ThànhTiềnMua = dt.CTHDs.Sum(t => t.THANHTIEN)
                          };
                dataGridView1.DataSource = loc;
            }
            catch{ }
        }

        private void thongke_Load(object sender, EventArgs e)
        {
            cboItemNV.Hide();
            cboItemLoaiPT.Hide();
        }

        private void radDoanhThu_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                cboItemNV.Hide();
                cboItemLoaiPT.Hide();
                var hd = from d in dt.HOADONs
                         where ThongKeTheoNgay() > 0
                         select new
                         {
                             MãHĐ = d.MAHD,
                             NgàyLậpHĐ = d.NGAYBAN,
                             ThànhTiền = d.TONGTIEN
                         };
                dataGridView1.DataSource = hd;
            }
            catch (Exception) { }
        }

        private void radNV_CheckedChanged(object sender, EventArgs e)
        {
            cboItemLoaiPT.Hide();
            var nv = from d in dt.NHANVIENs select d.TENNV;
            cboItemNV.Show();
            cboItemNV.DataSource = nv;
        }

        private void radTheLoai_CheckedChanged(object sender, EventArgs e)
        {
            cboItemNV.Hide();
            var loai = from d in dt.LOAIPHUTUNGs select d.TENPHUTUNG;
            cboItemLoaiPT.Show();
            cboItemLoaiPT.DataSource = loai;
        }

        private void cboItemLoaiPT_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string a = cboItemLoaiPT.SelectedItem.ToString();
                var loai = dt.LOAIPHUTUNGs.Where(t => t.TENPHUTUNG == a).First();
                var loc = from dh in dt.HOADONs
                          where ThongKeTheoNgay() > 0
                          join ct in dt.CTHDs on dh.MAHD equals ct.MAHD
                          join d in dt.PHUTUNGXEs on ct.MAPT equals d.MAPT
                          where d.MALOAI == loai.MALOAI
                          select new
                          {
                              MãPT = ct.MAPT,
                              TênPT = d.TENPT,
                              SốLượngMua = ct.SOLUONG,
                              GiáBán = d.GIABAN,
                              ThànhTiền = ct.SOLUONG * d.GIABAN
                          };
                dataGridView1.DataSource = loc;
            }
            catch (Exception) { }
        }

        private void dtpkFromDate_ValueChanged(object sender, EventArgs e)
        {

        }


    }
}
