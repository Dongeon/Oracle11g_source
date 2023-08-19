using Oracle11g.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle11g.Connection
{
    class Global
    {
        public static List<EMP> G_list_emp { get; set; }
        public static EMP G_emp { get; set; }
        public static EMP G_emp_update { get; set; }
        public static List<DEPT> G_list_dept { get; set; }
        public static DEPT G_dept { get; set; }
        public static DEPT G_dept_update { get; set; }
        public static List<BONUS> G_list_bonus { get; set; }
        public static BONUS G_bonus { get; set; }
        public static BONUS G_bonus_update { get; set; }
        public static List<SALGRADE> G_list_salgrade { get; set; }
        public static SALGRADE G_salgrade { get; set; }
        public static SALGRADE G_salgrade_update { get; set; }
        public static DBConnection selectedDatabase { get; set; }
    }
}
