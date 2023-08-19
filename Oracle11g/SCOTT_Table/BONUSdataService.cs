using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle11g.Table
{
    class BONUSdataService : DataService<BONUS>
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

        public List<BONUS> _Read(OracleDataReader rdr)
        {
            List<BONUS> ListBonus = new List<BONUS>();
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
                    BONUS bonus = new BONUS(splitresult);

                    ListBonus.Add(bonus);

                    bonus = null;
                    splitresult = null;
                }
            }
            else
            {
                MessageBox.Show("결과가 없습니다.","Error");
                ListBonus = null;
            }

            rdr.Close();

            return ListBonus;
        }
          
    }
}
