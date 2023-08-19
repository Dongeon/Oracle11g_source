using Oracle.ManagedDataAccess.Client;                                                                     
using Oracle11g.Connection;                                                                                
using System;                                                                                              
using System.Collections.Generic;                                                                          
using System.Linq;                                                                                         
using System.Text;                                                                                         
using System.Threading.Tasks;                                                                              
                                                                                                           
namespace Oracle11g.Table                                                                                  
{                                                                                                          
    class EX2_3dataService : DataService<EX2_3>                                             
    {                                                                                                      
        public OracleDataReader selectQuery(string sql)                                                    
        {                                                                                                  
            //DBConnection.InitDB();                                                                       
            DBConnection.InitDB(Global.selectedDatabase);                                                  
            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();               
            //string sql = GetSelectSQL(new EX2_3(), whereCondition);
            DBConnection.g_OraCommand.CommandText = sql;                                                   
            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();                              
                                                                                                           
            return rdr;                                                                                    
        }                                                                                                  
                                                                                                           
        public List<EX2_3> _Read(OracleDataReader rdr)
        {                                                                                                  
            List<EX2_3> listEX2_3 = new List<EX2_3>();
            if (rdr.HasRows)                                                                               
            {                                                                                              
                while (rdr.Read())                                                                         
                {                                                                                          
                    StringBuilder sb = new StringBuilder();                                                
                    for (int i = 0 ; i < rdr.FieldCount ; i++)                                             
                    {                                                                                      
                        sb.Append(rdr[rdr.GetName(i)].ToString());                                         
                        sb.Append(", ");                                                                 
                     }                                                                                      
                                                                                                           
                    string[] splitresult = sb.ToString().Substring(0, sb.ToString().Length - 1).Split(',');
                    EX2_3 data = new EX2_3(splitresult);
                                                                                                           
                    listEX2_3.Add(data);
                                                                                                           
                    data = null;                                                                           
                     splitresult = null;                                                                    
                }                                                                                          
            }                                                                                              
            else                                                                                           
                listEX2_3 = null;
                                                                                                           
            rdr.Close();                                                                                   
            return listEX2_3;
        }                                                                                                  
                                                                                                           
                                                                                                           
    }                                                                                                      
}                                                                                                          
