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
    class EX2_2 : DataService<EX2_2>     
    {                                            public EX2_2() { }               
        public string COLUMN1 { get; set; }
        public string COLUMN2 { get; set; }
        public string COLUMN3 { get; set; }
                                         
        public EX2_2 (string COLUMN1
, string COLUMN2
, string COLUMN3
)
        {                                
            this.COLUMN1 = COLUMN1;          
            this.COLUMN2 = COLUMN2;          
            this.COLUMN3 = COLUMN3;          
        }                                
        public EX2_2(string[] splitresult)
        {                                 
            this.COLUMN1 = splitresult[0];  
            this.COLUMN2 = splitresult[1];  
            this.COLUMN3 = splitresult[2];  
        }                                 
        public void clear()               
        {                                 
            this.COLUMN1 = null;            
            this.COLUMN2 = null;            
            this.COLUMN3 = null;            
        }                                 
                                          
    }                                     
}                                         
