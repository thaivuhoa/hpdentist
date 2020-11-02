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
    public partial class FrmPatientMng : Form
    {
        Database db;
        private DataSet dsPatients = new DataSet();
        private DataSet dsDistrict = new DataSet();
        private DataSet dsSymtoms = new DataSet();
        private DataSet dsServices = new DataSet();
        private int selectedRowIndex = -1;
        private String[] teethMaps;
        public static String symtoms;
        public static String symtomIDs;
        public static String patient_id;
        public static String ticket_id;
        public static Boolean _new;
        public static Boolean _newTicket;
        private Boolean change;
        public FrmPatientMng()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void selectOnRow()
        {
            try
            {
                _newTicket = false;
                int rowIndex = gridPatient.CurrentCell.RowIndex;
                selectedRowIndex = rowIndex;
                this.SetPatientDetail(dsPatients.Tables[0], rowIndex, "1");
            }
            catch { }
        }
        private void selectOnRow(int index)
        {
            try
            {
                _newTicket = false;
                this.SetPatientDetail(dsPatients.Tables[0], index, "1");
            }
            catch { }
        }
        private void selectOnRowAfterUpd()
        {
            int tmpIndex = selectedRowIndex;
            try
            {
                if (selectedRowIndex != -1)
                {
                    this.gridPatient.ClearSelection();
                    selectedRowIndex = tmpIndex;
                    this.gridPatient.Rows[selectedRowIndex].Selected = true;
                    //this.SetPatientDetail(dsPatients.Tables[0], selectedRowIndex, "1");
                    selectOnRow();
                }
            }
            catch { }
        }
        private void selectOnRowAfterIns()
        {
            try
            {
                if (selectedRowIndex != -1)
                {
                    this.gridPatient.ClearSelection();
                    this.gridPatient.Rows[gridPatient.Rows.Count-1].Selected = true;
                    //this.SetPatientDetail(dsPatients.Tables[0], selectedRowIndex, "1");
                    selectOnRow(gridPatient.Rows.Count - 1);
                }
            }
            catch { }
        }
        private void GridPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (change)
            {
                DialogResult rst = MessageBox.Show("Dữ liệu bạn nhập chưa lưu, bạn có thật sự muốn thoát để tạo lại?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rst.Equals(DialogResult.Yes))
                {
                    change = false;
                }
                else
                { return; }
            }
            this.selectOnRow();
        }
        private void SetPatientDetail(DataTable dt, int i, String type) // type 0: new, type 1: old
        {
            if (type == "1")
            {
                this.txtFullName.Text = dt.Rows[i]["fullname"].ToString();
                this.lbFullName2.Text = dt.Rows[i]["fullname"].ToString(); 
                this.txtStreet.Text = dt.Rows[i]["street"].ToString();
                this.lbStreet2.Text = dt.Rows[i]["street"].ToString();
                this.cboCity.SelectedValue = dt.Rows[i]["cityid"].ToString();
                this.lbCity2.Text = this.cboCity.Text;
                this.loadDistrict(int.Parse(dt.Rows[i]["cityid"].ToString()));
                this.cboDistrict.SelectedValue = dt.Rows[i]["districtid"].ToString();
                this.lbDistrict2.Text = this.cboDistrict.Text;
                this.txtTelephone.Text = dt.Rows[i]["telephone"].ToString();
                this.lbPhone2.Text = dt.Rows[i]["telephone"].ToString();
                this.cboService.SelectedValue = dt.Rows[i]["service"].ToString();
                this.cboDoctor.SelectedValue = dt.Rows[i]["doctorid"].ToString();
                //
                DateTime parsedDate;
                string dateValue = dt.Rows[i]["dateofbirth"].ToString();
                parsedDate = DateTime.Parse(dateValue);
                this.dtBirth.Value = parsedDate;
                this.lbBirth2.Text = parsedDate.ToShortDateString();
                //
                this.txtTreatReason.Text = dt.Rows[i]["treatreason"].ToString();
                //
                dateValue = dt.Rows[i]["treatdate"].ToString();
                parsedDate = DateTime.Parse(dateValue);
                this.dtTreatDate.Value = parsedDate;
                //
                this.txtNote.Text = dt.Rows[i]["notes"].ToString();
                //symtom
                symtoms = dt.Rows[i]["symtom"].ToString();
                this.setSymtomValues();
                //
                this.txtTicketId.Text = dt.Rows[i]["ticketid"].ToString();
                this.txtTotalCost.Text = dt.Rows[i]["total"].ToString(); 
                this.txtPrePay.Text = dt.Rows[i]["prepay"].ToString();
                //
                this.chkFinished.Checked = dt.Rows[i]["status"].ToString().Equals("0") ? false : true; 
                //this.txtRemain.Text = dt.Rows[i]["remain"].ToString();
                //teethmap
                loadTeechMap(dt.Rows[i]["teethmap"].ToString());
            }
            else
            {
                DateTime parsedDate;
                parsedDate = DateTime.Now;
                /* this.txtFullName.Text = "";
                 this.txtStreet.Text = "";
                 this.cboCity.SelectedValue = "";
                 this.cboDistrict.DataSource = null;
                 this.txtTelephone.Text = "";
                 this.dtBirth.Value = parsedDate;*/
                this.cboDoctor.SelectedValue = "2";

                //this.lbSymtom.Text = "";
                //
                this.txtTreatReason.Text = "";
                //
                this.dtTreatDate.Value = parsedDate;
                //
                this.txtNote.Text = "";
                this.cboService.SelectedValue = "8";
                //symtom
                /*symtoms = "";
                this.setSymtomValues();*/
                //load teethmap
                loadTeechMap(null);
                //
                this.txtTotalCost.Text = "";
                this.txtPrePay.Text = "";
                this.txtRemain.Text = "";
                this.chkFinished.Checked = false;
            }
        }
        public void setSymtomValues()
        {
            String[] syms = symtoms.Split(',');
            string symRst = "", symRstIDs = "";
            for (int j = 0; j < syms.Length; j++)
            {
                for (int k = 0; k < dsSymtoms.Tables[0].Rows.Count; k++)
                {
                    if (dsSymtoms.Tables[0].Rows[k]["id"].ToString().Equals(syms[j].ToString()))
                    {
                        symRstIDs = symRstIDs + dsSymtoms.Tables[0].Rows[k]["id"].ToString() + ",";
                        symRst = symRst + dsSymtoms.Tables[0].Rows[k]["name"].ToString() + ", ";
                        break;
                    }
                }
            }

            this.lbSymtom.Text = symRst.Length > 1 ? symRst.Substring(0, symRst.Length - 2) : "";
            this.lbSymtomIDs.Text = symRstIDs.Length > 1 ? symRstIDs.Substring(0, symRstIDs.Length - 2) : "";
            symtomIDs = lbSymtomIDs.Text;
            this.lbSymtom2.Text = symRst;
        }
        private void loadTeechMap(String treatTeeths)
        {

            //set color for treat teeth
            if (treatTeeths != null)
            {
                for (int i = 0; i < teethMaps.Length; i++)
                {
                    teethMaps[i] = treatTeeths.Substring(i, 1);
                }
                if (treatTeeths.Substring(0, 1) == "1") this.textBox2.BackColor = Color.Red; else this.textBox2.BackColor = Color.White;
                if (treatTeeths.Substring(1, 1) == "1") this.textBox3.BackColor = Color.Red; else this.textBox3.BackColor = Color.White;
                if (treatTeeths.Substring(2, 1) == "1") this.textBox4.BackColor = Color.Red; else this.textBox4.BackColor = Color.White;
                if (treatTeeths.Substring(3, 1) == "1") this.textBox5.BackColor = Color.Red; else this.textBox5.BackColor = Color.White;
                if (treatTeeths.Substring(4, 1) == "1") this.textBox6.BackColor = Color.Red; else this.textBox6.BackColor = Color.White;
                if (treatTeeths.Substring(5, 1) == "1") this.textBox7.BackColor = Color.Red; else this.textBox7.BackColor = Color.White;
                if (treatTeeths.Substring(6, 1) == "1") this.textBox8.BackColor = Color.Red; else this.textBox8.BackColor = Color.White;
                if (treatTeeths.Substring(7, 1) == "1") this.textBox9.BackColor = Color.Red; else this.textBox9.BackColor = Color.White;
                if (treatTeeths.Substring(8, 1) == "1") this.textBox10.BackColor = Color.Red; else this.textBox10.BackColor = Color.White;
                if (treatTeeths.Substring(9, 1) == "1") this.textBox11.BackColor = Color.Red; else this.textBox11.BackColor = Color.White;
                if (treatTeeths.Substring(10, 1) == "1") this.textBox12.BackColor = Color.Red; else this.textBox12.BackColor = Color.White;
                if (treatTeeths.Substring(11, 1) == "1") this.textBox13.BackColor = Color.Red; else this.textBox13.BackColor = Color.White;
                if (treatTeeths.Substring(12, 1) == "1") this.textBox14.BackColor = Color.Red; else this.textBox14.BackColor = Color.White;
                if (treatTeeths.Substring(13, 1) == "1") this.textBox15.BackColor = Color.Red; else this.textBox15.BackColor = Color.White;
                if (treatTeeths.Substring(14, 1) == "1") this.textBox16.BackColor = Color.Red; else this.textBox16.BackColor = Color.White;
                if (treatTeeths.Substring(15, 1) == "1") this.textBox17.BackColor = Color.Red; else this.textBox17.BackColor = Color.White;
                if (treatTeeths.Substring(16, 1) == "1") this.textBox20.BackColor = Color.Red; else this.textBox20.BackColor = Color.White;
                if (treatTeeths.Substring(17, 1) == "1") this.textBox21.BackColor = Color.Red; else this.textBox21.BackColor = Color.White;
                if (treatTeeths.Substring(18, 1) == "1") this.textBox22.BackColor = Color.Red; else this.textBox22.BackColor = Color.White;
                if (treatTeeths.Substring(19, 1) == "1") this.textBox23.BackColor = Color.Red; else this.textBox23.BackColor = Color.White;
                if (treatTeeths.Substring(20, 1) == "1") this.textBox24.BackColor = Color.Red; else this.textBox24.BackColor = Color.White;
                if (treatTeeths.Substring(21, 1) == "1") this.textBox25.BackColor = Color.Red; else this.textBox25.BackColor = Color.White;
                if (treatTeeths.Substring(22, 1) == "1") this.textBox26.BackColor = Color.Red; else this.textBox26.BackColor = Color.White;
                if (treatTeeths.Substring(23, 1) == "1") this.textBox27.BackColor = Color.Red; else this.textBox27.BackColor = Color.White;
                if (treatTeeths.Substring(24, 1) == "1") this.textBox28.BackColor = Color.Red; else this.textBox28.BackColor = Color.White;
                if (treatTeeths.Substring(25, 1) == "1") this.textBox29.BackColor = Color.Red; else this.textBox29.BackColor = Color.White;
                if (treatTeeths.Substring(26, 1) == "1") this.textBox30.BackColor = Color.Red; else this.textBox30.BackColor = Color.White;
                if (treatTeeths.Substring(27, 1) == "1") this.textBox31.BackColor = Color.Red; else this.textBox31.BackColor = Color.White;
                if (treatTeeths.Substring(28, 1) == "1") this.textBox32.BackColor = Color.Red; else this.textBox32.BackColor = Color.White;
                if (treatTeeths.Substring(29, 1) == "1") this.textBox33.BackColor = Color.Red; else this.textBox33.BackColor = Color.White;
                if (treatTeeths.Substring(30, 1) == "1") this.textBox34.BackColor = Color.Red; else this.textBox34.BackColor = Color.White;
                if (treatTeeths.Substring(31, 1) == "1") this.textBox35.BackColor = Color.Red; else this.textBox35.BackColor = Color.White;
            }
            else
            {
                for (int i = 0; i < teethMaps.Length; i++)
                {
                    teethMaps[i] = "0";
                }
                this.textBox2.BackColor = Color.White;
                this.textBox3.BackColor = Color.White;
                this.textBox4.BackColor = Color.White;
                this.textBox5.BackColor = Color.White;
                this.textBox6.BackColor = Color.White;
                this.textBox7.BackColor = Color.White;
                this.textBox8.BackColor = Color.White;
                this.textBox9.BackColor = Color.White;
                this.textBox10.BackColor = Color.White;
                this.textBox11.BackColor = Color.White;
                this.textBox12.BackColor = Color.White;
                this.textBox13.BackColor = Color.White;
                this.textBox14.BackColor = Color.White;
                this.textBox15.BackColor = Color.White;
                this.textBox16.BackColor = Color.White;
                this.textBox17.BackColor = Color.White;
                this.textBox20.BackColor = Color.White;
                this.textBox21.BackColor = Color.White;
                this.textBox22.BackColor = Color.White;
                this.textBox23.BackColor = Color.White;
                this.textBox24.BackColor = Color.White;
                this.textBox25.BackColor = Color.White;
                this.textBox26.BackColor = Color.White;
                this.textBox27.BackColor = Color.White;
                this.textBox28.BackColor = Color.White;
                this.textBox29.BackColor = Color.White;
                this.textBox30.BackColor = Color.White;
                this.textBox31.BackColor = Color.White;
                this.textBox32.BackColor = Color.White; 
            }
        }
        private void FrmPatientMng_Load(object sender, EventArgs e)
        {
            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            //this.gridPatient.Width = this.Size.Width - 70;

            db = new Database();
            teethMaps = new string[32];
            for (int i = 0; i < teethMaps.Length; i++) { teethMaps[i] = "0"; }
            this.gridPatient.AutoGenerateColumns = false;
            this.txtPatientID.Text = patient_id;

            if (patient_id != "")
            {
                this.tabPage1.Visible = false;
                this.tabPage2.Visible = true;
                this.tabControl1.SelectedTab = this.tabPage2;
                this.loadUpdate();
                //disable item due to update, not add new
                this.txtFullName.Enabled = false;
                this.txtStreet.Enabled = false;
                this.cboCity.Enabled = false;
                this.cboDistrict.Enabled = false;
                this.txtTelephone.Enabled = false;
                this.dtBirth.Enabled = false;
                this.btnSymtom.Enabled = false;
            }
            else
            {
                this.tabPage1.Visible = true;
                this.tabPage2.Visible = false;
                this.tabControl1.SelectedTab = this.tabPage1;
                this.loadAddNew();
                this.txtFullName.Focus();
            }
        }
        private void loadUpdate()
        {
            this.loadPatients();
            this.loadDoctor();
            this.loadCity();
            this.loadSymtoms();
            this.loadServices();
            //load symtoms list ##



            //load teeth map for patient

            /*
            string sql = "select teethmap from teethmap where patientid=" + patient_id +
                         " and ticketdetailid=" + ticket_id;
            Database db = new Database();
            DataSet ds = db.selectData(sql);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                teethMaps = ds.Tables[0].Rows[0]["teethmap"].ToString();
            }
            this.loadTeechMap(teethMaps);
            //this.tbTeethMap.Visible = false;
            */
            this.selectOnRow();
        }
        private void loadAddNew()
        {
            this.loadDoctor();
            this.loadCity();
            this.loadSymtoms();
            this.loadServices();
            /*this.cboCity.SelectedValue = "";
            this.cboDistrict.SelectedValue = "";*/
        }
        private void loadSymtoms()
        {
            string sql = "select * from symtom ";
            /*Database db = new Database();*/
            dsSymtoms = db.selectData(sql);
        }
        private void loadServices()
        {
            string sql = "select id as treatid, treatname  from serviceList ";
            /*Database db = new Database();*/
            dsServices = db.selectData(sql);
            if (dsServices != null && dsServices.Tables[0].Rows.Count > 0)
            {
                DataTable dtService = dsServices.Tables[0];
                this.cboService.DataSource = dtService;
                this.cboService.ValueMember = "treatid";
                this.cboService.DisplayMember = "treatname";
                this.cboService.SelectedValue = "8";
            }
        }
        private void loadPatients()
        {
            string sql = "select distinct t.id as ticketid, t.teethmap, t.prepay, t.total, t.doctorid, t.remain, p.fullname, p.telephone,  a.street & ', ' & c2.districtname & ', ' & c1.cityname as address, p.dateofbirth, " +
                         "t.service, s.treatname as servicename, format(t.treatdate,'DD/MM/YYYY') as treatdate, t.treatreason as treatreason, a.street as street, a.districtid, a.cityid, p.symtomhistory as symtom, t.notes, t.status, t.deleted " + 
                         " , switch(t.status=1,'Đã Điều Trị',t.status=0,'') as statusstr " +
                          "from patient p, addresses a, city c1, city c2, ticketdetail t, servicelist s " +
                          "where p.addressid = a.id and a.cityid = c1.cityid and a.districtid = c2.districtid and t.patientid = p.id and t.patientid = " + patient_id + " and t.service = s.id and t.deleted=0 " +
                          " order by t.id";
            /*Database db = new Database();*/
            dsPatients = db.selectData(sql);
            if (dsPatients != null && dsPatients.Tables[0].Rows.Count > 0)
            {
                this.gridPatient.DataSource = dsPatients.Tables[0];
            }
        }
        private void loadTickets()
        {
            string sql = "select distinct t.id as ticketid, t.doctorid, p.fullname, p.telephone,  a.street & ', ' & c2.districtname & ', ' & c1.cityname as address, p.dateofbirth, " +
                         "'' as service, t.treatdate, t.treatreason as treatreason, a.street as street, a.districtid, a.cityid, p.symtomhistory as symtom, t.notes " +
                          "from patient p, addresses a, city c1, city c2, ticketdetail t " +
                          "where p.addressid = a.id and a.cityid = c1.cityid and a.districtid = c2.districtid and t.patientid = p.id and t.patientid = " + patient_id +
                          " order by t.id desc";
            /*Database db = new Database();*/
            dsPatients = db.selectData(sql);
            if (dsPatients != null && dsPatients.Tables[0].Rows.Count > 0)
            {
                this.gridPatient.DataSource = dsPatients.Tables[0];
            }
        }
        private void loadCity()
        {
            string sql = "select distinct cityid, cityname " +
                "from city " +
                "order by cityid, cityname ";
            /*Database db = new Database();*/
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
        private void loadDoctor()
        {
            string sql = "select id as doctorid, fullname, telephone, status, dating from doctor order by fullname";
            /*Database db = new Database();*/
            DataSet dsDoctor = db.selectData(sql);
            if (dsDoctor != null && dsDoctor.Tables[0].Rows.Count > 0)
            {
                DataTable dtDoctor = dsDoctor.Tables[0];
                this.cboDoctor.DataSource = dtDoctor;
                this.cboDoctor.ValueMember = "doctorid";
                this.cboDoctor.DisplayMember = "fullname";
                this.cboDoctor.SelectedValue = "2";
            }
        }
        private void loadDistrict(int cityId)
        {
            string sql = "select distinct cityid, districtid, districtname " +
                "from city " +
                "order by cityid, districtname ";
            /*Database db = new Database();*/
            dsDistrict = db.selectData(sql);
            if (dsDistrict != null && dsDistrict.Tables[0].Rows.Count > 0)
            {
                DataTable dt = dsDistrict.Tables[0];
                dt.DefaultView.RowFilter = "cityid=" + cityId ;
                this.cboDistrict.DataSource = dt;
                this.cboDistrict.ValueMember = "districtid";
                this.cboDistrict.DisplayMember = "districtname";
            }
        }
        private void TextBox2_MouseEnter(object sender, EventArgs e)
        {
            this.textBox2.Cursor = Cursors.Hand;
        }

        private void TextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox2.BackColor != Color.Red)
            {
                this.textBox2.BackColor = Color.Red;
                teethMaps[0] = "1";
            }
            else
            {
                this.textBox2.BackColor = Color.White;
                teethMaps[0] = "0";
            }
            this.textBox2.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox3_MouseEnter(object sender, EventArgs e)
        {
            this.textBox3.Cursor = Cursors.Hand;
        }

        private void TextBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox3.BackColor != Color.Red)
            {
                this.textBox3.BackColor = Color.Red;
                teethMaps[1] = "1";
            }
            else
            {
                this.textBox3.BackColor = Color.White;
                teethMaps[1] = "0";
            }
            this.textBox3.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox4_MouseEnter(object sender, EventArgs e)
        {
            this.textBox4.Cursor = Cursors.Hand;
        }
        private void TextBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox4.BackColor != Color.Red)
            {
                this.textBox4.BackColor = Color.Red;
                teethMaps[2] = "1";
            }
            else
            {
                this.textBox4.BackColor = Color.White;
                teethMaps[2] = "0";
            }
            this.textBox4.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox5_MouseEnter(object sender, EventArgs e)
        {
            this.textBox5.Cursor = Cursors.Hand;
        }

        private void TextBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox5.BackColor != Color.Red)
            {
                this.textBox5.BackColor = Color.Red;
                teethMaps[3] = "1";
            }
            else
            {
                this.textBox5.BackColor = Color.White;
                teethMaps[3] = "0";
            }
            this.textBox5.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox6_MouseEnter(object sender, EventArgs e)
        {
            this.textBox6.Cursor = Cursors.Hand;
        }

        private void TextBox6_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox6.BackColor != Color.Red)
            {
                this.textBox6.BackColor = Color.Red;
                teethMaps[4] = "1";
            }
            else
            {
                this.textBox6.BackColor = Color.White;
                teethMaps[4] = "0";
            }

            this.textBox6.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox7_MouseEnter(object sender, EventArgs e)
        {
            this.textBox7.Cursor = Cursors.Hand;
        }

        private void TextBox7_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox7.BackColor != Color.Red)
            {
                this.textBox7.BackColor = Color.Red;
                teethMaps[5] = "1";
            }
            else
            {
                this.textBox7.BackColor = Color.White;
                teethMaps[5] = "0";
            }
            this.textBox7.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox8_MouseEnter(object sender, EventArgs e)
        {
            this.textBox8.Cursor = Cursors.Hand;
        }

        private void TextBox8_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox8.BackColor != Color.Red)
            {
                this.textBox8.BackColor = Color.Red;
                teethMaps[6] = "1";
            }
            else
            {
                this.textBox8.BackColor = Color.White;
                teethMaps[6] = "0";
            }
            this.textBox8.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox9_MouseEnter(object sender, EventArgs e)
        {
            this.textBox9.Cursor = Cursors.Hand;
        }

        private void TextBox9_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox9.BackColor != Color.Red)
            {
                this.textBox9.BackColor = Color.Red;
                teethMaps[7] = "1";
            }
            else
            {
                this.textBox9.BackColor = Color.White;
                teethMaps[7] = "0";
            }
            this.textBox9.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox10_MouseEnter(object sender, EventArgs e)
        {
            this.textBox10.Cursor = Cursors.Hand;
        }

        private void TextBox10_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox10.BackColor != Color.Red)
            {
                this.textBox10.BackColor = Color.Red;
                teethMaps[8] = "1";
            }
            else
            {
                this.textBox10.BackColor = Color.White;
                teethMaps[8] = "0";
            }
            this.textBox10.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox11_MouseEnter(object sender, EventArgs e)
        {
            this.textBox11.Cursor = Cursors.Hand;
        }

        private void TextBox11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox11.BackColor != Color.Red)
            {
                this.textBox11.BackColor = Color.Red;
                teethMaps[9] = "1";
            }
            else
            {
                this.textBox11.BackColor = Color.White;
                teethMaps[9] = "0";
            }
            this.textBox11.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox12_MouseEnter(object sender, EventArgs e)
        {
            this.textBox12.Cursor = Cursors.Hand;
        }

        private void TextBox12_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox12.BackColor != Color.Red)
            {
                this.textBox12.BackColor = Color.Red;
                teethMaps[10] = "1";
            }
            else
            {
                this.textBox12.BackColor = Color.White;
                teethMaps[10] = "0";
            }
            this.textBox12.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox13_MouseEnter(object sender, EventArgs e)
        {
            this.textBox13.Cursor = Cursors.Hand;
        }

        private void TextBox13_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox13.BackColor != Color.Red)
            {
                this.textBox13.BackColor = Color.Red;
                teethMaps[11] = "1";
            }
            else
            {
                this.textBox13.BackColor = Color.White;
                teethMaps[11] = "0";
            }
            this.textBox13.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox14_MouseEnter(object sender, EventArgs e)
        {
            this.textBox14.Cursor = Cursors.Hand;
        }

        private void TextBox14_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox14.BackColor != Color.Red)
            {
                this.textBox14.BackColor = Color.Red;
                teethMaps[12] = "1";
            }
            else
            {
                this.textBox14.BackColor = Color.White;
                teethMaps[12] = "0";
            }

            this.textBox14.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox15_MouseEnter(object sender, EventArgs e)
        {
            this.textBox15.Cursor = Cursors.Hand;
        }

        private void TextBox15_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox15.BackColor != Color.Red)
            {
                this.textBox15.BackColor = Color.Red;
                teethMaps[13] = "1";
            }
            else
            {
                this.textBox15.BackColor = Color.White;
                teethMaps[13] = "0";
            }
            this.textBox15.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox16_MouseEnter(object sender, EventArgs e)
        {
            this.textBox16.Cursor = Cursors.Hand;
        }

        private void TextBox16_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox16.BackColor != Color.Red)
            {
                this.textBox16.BackColor = Color.Red;
                teethMaps[14] = "1";
            }
            else
            {
                this.textBox16.BackColor = Color.White;
                teethMaps[14] = "0";
            }
            this.textBox16.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox17_MouseEnter(object sender, EventArgs e)
        {
            this.textBox17.Cursor = Cursors.Hand;
        }

        private void TextBox17_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox17.BackColor != Color.Red)
            {
                this.textBox17.BackColor = Color.Red;
                teethMaps[15] = "1";
            }
            else
            {
                this.textBox17.BackColor = Color.White;
                teethMaps[15] = "0";
            }
            this.textBox17.DeselectAll();
            this.lbLeft.Focus();
        }


        private void TextBox20_MouseEnter(object sender, EventArgs e)
        {
            this.textBox20.Cursor = Cursors.Hand;
        }

        private void TextBox20_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox20.BackColor != Color.Red)
            {
                this.textBox20.BackColor = Color.Red;
                teethMaps[16] = "1";
            }
            else
            {
                this.textBox20.BackColor = Color.White;
                teethMaps[16] = "0";
            }
            this.textBox20.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox21_MouseEnter(object sender, EventArgs e)
        {
            this.textBox21.Cursor = Cursors.Hand;
        }

        private void TextBox21_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox21.BackColor != Color.Red)
            {
                this.textBox21.BackColor = Color.Red;
                teethMaps[17] = "1";
            }
            else
            {
                this.textBox21.BackColor = Color.White;
                teethMaps[17] = "0";
            }
            this.textBox21.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox22_MouseEnter(object sender, EventArgs e)
        {
            this.textBox22.Cursor = Cursors.Hand;
        }

        private void TextBox22_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox22.BackColor != Color.Red)
            {
                this.textBox22.BackColor = Color.Red;
                teethMaps[18] = "1";
            }
            else
            {
                this.textBox22.BackColor = Color.White;
                teethMaps[18] = "0";
            }
            this.textBox22.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox23_MouseEnter(object sender, EventArgs e)
        {
            this.textBox23.Cursor = Cursors.Hand;
        }

        private void TextBox23_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox23.BackColor != Color.Red)
            {
                this.textBox23.BackColor = Color.Red;
                teethMaps[19] = "1";
            }
            else
            {
                this.textBox23.BackColor = Color.White;
                teethMaps[19] = "0";
            }
            this.textBox23.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox24_MouseEnter(object sender, EventArgs e)
        {
            this.textBox24.Cursor = Cursors.Hand;
        }

        private void TextBox24_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox24.BackColor != Color.Red)
            {
                this.textBox24.BackColor = Color.Red;
                teethMaps[20] = "1";
            }
            else
            {
                this.textBox24.BackColor = Color.White;
                teethMaps[20] = "0";
            }
            this.textBox24.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox25_MouseEnter(object sender, EventArgs e)
        {
            this.textBox25.Cursor = Cursors.Hand;
        }

        private void TextBox25_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox25.BackColor != Color.Red)
            {
                this.textBox25.BackColor = Color.Red;
                teethMaps[21] = "1";
            }
            else
            {
                this.textBox25.BackColor = Color.White;
                teethMaps[21] = "0";
            }
            this.textBox25.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox26_MouseEnter(object sender, EventArgs e)
        {
            this.textBox26.Cursor = Cursors.Hand;
        }

        private void TextBox26_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox26.BackColor != Color.Red)
            {
                this.textBox26.BackColor = Color.Red;
                teethMaps[22] = "1";
            }
            else
            {
                this.textBox26.BackColor = Color.White;
                teethMaps[22] = "0";
            }
            this.textBox26.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox27_MouseEnter(object sender, EventArgs e)
        {
            this.textBox27.Cursor = Cursors.Hand;
        }

        private void TextBox27_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox27.BackColor != Color.Red)
            {
                this.textBox27.BackColor = Color.Red;
                teethMaps[23] = "1";
            }
            else
            {
                this.textBox27.BackColor = Color.White;
                teethMaps[23] = "0";
            }
            this.textBox27.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox28_MouseEnter(object sender, EventArgs e)
        {
            this.textBox28.Cursor = Cursors.Hand;
        }

        private void TextBox28_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox28.BackColor != Color.Red)
            {
                this.textBox28.BackColor = Color.Red;
                teethMaps[24] = "1";
            }
            else
            {
                this.textBox28.BackColor = Color.White;
                teethMaps[24] = "0";
            }
            this.textBox28.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox29_MouseEnter(object sender, EventArgs e)
        {
            this.textBox29.Cursor = Cursors.Hand;
        }

        private void TextBox29_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox29.BackColor != Color.Red)
            {
                this.textBox29.BackColor = Color.Red;
                teethMaps[25] = "1";
            }
            else
            {
                this.textBox29.BackColor = Color.White;
                teethMaps[25] = "0";
            }
            this.textBox29.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox30_MouseEnter(object sender, EventArgs e)
        {
            this.textBox30.Cursor = Cursors.Hand;
        }

        private void TextBox30_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox30.BackColor != Color.Red)
            {
                this.textBox30.BackColor = Color.Red;
                teethMaps[26] = "1";
            }
            else
            {
                this.textBox30.BackColor = Color.White;
                teethMaps[26] = "0";
            }
            this.textBox30.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox31_MouseEnter(object sender, EventArgs e)
        {
            this.textBox31.Cursor = Cursors.Hand;
        }

        private void TextBox31_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox31.BackColor != Color.Red)
            {
                this.textBox31.BackColor = Color.Red;
                teethMaps[27] = "1";
            }
            else
            {
                this.textBox31.BackColor = Color.White;
                teethMaps[27] = "0";
            }
            this.textBox31.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox32_MouseEnter(object sender, EventArgs e)
        {
            this.textBox32.Cursor = Cursors.Hand;
        }

        private void TextBox32_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox32.BackColor != Color.Red)
            {
                this.textBox32.BackColor = Color.Red;
                teethMaps[28] = "1";
            }
            else
            {
                this.textBox32.BackColor = Color.White;
                teethMaps[28] = "0";
            }
            this.textBox32.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox33_MouseEnter(object sender, EventArgs e)
        {
            this.textBox33.Cursor = Cursors.Hand;
        }

        private void TextBox33_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox33.BackColor != Color.Red)
            {
                this.textBox33.BackColor = Color.Red;
                teethMaps[29] = "1";
            }
            else
            {
                this.textBox33.BackColor = Color.White;
                teethMaps[29] = "0";
            }
            this.textBox33.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox34_MouseEnter(object sender, EventArgs e)
        {
            this.textBox34.Cursor = Cursors.Hand;
        }

        private void TextBox34_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox34.BackColor != Color.Red)
            {
                this.textBox34.BackColor = Color.Red;
                teethMaps[30] = "1";
            }
            else
            {
                this.textBox34.BackColor = Color.White;
                teethMaps[30] = "0";
            }
            this.textBox34.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox35_MouseEnter(object sender, EventArgs e)
        {
            this.textBox35.Cursor = Cursors.Hand;
        }

        private void TextBox35_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox35.BackColor != Color.Red)
            {
                this.textBox35.BackColor = Color.Red;
                teethMaps[31] = "1";
            }
            else
            {
                this.textBox35.BackColor = Color.White;
                teethMaps[31] = "0";
            }
            this.textBox35.DeselectAll();
            this.lbLeft.Focus();
        }

        private void CboCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.loadDistrict(int.Parse(this.cboCity.SelectedValue.ToString()));
            }
            catch { }
        }

        private void BtnSymtom_Click(object sender, EventArgs e)
        {
            if (true)
            {
                frmAddSymtom._from = "ticket";//come from ticket detail form
                frmAddSymtom frm = new frmAddSymtom();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select Patient to edit symtom!", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //load again symtom
            this.lbSymtom.Text = symtoms;
            this.lbSymtomIDs.Text = symtomIDs;
        }

        private void FrmPatientMng_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.finalize();
            patient_id = "";
        }
        
        /* this function: if have at least 1 teeth be checked-> return true, else: return false*/
        private Boolean checkNotNullTeethMap()
        {
            for (int i = 0; i < teethMaps.Length; i++)
            {
                if (teethMaps[i].Equals("1"))
                    return true;
            }
            return false;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled) == false)
                return;
            if (this.chkTeethMaps.Checked == false && checkNotNullTeethMap() == false)
            {
                MessageBox.Show("Vui lòng chọn vị trí răng. Hoặc không chọn thì check vào [KHÔNG XÁC ĐỊNH]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //building teethMaps
            string stTeethMaps = "";
            for (int i = 0; i < teethMaps.Length; i++) { stTeethMaps += teethMaps[i]; }
            if (_new)
            {
                //verify existing
                string _sql = "select id from patient where ucase(fullname) like '*" + this.txtFullName.Text.Trim().ToUpper() + "*' and telephone like '" + 
                       this.txtTelephone.Text.Trim() + "'";
                /*Database db = new Database();*/
                int rst = -1;
                DataSet ds = db.selectData(_sql);
                int patientid = -1;
                //Create new Patient
                if (true)
                {
                    _sql = "insert into addresses(street, cityid, districtid) values('" + this.txtStreet.Text.Trim() +
                                "'," + this.cboCity.SelectedValue.ToString() +
                                "," + this.cboDistrict.SelectedValue.ToString() + ");";
                    rst = -1;
                    rst = db.updateData(_sql);
                    if (rst != -1)
                    {
                        //get the new addressid 
                        _sql = "select distinct id as addressid from addresses where street = '" + this.txtStreet.Text.Trim() + "' and cityid='" + this.cboCity.SelectedValue.ToString() +
                                "' and districtid='" + this.cboDistrict.SelectedValue.ToString() + "'";
                        ds = db.selectData(_sql);
                        int addressId = -1;
                        if (ds != null && ds.Tables[0].Rows.Count > 0)
                        {
                            addressId = int.Parse(ds.Tables[0].Rows[0]["addressid"].ToString());
                        }
                        _sql = "insert into patient(addressid,fullname,telephone,dateofbirth,symtomhistory,notes) values(" +
                                    addressId +
                                    ",'" + this.txtFullName.Text.Trim() +
                                    "', '" + this.txtTelephone.Text.Trim() +
                                    "', '" + this.dtBirth.Value +
                                    "', '" + symtoms +
                                    "', '" + this.txtNote.Text.Trim() + "')";
                        rst = db.updateData(_sql);
                        if (rst == -1)
                        {
                            MessageBox.Show("Có lỗi trong quá trình thêm mới bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi trong quá trình thêm địa chỉ cho bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    //insert new Ticket
                    //Step 1: get new patientid've just inserted above
                    _sql = "select max(id) as patientid from patient";
                    ds = db.selectData(_sql);
                    patientid = -1;
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        patientid = int.Parse(ds.Tables[0].Rows[0]["patientid"].ToString());
                    }
                    //Step 2: insert new ticketdetail
                    if (patientid != -1)
                    {
                        string _finished = this.chkFinished.Checked == true ? "1" : "0";
                        string totalCost = this.txtTotalCost.Text, prePay = this.txtPrePay.Text, remain = this.txtRemain.Text;
                        if (totalCost.Equals("")) { totalCost = "0"; }
                        if (prePay.Equals("")) { prePay = "0"; }
                        if (remain.Equals("")) { remain = "0"; }
                        _sql = "insert into ticketdetail(patientid, treatdate, treatreason, service, createdby, total, prepay, remain, doctorid, teethmap, notes, status, deleted)" +
                            " values(" + patientid + ", '" + this.dtTreatDate.Value + "', '" + this.txtTreatReason.Text.Trim() + "', '" + this.cboService.SelectedValue.ToString() + "', '" +
                            FrmHome.userid + "', '" + totalCost + "', '" + prePay + "', '" + remain +
                            "', '" + this.cboDoctor.SelectedValue + "', '"+ stTeethMaps + "','" + this.txtNote.Text.Trim() + "', '" + _finished + "','0')";
                        rst = db.updateData(_sql);
                        if (rst == -1)
                        {
                            MessageBox.Show("Có lỗi trong quá trình thêm mới chi tiết phiếu khám cho bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới bệnh nhân và chi tiết khám thành công!", "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                }
                patient_id = patientid.ToString();
                this.txtPatientID.Text = patient_id;
                loadPatients();
                selectedRowIndex = 0;
                selectOnRowAfterIns();
            }
            else // patient already exixts, just insert new ticket only
            {
                //insert new ticket only
                if (_newTicket)
                {
                    if (txtPatientID.Text != "")
                    {
                        string _finished = this.chkFinished.Checked == true ? "1" : "0";
                        string totalCost = this.txtTotalCost.Text, prePay = this.txtPrePay.Text, remain = this.txtRemain.Text;
                        if (totalCost.Equals("")) { totalCost = "0"; }
                        if (prePay.Equals("")) { prePay = "0"; }
                        if (remain.Equals("")) { remain = "0"; }
                        string _sql = "insert into ticketdetail(patientid, treatdate, treatreason, service, createdby, total, prepay, remain, doctorid, teethmap, notes, status, deleted)" +
                            " values(" + txtPatientID.Text + ", '" + this.dtTreatDate.Value + "', '" + this.txtTreatReason.Text.Trim() + "', '" + this.cboService.SelectedValue.ToString() + "', '" +
                            FrmHome.userid + "', '" + totalCost + "', '" + prePay + "', '" + remain +
                            "', '" + this.cboDoctor.SelectedValue + "', '" + stTeethMaps + "', '" + this.txtNote.Text.Trim() + "', '" + _finished + "','0')";
                        /*Database db = new Database();*/
                        int rst = db.updateData(_sql);
                        if (rst == -1)
                        {
                            MessageBox.Show("Có lỗi trong quá trình thêm mới chi tiết phiếu khám cho bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Thêm mới chi tiết khám thành công!", "Thông Báo", MessageBoxButtons.OK);
                        }
                    }
                    //select on the lastest row have just been inserted
                    selectedRowIndex = 0;
                    change = false;
                    loadPatients();
                    selectOnRowAfterIns();
                }
                //update ticket
                else
                {
                    string _finished = this.chkFinished.Checked == true ? "1" : "0";
                    string totalCost = this.txtTotalCost.Text, prePay = this.txtPrePay.Text, remain = this.txtRemain.Text;
                    if (totalCost.Equals("")) { totalCost = "0"; }
                    if (prePay.Equals("")) { prePay = "0"; }
                    if (remain.Equals("")) { remain = "0"; }
                    string _sql = "update ticketdetail set treatdate='" + this.dtTreatDate.Value + "', treatreason='" + this.txtTreatReason.Text.Trim() + "', service='" + this.cboService.SelectedValue.ToString() + "', " +
                        "total='" + totalCost + "', prepay='" + prePay + "', remain='" + remain + "', doctorid='" + this.cboDoctor.SelectedValue +
                        "', teethmap='" + stTeethMaps + "', notes='" + txtNote.Text.Trim() + "', updateby='" + FrmHome.userid + "', updatedate='" +
                        DateTime.Now.ToString() + "', status='"  + _finished + "' where id=" + this.txtTicketId.Text;
                    /*Database db = new Database();*/
                    int rst = db.updateData(_sql);
                    if (rst == -1)
                    {
                        MessageBox.Show("Có lỗi trong quá trình cập nhật chi tiết phiếu khám cho bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật chi tiết phiếu khám thành công!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    int tmpIndex = selectedRowIndex;
                    loadPatients();
                    selectedRowIndex = tmpIndex;
                    change = false;
                    selectOnRowAfterUpd();
                }
            }
            change = false;
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (this.txtTicketId.Text != "")
            {
                if (MessageBox.Show("Bạn có thật sự muốn xóa chi tiết khám?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question).Equals(DialogResult.OK))
                {
                    string _sql = "update ticketdetail set deleted='1' where id=" + this.txtTicketId.Text;
                    int rst = db.updateData(_sql);
                    if (rst == -1)
                    {
                        MessageBox.Show("Có lỗi trong quá trình xóa Phiếu khám cho bệnh nhân!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Xóa Phiếu khám thành công!", "Thông Báo", MessageBoxButtons.OK);
                    }
                    loadPatients();
                    selectOnRowAfterUpd();
                }
            }
        }

        private void TxtPrePay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtPrePay.Text = string.Format("{0:#,##0}", double.Parse(this.txtPrePay.Text));
                txtPrePay.Select(txtPrePay.Text.Length, 0);
                string tmp = (double.Parse(this.txtTotalCost.Text) - double.Parse(this.txtPrePay.Text)).ToString();
                this.txtRemain.Text = string.Format("{0:#,##0}", double.Parse(tmp));
            }
            catch { }
        }

        private void TxtTotalCost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.txtTotalCost.Text = string.Format("{0:#,##0}", double.Parse(this.txtTotalCost.Text));
                txtTotalCost.Select(txtTotalCost.Text.Length, 0);
                string tmp = (double.Parse(this.txtTotalCost.Text) - double.Parse(this.txtPrePay.Text)).ToString();
                this.txtRemain.Text = string.Format("{0:#,##0}", double.Parse(tmp));
            }
            catch { }
        }

        private void TxtFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtFullName.Text.Trim())){
                e.Cancel = true;
                txtFullName.Focus();
                errorProvider1.SetError(this.txtFullName,"Họ và Tên Bệnh Nhân phải nhập!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(this.txtFullName, "");
            }
        }

        private void TxtStreet_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStreet.Text.Trim()))
            {
                e.Cancel = true;
                txtStreet.Focus();
                errorProvider1.SetError(this.txtStreet, "Địa chỉ Bệnh Nhân phải nhập!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(this.txtStreet, "");
            }
        }

        private void CboCity_Validating(object sender, CancelEventArgs e)
        {
            if (this.cboCity.SelectedIndex == -1)
            {
                e.Cancel = true;
                cboCity.Focus();
                errorProvider1.SetError(this.cboCity, "Địa chỉ Bệnh Nhân phải nhập!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(this.cboCity, "");
            }
        }

        private void CboDistrict_Validating(object sender, CancelEventArgs e)
        {
            if (this.cboDistrict.SelectedIndex == -1)
            {
                e.Cancel = true;
                cboDistrict.Focus();
                errorProvider1.SetError(this.cboDistrict, "Điạ chỉ Bệnh Nhân phải nhập!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(this.cboDistrict, "");
            }
        }

        private void TxtTotalCost_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtPrePay_KeyPress(object sender, KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TxtTelephone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtTelephone.Text.Trim()))
            {
                e.Cancel = true;
                txtTelephone.Focus();
                errorProvider1.SetError(this.txtTelephone, "Điện Thoại Bệnh Nhân phải nhập!");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(this.txtTelephone, "");
            }
        }

        private void CboService_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (this.cboService.SelectedValue.ToString().Equals("8"))
                {
                    e.Cancel = true;
                    cboService.Focus();
                    errorProvider1.SetError(this.cboService, "Vui lòng chọn mục Điều Trị!");
                }
                else
                {
                    e.Cancel = false;
                    errorProvider1.SetError(this.cboService, "");
                }
            }
            catch { }
        }

        private void GridPatient_SelectionChanged(object sender, EventArgs e)
        {
            if (change)
            {
                DialogResult rst = MessageBox.Show("Dữ liệu bạn nhập chưa lưu, bạn có thật sự muốn thoát để tạo lại?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rst.Equals(DialogResult.Yes))
                {
                    change = false;
                }
                else
                { return; }
            }
            this.selectOnRow();
        }

        private void BtnCreateNew_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (change)
            {
                DialogResult rst = MessageBox.Show("Dữ liệu bạn nhập chưa lưu, bạn có thật sự muốn thoát để tạo lại?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rst.Equals(DialogResult.Yes))
                {
                    change = false;
                }
                else
                { return; }
            }

            this.SetPatientDetail(null, 0, "0");
            this.txtTicketId.Text = "";
            if (this.txtPatientID.Text == "") _new = true; else _new = false;
            _newTicket = true;
            change = true;
        }
    }
}
