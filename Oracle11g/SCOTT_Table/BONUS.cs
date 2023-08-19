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
    class BONUS : DataService<BONUS>
    {
        public string ENAME { get; set; }
        public string JOB { get; set; }
        public string SAL { get; set; }
        public string COMM { get; set; }

        public BONUS() { }
        public BONUS(string ENAME,
             string JOB,
             string SAL,
             string COMM)
        {
            this.ENAME = ENAME;
            this.JOB = JOB;
            this.SAL = SAL;
            this.COMM = COMM;
        }
        public BONUS(string[] splitresult)
        {
            this.ENAME = splitresult[0];
            this.JOB = splitresult[1];
            this.SAL = splitresult[2];
            this.COMM = splitresult[3];
        }
        public void clear()
        {
            this.ENAME = null;
            this.JOB = null;
            this.SAL = null;
            this.COMM = null;
        }
          
    }
}
