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
    class EX2_10_1 : DataService<EX2_10_1>     
    {                                            public EX2_10_1() { }               
        public string COL11 { get; set; }
        public string COL2 { get; set; }
        public Nullable<DateTime> CREATE_DATE { get; set; }
                                         
        public EX2_10_1 (string COL11
, string COL2
, Nullable<DateTime> CREATE_DATE
)
        {                                
            this.COL11 = COL11;          
            this.COL2 = COL2;          
            this.CREATE_DATE = CREATE_DATE;          
        }                                
        public EX2_10_1(string[] splitresult)
        {                                 
            this.COL11 = splitresult[0];  
            this.COL2 = splitresult[1];  
            if (splitresult[2] == "")
            {
                this.CREATE_DATE = null;            }
            else
            {
                this.CREATE_DATE = Convert.ToDateTime(splitresult[2])            }
        }                                 
        public void clear()               
        {                                 
            this.COL11 = null;            
            this.COL2 = null;            
            this.CREATE_DATE = null;            
        }                                 
                                          
    }                                     
}                                         
