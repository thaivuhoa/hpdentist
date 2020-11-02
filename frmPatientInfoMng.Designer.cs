namespace HpDentist
{
    partial class frmPatientInfoMng
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
            this.dtBirth = new System.Windows.Forms.DateTimePicker();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.cboCity = new System.Windows.Forms.ComboBox();
            this.cboDistrict = new System.Windows.Forms.ComboBox();
            this.txtStreet = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lbSymtom = new System.Windows.Forms.Label();
            this.btnSymtom = new System.Windows.Forms.Button();
            this.lbSymtomID = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.Label();
            this.chkDeleted = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // dtBirth
            // 
            this.dtBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBirth.Location = new System.Drawing.Point(197, 163);
            this.dtBirth.Name = "dtBirth";
            this.dtBirth.Size = new System.Drawing.Size(200, 22);
            this.dtBirth.TabIndex = 32;
            // 
            // txtTelephone
            // 
            this.txtTelephone.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTelephone.Location = new System.Drawing.Point(197, 127);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(131, 22);
            this.txtTelephone.TabIndex = 31;
            // 
            // cboCity
            // 
            this.cboCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCity.FormattingEnabled = true;
            this.cboCity.Location = new System.Drawing.Point(559, 126);
            this.cboCity.Name = "cboCity";
            this.cboCity.Size = new System.Drawing.Size(163, 24);
            this.cboCity.TabIndex = 29;
            this.cboCity.SelectedIndexChanged += new System.EventHandler(this.CboCity_SelectedIndexChanged);
            // 
            // cboDistrict
            // 
            this.cboDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDistrict.FormattingEnabled = true;
            this.cboDistrict.Location = new System.Drawing.Point(559, 162);
            this.cboDistrict.Name = "cboDistrict";
            this.cboDistrict.Size = new System.Drawing.Size(163, 24);
            this.cboDistrict.TabIndex = 30;
            // 
            // txtStreet
            // 
            this.txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet.Location = new System.Drawing.Point(559, 94);
            this.txtStreet.Name = "txtStreet";
            this.txtStreet.Size = new System.Drawing.Size(200, 22);
            this.txtStreet.TabIndex = 28;
            // 
            // txtFullName
            // 
            this.txtFullName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFullName.Location = new System.Drawing.Point(197, 94);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(172, 22);
            this.txtFullName.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(111, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 16);
            this.label9.TabIndex = 26;
            this.label9.Text = "NGÀY SINH:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(109, 130);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "ĐIỆN THOẠI:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(468, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "THÀNH PHỐ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(499, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 16);
            this.label7.TabIndex = 23;
            this.label7.Text = "ĐƯỜNG:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(509, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "QUẬN:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 21;
            this.label4.Text = "HỌ VÀ TÊN:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(213, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(448, 29);
            this.label2.TabIndex = 33;
            this.label2.Text = "CẬP NHẬT THÔNG TIN BỆNH NHÂN";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(722, 242);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 23);
            this.btnCancel.TabIndex = 41;
            this.btnCancel.Text = "ĐÓN&G";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(622, 242);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(88, 23);
            this.btnDelete.TabIndex = 40;
            this.btnDelete.Text = "&XÓA";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(525, 242);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 23);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "&LƯU";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(90, 203);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 16);
            this.label11.TabIndex = 48;
            this.label11.Text = "TIỀN SỬ BỆNH:";
            // 
            // lbSymtom
            // 
            this.lbSymtom.AutoSize = true;
            this.lbSymtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSymtom.Location = new System.Drawing.Point(235, 195);
            this.lbSymtom.Name = "lbSymtom";
            this.lbSymtom.Size = new System.Drawing.Size(0, 16);
            this.lbSymtom.TabIndex = 49;
            // 
            // btnSymtom
            // 
            this.btnSymtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSymtom.Image = global::HpDentist.Properties.Resources.add;
            this.btnSymtom.Location = new System.Drawing.Point(197, 198);
            this.btnSymtom.Name = "btnSymtom";
            this.btnSymtom.Size = new System.Drawing.Size(29, 23);
            this.btnSymtom.TabIndex = 47;
            this.btnSymtom.UseVisualStyleBackColor = true;
            this.btnSymtom.Click += new System.EventHandler(this.BtnSymtom_Click);
            // 
            // lbSymtomID
            // 
            this.lbSymtomID.AutoSize = true;
            this.lbSymtomID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSymtomID.Location = new System.Drawing.Point(194, 263);
            this.lbSymtomID.Name = "lbSymtomID";
            this.lbSymtomID.Size = new System.Drawing.Size(0, 16);
            this.lbSymtomID.TabIndex = 50;
            // 
            // txtPatientID
            // 
            this.txtPatientID.AutoSize = true;
            this.txtPatientID.Location = new System.Drawing.Point(61, 26);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(0, 13);
            this.txtPatientID.TabIndex = 51;
            // 
            // chkDeleted
            // 
            this.chkDeleted.AutoSize = true;
            this.chkDeleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDeleted.Location = new System.Drawing.Point(197, 242);
            this.chkDeleted.Name = "chkDeleted";
            this.chkDeleted.Size = new System.Drawing.Size(140, 20);
            this.chkDeleted.TabIndex = 52;
            this.chkDeleted.Text = "Bệnh Nhân Đã Xóa";
            this.chkDeleted.UseVisualStyleBackColor = true;
            // 
            // frmPatientInfoMng
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 318);
            this.Controls.Add(this.chkDeleted);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.lbSymtomID);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbSymtom);
            this.Controls.Add(this.btnSymtom);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtBirth);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.cboCity);
            this.Controls.Add(this.cboDistrict);
            this.Controls.Add(this.txtStreet);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Name = "frmPatientInfoMng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cập Nhật Thông Tin Bệnh Nhân";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPatientInfoMng_FormClosed);
            this.Load += new System.EventHandler(this.FrmPatientInfoMng_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtBirth;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.ComboBox cboCity;
        private System.Windows.Forms.ComboBox cboDistrict;
        private System.Windows.Forms.TextBox txtStreet;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbSymtom;
        private System.Windows.Forms.Button btnSymtom;
        private System.Windows.Forms.Label lbSymtomID;
        private System.Windows.Forms.Label txtPatientID;
        private System.Windows.Forms.CheckBox chkDeleted;
    }
}
