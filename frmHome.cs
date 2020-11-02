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
    public partial class FrmHome : Form
    {
        public static string userName;
        public static string fullName;
        public static string userid;
        public static string passWord;
        public static int userType;
        public FrmHome()
        {
            InitializeComponent();
        }

        private void LnkChangePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmChangePass.userName = FrmHome.userName;
            frmChangePass.password = FrmHome.passWord;
            frmChangePass f = new frmChangePass();
            f.ShowDialog();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            this.lbUserName.Text = fullName;
            if (userType == 1)
            {
                this.btnManageUser.Visible = true;
            }
            else
            {
                this.btnManageUser.Visible = false;
            }
        }

        private void LnkLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
            this.Close();
        }

        private void BtnManageUser_Click(object sender, EventArgs e)
        {
            FrmManageUsers frm = new FrmManageUsers();
            frm.ShowDialog();
        }

        private void BtnSymtom_Click(object sender, EventArgs e)
        {
            FrmSymtomMng frm = new FrmSymtomMng();
            frm.ShowDialog();
        }

        private void BtnPatientManage_Click(object sender, EventArgs e)
        {
            //FrmPatientMng frm = new FrmPatientMng();
            frmListPatient frm = new frmListPatient();
            frm.ShowDialog();
        }

    }
}
