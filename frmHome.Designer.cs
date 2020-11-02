namespace HpDentist
{
    partial class FrmHome
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPatientManage = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.btnSymtom = new System.Windows.Forms.Button();
            this.lnkChangePass = new System.Windows.Forms.LinkLabel();
            this.btnManageUser = new System.Windows.Forms.Button();
            this.lnkLogOut = new System.Windows.Forms.LinkLabel();
            this.lbUserName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(139, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(534, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH QUẢN TRỊ PHÒNG KHÁM";
            // 
            // btnPatientManage
            // 
            this.btnPatientManage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPatientManage.Location = new System.Drawing.Point(266, 151);
            this.btnPatientManage.Name = "btnPatientManage";
            this.btnPatientManage.Size = new System.Drawing.Size(284, 35);
            this.btnPatientManage.TabIndex = 1;
            this.btnPatientManage.Text = "BỆNH NHÂN VÀ PHIẾU KHÁM";
            this.btnPatientManage.UseVisualStyleBackColor = true;
            this.btnPatientManage.Click += new System.EventHandler(this.BtnPatientManage_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoctor.Location = new System.Drawing.Point(266, 210);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(284, 35);
            this.btnDoctor.TabIndex = 2;
            this.btnDoctor.Text = "DANH SÁCH BÁC SĨ";
            this.btnDoctor.UseVisualStyleBackColor = true;
            // 
            // btnSymtom
            // 
            this.btnSymtom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSymtom.Location = new System.Drawing.Point(266, 269);
            this.btnSymtom.Name = "btnSymtom";
            this.btnSymtom.Size = new System.Drawing.Size(284, 35);
            this.btnSymtom.TabIndex = 3;
            this.btnSymtom.Text = "DANH MỤC TIỀN SỬ BỆNH";
            this.btnSymtom.UseVisualStyleBackColor = true;
            this.btnSymtom.Click += new System.EventHandler(this.BtnSymtom_Click);
            // 
            // lnkChangePass
            // 
            this.lnkChangePass.AutoSize = true;
            this.lnkChangePass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkChangePass.Location = new System.Drawing.Point(611, 35);
            this.lnkChangePass.Name = "lnkChangePass";
            this.lnkChangePass.Size = new System.Drawing.Size(118, 16);
            this.lnkChangePass.TabIndex = 30;
            this.lnkChangePass.TabStop = true;
            this.lnkChangePass.Text = "Change Password";
            this.lnkChangePass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkChangePass_LinkClicked);
            // 
            // btnManageUser
            // 
            this.btnManageUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnManageUser.Location = new System.Drawing.Point(266, 328);
            this.btnManageUser.Name = "btnManageUser";
            this.btnManageUser.Size = new System.Drawing.Size(284, 35);
            this.btnManageUser.TabIndex = 5;
            this.btnManageUser.Text = "QUẢN TRỊ NGƯỜI DÙNG";
            this.btnManageUser.UseVisualStyleBackColor = true;
            this.btnManageUser.Visible = false;
            this.btnManageUser.Click += new System.EventHandler(this.BtnManageUser_Click);
            // 
            // lnkLogOut
            // 
            this.lnkLogOut.AutoSize = true;
            this.lnkLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogOut.LinkColor = System.Drawing.Color.Red;
            this.lnkLogOut.Location = new System.Drawing.Point(734, 35);
            this.lnkLogOut.Name = "lnkLogOut";
            this.lnkLogOut.Size = new System.Drawing.Size(54, 16);
            this.lnkLogOut.TabIndex = 31;
            this.lnkLogOut.TabStop = true;
            this.lnkLogOut.Text = "Log Out";
            this.lnkLogOut.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLogOut_LinkClicked);
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUserName.ForeColor = System.Drawing.Color.Blue;
            this.lbUserName.Location = new System.Drawing.Point(656, 9);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(83, 16);
            this.lbUserName.TabIndex = 32;
            this.lbUserName.Text = "Thai Vu Hoa";
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lnkLogOut);
            this.Controls.Add(this.lnkChangePass);
            this.Controls.Add(this.btnManageUser);
            this.Controls.Add(this.btnSymtom);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.btnPatientManage);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPatientManage;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.Button btnSymtom;
        private System.Windows.Forms.LinkLabel lnkChangePass;
        private System.Windows.Forms.Button btnManageUser;
        private System.Windows.Forms.LinkLabel lnkLogOut;
        private System.Windows.Forms.Label lbUserName;
    }
}

