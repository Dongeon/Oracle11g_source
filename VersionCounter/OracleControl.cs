using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VersionCounter
{
    class OracleControl
    {

        string strCon = @"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))
                                    (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl))); User Id = scott; Password = 1234;";
        OracleConnection conn;

        public OracleControl(){}

        public void ConnectionOracle()
        {
            try
            {
                if (conn == null)
                {
                    conn = new OracleConnection(strCon);
                }
                conn.Open();
                Console.WriteLine("DB Connection Open Success");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : The Database Connected is fail..." + e.Message);
            }
        }

        public void DisconnectionOracle()
        {
            if (conn != null)
            {
                conn.Close();
                Console.WriteLine("DB Connection Close");
            }
        }

        public List<string> SelectQueryOracle(string query)
        {
            OracleCommand cmd = new OracleCommand();
            this.ConnectionOracle();
            try
            {
                if (conn == null)
                {
                    Console.WriteLine("Error : syntex error");
                    return null;
                }
                if (cmd == null)
                {
                    cmd = new OracleCommand();
                }
                cmd.Connection = conn;
                cmd.CommandText = query;
                OracleDataReader reader = cmd.ExecuteReader();
                List<string> tempList = new List<string>();
                while (reader.Read())
                {
                    string temp = null;
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        temp += reader[i].ToString() + " ";
                    }
                    tempList.Add(temp);
                }
                return tempList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error : " + e.Message);
                return null;
            }
            finally
            {
                this.DisconnectionOracle();
            }
        }
    }
}
