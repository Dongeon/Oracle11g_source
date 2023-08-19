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
    class PROMOTIONS : DataService<PROMOTIONS>     
    {                                            public PROMOTIONS() { }               
        public string PROMO_ID { get; set; }
        public string PROMO_NAME { get; set; }
                                         
        public PROMOTIONS (string PROMO_ID
, string PROMO_NAME
)
        {                                
            this.PROMO_ID = PROMO_ID;          
            this.PROMO_NAME = PROMO_NAME;          
        }                                
        public PROMOTIONS(string[] splitresult)
        {                                 
            this.PROMO_ID = splitresult[0];  
            this.PROMO_NAME = splitresult[1];  
        }                                 
        public void clear()               
        {                                 
            this.PROMO_ID = null;            
            this.PROMO_NAME = null;            
        }                                 
                                          
    }                                     
}                                         
