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
    class EX2_9 : DataService<EX2_9>     
    {                                            public EX2_9() { }               
        public string NUM1 { get; set; }
        public string GENDER { get; set; }
                                         
        public EX2_9 (string NUM1
, string GENDER
)
        {                                
            this.NUM1 = NUM1;          
            this.GENDER = GENDER;          
        }                                
        public EX2_9(string[] splitresult)
        {                                 
            this.NUM1 = splitresult[0];  
            this.GENDER = splitresult[1];  
        }                                 
        public void clear()               
        {                                 
            this.NUM1 = null;            
            this.GENDER = null;            
        }                                 
                                          
    }                                     
}                                         
