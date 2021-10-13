using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoanCNPM.DAL;
namespace DoanCNPM
{
    public partial class rpLoai : Form
    {
        public rpLoai()
        {
            InitializeComponent();
        }

        private void rpLoai_Load(object sender, EventArgs e)
        {
            this.rp.RefreshReport();
        }
        DataClassesTestDataContext db = new DataClassesTestDataContext();


        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QL_PHUTUNGConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "rpLOAI";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@NGAYBAN", textBox1.Text));
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            rp.ProcessingMode = ProcessingMode.Local;
            rp.LocalReport.ReportPath = "Report7.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSetLoai";
                rds.Value = ds.Tables[0];
                rp.LocalReport.DataSources.Clear();
                rp.LocalReport.DataSources.Add(rds);
                rp.RefreshReport();
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.QL_PHUTUNGConnectionString;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "rpDT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.Add(new SqlParameter("@NGAYBAN", textBox2.Text));
            DataSet ds = new DataSet();
            SqlDataAdapter dap = new SqlDataAdapter(cmd);
            dap.Fill(ds);
            rp.ProcessingMode = ProcessingMode.Local;
            rp.LocalReport.ReportPath = "Report8.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSetDT";
                rds.Value = ds.Tables[0];
                rp.LocalReport.DataSources.Clear();
                rp.LocalReport.DataSources.Add(rds);
                rp.RefreshReport();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
