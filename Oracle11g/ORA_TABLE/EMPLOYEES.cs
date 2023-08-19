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
    class EMPLOYEES : DataService<EMPLOYEES>     
    {                                            public EMPLOYEES() { }               
        public string EMPLOYEE_ID { get; set; }
        public string EMP_NAME { get; set; }
        public string EMAIL { get; set; }
        public string PHONE_NUMBER { get; set; }
        public Nullable<DateTime> HIRE_DATE { get; set; }
        public string SALARY { get; set; }
        public string MANAGER_ID { get; set; }
        public string COMMISSION_PCT { get; set; }
        public Nullable<DateTime> RETIRE_DATE { get; set; }
        public string DEPARTMENT_ID { get; set; }
        public string JOB_ID { get; set; }
        public Nullable<DateTime> CREATE_DATE { get; set; }
        public Nullable<DateTime> UPDATE_DATE { get; set; }
                                         
        public EMPLOYEES (string EMPLOYEE_ID
, string EMP_NAME
, string EMAIL
, string PHONE_NUMBER
, Nullable<DateTime> HIRE_DATE
, string SALARY
, string MANAGER_ID
, string COMMISSION_PCT
, Nullable<DateTime> RETIRE_DATE
, string DEPARTMENT_ID
, string JOB_ID
, Nullable<DateTime> CREATE_DATE
, Nullable<DateTime> UPDATE_DATE
)
        {                                
            this.EMPLOYEE_ID = EMPLOYEE_ID;          
            this.EMP_NAME = EMP_NAME;          
            this.EMAIL = EMAIL;          
            this.PHONE_NUMBER = PHONE_NUMBER;          
            this.HIRE_DATE = HIRE_DATE;          
            this.SALARY = SALARY;          
            this.MANAGER_ID = MANAGER_ID;          
            this.COMMISSION_PCT = COMMISSION_PCT;          
            this.RETIRE_DATE = RETIRE_DATE;          
            this.DEPARTMENT_ID = DEPARTMENT_ID;          
            this.JOB_ID = JOB_ID;          
            this.CREATE_DATE = CREATE_DATE;          
            this.UPDATE_DATE = UPDATE_DATE;          
        }                                
        public EMPLOYEES(string[] splitresult)
        {                                 
            this.EMPLOYEE_ID = splitresult[0];  
            this.EMP_NAME = splitresult[1];  
            this.EMAIL = splitresult[2];  
            this.PHONE_NUMBER = splitresult[3];  
            if (splitresult[4] == "")
            {
                this.HIRE_DATE = null;            }
            else
            {
                this.HIRE_DATE = Convert.ToDateTime(splitresult[4])            }
            this.SALARY = splitresult[5];  
            this.MANAGER_ID = splitresult[6];  
            this.COMMISSION_PCT = splitresult[7];  
            if (splitresult[8] == "")
            {
                this.RETIRE_DATE = null;            }
            else
            {
                this.RETIRE_DATE = Convert.ToDateTime(splitresult[8])            }
            this.DEPARTMENT_ID = splitresult[9];  
            this.JOB_ID = splitresult[10];  
            if (splitresult[11] == "")
            {
                this.CREATE_DATE = null;            }
            else
            {
                this.CREATE_DATE = Convert.ToDateTime(splitresult[11])            }
            if (splitresult[12] == "")
            {
                this.UPDATE_DATE = null;            }
            else
            {
                this.UPDATE_DATE = Convert.ToDateTime(splitresult[12])            }
        }                                 
        public void clear()               
        {                                 
            this.EMPLOYEE_ID = null;            
            this.EMP_NAME = null;            
            this.EMAIL = null;            
            this.PHONE_NUMBER = null;            
            this.HIRE_DATE = null;            
            this.SALARY = null;            
            this.MANAGER_ID = null;            
            this.COMMISSION_PCT = null;            
            this.RETIRE_DATE = null;            
            this.DEPARTMENT_ID = null;            
            this.JOB_ID = null;            
            this.CREATE_DATE = null;            
            this.UPDATE_DATE = null;            
        }                                 
                                          
    }                                     
}                                         
