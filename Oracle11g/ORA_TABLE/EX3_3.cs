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
    class EX3_3 : DataService<EX3_3>     
    {                                            public EX3_3() { }               
        public string EMPLOYEE_ID { get; set; }
        public string BONUS_AMT { get; set; }
                                         
        public EX3_3 (string EMPLOYEE_ID
, string BONUS_AMT
)
        {                                
            this.EMPLOYEE_ID = EMPLOYEE_ID;          
            this.BONUS_AMT = BONUS_AMT;          
        }                                
        public EX3_3(string[] splitresult)
        {                                 
            this.EMPLOYEE_ID = splitresult[0];  
            this.BONUS_AMT = splitresult[1];  
        }                                 
        public void clear()               
        {                                 
            this.EMPLOYEE_ID = null;            
            this.BONUS_AMT = null;            
        }                                 
                                          
    }                                     
}                                         
