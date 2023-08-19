using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle11g.Connection
{

    class DBConnection
    {
        public string DB_name { get; set; }
        public string DB_host{ get; set; }
        public string DB_port{ get; set; }
        public string DB_id  { get; set; }
        public string DB_password { get; set; }
        public string DB_tabledirectory { get; set; }

        public DBConnection()
        {

        }
        public DBConnection(string DB_name, string DB_host, string DB_port, string DB_id, string DB_password, string DB_tabledirectory)
        {
            this.DB_name = DB_name;
            this.DB_host = DB_host;
            this.DB_port = DB_port;
            this.DB_id = DB_id;
            this.DB_password = DB_password;
            this.DB_tabledirectory = DB_tabledirectory;
        }


        public static Oracle.ManagedDataAccess.Client.OracleTransaction g_OraTransaction = null;
        public static Oracle.ManagedDataAccess.Client.OracleConnection g_OraConnection = null;
        public static Oracle.ManagedDataAccess.Client.OracleCommand g_OraCommand = null;
        //public static string m_ConnectionString = "Data Source=(DESCRIPTION="
        //             + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521)))"
        //             + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));"
        //             + "User Id=scott;Password=ttiger";
        public static string setm_ConnectionString(DBConnection conn)
        {
            return "Data Source=(DESCRIPTION="
                     + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST="+ conn.DB_host + ")(PORT=" + conn.DB_port + ")))"
                     + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl)));"
                     + "User Id=" + conn.DB_id + ";Password=" + conn.DB_password + "";
        }
        public static void InitDB(DBConnection conn)
        {
            try
            {
                g_OraConnection = new Oracle.ManagedDataAccess.Client.OracleConnection();
                g_OraConnection.ConnectionString = setm_ConnectionString(Global.selectedDatabase);
                g_OraConnection.Open();

                if (g_OraConnection.State == System.Data.ConnectionState.Open)
                {
                    g_OraCommand = new Oracle.ManagedDataAccess.Client.OracleCommand();
                    g_OraCommand.Connection = g_OraConnection;
                }
                else
                {
                    MessageBox.Show("fail");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public bool Query(string sql)
        {
            try
            {
                //InitDB();

                //g_OraTransaction = g_OraConnection.BeginTransaction();
                g_OraCommand.CommandText = sql;
                g_OraCommand.ExecuteNonQuery();

                g_OraTransaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            //END
        }
    }
}
