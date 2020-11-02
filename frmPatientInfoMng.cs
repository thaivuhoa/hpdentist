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
    public partial class frmPatientInfoMng : Form
    {
        private DataSet dsPatients = new DataSet();
        private DataSet dsDistrict = new DataSet();
        private DataSet dsSymtoms = new DataSet();
        private string address_id;
        public static String symtoms;
        public static string symtomIDs;
        public static String patient_id;
        public static Boolean _new;
        private Database db;
        public frmPatientInfoMng()
        {
            InitializeComponent();
        }
        private void loadCity()
        {
            string sql = "select distinct cityid, cityname " +
                "from city " +
                "order by cityid, cityname ";
            DataSet dsCity = db.selectData(sql);
            if (dsCity != null && dsCity.Tables[0].Rows.Count > 0)
            {
                DataTable dtCity = dsCity.Tables[0];
                this.cboCity.DataSource = dtCity;
                this.cboCity.ValueMember = "cityid";
                this.cboCity.DisplayMember = "cityname";
                this.cboCity.SelectedValue = "79";
            }
        }
        private void loadDistrict(int cityId)
        {
            string sql = "select distinct cityid, districtid, districtname " +
                "from city " +
                "order by cityid, districtname ";
            dsDistrict = db.selectData(sql);
            if (dsDistrict != null && dsDistrict.Tables[0].Rows.Count > 0)
            {
                DataTable dt = dsDistrict.Tables[0];
                dt.DefaultView.RowFilter = "cityid=" + cityId;
                this.cboDistrict.DataSource = dt;
                this.cboDistrict.ValueMember = "districtid";
                this.cboDistrict.DisplayMember = "districtname";
            }
        }
        private void loadPatients()
        {
            string sql = "select distinct p.id as patientid, p.fullname, p.telephone, a.street, p.addressid, a.street & ', ' & c2.districtname & ', ' & c1.cityname as address, p.dateofbirth, " +
                         "'' as service, a.street as street, a.districtid, a.cityid, p.symtomhistory as symtom, p.deleted " +
                          "from patient p, addresses a, city c1, city c2 " +
                          "where p.addressid = a.id and a.cityid = c1.cityid and a.districtid = c2.districtid and p.id = " + patient_id +
                          " ";
            dsPatients = db.selectData(sql);
            if (dsPatients != null && dsPatients.Tables[0].Rows.Count > 0)
            {
                this.txtFullName.Text = dsPatients.Tables[0].Rows[0]["fullname"].ToString();
                this.txtTelephone.Text = dsPatients.Tables[0].Rows[0]["telephone"].ToString();
                DateTime parsedDate;
                string dateValue = dsPatients.Tables[0].Rows[0]["dateofbirth"].ToString();
                parsedDate = DateTime.Parse(dateValue);
                this.dtBirth.Value = parsedDate;
                this.txtStreet.Text = dsPatients.Tables[0].Rows[0]["street"].ToString();
                this.cboCity.SelectedValue = dsPatients.Tables[0].Rows[0]["cityid"].ToString();
                this.loadDistrict(int.Parse(dsPatients.Tables[0].Rows[0]["cityid"].ToString()));
                this.cboDistrict.SelectedValue = dsPatients.Tables[0].Rows[0]["districtid"].ToString();
                this.address_id = dsPatients.Tables[0].Rows[0]["addressid"].ToString();
                this.lbSymtomID.Text= dsPatients.Tables[0].Rows[0]["symtom"].ToString();
                symtoms = dsPatients.Tables[0].Rows[0]["symtom"].ToString();

                //load text symtoms
                this.lbSymtom.Text = dsPatients.Tables[0].Rows[0]["symtom"].ToString();
                string[] symid = this.lbSymtom.Text.Split(',');
                this.lbSymtom.Text = "";
                for (int i = 0; i < symid.Length; i++) {
                    for (int j = 0; j < dsSymtoms.Tables[0].Rows.Count; j++)
                    {
                        if (dsSymtoms.Tables[0].Rows[j]["id"].ToString().Equals(symid[i]))
                        {
                            this.lbSymtom.Text += dsSymtoms.Tables[0].Rows[i]["name"].ToString() + ", ";
                            break;
                        }
                    }
                }
                this.lbSymtom.Text = lbSymtom.Text.Length > 1 ? lbSymtom.Text.Substring(0, lbSymtom.Text.Length - 2) : "";
                symtoms = this.lbSymtom.Text;
                this.txtPatientID.Text = dsPatients.Tables[0].Rows[0]["patientid"].ToString();
                this.chkDeleted.Checked = dsPatients.Tables[0].Rows[0]["deleted"].ToString().Equals("True") ? true : false;
                if (this.chkDeleted.Checked)
                    this.btnDelete.Enabled = false;
                else
                    this.btnDelete.Enabled = true;
            }
        }
        private void loadSymtoms()
        {
            string sql = "select * from symtom ";
            dsSymtoms = db.selectData(sql);
        }
        private void FrmPatientInfoMng_Load(object sender, EventArgs e)
        {
            db = new Database();
            this.loadCity();
            loadSymtoms();
            this.loadPatients();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (_new == false)
            {
                string _check = this.chkDeleted.Checked.Equals(true) ? "1" : "0";
                string sql = "update patient set fullname = '" + this.txtFullName.Text.Trim() +
                             "', telephone='" + this.txtTelephone.Text.Trim() +
                             "', dateofbirth='" + this.dtBirth.Value + "', deleted='" + _check + "'" +
                             " where id=" + patient_id;
                Database db = new Database();
                int rst = -1;
                rst = db.updateData(sql);
                if (rst != -1)
                {
                    sql = "update addresses set street='" + this.txtStreet.Text.Trim() +
                          "', cityid='" + this.cboCity.SelectedValue.ToString() +
                          "', districtid ='" + this.cboDistrict.SelectedValue.ToString() +
                          "' where id=" + this.address_id;
                    rst = db.updateData(sql);
                    if (rst == -1)
                    {
                        MessageBox.Show("Có lỗi trong quá trình cập nhật thông tin địa chỉ!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin bệnh nhân thành công!", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi trong quá trình cập nhật thông tin bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
            else //create new Patient
            {
                string sql = "insert into addresses(street, cityid, districtid) values('" + this.txtStreet.Text.Trim() +
                          "'," + this.cboCity.SelectedValue.ToString() +
                          "," + this.cboDistrict.SelectedValue.ToString() + ");";
                Database db = new Database();
                int rst = -1;
                rst = db.updateData(sql);
                if (rst != -1)
                {
                    //get the new addressid 
                    sql = "select distinct id as addressid from addresses where street = '" + this.txtStreet.Text.Trim() + "' and cityid=" + this.cboCity.SelectedValue.ToString() + 
                          " and districtid=" + this.cboDistrict.SelectedValue.ToString();
                    DataSet ds = db.selectData(sql);
                    int addressId = -1;
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        addressId = int.Parse(ds.Tables[0].Rows[0]["addressid"].ToString());
                    }
                    sql = "insert into patient(addressid,fullname,telephone,dateofbirth,treatreason,symtomhistory,note) values(" +
                             addressId + 
                             ",'" + this.txtFullName.Text.Trim() +
                             "', telephone='" + this.txtTelephone.Text.Trim() +
                             "', dateofbirth='" + this.dtBirth.Value +
                             "' where id=" + patient_id;
                    rst = db.updateData(sql);
                    if (rst == -1)
                    {
                        MessageBox.Show("Có lỗi trong quá trình thêm mới bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Thêm mới bệnh nhân thành công!", "Thông Báo", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Có lỗi trong quá trình thêm địa chỉ cho bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtPatientID.Text != "")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa Bệnh nhân?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question).Equals(DialogResult.OK))
                {
                    string sql = "update patient set deleted=1 where id=" + patient_id;
                    int rst = -1;
                    Database db = new Database();
                    rst = db.updateData(sql);
                    if (rst == -1)
                    {
                        MessageBox.Show("Có lỗi trong quá trình xóa tin bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Bệnh nhân đã được xóa thành công!", "Thông Báo", MessageBoxButtons.OK);
                        this.Close();
                    }
                }
            }
        }

        private void CboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadDistrict(int.Parse(this.cboCity.SelectedValue.ToString()));
            }
            catch { }
        }
        public void setSymtomValues()
        {
            String[] syms = symtoms.Split(',');
            string symRst = "";
            for (int j = 0; j < syms.Length; j++)
            {
                for (int k = 0; k < dsSymtoms.Tables[0].Rows.Count; k++)
                {
                    if (dsSymtoms.Tables[0].Rows[k]["id"].ToString().Equals(syms[j].ToString()))
                    {
                        symRst = symRst + dsSymtoms.Tables[0].Rows[k]["name"].ToString() + ", ";
                        break;
                    }
                }
            }
            this.lbSymtom.Text = symRst.Length > 1 ? symRst.Substring(0, symRst.Length - 2) : "";
        }
        private void BtnSymtom_Click(object sender, EventArgs e)
        {
            if (true)//symtoms != null)
            {
                frmAddSymtom._from = "patient";
                frmAddSymtom frm = new frmAddSymtom();
                frm.ShowDialog();
            }
            //load again symtom
            this.lbSymtom.Text = symtoms;
            this.lbSymtomID.Text = symtomIDs;
        }

        private void FrmPatientInfoMng_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.finalize();
        }
    }
}
