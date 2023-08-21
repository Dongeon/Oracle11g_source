using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VersionCounter
{
    internal class Program
    {
        static void Main(string[] args)
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
            }

            Console.ReadKey();

        }



    }
}
