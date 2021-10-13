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
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;


namespace DoanCNPM
{
    public partial class FromYT : DevExpress.XtraEditors.XtraForm
    {
        public FromYT()
        {
            InitializeComponent();
            loadddd(CBTENHANG);
      
       
        }

        private void loadddd(DevExpress.XtraEditors.Repository.RepositoryItemSearchLookUpEdit CBTENHANG)
        {
            var hd = from k in db.PHUTUNGXEs
                     select k;
            CBTENHANG.DataSource = hd.ToList();
            CBTENHANG.DisplayMember = "GIABAN";
            CBTENHANG.ValueMember = "MAPT";

            CBTENHANG.PopupFilterMode = DevExpress.XtraEditors.PopupFilterMode.Contains;
            CBTENHANG.PopupFormSize = new Size(600, 400);
            CBTENHANG.View.Columns.Clear();
            CBTENHANG.View.Columns.AddVisible("MAPT", "MÃ HÀNG");
            CBTENHANG.View.Columns.AddVisible("TENPT", "TÊN HÀNG");
            CBTENHANG.View.Columns.AddVisible("GIABAN", "GIÁ");
            CBTENHANG.View.OptionsView.ShowColumnHeaders = true;
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        private void FromYT_Load(object sender, EventArgs e)
        {
            loaddulieu();
        }
        
        public void loaddulieu()
        {

            SqlConnection custConn = new SqlConnection("Data Source=DESKTOP-IBF305R;Initial Catalog=QL_PHUTUNG1;User ID=sa;Password=sa123");
            SqlDataAdapter customerDA = new SqlDataAdapter("SELECT * FROM CTHD where MAHD= 1 ", custConn);
            custConn.Open();
            DataSet customerDS = new DataSet();
            customerDA.Fill(customerDS);
            gridControl1.DataSource = customerDS.Tables[0];
            custConn.Close();

        }

  


        private void CBTENHANG_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            if (e.Value == null)
            {
                return;
            }
            else if (e.Value.ToString() == "")
            {
                return;
            }
            else
            { e.DisplayText = e.Value.ToString(); }
        }

       

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
           
