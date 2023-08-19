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
    class KOR_LOAN_STATUS : DataService<KOR_LOAN_STATUS>     
    {                                            public KOR_LOAN_STATUS() { }               
        public string PERIOD { get; set; }
        public string REGION { get; set; }
        public string GUBUN { get; set; }
        public string LOAN_JAN_AMT { get; set; }
                                         
        public KOR_LOAN_STATUS (string PERIOD
, string REGION
, string GUBUN
, string LOAN_JAN_AMT
)
        {                                
            this.PERIOD = PERIOD;          
            this.REGION = REGION;          
            this.GUBUN = GUBUN;          
            this.LOAN_JAN_AMT = LOAN_JAN_AMT;          
        }                                
        public KOR_LOAN_STATUS(string[] splitresult)
        {                                 
            this.PERIOD = splitresult[0];  
            this.REGION = splitresult[1];  
            this.GUBUN = splitresult[2];  
            this.LOAN_JAN_AMT = splitresult[3];  
        }                                 
        public void clear()               
        {                                 
            this.PERIOD = null;            
            this.REGION = null;            
            this.GUBUN = null;            
            this.LOAN_JAN_AMT = null;            
        }                                 
                                          
    }                                     
}                                         
