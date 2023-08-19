using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle11g.Table
{
    public class SALGRADEdataService : DataService<SALGRADE>
    {
        public OracleDataReader selectQuery(string sql)
        {
            //DBConnection.InitDB();
            DBConnection.InitDB(Global.selectedDatabase);
            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();
            DBConnection.g_OraCommand.CommandText = sql;
            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();

            return rdr;
        }

        public List<SALGRADE> _Read(OracleDataReader rdr)
        {
            List<SALGRADE> listSalgrade = new List<SALGRADE>();

            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0 ; i < rdr.FieldCount ; i++)
                    {
                        sb.Append(rdr[rdr.GetName(i)].ToString());
                        sb.Append(",");
                    }
                    string[] splitresult = sb.ToString().Substring(0, sb.ToString().Length - 1).Split(',');
                    SALGRADE salgrade = new SALGRADE(splitresult);

                    listSalgrade.Add(salgrade);

                    salgrade = null;
                    splitresult = null;
                }
            }
            else
            {
                listSalgrade = null;
            }
            rdr.Close();
            return listSalgrade;
        }
    }
}
