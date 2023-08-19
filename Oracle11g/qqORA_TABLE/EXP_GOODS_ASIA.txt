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
    class EXP_GOODS_ASIA : DataService<EXP_GOODS_ASIA>     
    {                                            public EXP_GOODS_ASIA() { }               
        public string COUNTRY { get; set; }
        public string SEQ { get; set; }
        public string GOODS { get; set; }
                                         
        public EXP_GOODS_ASIA (string COUNTRY
, string SEQ
, string GOODS
)
        {                                
            this.COUNTRY = COUNTRY;          
            this.SEQ = SEQ;          
            this.GOODS = GOODS;          
        }                                
        public EXP_GOODS_ASIA(string[] splitresult)
        {                                 
            this.COUNTRY = splitresult[0];  
            this.SEQ = splitresult[1];  
            this.GOODS = splitresult[2];  
        }                                 
        public void clear()               
        {                                 
            this.COUNTRY = null;            
            this.SEQ = null;            
            this.GOODS = null;            
        }                                 
                                          
    }                                     
}                                         
