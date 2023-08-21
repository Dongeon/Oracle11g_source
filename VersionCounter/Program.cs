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

            using (var repo = new Repository(@"D:\source\LibGit2Sharp"))
            {
                Commit commit = repo.Lookup<Commit>("73b48894238c3e9c37f9f3a696bbd4bffcf45ce5");
                Console.WriteLine("Author: {0}", commit.Author.Name);
                Console.WriteLine("Message: {0}", commit.MessageShort);
            }

            Console.ReadKey();
        }



    }
}
