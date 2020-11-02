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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            DataSet dsUser = new DataSet();
            string query = "";
            if (this.txtUserName.Text.Trim().ToUpper().Equals("ADMIN"))
            {
                query = "select id as userid, username, fullname, usertype from users where ucase(username) = '" + this.txtUserName.Text.Trim().ToUpper() +
                "' and password = '" + this.txtPassword.Text + "'";
            }
            else
            {
                query= "select id as userid, username, fullname, usertype from users where ucase(username) = '" + this.txtUserName.Text.Trim().ToUpper() +
                "' and password = '" + this.txtPassword.Text + "' and Date() >= effectdate and Date() <= expireddate ";
            }
            dsUser = db.selectData(query);
            if (dsUser != null && dsUser.Tables[0].Rows.Count > 0)
            {
                this.Hide();
                FrmHome.userName = this.txtUserName.Text.Trim();
                FrmHome.fullName = dsUser.Tables[0].Rows[0]["fullname"].ToString();
                FrmHome.userid = dsUser.Tables[0].Rows[0]["userid"].ToString();
                FrmHome.passWord = this.txtPassword.Text.Trim();
                FrmHome.userType = int.Parse(dsUser.Tables[0].Rows[0]["usertype"].ToString());
                FrmHome frmHome = new FrmHome();
                frmHome.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không đúng. Vui lòng kiểm tra lại hoặc liên hệ Quản Trị!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.BtnLogin_Click(sender, e);
            }
        }
    }
}
