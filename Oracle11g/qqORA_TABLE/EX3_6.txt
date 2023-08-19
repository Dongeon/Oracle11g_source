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
    class EX3_6 : DataService<EX3_6>     
    {                                            public EX3_6() { }               
        public string EMPLOYEE_ID { get; set; }
        public string EMP_NAME { get; set; }
        public string SALARY { get; set; }
        public string MANAGER_ID { get; set; }
                                         
        public EX3_6 (string EMPLOYEE_ID
, string EMP_NAME
, string SALARY
, string MANAGER_ID
)
        {                                
            this.EMPLOYEE_ID = EMPLOYEE_ID;          
            this.EMP_NAME = EMP_NAME;          
            this.SALARY = SALARY;          
            this.MANAGER_ID = MANAGER_ID;          
        }                                
        public EX3_6(string[] splitresult)
        {                                 
            this.EMPLOYEE_ID = splitresult[0];  
            this.EMP_NAME = splitresult[1];  
            this.SALARY = splitresult[2];  
            this.MANAGER_ID = splitresult[3];  
        }                                 
        public void clear()               
        {                                 
            this.EMPLOYEE_ID = null;            
            this.EMP_NAME = null;            
            this.SALARY = null;            
            this.MANAGER_ID = null;            
        }                                 
                                          
    }                                     
}                                         
