using Oracle.ManagedDataAccess.Client;                                                                     
using Oracle11g.Connection;                                                                                
using System;                                                                                              
using System.Collections.Generic;                                                                          
using System.Linq;                                                                                         
using System.Text;                                                                                         
using System.Threading.Tasks;                                                                              
                                                                                                           
namespace Oracle11g.Table                                                                                  
{                                                                                                          
    class EMPLOYEESdataService : DataService<EMPLOYEES>                                             
    {                                                                                                      
        public OracleDataReader selectQuery(string sql)                                                    
        {                                                                                                  
            //DBConnection.InitDB();                                                                       
            DBConnection.InitDB(Global.selectedDatabase);                                                  
            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();               
            //string sql = GetSelectSQL(new EMPLOYEES(), whereCondition);
            DBConnection.g_OraCommand.CommandText = sql;                                                   
            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();                              
                                                                                                           
            return rdr;                                                                                    
        }                                                                                                  
                                                                                                           
        public List<EMPLOYEES> _Read(OracleDataReader rdr)
        {                                                                                                  
            List<EMPLOYEES> listEMPLOYEES = new List<EMPLOYEES>();
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
                    EMPLOYEES data = new EMPLOYEES(splitresult);
                                                                                                           
                    listEMPLOYEES.Add(data);
                                                                                                           
                    data = null;                                                                           
                     splitresult = null;                                                                    
                }                                                                                          
            }                                                                                              
            else                                                                                           
                listEMPLOYEES = null;
                                                                                                           
            rdr.Close();                                                                                   
            return listEMPLOYEES;
        }                                                                                                  
                                                                                                           
                                                                                                           
    }                                                                                                      
}                                                                                                          
