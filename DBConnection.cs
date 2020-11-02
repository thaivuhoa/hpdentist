using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Configuration;

namespace HpDentist
{
    class Database
    {
        #region Variables

        String Name = "HPDentist.accdb";
        String Path = "";
        String ConnectionString;
        OleDbConnection Connection;

        #endregion

        #region Init Destroy

        public Database()
        {
            Path = Application.StartupPath + "\\" + Name;
            ConnectionString = @"Provider = Microsoft.ACE.OLEDB.12.0; " +
                                "Data Source = " + Path + ";";// +
                                                              //"Persist Security Info = False;";

            ConnectionString = System.Configuration.ConfigurationSettings.AppSettings.Get("connectionString");
            Connection = new OleDbConnection(ConnectionString);
            if (Connection.State == System.Data.ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public void finalize()
        {
            if (Connection.State == System.Data.ConnectionState.Open)
            {
                try { Connection.Close(); }
                catch { }
            }
        }

        #endregion

        #region Queries

        public void execute(String query)
        {
            OleDbCommand command = new OleDbCommand(query, Connection);
            command.ExecuteNonQuery();
        }

        public OleDbDataReader select(String query)
        {
            OleDbCommand command = new OleDbCommand(query, Connection);
            OleDbDataReader data = command.ExecuteReader();
            return data;
        }

        public DataSet selectData(String query)
        {
            OleDbCommand command = new OleDbCommand(query, Connection);
            command.CommandType = CommandType.Text;
            command.CommandText = query;
            OleDbDataAdapter adp = new OleDbDataAdapter(command);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            return ds;
        }
        public int updateData(String query)
        {
            int rst = -1;
            OleDbCommand command = new OleDbCommand(query, Connection);
            //command.CommandType = CommandType.Text;
            command.CommandText = query;
            rst = command.ExecuteNonQuery();
            return rst;
        }

        public object scalar(String query)
        {
            OleDbCommand command = new OleDbCommand(query, Connection);
            object data = new object();
            data = command.ExecuteScalar();
            return data;
        }

        #endregion

        #region Encryption Security

        public String stripInjection(String field)
        {
            String x = field.Replace(@"'", string.Empty);
            x = x.Replace(@"""", string.Empty);
            return x;
        }

        public string md5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString().ToUpper();
        }

        #endregion
    }
}
