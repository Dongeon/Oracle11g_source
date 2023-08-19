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
    class EX3_2 : DataService<EX3_2>     
    {                                            public EX3_2() { }               
        public string EMP_ID { get; set; }
        public string EMP_NAME { get; set; }
                                         
        public EX3_2 (string EMP_ID
, string EMP_NAME
)
        {                                
            this.EMP_ID = EMP_ID;          
            this.EMP_NAME = EMP_NAME;          
        }                                
        public EX3_2(string[] splitresult)
        {                                 
            this.EMP_ID = splitresult[0];  
            this.EMP_NAME = splitresult[1];  
        }                                 
        public void clear()               
        {                                 
            this.EMP_ID = null;            
            this.EMP_NAME = null;            
        }                                 
                                          
    }                                     
}                                         
