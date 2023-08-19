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
    class SALES : DataService<SALES>     
    {                                            public SALES() { }               
        public string PROD_ID { get; set; }
        public string CUST_ID { get; set; }
        public string CHANNEL_ID { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public Nullable<DateTime> SALES_DATE { get; set; }
        public string SALES_MONTH { get; set; }
        public string QUANTITY_SOLD { get; set; }
        public string AMOUNT_SOLD { get; set; }
        public Nullable<DateTime> CREATE_DATE { get; set; }
        public Nullable<DateTime> UPDATE_DATE { get; set; }
                                         
        public SALES (string PROD_ID
, string CUST_ID
, string CHANNEL_ID
, string EMPLOYEE_ID
, Nullable<DateTime> SALES_DATE
, string SALES_MONTH
, string QUANTITY_SOLD
, string AMOUNT_SOLD
, Nullable<DateTime> CREATE_DATE
, Nullable<DateTime> UPDATE_DATE
)
        {                                
            this.PROD_ID = PROD_ID;          
            this.CUST_ID = CUST_ID;          
            this.CHANNEL_ID = CHANNEL_ID;          
            this.EMPLOYEE_ID = EMPLOYEE_ID;          
            this.SALES_DATE = SALES_DATE;          
            this.SALES_MONTH = SALES_MONTH;          
            this.QUANTITY_SOLD = QUANTITY_SOLD;          
            this.AMOUNT_SOLD = AMOUNT_SOLD;          
            this.CREATE_DATE = CREATE_DATE;          
            this.UPDATE_DATE = UPDATE_DATE;          
        }                                
        public SALES(string[] splitresult)
        {                                 
            this.PROD_ID = splitresult[0];  
            this.CUST_ID = splitresult[1];  
            this.CHANNEL_ID = splitresult[2];  
            this.EMPLOYEE_ID = splitresult[3];  
            if (splitresult[4] == "")
            {
                this.SALES_DATE = null;            }
            else
            {
                this.SALES_DATE = Convert.ToDateTime(splitresult[4])            }
            this.SALES_MONTH = splitresult[5];  
            this.QUANTITY_SOLD = splitresult[6];  
            this.AMOUNT_SOLD = splitresult[7];  
            if (splitresult[8] == "")
            {
                this.CREATE_DATE = null;            }
            else
            {
                this.CREATE_DATE = Convert.ToDateTime(splitresult[8])            }
            if (splitresult[9] == "")
            {
                this.UPDATE_DATE = null;            }
            else
            {
                this.UPDATE_DATE = Convert.ToDateTime(splitresult[9])            }
        }                                 
        public void clear()               
        {                                 
            this.PROD_ID = null;            
            this.CUST_ID = null;            
            this.CHANNEL_ID = null;            
            this.EMPLOYEE_ID = null;            
            this.SALES_DATE = null;            
            this.SALES_MONTH = null;            
            this.QUANTITY_SOLD = null;            
            this.AMOUNT_SOLD = null;            
            this.CREATE_DATE = null;            
            this.UPDATE_DATE = null;            
        }                                 
                                          
    }                                     
}                                         
