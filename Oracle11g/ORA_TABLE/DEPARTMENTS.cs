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
    class DEPARTMENTS : DataService<DEPARTMENTS>     
    {                                            public DEPARTMENTS() { }               
        public string DEPARTMENT_ID { get; set; }
        public string DEPARTMENT_NAME { get; set; }
        public string PARENT_ID { get; set; }
        public string MANAGER_ID { get; set; }
        public Nullable<DateTime> CREATE_DATE { get; set; }
        public Nullable<DateTime> UPDATE_DATE { get; set; }
                                         
        public DEPARTMENTS (string DEPARTMENT_ID
, string DEPARTMENT_NAME
, string PARENT_ID
, string MANAGER_ID
, Nullable<DateTime> CREATE_DATE
, Nullable<DateTime> UPDATE_DATE
)
        {                                
            this.DEPARTMENT_ID = DEPARTMENT_ID;          
            this.DEPARTMENT_NAME = DEPARTMENT_NAME;          
            this.PARENT_ID = PARENT_ID;          
            this.MANAGER_ID = MANAGER_ID;          
            this.CREATE_DATE = CREATE_DATE;          
            this.UPDATE_DATE = UPDATE_DATE;          
        }                                
        public DEPARTMENTS(string[] splitresult)
        {                                 
            this.DEPARTMENT_ID = splitresult[0];  
            this.DEPARTMENT_NAME = splitresult[1];  
            this.PARENT_ID = splitresult[2];  
            this.MANAGER_ID = splitresult[3];  
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
            this.DEPARTMENT_ID = null;            
            this.DEPARTMENT_NAME = null;            
            this.PARENT_ID = null;            
            this.MANAGER_ID = null;            
            this.CREATE_DATE = null;            
            this.UPDATE_DATE = null;            
        }                                 
                                          
    }                                     
}                                         
