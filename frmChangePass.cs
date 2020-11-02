using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HpDentist
{
    public partial class frmChangePass : Form
    {
        public static string userName;
        public static string password;
        public frmChangePass()
        {
            InitializeComponent();
        }

        private int checkInput()
        {
            if (this.txtNewPass.Text == "")
            {
                this.lbError.Text = "Please input the New Password!";
                this.txtNewPass.Focus();
                return 0;
            }
            if (this.txtPassConfirm.Text == "")
            {
                this.lbError.Text = "Please input the confirm Password!";
                this.txtPassConfirm.Focus();
                return 0;
            }
            if (this.txtNewPass.Text != this.txtPassConfirm.Text)
            {
                this.lbError.Text = "New Password and Confirm Password must be the same!";
                this.txtNewPass.Focus();
                return 0;
            }
            //check for old password different with new password
            string sql = "select * from users where username = '" + userName + "' and [password]='" + this.txtNewPass.Text + "'";
            Database db = new Database();
            DataSet ds = new DataSet();
            ds = db.selectData(sql);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                this.lbError.Text = "New password must be different with old password!";
                this.txtNewPass.Focus();
                return 0;
            }
            this.lbError.Text = "";
            return 1;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this.checkInput() == 1)
            {
                Database db = new Database();
                string sql = "update users set [password]='" + this.txtNewPass.Text.Trim() + "' where username='" +
                             userName + "' and [password]='" + password + "'";
                int upd = db.updateData(sql);
                if (upd != -1)
                {
                    MessageBox.Show("Password was changed successfully!");
                    this.Close();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPassConfirm.Focus();
            }
        }

        private void TxtPassConfirm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.BtnSave_Click(sender, e);
            }
        }
    }
}
