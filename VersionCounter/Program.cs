using LibGit2Sharp;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace VersionCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //-- 1. VERSION CONTROL 
            string version = Program.VersionControl();
            Console.WriteLine("============================================================");
            //-- 2. GET GIT COMMIT DATA - AFTER LAST BUILD
            Program.libgit2SharpExample();
            Console.WriteLine("============================================================");
            //-- 3. VERSION DATA INSERT
            //Program.oracleconn();
            Console.ReadKey();

        }

        public static string VersionControl()
        {

            //-- Major.Minor.Build
            string filePath = @"C:\Users\admin\Source\Repos\Dongeon\Oracle11g_source\VersionCounter\Version.txt";
            string[] str = null;
            string newVersion = "";
            if (File.Exists(filePath))
            {
                string line = "";
                var reader = new StreamReader(filePath);
                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    Console.WriteLine(line);
                }

                str = line.Split('.');

                str[0] = str[0] + ".";
                str[1] = str[1] + ".";
                int intBuild = int.Parse(str[2]);
                intBuild++;

                str[2] = intBuild + "";
                reader.Close();
            }

            using (var writer = new StreamWriter(filePath))
            {
                foreach (string s in str)
                {
                    newVersion += s;
                }
                writer.Write(newVersion);
                Console.WriteLine(newVersion);
            }

            return newVersion;
        }

        public static void libgit2SharpExample()
        {
            CommitFilter commitFilter = new CommitFilter(); 
            //-- GIT REPO 설정
            //using (var repo = new Repository(@"C:\Users\admin\Source\Repos\ISIA"))
            using (var repo = new Repository(@"C:\Users\admin\Source\Repos\Dongeon\Oracle11g_source"))
            {

                ////-- GIT COMMITS LIST
                //var commits = repo.Head.Commits;
                //foreach (var comm in commits)
                //{
                //    Console.WriteLine("============================================================");
                //    Console.WriteLine("id        = " + comm.Id);
                //    Console.WriteLine("message   = " + comm.Message);
                //    Console.WriteLine("Name      = " + comm.Author.Name);
                //    List<String> strname = comm.Tree.Select(t => t.Name).ToList();
                //    List<String> strpath = comm.Tree.Select(t => t.Path).ToList();

                //    foreach(string str in strname) Console.Write(str + "/");
                //    Console.WriteLine("============================================================");
                //    foreach (string str in strpath) Console.Write(str + "/");
                //    Console.WriteLine("============================================================");

                //    Console.WriteLine("Files     = " + comm.Tree.Select(t => t.Name).ToList());
                //}

                //CommitFilter cf = new CommitFilter
                //{
                //    SortBy = CommitSortStrategies.Reverse | CommitSortStrategies.Time,
                //    ExcludeReachableFrom = repo.Branches["master"].Tip,
                //    IncludeReachableFrom = repo.Head.Tip
                //};

                //var results = repo.Commits.QueryBy(cf);

                //foreach (var result in results)
                //{
                //    //Process commits here.
                //    Console.WriteLine("Files     = ");
                //}

                //foreach(string str in repo.Index.)
                //{

                //}
            }
        }

        public static void oracleconn()
        {
            // 오라클 연결
            OracleConnection conn = new OracleConnection(@"Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))
                                    (CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=orcl))); User Id = scott; Password = 1234;");
            conn.Open();

            // 명령 객체 생성
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;

            // SQL문 지정 및 INSERT 실행
            cmd.CommandText = "INSERT INTO DEPT (DEPTNO,DNAME,LOC) VALUES (31,'dong','eon')";
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}
