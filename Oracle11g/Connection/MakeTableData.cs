using Oracle.ManagedDataAccess.Client;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Oracle11g.Connection
{
    public class MakeTableData
    {
        public void getData()
        {
            // -- 01. 디렉토리 있는지 없는지 확인

            string directoryPath = @"C:\Users\admin\Documents\Visual Studio 2015\Projects\Oracle11g\Oracle11g\" + Global.selectedDatabase.DB_tabledirectory;
            DirectoryInfo diinfo = new DirectoryInfo(directoryPath);
            if (diinfo.Exists == true)
            {
                return;
            }


            // -- 02. DBCONN 및 테이블 명, 컬럼, 데이터 타입 조회
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            string[] table_name = null;
            string[] table_field = null;
            Hashtable resultHs = new Hashtable();

            DBConnection.InitDB(Global.selectedDatabase);
            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();
            DBConnection.g_OraCommand.CommandText = "        SELECT                                                            "
                                                    + "            B.TABLE_NAME,                                                "
                                                    + "            B.COLUMN_ID AS 컬럼순서,                                     "
                                                    + "            B.COLUMN_NAME  AS 컬럼명,                                    "
                                                    + "            B.DATA_TYPE AS 테이터타입                                    "
                                                    + "        FROM USER_COL_COMMENTS A, USER_TAB_COLUMNS B, USER_TAB_COMMENTS C"
                                                    + "        WHERE B.TABLE_NAME = A.TABLE_NAME                                "
                                                    + "            AND B.COLUMN_NAME = A.COLUMN_NAME                            "
                                                    + "            AND A.TABLE_NAME = C.TABLE_NAME                              "
                                                    + "        ORDER BY B.TABLE_NAME, B.COLUMN_ID                               ";
            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();
            table_name = new string[rdr.RowSize];
            table_field = new string[rdr.RowSize];
            while (rdr.Read())
            {
                sb1.Append(rdr["TABLE_NAME"].ToString() + ",");

                string dataType = string.Empty;
                if (rdr["테이터타입"].ToString().Equals("DATE"))
                    dataType = "Nullable<DateTime>";
                else
                    dataType = "string";
                sb2.Append(rdr["TABLE_NAME"].ToString() + "=" + dataType + "/" + rdr["컬럼명"].ToString() + ",");
            }
            table_name = sb1.ToString().Split(',');
            table_name = table_name.Distinct().ToArray();

            table_field = sb2.ToString().Split(',');

            foreach (string tab in table_name)
            {
                string dataValue = string.Empty;
                for (int i = 0 ; i < table_field.Length ; i++)
                {
                    if (tab.Equals(table_field[i].Split('=')[0]))
                    {
                        if (table_field[i].Equals(""))
                        {

                        }
                        else
                            dataValue += table_field[i].Split('=')[1] + " ";
                    }
                }
                resultHs.Add(tab, dataValue);
            }
            
            // -- 03. 디렉토리 생성 및 테이블 생성
            if (diinfo.Exists == false)
            {
                diinfo.Create();
                setTableClass(resultHs, directoryPath);
                setDataService(resultHs, directoryPath);
            }
        }

        //  테이블 클래스 생성
        public void setTableClass(Hashtable resultHs, string dicPath)
        {
            try
            {
                foreach (var item in resultHs.Keys)
                {
                    StringBuilder resultsb = new StringBuilder();
                    string filepath = dicPath + "\\" + item + ".cs";
                    if (item != null)
                    {
                        //-- item 별 data 배열에 저장
                        string[] table_field = resultHs[item].ToString().Split(' ');


                        //-- class 생성
                        resultsb.Append("using Oracle.ManagedDataAccess.Client;   \n");
                        resultsb.Append("using Oracle11g.Connection;              \n");
                        resultsb.Append("using System;                            \n");
                        resultsb.Append("using System.Collections.Generic;        \n");
                        resultsb.Append("using System.ComponentModel;             \n");
                        resultsb.Append("using System.Linq;                       \n");
                        resultsb.Append("using System.Text;                       \n");
                        resultsb.Append("using System.Threading.Tasks;            \n");
                        resultsb.Append("using System.Windows.Forms;              \n");
                        resultsb.Append("                                         \n");
                        resultsb.Append("namespace Oracle11g.Table                \n");
                        resultsb.Append("{                                        \n");
                        resultsb.Append(String.Format("    class {0} : DataService<{0}>     \n", item));
                        resultsb.Append("    {                                    ");
                        resultsb.Append(String.Format("        public {0}() ", item) + "{ }               \n");
                        for (int i = 0 ; i < table_field.Length ; i++)
                        {
                            if (!table_field[i].Equals(""))
                            {
                                string appendDataColmn = string.Empty;
                                string appendDataType = string.Empty;
                                appendDataColmn = table_field[i].Split('/')[0];
                                appendDataType = table_field[i].Split('/')[1];
                                resultsb.Append(String.Format("        public {0} {1} ", appendDataColmn, appendDataType) + "{ get; set; }\n");
                            }
                        }
                        resultsb.Append("                                         \n");
                        string parameter = string.Empty;

                        for (int i = 0 ; i < table_field.Length ; i++)
                        {
                            if (!table_field[i].Equals(""))
                            {
                                parameter += table_field[i].Replace("/", " ") + "\n, ";
                            }
                        }
                        resultsb.Append(String.Format("        public {0} ("+ "{1}" + ")\n", item, parameter).Replace(", )",")"));
                        resultsb.Append("        {                                \n");

                        for (int i = 0 ; i < table_field.Length ; i++)
                        {

                            if (!table_field[i].Equals(""))
                                resultsb.Append(String.Format("            this.{0} = {0};          \n", table_field[i].Split('/')[1]));

                        }
                        resultsb.Append("        }                                \n");
                        resultsb.Append(String.Format("        public {0}(string[] splitresult)\n", item));
                        resultsb.Append("        {                                 \n");
                        for (int i = 0 ; i < table_field.Length ; i++)
                        {
                            if(table_field[i].Split('/')[0].Contains("DateTime"))
                            {
                                resultsb.Append(String.Format("            if (splitresult[{0}] == \"\")\n", i));
                                resultsb.Append("            {\n");
                                resultsb.Append(String.Format("                this.{0} = null;", table_field[i].Split('/')[1]));
                                resultsb.Append("            }\n");
                                resultsb.Append("            else\n");
                                resultsb.Append("            {\n");
                                resultsb.Append(String.Format("                this.{0} = Convert.ToDateTime(splitresult[{1}])", table_field[i].Split('/')[1],i));
                                resultsb.Append("            }\n");
                            }
                            else if (!table_field[i].Equals(""))
                            {
                                resultsb.Append(String.Format("            this.{0} = splitresult[{1}];  \n", table_field[i].Split('/')[1], i));
                            }
                        }
                        resultsb.Append("        }                                 \n");
                        resultsb.Append("        public void clear()               \n");
                        resultsb.Append("        {                                 \n");
                        for (int i = 0 ; i < table_field.Length ; i++)
                        {
                            if (!table_field[i].Equals(""))
                                resultsb.Append(String.Format("            this.{0} = null;            \n", table_field[i].Split('/')[1]));
                        }
                        resultsb.Append("        }                                 \n");
                        resultsb.Append("                                          \n");
                        resultsb.Append("    }                                     \n");
                        resultsb.Append("}                                         \n");
                        System.IO.File.WriteAllText(filepath, resultsb.ToString(), Encoding.Default);
                    }
                }
            }
            catch (Exception ex)
            {
                new QueryLog().Logging(ex.ToString(), "", "", QueryLog.LOGTYPE.TEXT);
            }
            
        }

        //  DataService  생성
        public void setDataService(Hashtable resultHs, string dicPath)
        {
            try
            {
                foreach (var item in resultHs.Keys)
                {
                    StringBuilder resultsb = new StringBuilder();
                    string filepath = dicPath + "\\" + item + "dataService.cs";
                    resultsb.Append("using Oracle.ManagedDataAccess.Client;                                                                     \n");
                    resultsb.Append("using Oracle11g.Connection;                                                                                \n");
                    resultsb.Append("using System;                                                                                              \n");
                    resultsb.Append("using System.Collections.Generic;                                                                          \n");
                    resultsb.Append("using System.Linq;                                                                                         \n");
                    resultsb.Append("using System.Text;                                                                                         \n");
                    resultsb.Append("using System.Threading.Tasks;                                                                              \n");
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append("namespace Oracle11g.Table                                                                                  \n");
                    resultsb.Append("{                                                                                                          \n");
                    resultsb.Append(String.Format("    class {0}dataService : DataService<{0}>                                             \n",item));
                    resultsb.Append("    {                                                                                                      \n");
                    resultsb.Append("        public OracleDataReader selectQuery(string sql)                                                    \n");
                    resultsb.Append("        {                                                                                                  \n");
                    resultsb.Append("            //DBConnection.InitDB();                                                                       \n");
                    resultsb.Append("            DBConnection.InitDB(Global.selectedDatabase);                                                  \n");
                    resultsb.Append("            DBConnection.g_OraTransaction = DBConnection.g_OraConnection.BeginTransaction();               \n");
                    resultsb.Append(String.Format("            //string sql = GetSelectSQL(new {0}(), whereCondition);\n", item));
                    resultsb.Append("            DBConnection.g_OraCommand.CommandText = sql;                                                   \n");
                    resultsb.Append("            OracleDataReader rdr = DBConnection.g_OraCommand.ExecuteReader();                              \n");
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append("            return rdr;                                                                                    \n");
                    resultsb.Append("        }                                                                                                  \n");
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append(String.Format("        public List<{0}> _Read(OracleDataReader rdr)\n", item));
                    resultsb.Append("        {                                                                                                  \n");
                    resultsb.Append(String.Format("            List<{0}> list{0} = new List<{0}>();\n", item));
                    resultsb.Append("            if (rdr.HasRows)                                                                               \n");
                    resultsb.Append("            {                                                                                              \n");
                    resultsb.Append("                while (rdr.Read())                                                                         \n");
                    resultsb.Append("                {                                                                                          \n");
                    resultsb.Append("                    StringBuilder sb = new StringBuilder();                                                \n");
                    resultsb.Append("                    for (int i = 0 ; i < rdr.FieldCount ; i++)                                             \n");
                    resultsb.Append("                    {                                                                                      \n");
                    resultsb.Append("                        sb.Append(rdr[rdr.GetName(i)].ToString());                                         \n");
                    resultsb.Append("                        sb.Append(\", \");                                                                 \n ");
                    resultsb.Append("                    }                                                                                      \n");
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append("                    string[] splitresult = sb.ToString().Substring(0, sb.ToString().Length - 1).Split(',');\n");
                    resultsb.Append(String.Format("                    {0} data = new {0}(splitresult);\n", item));
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append(String.Format("                    list{0}.Add(data);\n", item));
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append("                    data = null;                                                                           \n ");
                    resultsb.Append("                    splitresult = null;                                                                    \n");
                    resultsb.Append("                }                                                                                          \n");
                    resultsb.Append("            }                                                                                              \n");
                    resultsb.Append("            else                                                                                           \n");
                    resultsb.Append(String.Format("                list{0} = null;\n", item));
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append("            rdr.Close();                                                                                   \n");
                    resultsb.Append(String.Format("            return list{0};\n", item));
                    resultsb.Append("        }                                                                                                  \n");
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append("                                                                                                           \n");
                    resultsb.Append("    }                                                                                                      \n");
                    resultsb.Append("}                                                                                                          \n");
                    System.IO.File.WriteAllText(filepath, resultsb.ToString(), Encoding.Default);
                }
            }
            catch
            {

            }
        }

        static void buildMethod(string pathCode)
        {
            string code = pathCode;

            // C# 컴파일러 객체 생성
            CodeDomProvider codeDom = CodeDomProvider.CreateProvider("CSharp");

            // 컴파일러 파라미터 옵션: 메모리에 어셈블리 생성
            CompilerParameters cparams = new CompilerParameters();
            cparams.GenerateInMemory = true;
            // cparams.ReferencedAssemblies.Add("ThirdParty.dll");            

            // 소스코드를 컴파일해서 어셈블리 생성
            CompilerResults results = codeDom.CompileAssemblyFromSource(cparams, code);

            // 컴파일 에러 있는 경우 표시
            if (results.Errors.Count > 0)
            {
                foreach (var err in results.Errors)
                {
                    Console.WriteLine(err.ToString());
                }
                return;
            }

            // 어셈블리 로딩            
            Type myType = results.CompiledAssembly.GetType("Test.MyClass");
            object myObject = Activator.CreateInstance(myType);

            // 동적 클래스의 속성 읽기/쓰기
            PropertyInfo pi = myObject.GetType().GetProperty("Name");
            if (pi != null)
            {
                pi.SetValue(myObject, "Alex", null);
            }

            object name = pi.GetValue(myObject);
            Console.WriteLine(name);

            // 동적 클래스의 메서드 호출
            MethodInfo mi = myObject.GetType().GetMethod("PrintName");
            mi.Invoke(myObject, null);
        }
    }
}
