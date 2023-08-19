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
    class EX2_6 : DataService<EX2_6>     
    {                                            public EX2_6() { }               
        public string COL_NULL { get; set; }
        public string COL_NOT_NULL { get; set; }
                                         
        public EX2_6 (string COL_NULL
, string COL_NOT_NULL
)
        {                                
            this.COL_NULL = COL_NULL;          
            this.COL_NOT_NULL = COL_NOT_NULL;          
        }                                
        public EX2_6(string[] splitresult)
        {                                 
            this.COL_NULL = splitresult[0];  
            this.COL_NOT_NULL = splitresult[1];  
        }                                 
        public void clear()               
        {                                 
            this.COL_NULL = null;            
            this.COL_NOT_NULL = null;            
        }                                 
                                          
    }                                     
}                                         
