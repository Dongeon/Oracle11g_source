using Oracle.ManagedDataAccess.Client;                                                                     
using Oracle11g.Connection;                                                                                
using System;                                                                                              
using System.Collections.Generic;                                                                          
using System.Linq;                                                                                         
using System.Text;                                                                                         
using System.Threading.Tasks;                                                                              
                                                                                                           
namespace Oracle11g.Table                                                                                  
{                                                                                                          
    class EXP_GOODS_ASIAdataService : DataService<EXP_GOODS_ASIA>                                             
    {                                                                                                      
        public OracleDataReader selectQuery(string sql)                                                    
        {                                                                                                  
            //DBConnection.InitDB();                                                                       
            DBConnection.InitDB(Global.selectedDatabase);                                                  
            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();               
            //string sql = GetSelectSQL(new EXP_GOODS_ASIA(), whereCondition);
            DBConnection.g_OraCommand.CommandText = sql;                                                   
            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();                              
                                                                                                           
            return rdr;                                                                                    
        }                                                                                                  
                                                                                                           
        public List<EXP_GOODS_ASIA> _Read(OracleDataReader rdr)
        {                                                                                                  
            List<EXP_GOODS_ASIA> listEXP_GOODS_ASIA = new List<EXP_GOODS_ASIA>();
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
                    EXP_GOODS_ASIA data = new EXP_GOODS_ASIA(splitresult);
                                                                                                           
                    listEXP_GOODS_ASIA.Add(data);
                                                                                                           
                    data = null;                                                                           
                     splitresult = null;                                                                    
                }                                                                                          
            }                                                                                              
            else                                                                                           
                listEXP_GOODS_ASIA = null;
                                                                                                           
            rdr.Close();                                                                                   
            return listEXP_GOODS_ASIA;
        }                                                                                                  
                                                                                                           
                                                                                                           
    }                                                                                                      
}                                                                                                          
