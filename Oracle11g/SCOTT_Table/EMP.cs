using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle11g.Table
{
    class EMP : DataService<EMP>
    {
        public string EMPNO { get; set; }
        public string ENAME { get; set; }
        public string JOB { get; set; }
        public string MGR { get; set; }
        public Nullable<DateTime> HIREDATE { get; set; }
        public string SAL { get; set; }
        public string COMM { get; set; }
        public string DEPTNO { get; set; }

        public EMP() { }
        public EMP(string a) {
            if (a.Equals("Global"))
            {
                this.EMPNO = "";
                this.ENAME = "";
                this.JOB = "";
                this.MGR = "";
                this.HIREDATE = null;
                this.SAL = "";
                this.COMM = "";
                this.DEPTNO = "";
            }
                
        }
        public EMP(string EMPNO,
           string ENAME,
           string JOB,
           string MGR,
           Nullable<DateTime> HIREDATE,
           string SAL,
           string COMM,
           string DEPTNO)
        {
            this.EMPNO = EMPNO;
            this.ENAME = ENAME;
            this.JOB = JOB;
            this.MGR = MGR;
            this.HIREDATE = HIREDATE;   
            this.SAL = SAL;
            this.COMM = COMM;
            this.DEPTNO = DEPTNO;
        }
        public EMP(string[] splitresult)
        {
            this.EMPNO = splitresult[0];
            this.ENAME = splitresult[1];
            this.JOB = splitresult[2];
            this.MGR = splitresult[3];
            if(splitresult[4] == "")
            {
                this.HIREDATE = null;
            }
            else
            {
                this.HIREDATE = Convert.ToDateTime(splitresult[4]);
            }
            
            this.SAL = splitresult[5];
            this.COMM = splitresult[6];
            this.DEPTNO = splitresult[7];
        }
        public void clear()
        {
            this.EMPNO = null;
            this.ENAME = null;
            this.JOB = null;
            this.MGR = null;
            this.HIREDATE = null;
            this.SAL = null;
            this.COMM = null;
            this.DEPTNO = null;
        }
    }
}
