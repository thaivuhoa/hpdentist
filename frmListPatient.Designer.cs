namespace HpDentist
{
    partial class frmListPatient
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridPatients = new System.Windows.Forms.DataGridView();
            this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.service = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatreason = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.teethmap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Patientid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ticketid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.symtom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServiceSrch = new System.Windows.Forms.TextBox();
            this.txtPhoneSrch = new System.Windows.Forms.TextBox();
            this.txtAddressSrch = new System.Windows.Forms.TextBox();
            this.txtFullNmSrch = new System.Windows.Forms.TextBox();
            this.txtTreatReason = new System.Windows.Forms.TextBox();
            this.dtFrom = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtTo = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnReload = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tipTicketDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdatePatient = new System.Windows.Forms.ToolStripMenuItem();
            this.tipAddPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.chkDeleted = new System.Windows.Forms.CheckBox();
            this.btnAddPatient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridPatients)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridPatients
            // 
            this.gridPatients.AllowUserToAddRows = false;
            this.gridPatients.AllowUserToDeleteRows = false;
            this.gridPatients.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fullname,
            this.address,
            this.phone,
            this.service,
            this.treatdate,
            this.treatreason,
            this.teethmap,
            this.Patientid,
            this.ticketid,
            this.symtom});
            this.gridPatients.Location = new System.Drawing.Point(29, 166);
            this.gridPatients.Name = "gridPatients";
            this.gridPatients.ReadOnly = true;
            this.gridPatients.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPatients.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPatients.Size = new System.Drawing.Size(1136, 329);
            this.gridPatients.TabIndex = 10;
            this.gridPatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPatients_CellClick);
            this.gridPatients.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPatients_CellContentDoubleClick);
            this.gridPatients.CellContextMenuStripChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPatients_CellContentDoubleClick);
            this.gridPatients.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.GridPatients_DataBindingComplete);
            this.gridPatients.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GridPatients_MouseClick);
            // 
            // fullname
            // 
            this.fullname.DataPropertyName = "fullname";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fullname.DefaultCellStyle = dataGridViewCellStyle2;
            this.fullname.HeaderText = "HỌ VÀ TÊN";
            this.fullname.Name = "fullname";
            this.fullname.ReadOnly = true;
            this.fullname.Width = 170;
            // 
            // address
            // 
            this.address.DataPropertyName = "address";
            this.address.HeaderText = "ĐỊA CHỈ";
            this.address.Name = "address";
            this.address.ReadOnly = true;
            this.address.Width = 250;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "telephone";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phone.DefaultCellStyle = dataGridViewCellStyle3;
            this.phone.HeaderText = "PHONE";
            this.phone.Name = "phone";
            this.phone.ReadOnly = true;
            // 
            // service
            // 
            this.service.DataPropertyName = "servicename";
            this.service.HeaderText = "ĐIỀU TRỊ";
            this.service.Name = "service";
            this.service.ReadOnly = true;
            this.service.Width = 150;
            // 
            // treatdate
            // 
            this.treatdate.DataPropertyName = "treatdateval";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.treatdate.DefaultCellStyle = dataGridViewCellStyle4;
            this.treatdate.HeaderText = "NGÀY ĐIỀU TRỊ";
            this.treatdate.Name = "treatdate";
            this.treatdate.ReadOnly = true;
            this.treatdate.Width = 150;
            // 
            // treatreason
            // 
            this.treatreason.DataPropertyName = "treatreason";
            this.treatreason.HeaderText = "NGUYÊN NHÂN";
            this.treatreason.Name = "treatreason";
            this.treatreason.ReadOnly = true;
            this.treatreason.Width = 313;
            // 
            // teethmap
            // 
            this.teethmap.HeaderText = "TeethMap";
            this.teethmap.Name = "teethmap";
            this.teethmap.ReadOnly = true;
            this.teethmap.Visible = false;
            // 
            // Patientid
            // 
            this.Patientid.DataPropertyName = "patientid";
            this.Patientid.HeaderText = "Patientid";
            this.Patientid.Name = "Patientid";
            this.Patientid.ReadOnly = true;
            this.Patientid.Visible = false;
            // 
            // ticketid
            // 
            this.ticketid.DataPropertyName = "ticketid";
            this.ticketid.HeaderText = "TicketId";
            this.ticketid.Name = "ticketid";
            this.ticketid.ReadOnly = true;
            this.ticketid.Visible = false;
            // 
            // symtom
            // 
            this.symtom.DataPropertyName = "symtom";
            this.symtom.HeaderText = "SYMTOM";
            this.symtom.Name = "symtom";
            this.symtom.ReadOnly = true;
            this.symtom.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(366, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(317, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "DANH SÁCH BỆNH NHÂN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtServiceSrch
            // 
            this.txtServiceSrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtServiceSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtServiceSrch.Location = new System.Drawing.Point(551, 136);
            this.txtServiceSrch.Name = "txtServiceSrch";
            this.txtServiceSrch.Size = new System.Drawing.Size(143, 23);
            this.txtServiceSrch.TabIndex = 8;
            this.txtServiceSrch.TextChanged += new System.EventHandler(this.TxtServiceSrch_TextChanged);
            // 
            // txtPhoneSrch
            // 
            this.txtPhoneSrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPhoneSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneSrch.Location = new System.Drawing.Point(451, 136);
            this.txtPhoneSrch.Name = "txtPhoneSrch";
            this.txtPhoneSrch.Size = new System.Drawing.Size(90, 23);
            this.txtPhoneSrch.TabIndex = 7;
            this.txtPhoneSrch.TextChanged += new System.EventHandler(this.TxtPhoneSrch_TextChanged);
            // 
            // txtAddressSrch
            // 
            this.txtAddressSrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAddressSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressSrch.Location = new System.Drawing.Point(199, 136);
            this.txtAddressSrch.Name = "txtAddressSrch";
            this.txtAddressSrch.Size = new System.Drawing.Size(194, 23);
            this.txtAddressSrch.TabIndex = 6;
            this.txtAddressSrch.TextChanged += new System.EventHandler(this.TxtAddressSrch_TextChanged);
            // 
            // txtFullNmSrch
            // 
            this.txtFullNmSrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFullNmSrch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullNmSrch.Location = new System.Drawing.Point(29, 136);
            this.txtFullNmSrch.Name = "txtFullNmSrch";
            this.txtFullNmSrch.Size = new System.Drawing.Size(164, 23);
            this.txtFullNmSrch.TabIndex = 5;
            this.txtFullNmSrch.TextChanged += new System.EventHandler(this.TxtFullNmSrch_TextChanged);
            // 
            // txtTreatReason
            // 
            this.txtTreatReason.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTreatReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTreatReason.Location = new System.Drawing.Point(849, 136);
            this.txtTreatReason.Name = "txtTreatReason";
            this.txtTreatReason.Size = new System.Drawing.Size(198, 23);
            this.txtTreatReason.TabIndex = 9;
            this.txtTreatReason.TextChanged += new System.EventHandler(this.TxtTreatReason_TextChanged);
            // 
            // dtFrom
            // 
            this.dtFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFrom.Location = new System.Drawing.Point(269, 79);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Size = new System.Drawing.Size(123, 23);
            this.dtFrom.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(54, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "THỜI GIAN ĐIỀU TRỊ TỪ NGÀY:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(427, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "ĐẾN NGÀY:";
            // 
            // dtTo
            // 
            this.dtTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTo.Location = new System.Drawing.Point(519, 79);
            this.dtTo.Name = "dtTo";
            this.dtTo.Size = new System.Drawing.Size(118, 23);
            this.dtTo.TabIndex = 2;
            // 
            // btnFilter
            // 
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.Location = new System.Drawing.Point(652, 72);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(108, 36);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "LỌC DỮ LIỆU";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.BtnFilter_Click);
            // 
            // btnReload
            // 
            this.btnReload.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReload.Location = new System.Drawing.Point(775, 72);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(103, 36);
            this.btnReload.TabIndex = 4;
            this.btnReload.Text = "LÀM MỚI";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Visible = false;
            this.btnReload.Click += new System.EventHandler(this.BtnReload_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tipTicketDetail,
            this.btnUpdatePatient,
            this.tipAddPatient});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(202, 70);
            // 
            // tipTicketDetail
            // 
            this.tipTicketDetail.Name = "tipTicketDetail";
            this.tipTicketDetail.Size = new System.Drawing.Size(201, 22);
            this.tipTicketDetail.Text = "Chi Tiết Phiếu Khám";
            this.tipTicketDetail.Click += new System.EventHandler(this.TipTicketDetail_Click);
            // 
            // btnUpdatePatient
            // 
            this.btnUpdatePatient.Name = "btnUpdatePatient";
            this.btnUpdatePatient.Size = new System.Drawing.Size(201, 22);
            this.btnUpdatePatient.Text = "Cập Nhật Thông Tin BN";
            this.btnUpdatePatient.Click += new System.EventHandler(this.BtnUpdatePatient_Click);
            // 
            // tipAddPatient
            // 
            this.tipAddPatient.Name = "tipAddPatient";
            this.tipAddPatient.Size = new System.Drawing.Size(201, 22);
            this.tipAddPatient.Text = "Thêm Mới Bệnh Nhân";
            this.tipAddPatient.Click += new System.EventHandler(this.TipAddPatient_Click);
            // 
            // chkDeleted
            // 
            this.chkDeleted.AutoSize = true;
            this.chkDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleted.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.chkDeleted.Location = new System.Drawing.Point(901, 80);
            this.chkDeleted.Name = "chkDeleted";
            this.chkDeleted.Size = new System.Drawing.Size(201, 21);
            this.chkDeleted.TabIndex = 11;
            this.chkDeleted.Text = "Tìm kiếm bệnh nhân đã xóa";
            this.chkDeleted.UseVisualStyleBackColor = true;
            // 
            // btnAddPatient
            // 
            this.btnAddPatient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatient.Location = new System.Drawing.Point(703, 15);
            this.btnAddPatient.Name = "btnAddPatient";
            this.btnAddPatient.Size = new System.Drawing.Size(144, 28);
            this.btnAddPatient.TabIndex = 12;
            this.btnAddPatient.Text = "THÊM MỚI BỆNH NHÂN";
            this.btnAddPatient.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAddPatient.UseVisualStyleBackColor = true;
            this.btnAddPatient.Click += new System.EventHandler(this.BtnAddPatient_Click);
            // 
            // frmListPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 507);
            this.Controls.Add(this.btnAddPatient);
            this.Controls.Add(this.chkDeleted);
            this.Controls.Add(this.btnReload);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtTo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtFrom);
            this.Controls.Add(this.txtTreatReason);
            this.Controls.Add(this.txtServiceSrch);
            this.Controls.Add(this.txtPhoneSrch);
            this.Controls.Add(this.txtAddressSrch);
            this.Controls.Add(this.txtFullNmSrch);
            this.Controls.Add(this.gridPatients);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "frmListPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient List";
            this.Load += new System.EventHandler(this.FrmListPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridPatients)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServiceSrch;
        private System.Windows.Forms.TextBox txtPhoneSrch;
        private System.Windows.Forms.TextBox txtAddressSrch;
        private System.Windows.Forms.TextBox txtFullNmSrch;
        private System.Windows.Forms.TextBox txtTreatReason;
        private System.Windows.Forms.DateTimePicker dtFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridView gridPatients;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnUpdatePatient;
        private System.Windows.Forms.CheckBox chkDeleted;
        private System.Windows.Forms.ToolStripMenuItem tipAddPatient;
        private System.Windows.Forms.Button btnAddPatient;
        private System.Windows.Forms.ToolStripMenuItem tipTicketDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn service;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatreason;
        private System.Windows.Forms.DataGridViewTextBoxColumn teethmap;
        private System.Windows.Forms.DataGridViewTextBoxColumn Patientid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ticketid;
        private System.Windows.Forms.DataGridViewTextBoxColumn symtom;
    }
}
