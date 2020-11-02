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
    public partial class FrmManageUsers : Form
    {
        public FrmManageUsers()
        {
            InitializeComponent();
        }
        private Boolean _edit;
        private string _fullName;
        private string _password;
        private int _userType;
        private DateTime _fromDate;
        private DateTime _toDate;
        private DataTable _dtUsers;
        private void loadUsers()
        {
            string sql = "select username, fullname,password, iif(usertype=1,'admin','user') as user_type, effectdate, expireddate from users";
            Database db = new Database();
            DataSet ds = db.selectData(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this._dtUsers = ds.Tables[0];
                this.gridUsers.DataSource = ds.Tables[0];
                this.gridUsers.Rows[0].Selected = true;
            }
        }
        private void FrmManageUsers_Load(object sender, EventArgs e)
        {
            this.loadUsers();
            this.dtTo.Value = DateTime.Now.AddDays(30);
            this._edit = false;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void setUserValue(object sender, EventArgs e)
        {
            Boolean save = false;
            if (this._edit == true)
            {
                if (MessageBox.Show("Data has not been saved, do you want to save?", "confirm"
                        , MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    save = true;
                }
                else
                {
                    save = false;
                }
            }
            if (save == true)
            {
                this.BtnSave_Click(sender, e);
                return;
            }
            else
            {
                try
                {
                    this.txtUserName.Enabled = false;
                    int rowIndex = gridUsers.CurrentCell.RowIndex;
                    this.txtUserName.Text = gridUsers.Rows[rowIndex].Cells["username"].Value.ToString();
                    this.txtFullName.Text = gridUsers.Rows[rowIndex].Cells["fullname"].Value.ToString();
                    this._fullName = this.txtFullName.Text;
                    this.txtPassword.Text = gridUsers.Rows[rowIndex].Cells["password"].Value.ToString();
                    this._password = this.txtPassword.Text;
                    string userType = gridUsers.Rows[rowIndex].Cells["usertype"].Value.ToString();
                    if (userType == "admin")
                    {
                        this.cboUserType.SelectedIndex = 1;
                        this._userType = 1;
                    }
                    else if (userType == "user")
                    {
                        this.cboUserType.SelectedIndex = 2;
                        this._userType = 2;
                    }
                    else
                    {
                        this.cboUserType.SelectedIndex = 0;
                        this._userType = 0;
                    }

                    //set date time
                    DateTime parsedDate;
                    string dateValue = gridUsers.Rows[rowIndex].Cells["effectdate"].Value.ToString();
                    parsedDate = DateTime.Parse(dateValue);
                    this.dtFrom.Value = parsedDate;
                    this._fromDate = this.dtFrom.Value;
                    //
                    dateValue = gridUsers.Rows[rowIndex].Cells["expireddate"].Value.ToString();
                    parsedDate = DateTime.Parse(dateValue);
                    this.dtTo.Value = parsedDate;
                    this._toDate = this.dtTo.Value;
                }
                catch { }
            }
        }

        private Boolean checkInput()
        {
            if (this.txtFullName.Text.Trim() == "")
            {
                MessageBox.Show("Nhập vào Họ Và Tên!", "Input data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtFullName.Focus();
                return false;
            }
            if (this.txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Tên Đăng Nhập bắt buộc nhập!", "Input data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUserName.Focus();
                return false;
            }
            if (this.txtUserName.Text.Trim().IndexOf(' ') >0)
            {
                MessageBox.Show("Tên Đăng nhập không được có khoảng trắng!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtUserName.Focus();
                return false;
            }
            if (this.txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please input the Password!", "Input data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtPassword.Focus();
                return false;
            }
            if (this.cboUserType.SelectedIndex == 0 || this.cboUserType.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the User Type!", "Input data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.cboUserType.Focus();
                return false;
            }
            if (this.dtFrom.Value.ToLongDateString() == this.dtTo.Value.ToLongDateString())
            {
                MessageBox.Show("Please choose the From date and End Date of user!", "Input data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.dtFrom.Focus();
                return false;
            }
            return true;
        }
        //return true: data was changed; return false: data was not changed
        private bool changedData()
        {
            if (this._userType == this.cboUserType.SelectedIndex &&
                                       this._fullName == this.txtFullName.Text.Trim() &&
                                       this._password == this.txtPassword.Text &&
                                       this._fromDate == this.dtFrom.Value &&
                                       this._toDate == this.dtTo.Value)
            {
                return false;
            }
            return true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (this._edit == false || !changedData())
                return;
            if (this.checkInput() == true)
            {
                string fullName = this.txtFullName.Text.Trim();
                string userName = this.txtUserName.Text.Trim();
                string passWord = this.txtPassword.Text;
                int userType = this.cboUserType.SelectedIndex;
                //save data to DB
                string sql = "";
                Database db = new Database();
                if (this.txtUserName.Enabled == true) //insert new user
                {
                    //verify the existing of new user in DB
                    sql = "select * from users where username ='" + this.txtUserName.Text.Trim() + "'";
                    DataSet ds = db.selectData(sql);
                    if (ds != null && ds.Tables[0].Rows.Count == 0)
                    {
                        sql = "insert into users(username, [password], fullname, usertype, effectdate, expireddate)" +
                            "  values('" + this.txtUserName.Text.Trim() + "','" + this.txtPassword.Text +
                            "', '" + this.txtFullName.Text.Trim() + "'," + this.cboUserType.SelectedIndex + ",'" +
                            this.dtFrom.Value + "','" + this.dtTo.Value + "')";
                    }
                    else
                    {
                        MessageBox.Show("User [" + this.txtUserName.Text.Trim() + "] already exists in system!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtUserName.Focus();
                        return;
                    }
                }
                else
                    sql = "update users set fullname='" + this.txtFullName.Text.Trim() + "', [password]='" + this.txtPassword.Text +
                        "', usertype=" + this.cboUserType.SelectedIndex + ", effectdate='" + this.dtFrom.Value + "', expireddate='" +
                        this.dtTo.Value + "' where username='" + this.txtUserName.Text.Trim() + "'";

                if (db.updateData(sql) != -1)
                {
                    MessageBox.Show("User [" + this.txtUserName.Text.Trim() + "] was saved sucessfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //load data again for grid user
                    this.loadUsers();
                    this._edit = false;

                }
                else
                {
                    MessageBox.Show("Could not save User [" + this.txtUserName.Text.Trim() + "]!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            this.txtUserName.Enabled = true;
            this.txtFullName.Text = "";
            this.txtUserName.Text = "";
            this.txtPassword.Text = "";
            this.cboUserType.SelectedIndex = 0;
            this.dtFrom.Value = DateTime.Now;
            this.dtTo.Value = DateTime.Now.AddDays(30);
            MessageBox.Show("User after created will be expired after next 30 days. Please change the epriry date of user!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.dtTo.Focus();
            this._edit = false;
        }


        private void GridUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.setUserValue(sender, e);
            this._edit = false;
        }

        private void TxtFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this._edit = true;
            this._fullName = this.txtFullName.Text.Trim();
        }

        private void TxtUserName_KeyPress(object sender, KeyPressEventArgs e)
        {
            this._edit = true;
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            this._edit = true;
        }

        private void CboUserType_MouseClick(object sender, MouseEventArgs e)
        {
            this._edit = true;
        }

        private void DtFrom_ValueChanged(object sender, EventArgs e)
        {
            this._edit = true;
        }

        private void DtTo_ValueChanged(object sender, EventArgs e)
        {
            this._edit = true;
        }

        private void TxtFullName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (this.txtUserName.Enabled == true)
                    this.txtUserName.Focus();
                else
                    this.txtPassword.Focus();
            }
        }

        private void TxtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.txtPassword.Focus();
            }
        }

        private void TxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cboUserType.Focus();
            }
        }

        private void CboUserType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtFrom.Focus();
            }
        }

        private void DtFrom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.dtTo.Focus();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.loadUsers();
        }

        private void TxtUserNameSrch_TextChanged(object sender, EventArgs e)
        {
            this._dtUsers.DefaultView.RowFilter = "username like '%" + this.txtUserNameSrch.Text + "%' and fullname like '%" +
                this.txtFullNameSrch.Text + "%'";
            this.gridUsers.DataSource = this._dtUsers;
        }

        private void TxtFullNameSrch_TextChanged(object sender, EventArgs e)
        {
            this._dtUsers.DefaultView.RowFilter = "username like '%" + this.txtUserNameSrch.Text + "%' and fullname like '%" +
                                                  this.txtFullNameSrch.Text + "%'";
            this.gridUsers.DataSource = this._dtUsers;
        }
    }
}