            if ((e.Value == null) || (e.Value.ToString() == "")) return;
            decimal DONGIA = 0;
            decimal SOLUONG = 0;
            decimal GIAMGIA = 0;
            decimal THANHTIEN = 0;
            if (gridView1.GetRowCellValue(e.RowHandle, "SOLUONG") is DBNull)
            {
                SOLUONG = 0;
            }
            else
                SOLUONG = Math.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "SOLUONG")), 3, MidpointRounding.AwayFromZero);

            ////////////////
            if (gridView1.GetRowCellValue(e.RowHandle, "DONGIA") is DBNull)
            {
                DONGIA = 0;
            }
            else
                DONGIA = Math.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "DONGIA")), 0, MidpointRounding.AwayFromZero);
            /////////////

            if (gridView1.GetRowCellValue(e.RowHandle, "GIAMGIA") is DBNull)
            {
                GIAMGIA = 0;
            }
            else
                GIAMGIA = Math.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "GIAMGIA")), 0, MidpointRounding.AwayFromZero);
            ////////////////
            if (gridView1.GetRowCellValue(e.RowHandle, "THANHTIEN") is DBNull)
            {
                THANHTIEN = 0;
            }
            else
                THANHTIEN = Math.Round(Convert.ToDecimal(gridView1.GetRowCellValue(e.RowHandle, "THANHTIEN")), 0, MidpointRounding.AwayFromZero);
            //////////////

            switch (e.Column.FieldName.ToString())
            {

                case "MAPT":
                    this.gridView1.SetRowCellValue(e.RowHandle, "DONGIA", this.CBTENHANG.GetDisplayValueByKeyValue(e.Value.ToString()));
                    #region asdas
                    for (int i = 0; i < this.gridView1.RowCount - 1; i++)
                    {
                        if (gridView1.GetRowCellValue(i, "MAPT") == null) continue;
                        string tmp = gridView1.GetRowCellValue(i, "MAPT").ToString();
                        int dong = gridView1.FocusedRowHandle;
                        string mahang = gridView1.GetRowCellValue(dong, "MAPT").ToString();
                        if (tmp == mahang)
                        {
                            this.gridView1.SetRowCellValue(e.RowHandle, "MAPT", "");
                            MessageBox.Show("Đã tồn tại giá trị rồi !!!!","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            return;
                        }
                     
                    } 
                    this.gridView1.SetRowCellValue(e.RowHandle, "DONGIA", this.CBTENHANG.GetDisplayValueByKeyValue(e.Value.ToString()));
                    #endregion
                    this.gridView1.FocusedRowHandle = e.RowHandle;
                    break;

                case "DONGIA":
                    THANHTIEN = Math.Round(SOLUONG * DONGIA - GIAMGIA, 0, MidpointRounding.AwayFromZero);
                    this.gridView1.SetRowCellValue(e.RowHandle, "THANHTIEN", THANHTIEN);
                    break;
                case "SOLUONG":
                    THANHTIEN = Math.Round(SOLUONG * DONGIA - GIAMGIA, 0, MidpointRounding.AwayFromZero);
                    this.gridView1.SetRowCellValue(e.RowHandle, "THANHTIEN", THANHTIEN);
                    break;
                case "GIAMGIA":
                    THANHTIEN = Math.Round(SOLUONG * DONGIA - GIAMGIA, 0, MidpointRounding.AwayFromZero);
                    this.gridView1.SetRowCellValue(e.RowHandle, "THANHTIEN", THANHTIEN);
                    break;

            }

        }

        private void gridView1_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            tinhtong();
        }

        private void tinhtong()
        {
            decimal thanhtien = 0;
            for (int i = 0; i < this.gridView1.RowCount; i++)
            {
                thanhtien += Convert.ToDecimal(this.gridView1.GetRowCellValue(i, "THANHTIEN"));

            }
            this.spinEdit1.Text = thanhtien.ToString();

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

       
            int gitri = gridView1.RowCount;

            int kk = db.CTHDs.Where(x => x.MAHD == 1).Count();

            int demm = gitri - kk;

         
            for (int i = 0; i < gitri - 1; i++)
            {
                if (this.gridView1.GetRowCellValue(i, "MAPT").ToString() == "")
                {
                    MessageBox.Show("Bạn cần sửa thông tin của dòng -> " + this.gridView1.GetRowCellValue(i, "MAPT").ToString() + " Không được để trắng");
                    loaddulieu();
                    return;
                }
                CTHD ct = new CTHD();
                ct.MAHD = int.Parse(this.gridView1.GetRowCellValue(i, "MAHD").ToString());
                ct.MAPT = int.Parse(this.gridView1.GetRowCellValue(i, "MAPT").ToString());
                ct.SOLUONG = int.Parse(this.gridView1.GetRowCellValue(i, "SOLUONG").ToString());
                ct.DONGIA = int.Parse(this.gridView1.GetRowCellValue(i, "DONGIA").ToString());
                ct.GIAMGIA = int.Parse(this.gridView1.GetRowCellValue(i, "GIAMGIA").ToString());
                ct.THANHTIEN = int.Parse(this.gridView1.GetRowCellValue(i, "THANHTIEN").ToString());
                db.SubmitChanges();
             
            }
            for (int i = kk; i < gitri - 1; i++)
            {
              
                CTHD ct = new CTHD();
                ct.MAHD = int.Parse(this.gridView1.GetRowCellValue(i, "MAHD").ToString());
                ct.MAPT = int.Parse(this.gridView1.GetRowCellValue(i, "MAPT").ToString());
                ct.SOLUONG = int.Parse(this.gridView1.GetRowCellValue(i, "SOLUONG").ToString());
                ct.DONGIA = int.Parse(this.gridView1.GetRowCellValue(i, "DONGIA").ToString());
                ct.GIAMGIA = int.Parse(this.gridView1.GetRowCellValue(i, "GIAMGIA").ToString());
                ct.THANHTIEN = int.Parse(this.gridView1.GetRowCellValue(i, "THANHTIEN").ToString());
                db.CTHDs.InsertOnSubmit(ct);
                db.SubmitChanges();
           
            }
            loaddulieu();
            XtraMessageBox.Show("Thay đổi thành công", "Thông Báo");
        }
        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as GridView;
            view.SetRowCellValue(e.RowHandle, view.Columns["MAHD"], 1);
            view.SetRowCellValue(e.RowHandle, view.Columns["SOLUONG"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["DONGIA"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["GIAMGIA"], 0);
            view.SetRowCellValue(e.RowHandle, view.Columns["THANHTIEN"], 0);

            //////////////////////////////
            

            ////////


        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int gitri = gridView1.RowCount;

            int kk = db.CTHDs.Where(x => x.MAHD == 1).Count();
            for (int i = 0; i < gitri - 1; i++)
            {
                if (this.gridView1.GetRowCellValue(i, "MAPT").ToString() == "")
                {
                    MessageBox.Show("Bạn cần sửa thông tin của dòng -> " + this.gridView1.GetRowCellValue(i, "MAPT").ToString() + " Không được để trắng");
                    loaddulieu();
                    return;
                }
                CTHD ct = new CTHD();
                ct.MAHD = int.Parse(this.gridView1.GetRowCellValue(i, "MAHD").ToString());
                ct.MAPT = int.Parse(this.gridView1.GetRowCellValue(i, "MAPT").ToString());
                ct.SOLUONG = int.Parse(this.gridView1.GetRowCellValue(i, "SOLUONG").ToString());
                ct.DONGIA = int.Parse(this.gridView1.GetRowCellValue(i, "DONGIA").ToString());
                ct.GIAMGIA = int.Parse(this.gridView1.GetRowCellValue(i, "GIAMGIA").ToString());
                ct.THANHTIEN = int.Parse(this.gridView1.GetRowCellValue(i, "THANHTIEN").ToString());
                db.SubmitChanges();
            }
            XtraMessageBox.Show("Thay đổi thành công", "Thông Báo");
            loaddulieu();
        }
        int maaaa = 0;
        int maa = 0;
        private void gridControl1_Click(object sender, EventArgs e)
        {
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            maa = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAHD").ToString().Trim());
            maaaa = int.Parse(gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "MAPT").ToString().Trim());
            CTHD knew = db.CTHDs.Where(x => x.MAHD == maa && x.MAPT == maaaa).First();
            db.CTHDs.DeleteOnSubmit(knew);
            db.SubmitChanges();
            MessageBox.Show("Xóa thành công!", "Thông Báo");
            loaddulieu();
        }




    }
}