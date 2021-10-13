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
    public partial class report : Form
    {
        public report()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            load(); 
            this.rp.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QL_PHUTUNGConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "rpHD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@SDT",textBox1.Text));
            cmd.Parameters.Add(new SqlParameter("@NGAY", dateTimePicker1.Value.Date));
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            rp.ProcessingMode = ProcessingMode.Local;
            rp.LocalReport.ReportPath = "Report1.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "dsHDBH";
                rds.Value = ds.Tables[0];
                rp.LocalReport.DataSources.Clear();
                rp.LocalReport.DataSources.Add(rds);
                rp.RefreshReport();
            }
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();
        public void load()
        {
            dataGridView1.DataSource = db.HOADONs.ToList();
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[6].Visible = false;


            var k = from s in db.HOADONs
                    from a in db.NHANVIENs
                    where s.MANV == a.MANV 
                    select new
                    {
                        MAHD = s.MAHD,
                        SDT = s.SDT,
                        TENNV = a.TENNV,
                        NGAYBAN = s.NGAYBAN,

                    };
            dataGridView1.DataSource = k;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

    }
}
