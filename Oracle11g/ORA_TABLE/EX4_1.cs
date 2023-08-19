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
    class EX4_1 : DataService<EX4_1>     
    {                                            public EX4_1() { }               
        public string PHONE_NUM { get; set; }
                                         
        public EX4_1 (string PHONE_NUM
)
        {                                
            this.PHONE_NUM = PHONE_NUM;          
        }                                
        public EX4_1(string[] splitresult)
        {                                 
            this.PHONE_NUM = splitresult[0];  
        }                                 
        public void clear()               
        {                                 
            this.PHONE_NUM = null;            
        }                                 
                                          
    }                                     
}                                         
