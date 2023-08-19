using Oracle.ManagedDataAccess.Client;
using Oracle11g.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle11g.Table
{
    public class SALGRADE : DataService<SALGRADE>
    {
        public string GRADE { get; set; }
        public string LOSAL { get; set; }
        public string HISAL { get; set; }

        public SALGRADE() { }
        public SALGRADE(string GRADE,
                        string LOSAL,
                        string HISAL)
        {
            this.GRADE = GRADE;
            this.LOSAL = LOSAL;
            this.HISAL = HISAL;
        }
        public SALGRADE(string[] splitresult)
        {
            this.GRADE = splitresult[0];
            this.LOSAL= splitresult[1];
            this.HISAL= splitresult[2];
        }
        public void clear()
        {
            this.GRADE = null;
            this.LOSAL = null;
            this.HISAL = null;
        }
    }
}
