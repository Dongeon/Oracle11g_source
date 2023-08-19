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
    class JOBS : DataService<JOBS>     
    {                                            public JOBS() { }               
        public string JOB_ID { get; set; }
        public string JOB_TITLE { get; set; }
        public string MIN_SALARY { get; set; }
        public string MAX_SALARY { get; set; }
        public Nullable<DateTime> CREATE_DATE { get; set; }
        public Nullable<DateTime> UPDATE_DATE { get; set; }
                                         
        public JOBS (string JOB_ID
, string JOB_TITLE
, string MIN_SALARY
, string MAX_SALARY
, Nullable<DateTime> CREATE_DATE
, Nullable<DateTime> UPDATE_DATE
)
        {                                
            this.JOB_ID = JOB_ID;          
            this.JOB_TITLE = JOB_TITLE;          
            this.MIN_SALARY = MIN_SALARY;          
            this.MAX_SALARY = MAX_SALARY;          
            this.CREATE_DATE = CREATE_DATE;          
            this.UPDATE_DATE = UPDATE_DATE;          
        }                                
        public JOBS(string[] splitresult)
        {                                 
            this.JOB_ID = splitresult[0];  
            this.JOB_TITLE = splitresult[1];  
            this.MIN_SALARY = splitresult[2];  
            this.MAX_SALARY = splitresult[3];  
            if (splitresult[4] == "")
            {
                this.CREATE_DATE = null;            }
            else
            {
                this.CREATE_DATE = Convert.ToDateTime(splitresult[4])            }
            if (splitresult[5] == "")
            {
                this.UPDATE_DATE = null;            }
            else
            {
                this.UPDATE_DATE = Convert.ToDateTime(splitresult[5])            }
        }                                 
        public void clear()               
        {                                 
            this.JOB_ID = null;            
            this.JOB_TITLE = null;            
            this.MIN_SALARY = null;            
            this.MAX_SALARY = null;            
            this.CREATE_DATE = null;            
            this.UPDATE_DATE = null;            
        }                                 
                                          
    }                                     
}                                         
