namespace DoanCNPM
{
    partial class thongke
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnThongKe = new System.Windows.Forms.Panel();
            this.radPT = new System.Windows.Forms.RadioButton();
            this.radNV = new System.Windows.Forms.RadioButton();
            this.radTheLoai = new System.Windows.Forms.RadioButton();
            this.radDoanhThu = new System.Windows.Forms.RadioButton();
            this.cboItemLoaiPT = new System.Windows.Forms.ComboBox();
            this.cboItemNV = new System.Windows.Forms.ComboBox();
            this.dtpkToDate = new System.Windows.Forms.DateTimePicker();
            this.dtpkFromDate = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnThongKe
            // 
            this.pnThongKe.Controls.Add(this.radPT);
            this.pnThongKe.Controls.Add(this.radNV);
            this.pnThongKe.Controls.Add(this.radTheLoai);
            this.pnThongKe.Controls.Add(this.radDoanhThu);
            this.pnThongKe.Controls.Add(this.cboItemLoaiPT);
            this.pnThongKe.Controls.Add(this.cboItemNV);
            this.pnThongKe.Location = new System.Drawing.Point(30, 101);
            this.pnThongKe.Margin = new System.Windows.Forms.Padding(4);
            this.pnThongKe.Name = "pnThongKe";
            this.pnThongKe.Size = new System.Drawing.Size(1032, 55);
            this.pnThongKe.TabIndex = 17;
            // 
            // radPT
            // 
            this.radPT.AutoSize = true;
            this.radPT.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radPT.ForeColor = System.Drawing.Color.Purple;
            this.radPT.Location = new System.Drawing.Point(4, 22);
            this.radPT.Margin = new System.Windows.Forms.Padding(4);
            this.radPT.Name = "radPT";
            this.radPT.Size = new System.Drawing.Size(214, 29);
            this.radPT.TabIndex = 2;
            this.radPT.TabStop = true;
            this.radPT.Text = "Phụ Tùng Được Mua";
            this.radPT.UseVisualStyleBackColor = false;
            this.radPT.CheckedChanged += new System.EventHandler(this.radPT_CheckedChanged);
            // 
            // radNV
            // 
            this.radNV.AutoSize = true;
            this.radNV.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radNV.ForeColor = System.Drawing.Color.Purple;
            this.radNV.Location = new System.Drawing.Point(241, 22);
            this.radNV.Margin = new System.Windows.Forms.Padding(4);
            this.radNV.Name = "radNV";
            this.radNV.Size = new System.Drawing.Size(125, 29);
            this.radNV.TabIndex = 2;
            this.radNV.TabStop = true;
            this.radNV.Text = "Nhân Viên";
            this.radNV.UseVisualStyleBackColor = false;
            this.radNV.CheckedChanged += new System.EventHandler(this.radNV_CheckedChanged);
            // 
            // radTheLoai
            // 
            this.radTheLoai.AutoSize = true;
            this.radTheLoai.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radTheLoai.ForeColor = System.Drawing.Color.Purple;
            this.radTheLoai.Location = new System.Drawing.Point(384, 22);
            this.radTheLoai.Margin = new System.Windows.Forms.Padding(4);
            this.radTheLoai.Name = "radTheLoai";
            this.radTheLoai.Size = new System.Drawing.Size(141, 29);
            this.radTheLoai.TabIndex = 2;
            this.radTheLoai.TabStop = true;
            this.radTheLoai.Text = "Thể Loại PT";
            this.radTheLoai.UseVisualStyleBackColor = false;
            this.radTheLoai.CheckedChanged += new System.EventHandler(this.radTheLoai_CheckedChanged);
            // 
            // radDoanhThu
            // 
            this.radDoanhThu.AutoSize = true;
            this.radDoanhThu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.radDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDoanhThu.ForeColor = System.Drawing.Color.Purple;
            this.radDoanhThu.Location = new System.Drawing.Point(540, 22);
            this.radDoanhThu.Margin = new System.Windows.Forms.Padding(4);
            this.radDoanhThu.Name = "radDoanhThu";
            this.radDoanhThu.Size = new System.Drawing.Size(131, 29);
            this.radDoanhThu.TabIndex = 2;
            this.radDoanhThu.TabStop = true;
            this.radDoanhThu.Text = "Doanh Thu";
            this.radDoanhThu.UseVisualStyleBackColor = false;
            this.radDoanhThu.CheckedChanged += new System.EventHandler(this.radDoanhThu_CheckedChanged);
            // 
            // cboItemLoaiPT
            // 
            this.cboItemLoaiPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemLoaiPT.FormattingEnabled = true;
            this.cboItemLoaiPT.Location = new System.Drawing.Point(695, 17);
            this.cboItemLoaiPT.Margin = new System.Windows.Forms.Padding(4);
            this.cboItemLoaiPT.Name = "cboItemLoaiPT";
            this.cboItemLoaiPT.Size = new System.Drawing.Size(332, 33);
            this.cboItemLoaiPT.TabIndex = 3;
            this.cboItemLoaiPT.SelectedIndexChanged += new System.EventHandler(this.cboItemLoaiPT_SelectedIndexChanged);
            // 
            // cboItemNV
            // 
            this.cboItemNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboItemNV.FormattingEnabled = true;
            this.cboItemNV.Location = new System.Drawing.Point(695, 17);
            this.cboItemNV.Margin = new System.Windows.Forms.Padding(4);
            this.cboItemNV.Name = "cboItemNV";
            this.cboItemNV.Size = new System.Drawing.Size(332, 33);
            this.cboItemNV.TabIndex = 3;
            // 
            // dtpkToDate
            // 
            this.dtpkToDate.CustomFormat = "dd/MM/yyyy";
            this.dtpkToDate.Enabled = false;
            this.dtpkToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkToDate.Location = new System.Drawing.Point(646, 62);
            this.dtpkToDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkToDate.Name = "dtpkToDate";
            this.dtpkToDate.Size = new System.Drawing.Size(151, 30);
            this.dtpkToDate.TabIndex = 15;
            // 
            // dtpkFromDate
            // 
            this.dtpkFromDate.CustomFormat = "dd/MM/yyyy";
            this.dtpkFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkFromDate.Location = new System.Drawing.Point(359, 62);
            this.dtpkFromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpkFromDate.Name = "dtpkFromDate";
            this.dtpkFromDate.Size = new System.Drawing.Size(151, 30);
            this.dtpkFromDate.TabIndex = 16;
            this.dtpkFromDate.ValueChanged += new System.EventHandler(this.dtpkFromDate_ValueChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 204);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1077, 309);
            this.dataGridView1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(533, 63);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Đến Ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(262, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "Từ Ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(442, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 31);
            this.label1.TabIndex = 11;
            this.label1.Text = "Thống Kê";
            // 
            // thongke
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 513);
            this.Controls.Add(this.pnThongKe);
            this.Controls.Add(this.dtpkToDate);
            this.Controls.Add(this.dtpkFromDate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "thongke";
            this.Text = "thongke";
            this.Load += new System.EventHandler(this.thongke_Load);
            this.pnThongKe.ResumeLayout(false);
            this.pnThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnThongKe;
        private System.Windows.Forms.RadioButton radPT;
        private System.Windows.Forms.RadioButton radNV;
        private System.Windows.Forms.RadioButton radTheLoai;
        private System.Windows.Forms.RadioButton radDoanhThu;
        private System.Windows.Forms.ComboBox cboItemLoaiPT;
        private System.Windows.Forms.ComboBox cboItemNV;
        private System.Windows.Forms.DateTimePicker dtpkToDate;
        private System.Windows.Forms.DateTimePicker dtpkFromDate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}