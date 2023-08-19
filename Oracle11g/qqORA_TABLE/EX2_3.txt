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
    class EX2_3 : DataService<EX2_3>     
    {                                            public EX2_3() { }               
        public string COL_INT { get; set; }
        public string COL_DEC { get; set; }
        public string COL_NUM { get; set; }
                                         
        public EX2_3 (string COL_INT
, string COL_DEC
, string COL_NUM
)
        {                                
            this.COL_INT = COL_INT;          
            this.COL_DEC = COL_DEC;          
            this.COL_NUM = COL_NUM;          
        }                                
        public EX2_3(string[] splitresult)
        {                                 
            this.COL_INT = splitresult[0];  
            this.COL_DEC = splitresult[1];  
            this.COL_NUM = splitresult[2];  
        }                                 
        public void clear()               
        {                                 
            this.COL_INT = null;            
            this.COL_DEC = null;            
            this.COL_NUM = null;            
        }                                 
                                          
    }                                     
}                                         
