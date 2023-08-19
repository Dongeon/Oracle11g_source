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
    class EX2_5 : DataService<EX2_5>     
    {                                            public EX2_5() { }               
        public Nullable<DateTime> COL_DATE { get; set; }
        public string COL_TIMESTAMP { get; set; }
        public string COL_TIMESTAMP2 { get; set; }
                                         
        public EX2_5 (Nullable<DateTime> COL_DATE
, string COL_TIMESTAMP
, string COL_TIMESTAMP2
)
        {                                
            this.COL_DATE = COL_DATE;          
            this.COL_TIMESTAMP = COL_TIMESTAMP;          
            this.COL_TIMESTAMP2 = COL_TIMESTAMP2;          
        }                                
        public EX2_5(string[] splitresult)
        {                                 
            if (splitresult[0] == "")
            {
                this.COL_DATE = null;            }
            else
            {
                this.COL_DATE = Convert.ToDateTime(splitresult[0])            }
            this.COL_TIMESTAMP = splitresult[1];  
            this.COL_TIMESTAMP2 = splitresult[2];  
        }                                 
        public void clear()               
        {                                 
            this.COL_DATE = null;            
            this.COL_TIMESTAMP = null;            
            this.COL_TIMESTAMP2 = null;            
        }                                 
                                          
    }                                     
}                                         
