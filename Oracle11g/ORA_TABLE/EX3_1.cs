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
    class EX3_1 : DataService<EX3_1>     
    {                                            public EX3_1() { }               
        public string COL1 { get; set; }
        public string COL2 { get; set; }
        public Nullable<DateTime> COL3 { get; set; }
                                         
        public EX3_1 (string COL1
, string COL2
, Nullable<DateTime> COL3
)
        {                                
            this.COL1 = COL1;          
            this.COL2 = COL2;          
            this.COL3 = COL3;          
        }                                
        public EX3_1(string[] splitresult)
        {                                 
            this.COL1 = splitresult[0];  
            this.COL2 = splitresult[1];  
            if (splitresult[2] == "")
            {
                this.COL3 = null;            }
            else
            {
                this.COL3 = Convert.ToDateTime(splitresult[2])            }
        }                                 
        public void clear()               
        {                                 
            this.COL1 = null;            
            this.COL2 = null;            
            this.COL3 = null;            
        }                                 
                                          
    }                                     
}                                         
