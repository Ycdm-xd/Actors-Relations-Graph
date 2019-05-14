using System;
using System.Collections.Generic;

using Graph;
using InputOutput;
using Bonus;

namespace Driver
{
    public class Program // Schwarzenegger, Arnold/Quinn, Glenn
    {
        public static Dictionary<string, Node> allNodes = new Dictionary<string, Node>();
        public static void Main() // Movies.txt - Queries.txt - Correct.txt
        {
            MoviesFile.Get();
            //QueriesFile.SolveAll();
            //QueriesFile.CompareResults();
            //Bonus1.NotThatHardTbh();
            while (true)
                Bonus2.Asdf();
        }
    }
}