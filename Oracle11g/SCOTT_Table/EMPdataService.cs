using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle11g.Table
{
    class EMPdataService : DataService<EMP>
    {
        public OracleDataReader selectQuery(string sql)
        {
            //DBConnection.InitDB();
            DBConnection.InitDB(Global.selectedDatabase);
            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();
            //string sql = GetSelectSQL(new EMP(), whereCondition);
            DBConnection.g_OraCommand.CommandText = sql;
            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();
            
            return rdr;
        }

        public List<EMP> _Read(OracleDataReader rdr)
        {
            List<EMP> listEmp = new List<EMP>();
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
                    EMP emp = new EMP(splitresult);

                    listEmp.Add(emp);

                    emp = null;
                    splitresult = null;
                }
            }
            else
                listEmp = null;

            rdr.Close();
            return listEmp;
        }


    }
}
