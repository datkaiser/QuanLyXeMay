using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using DoanCNPM.DAL;
namespace DoanCNPM
{
    public partial class reportNH : Form
    {
        public reportNH()
        {
            InitializeComponent();
        }

        private void reportNH_Load(object sender, EventArgs e)
        {
            load();
            this.rp.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QL_PHUTUNGConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "rpNH";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@TENNCC", textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@NGAY", dateTimePicker1.Value.Date));
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            rp.ProcessingMode = ProcessingMode.Local;
            rp.LocalReport.ReportPath = "Report2.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];
                rp.LocalReport.DataSources.Clear();
                rp.LocalReport.DataSources.Add(rds);
                rp.RefreshReport();
            }
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public void load()
        {
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
            dataGridView1.DataSource = k;
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
