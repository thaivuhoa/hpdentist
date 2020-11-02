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
    public partial class frmListPatient : Form
    {
        private DataSet dsPatients = new DataSet();
        private DataTable _dtListPatient;
        private int selectedPatient;
        public frmListPatient()
        {
            InitializeComponent();
        }

        private void FrmListPatient_Load(object sender, EventArgs e)
        {
            this.dtFrom.Value = DateTime.Now.AddDays(-20);
            this.dtTo.Value = DateTime.Now.AddDays(20);
            this.gridPatients.AutoGenerateColumns = false;
            //this.loadPatients();
            BtnFilter_Click(sender, e);
        }

        private void loadPatients()
        {
            string sql = "select distinct t.id as ticketid, t.patientid, p.fullname, p.telephone,  a.street & ', ' & c2.districtname & ', ' & c1.cityname as address, p.dateofbirth, " +
                         "'' as service, format(t.treatdate,'DD/MM/YYYY') as treatdateval, t.treatdate, t.treatreason as treatreason, a.street as street, a.districtid, a.cityid, p.symtomhistory as symtom, t.notes, s.treatname as servicename " +
                          "from patient p, addresses a, city c1, city c2, servicelist s, (select id, treatdate,treatreason,notes, status, patientid, service from ticketdetail where treatdate in (SELECT Max(TicketDetail.treatdate) AS MaxOftreatdate FROM TicketDetail WHERE status=0 and deleted=0 GROUP BY TicketDetail.patientid))  t " +
                          "where p.addressid = a.id and a.cityid = c1.cityid and a.districtid = c2.districtid and t.patientid = p.id and t.status = 0 " +
                          " and s.id = t.service ";
            if (chkDeleted.Checked == true)
                sql = sql + " and (p.deleted=True or p.deleted=False) ";
            else
                sql = sql + " and p.deleted=False ";
            sql += " ORDER BY treatdate";
            Database db = new Database();
            dsPatients = db.selectData(sql);
            if (dsPatients != null && dsPatients.Tables[0].Rows.Count > 0)
            {
                _dtListPatient = dsPatients.Tables[0];
                this.gridPatients.DataSource = _dtListPatient;
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            /*string sql = "select distinct t.id as ticketid, t.patientid, p.fullname, p.telephone,  a.street & ', ' & c2.districtname & ', ' & c1.cityname as address, p.dateofbirth, " +
             "'' as service, t.treatdate, p.treatreason as treatreason, a.street as street, a.districtid, a.cityid, p.symtomhistory as symtom, t.note " +
              "from patient p, addresses a, city c1, city c2, ticketdetail t " +
              "where p.addressid = a.id and a.cityid = c1.cityid and a.districtid = c2.districtid and t.patientid = p.id and t.treatdate between #" + 
                this.dtFrom.Value.ToString("MM/dd/yyyy") + "# and #" + this.dtTo.Value.ToString("MM/dd/yyyy") + "#" +
              " ";*/
            string sql = "select distinct t.patientid, p.fullname, p.telephone,  a.street & ', ' & c2.districtname & ', ' & c1.cityname as address, p.dateofbirth, " +
             "'' as service, format(t.treatdate,'DD/MM/YYYY') as treatdateval, t.treatdate, t.treatreason as treatreason, a.street as street, a.districtid, a.cityid, p.symtomhistory as symtom, t.notes " +
              "from patient p, addresses a, city c1, city c2, (select id, treatdate,treatreason,notes, status, patientid, deleted from ticketdetail where treatdate in (SELECT Max(TicketDetail.treatdate) AS MaxOftreatdate FROM TicketDetail GROUP BY TicketDetail.patientid)) t " +
              "where p.addressid = a.id and a.cityid = c1.cityid and a.districtid = c2.districtid and t.patientid = p.id and t.treatdate between #" +
                this.dtFrom.Value.ToString("MM/dd/yyyy") + "# and #" + this.dtTo.Value.ToString("MM/dd/yyyy") + "# and t.deleted=0" +
              " ";
            if (chkDeleted.Checked == true)
                sql = sql + " and (p.deleted=True or p.deleted=False) ";
            else
                sql = sql + " and p.deleted=False ";

            Database db = new Database();
            dsPatients = db.selectData(sql);
            if (dsPatients != null && dsPatients.Tables[0].Rows.Count > 0)
            {
                _dtListPatient = dsPatients.Tables[0];
                this.gridPatients.DataSource = _dtListPatient;
            }
            else
            {
                this.gridPatients.DataSource = null;
            }
        }

        private void TxtFullNmSrch_TextChanged(object sender, EventArgs e)
        {
            this._dtListPatient.DefaultView.RowFilter = "fullname like '%" + this.txtFullNmSrch.Text + "%' and address like '%" + this.txtAddressSrch.Text + "%' and " +
                "telephone like '%" + this.txtPhoneSrch.Text + "%' and service like '%" + this.txtServiceSrch.Text + "%' and treatreason like '%" +
                this.txtTreatReason.Text + "%' ";
            this.gridPatients.DataSource = _dtListPatient;
        }

        private void TxtAddressSrch_TextChanged(object sender, EventArgs e)
        {
            TxtFullNmSrch_TextChanged(sender, e);
        }

        private void TxtPhoneSrch_TextChanged(object sender, EventArgs e)
        {
            TxtFullNmSrch_TextChanged(sender, e);
        }

        private void TxtServiceSrch_TextChanged(object sender, EventArgs e)
        {
            TxtFullNmSrch_TextChanged(sender, e);
        }

        private void TxtTreatReason_TextChanged(object sender, EventArgs e)
        {
            TxtFullNmSrch_TextChanged(sender, e);
        }

        private void BtnReload_Click(object sender, EventArgs e)
        {
            this.loadPatients();
            this.dtFrom.Value = DateTime.Now.AddDays(-20);
            this.dtTo.Value = DateTime.Now.AddDays(20);
            try
            {
                this.gridPatients.ClearSelection();
                this.gridPatients.Rows[selectedPatient].Selected = true;
            }
            catch { }
        }

        private void GridPatients_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string patient_id = this.gridPatients.Rows[e.RowIndex].Cells["patientid"].Value.ToString();
            //string ticket_id = this.gridPatients.Rows[e.RowIndex].Cells["ticketid"].Value.ToString();
            FrmPatientMng frm = new FrmPatientMng();
            FrmPatientMng.patient_id = patient_id;
            //FrmPatientMng.ticket_id = ticket_id;
            FrmPatientMng._new = false;
            frm.ShowDialog();
        }

        private void ContextMenuStrip1_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("abc");
        }

        private void GridPatients_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                /*
                m.MenuItems.Add(new MenuItem("Cut"));
                m.MenuItems.Add(new MenuItem("Copy"));
                m.MenuItems.Add(new MenuItem("Paste"));
                */

                int currentMouseOverRow = gridPatients.HitTest(e.X, e.Y).RowIndex;

                if (currentMouseOverRow >= 0)
                {
                    contextMenuStrip1.Show(gridPatients, new Point(e.X, e.Y));
                }

            }
        }

        private void BtnUpdatePatient_Click(object sender, EventArgs e)
        {
            string patient_id = this.gridPatients.Rows[this.gridPatients.CurrentRow.Index].Cells["patientid"].Value.ToString();
            frmPatientInfoMng frm = new frmPatientInfoMng();
            frmPatientInfoMng.patient_id = patient_id;
            frmPatientInfoMng._new = false;
            frm.ShowDialog();
            BtnFilter_Click(sender, e);
        }

        private void BtnAddPatient_Click(object sender, EventArgs e)
        {
            FrmPatientMng frm = new FrmPatientMng();
            FrmPatientMng._new = true;
            FrmPatientMng.patient_id = "";
            frm.ShowDialog();
        }

        private void TipAddPatient_Click(object sender, EventArgs e)
        {
            this.BtnAddPatient_Click(sender, e);
        }

        private void TipTicketDetail_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.gridPatients.CurrentRow;
            string patient_id = row.Cells["patientid"].Value.ToString();
            //string ticket_id = row.Cells["ticketid"].Value.ToString();
            FrmPatientMng frm = new FrmPatientMng();
            FrmPatientMng.patient_id = patient_id;
            //FrmPatientMng.ticket_id = ticket_id;
            FrmPatientMng._new = false;
            frm.ShowDialog();
        }

        private void GridPatients_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (this.gridPatients.Rows.Count > 0)
                this.tipTicketDetail.Visible = true;
            else
                this.tipTicketDetail.Visible = false;
        }

        private void GridPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedPatient = gridPatients.CurrentCell.RowIndex;
        }
    }
}
