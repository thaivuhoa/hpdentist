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
        private DataSet dsPatients = new DataSet();
        private DataSet dsDistrict = new DataSet();
        private DataSet dsSymtoms = new DataSet();
        public static String symtoms;
        public FrmPatientMng()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GridPatient_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = gridPatient.CurrentCell.RowIndex;
            this.SetPatientDetail(dsPatients.Tables[0], rowIndex);
        }
        private void SetPatientDetail(DataTable dt, int i)
        {
            this.txtFullName.Text = dt.Rows[i]["fullname"].ToString();
            this.txtStreet.Text = dt.Rows[i]["street"].ToString();
            this.cboCity.SelectedValue = dt.Rows[i]["cityid"].ToString();
            this.loadDistrict(int.Parse(dt.Rows[i]["cityid"].ToString()));
            this.cboDistrict.SelectedValue = dt.Rows[i]["districtid"].ToString();
            this.txtTelephone.Text = dt.Rows[i]["telephone"].ToString();
            //
            DateTime parsedDate;
            string dateValue = dt.Rows[i]["dateofbirth"].ToString();
            parsedDate = DateTime.Parse(dateValue);
            this.dtBirth.Value = parsedDate;
            //
            this.txtTreatReason.Text = dt.Rows[i]["treatreason"].ToString();
            //
            dateValue = dt.Rows[i]["treatdate"].ToString();
            parsedDate = DateTime.Parse(dateValue);
            this.dtTreatDate.Value = parsedDate;
            //
            this.txtNote.Text = dt.Rows[i]["note"].ToString();
            //symtom
            symtoms = dt.Rows[i]["symtom"].ToString();
            this.setSymtomValues();
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
            if (symRst.Length > 0)
                symRst = symRst.Substring(0, symRst.Length - 2);
            this.lbSymtom.Text = symRst;
        }
        private void loadTeechMap(String[] treatTeeths)
        {
            this.textBox1.Text = "9";
            this.textBox2.Text = "8";
            this.textBox3.Text = "7";
            this.textBox4.Text = "6";
            this.textBox5.Text = "5";
            this.textBox6.Text = "4";
            this.textBox7.Text = "3";
            this.textBox8.Text = "2";
            this.textBox9.Text = "1";
            //
            this.textBox10.Text = "1";
            this.textBox11.Text = "2";
            this.textBox12.Text = "3";
            this.textBox13.Text = "4";
            this.textBox14.Text = "5";
            this.textBox15.Text = "6";
            this.textBox16.Text = "7";
            this.textBox17.Text = "8";
            this.textBox18.Text = "9";
            //
            this.textBox19.Text = "9";
            this.textBox20.Text = "8";
            this.textBox21.Text = "7";
            this.textBox22.Text = "6";
            this.textBox23.Text = "5";
            this.textBox24.Text = "4";
            this.textBox25.Text = "3";
            this.textBox26.Text = "2";
            this.textBox27.Text = "1";
            //
            this.textBox28.Text = "1";
            this.textBox29.Text = "2";
            this.textBox30.Text = "3";
            this.textBox31.Text = "4";
            this.textBox32.Text = "5";
            this.textBox33.Text = "6";
            this.textBox34.Text = "7";
            this.textBox35.Text = "8";
            this.textBox36.Text = "9";
            //set color for treat teeth
            if (treatTeeths[0] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[1] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[2] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[3] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[4] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[5] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[6] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[7] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[8] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[9] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[10] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[11] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[12] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[13] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[14] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[15] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[16] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[17] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[18] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[19] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[20] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[21] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[22] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[23] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[24] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[25] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[26] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[27] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[28] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[29] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[30] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
            if (treatTeeths[31] == "1") this.textBox1.BackColor = Color.Red; else this.textBox1.BackColor = Color.Blue;
        }
        private void FrmPatientMng_Load(object sender, EventArgs e)
        {
            this.loadPatients();
            this.loadCity();
            this.loadSymtoms();
            String[] treatTeechs = null;
            //this.loadTeechMap(treatTeechs);
            //this.tbTeethMap.Visible = false;

        }
        private void loadSymtoms()
        {
            string sql = "select * from symtom ";
            Database db = new Database();
            dsSymtoms = db.selectData(sql);
        }
        private void loadPatients()
        {
            string sql = "select distinct p.fullname, p.telephone,  a.street & ', ' & c2.districtname & ', ' & c1.cityname as address, p.dateofbirth, " +
                         "'' as service, t.treatdate, p.treatreason as treatreason, a.street as street, a.districtid, a.cityid, p.symtomhistory as symtom, t.note " +
                          "from patient p, addresses a, city c1, city c2, ticketdetail t " +
                          "where p.addressid = a.id and a.cityid = c1.cityid and a.districtid = c2.districtid and t.patientid = p.id and t.status = 0 " +
                          " ";
            Database db = new Database();
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
            Database db = new Database();
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
            Database db = new Database();
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
        private void TextBox1_MouseEnter(object sender, EventArgs e)
        {
            this.textBox1.Cursor = Cursors.Hand;
        }

        private void TextBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox1.BackColor != Color.Red)
                this.textBox1.BackColor = Color.Red;
            else
                this.textBox1.BackColor = Color.White;

            this.textBox1.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox2_MouseEnter(object sender, EventArgs e)
        {
            this.textBox2.Cursor = Cursors.Hand;
        }

        private void TextBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox2.BackColor != Color.Red)
                this.textBox2.BackColor = Color.Red;
            else
                this.textBox2.BackColor = Color.White;

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
                this.textBox3.BackColor = Color.Red;
            else
                this.textBox3.BackColor = Color.White;

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
                this.textBox4.BackColor = Color.Red;
            else
                this.textBox4.BackColor = Color.White;

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
                this.textBox5.BackColor = Color.Red;
            else
                this.textBox5.BackColor = Color.White;

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
                this.textBox6.BackColor = Color.Red;
            else
                this.textBox6.BackColor = Color.White;

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
                this.textBox7.BackColor = Color.Red;
            else
                this.textBox7.BackColor = Color.White;

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
                this.textBox8.BackColor = Color.Red;
            else
                this.textBox8.BackColor = Color.White;

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
                this.textBox9.BackColor = Color.Red;
            else
                this.textBox9.BackColor = Color.White;

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
                this.textBox10.BackColor = Color.Red;
            else
                this.textBox10.BackColor = Color.White;

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
                this.textBox11.BackColor = Color.Red;
            else
                this.textBox11.BackColor = Color.White;

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
                this.textBox12.BackColor = Color.Red;
            else
                this.textBox12.BackColor = Color.White;

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
                this.textBox13.BackColor = Color.Red;
            else
                this.textBox13.BackColor = Color.White;

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
                this.textBox14.BackColor = Color.Red;
            else
                this.textBox14.BackColor = Color.White;

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
                this.textBox15.BackColor = Color.Red;
            else
                this.textBox15.BackColor = Color.White;

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
                this.textBox16.BackColor = Color.Red;
            else
                this.textBox16.BackColor = Color.White;

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
                this.textBox17.BackColor = Color.Red;
            else
                this.textBox17.BackColor = Color.White;

            this.textBox17.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox18_MouseEnter(object sender, EventArgs e)
        {
            this.textBox18.Cursor = Cursors.Hand;
        }

        private void TextBox18_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox18.BackColor != Color.Red)
                this.textBox18.BackColor = Color.Red;
            else
                this.textBox18.BackColor = Color.White;

            this.textBox18.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox19_MouseEnter(object sender, EventArgs e)
        {
            this.textBox19.Cursor = Cursors.Hand;
        }

        private void TextBox19_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox19.BackColor != Color.Red)
                this.textBox19.BackColor = Color.Red;
            else
                this.textBox19.BackColor = Color.White;

            this.textBox19.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox20_MouseEnter(object sender, EventArgs e)
        {
            this.textBox20.Cursor = Cursors.Hand;
        }

        private void TextBox20_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox20.BackColor != Color.Red)
                this.textBox20.BackColor = Color.Red;
            else
                this.textBox20.BackColor = Color.White;

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
                this.textBox21.BackColor = Color.Red;
            else
                this.textBox21.BackColor = Color.White;

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
                this.textBox22.BackColor = Color.Red;
            else
                this.textBox22.BackColor = Color.White;

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
                this.textBox23.BackColor = Color.Red;
            else
                this.textBox23.BackColor = Color.White;

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
                this.textBox24.BackColor = Color.Red;
            else
                this.textBox24.BackColor = Color.White;

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
                this.textBox25.BackColor = Color.Red;
            else
                this.textBox25.BackColor = Color.White;

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
                this.textBox26.BackColor = Color.Red;
            else
                this.textBox26.BackColor = Color.White;

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
                this.textBox27.BackColor = Color.Red;
            else
                this.textBox27.BackColor = Color.White;

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
                this.textBox28.BackColor = Color.Red;
            else
                this.textBox28.BackColor = Color.White;

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
                this.textBox29.BackColor = Color.Red;
            else
                this.textBox29.BackColor = Color.White;

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
                this.textBox30.BackColor = Color.Red;
            else
                this.textBox30.BackColor = Color.White;

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
                this.textBox31.BackColor = Color.Red;
            else
                this.textBox31.BackColor = Color.White;

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
                this.textBox32.BackColor = Color.Red;
            else
                this.textBox32.BackColor = Color.White;

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
                this.textBox33.BackColor = Color.Red;
            else
                this.textBox33.BackColor = Color.White;

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
                this.textBox34.BackColor = Color.Red;
            else
                this.textBox34.BackColor = Color.White;

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
                this.textBox35.BackColor = Color.Red;
            else
                this.textBox35.BackColor = Color.White;

            this.textBox35.DeselectAll();
            this.lbLeft.Focus();
        }

        private void TextBox36_MouseEnter(object sender, EventArgs e)
        {
            this.textBox36.Cursor = Cursors.Hand;
        }

        private void TextBox36_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.textBox36.BackColor != Color.Red)
                this.textBox36.BackColor = Color.Red;
            else
                this.textBox36.BackColor = Color.White;

            this.textBox36.DeselectAll();
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
            if (symtoms != null)
            {
                frmAddSymtom frm = new frmAddSymtom();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select Patient to edit symtom!", "Error message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //load again symtom
            this.setSymtomValues();
        }
    }
}
