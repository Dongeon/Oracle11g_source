using Oracle.ManagedDataAccess.Client;                                                                     
using Oracle11g.Connection;                                                                                
using System;                                                                                              
using System.Collections.Generic;                                                                          
using System.Linq;                                                                                         
using System.Text;                                                                                         
using System.Threading.Tasks;                                                                              
                                                                                                           
namespace Oracle11g.Table                                                                                  
{                                                                                                          
    class ORDERSdataService : DataService<ORDERS>                                             
    {                                                                                                      
        public OracleDataReader selectQuery(string sql)                                                    
        {                                                                                                  
            //DBConnection.InitDB();                                                                       
            DBConnection.InitDB(Global.selectedDatabase);                                                  
            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();               
            //string sql = GetSelectSQL(new ORDERS(), whereCondition);
            DBConnection.g_OraCommand.CommandText = sql;                                                   
            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();                              
                                                                                                           
            return rdr;                                                                                    
        }                                                                                                  
                                                                                                           
        public List<ORDERS> _Read(OracleDataReader rdr)
        {                                                                                                  
            List<ORDERS> listORDERS = new List<ORDERS>();
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
                    ORDERS data = new ORDERS(splitresult);
                                                                                                           
                    listORDERS.Add(data);
                                                                                                           
                    data = null;                                                                           
                     splitresult = null;                                                                    
                }                                                                                          
            }                                                                                              
            else                                                                                           
                listORDERS = null;
                                                                                                           
            rdr.Close();                                                                                   
            return listORDERS;
        }                                                                                                  
                                                                                                           
                                                                                                           
    }                                                                                                      
}                                                                                                          
