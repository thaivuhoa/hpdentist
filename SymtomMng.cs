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
    public partial class FrmSymtomMng : Form
    {
        public FrmSymtomMng()
        {
            InitializeComponent();
        }
        private Boolean _new;
        private string _name;
        private DataTable _dtSymtoms;
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadSymtoms()
        {
            string sql = "select name, note from symtom order by id";
            Database db = new Database();
            DataSet ds = db.selectData(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                this._dtSymtoms = ds.Tables[0];
                this.gridSymtom.DataSource = ds.Tables[0];
                this.gridSymtom.Rows[0].Selected = true;
            }
        }
        private void SymtomMng_Load(object sender, EventArgs e)
        {
            this.loadSymtoms();
            this._new = true;
        }

        private void GridSymtom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowIndex = gridSymtom.CurrentCell.RowIndex;
                this.txtName.Text = gridSymtom.Rows[rowIndex].Cells["name"].Value.ToString();
                this.txtNote.Text = gridSymtom.Rows[rowIndex].Cells["note"].Value.ToString();
                this._new = false;
                this._name = this.txtName.Text;
            }
            catch { }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string sql = "";
            Database db = new Database();

            if (this._new)
            {
                sql = "select * from symtom where [name] ='" + this.txtName.Text.Trim() + "'";
                DataSet ds = db.selectData(sql);
                if (ds != null && ds.Tables[0].Rows.Count == 0)
                {
                    sql = "insert into symtom([name], [note]) values('" + this.txtName.Text.Trim() + "','" + this.txtNote.Text + "')";
                }
                else //symtom already exists
                {
                    MessageBox.Show("The symtom [" + this.txtName.Text.Trim() + "] already exists in system.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtName.Focus();
                    return;
                }
            }
            else
            {
                sql = "update symtom set [name]='" + this.txtName.Text.Trim() + "', [note]='" + this.txtNote.Text + "' where [name]='" + this._name + "'";
            }
            if (db.updateData(sql) != -1)
            {
                this.loadSymtoms();
            }
            else
                MessageBox.Show("Error when updating symtom [" + this.txtName.Text.Trim() + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            this.txtName.Text = "";
            this.txtNote.Text = "";
            this.txtName.Focus();
            this._new = true;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string sql = "delete from symtom where [name]='" + this.txtName.Text.Trim() + "'";
            Database db = new Database();
            if(db.updateData(sql) != -1)
            {
                this.txtName.Text = "";
                this.txtNote.Text = "";
                this.loadSymtoms();
                this._new = true;
            }
            else
            {
                MessageBox.Show("Error when deleting symtom [" + this.txtName.Text.Trim() + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.loadSymtoms();
        }

        private void TxtNameSrch_TextChanged(object sender, EventArgs e)
        {
            this._dtSymtoms.DefaultView.RowFilter = "name like '%" + this.txtNameSrch.Text + "%'";
            this.gridSymtom.DataSource = this._dtSymtoms;
        }

        private void TxtNoteSrch_TextChanged(object sender, EventArgs e)
        {
            this._dtSymtoms.DefaultView.RowFilter = "note is null or note like '%" + this.txtNoteSrch.Text.Trim() + "%' and name like '%" +
                this.txtNameSrch.Text + "%'";
            this.gridSymtom.DataSource = this._dtSymtoms;
        }
    }
}
