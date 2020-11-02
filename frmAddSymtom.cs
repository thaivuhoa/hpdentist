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
    public partial class frmAddSymtom : Form
    {
        private DataSet dsSymtom;
        public static string _from = "";
        public static string systoms = "";
        public frmAddSymtom()
        {
            InitializeComponent();
        }

        private void FrmAddSymtom_Load(object sender, EventArgs e)
        {
            loadSymtom(_from);
        }
        private void loadSymtom(string fromType)
        {
            try
            {
                string sql = "select id, name, note " +
                    "from symtom " +
                    "order by name ";
                Database db = new Database();
                dsSymtom = db.selectData(sql);
                if (dsSymtom != null && dsSymtom.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = dsSymtom.Tables[0];
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        this.chkSymtom.Items.Add(dt.Rows[i]["name"].ToString());
                    }
                }
                string _setSymtoms = "";
                if (_from.Equals("patient"))
                    _setSymtoms = frmPatientInfoMng.symtoms;
                else
                    _setSymtoms = FrmPatientMng.symtoms;

                //set check for symtom from patient form
                if (_setSymtoms== null || _setSymtoms.Equals(""))
                {
                    for (int j = 0; j < dsSymtom.Tables[0].Rows.Count; j++)
                    {
                        this.chkSymtom.SetItemChecked(j, false);
                    }
                }
                else
                {
                    _setSymtoms = _setSymtoms.Replace(", ", ",");
                    string[] symtoms = _setSymtoms.Split(',');
                    for (int i = 0; i < symtoms.Length; i++)
                    {
                        for (int j = 0; j < dsSymtom.Tables[0].Rows.Count; j++)
                        {
                            if (dsSymtom.Tables[0].Rows[j]["name"].ToString() == symtoms[i])
                            {
                                this.chkSymtom.SetItemChecked(j, true);
                                break;
                            }
                        }
                    }
                }

            }
            catch { }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string outSymtoms = "";
            string outSymtomIDs = "";
            for (int i =0; i < dsSymtom.Tables[0].Rows.Count; i++)
            {
                if(chkSymtom.GetItemCheckState(i) == CheckState.Checked)
                {
                    outSymtoms += dsSymtom.Tables[0].Rows[i]["name"].ToString() + ", ";
                    outSymtomIDs += dsSymtom.Tables[0].Rows[i]["id"].ToString() + ",";
                }
            }
            outSymtoms = outSymtoms.Length > 1 ? outSymtoms.Substring(0, outSymtoms.Length - 2) : "";
            if (_from.Equals("ticket"))
            {
                FrmPatientMng.symtoms = outSymtoms;
                FrmPatientMng.symtomIDs = outSymtomIDs;
            }
            else
            {
                frmPatientInfoMng.symtoms = outSymtoms;
                frmPatientInfoMng.symtomIDs = outSymtomIDs;
            }
            this.Close();
        }

        private void FrmAddSymtom_FormClosed(object sender, FormClosedEventArgs e)
        {
            systoms = "";
            _from = "";
        }
    }
}
