using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle11g.Table
{
    public class DEPT : DataService<DEPT>
    {
        public string DEPTNO { get; set; }
        public string DNAME { get; set; }
        public string LOC { get; set; }

        public DEPT() { }
        public DEPT(string DEPTNO,
                    string DNAME,
                    string LOC)
        {
            this.DEPTNO = DEPTNO;
            this.DNAME = DNAME;
            this.LOC = LOC;
        }
        public DEPT(string[] splitresult)
        {
            this.DEPTNO = splitresult[0];
            this.DNAME = splitresult[1];
            this.LOC = splitresult[2];
        }
        public void clear()
        {
            this.DEPTNO = null;
            this.DNAME = null;
            this.LOC = null;
        }
    }
}
