using LibGit2Sharp;
using System;
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


            string version = Program.VersionControl();

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

        void libgit2SharpExample()
        {
            using (var repo = new Repository(@"C:\Users\admin\Source\Repos\Dongeon\Oracle11g_source"))
            {
                Commit commit = repo.Head.Tip;
                Console.WriteLine("Author: {0}", commit.Author.Name);
                Console.WriteLine("Message: {0}", commit.MessageShort);

                //-- get tree
                foreach (TreeEntry treeEntry in commit.Tree)
                {
                    Console.WriteLine("Path:{0} - Type:{1}", treeEntry.Path, treeEntry.TargetType);
                }

                Console.WriteLine("SHA = " + commit.Sha);
                Console.WriteLine("MessageShort = " + commit.MessageShort);
                Console.WriteLine("Message = " + commit.Message);
                Console.WriteLine("Author = " + commit.Author);
                Console.WriteLine("Committer = " + commit.Committer);
                Console.WriteLine("============================================================");
                Console.WriteLine("id = " + commit.Id);
                Console.WriteLine("message = " + commit.Message);
                Console.WriteLine("Name = " + commit.Author.Name);
                Console.WriteLine(commit.Tree.Select(t => t.Name).ToList());

                Console.WriteLine("============================================================");

            }
        }

        void oracleconn()
        {
            //-- connect oracle
            OracleControl conn = new OracleControl();
            conn.ConnectionOracle();
            List<string> query = conn.SelectQueryOracle("SELECT * FROM dept");
            foreach (string item in query)
            {
                Console.WriteLine(item);
            }
            conn.DisconnectionOracle();
        }
    }
}
