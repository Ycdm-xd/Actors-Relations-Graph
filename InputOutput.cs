using System;
using System.Collections.Generic;
using System.IO;

using Graph;
using Solution;
using Driver;
using System.Diagnostics;

namespace InputOutput
{
    public static class MoviesFile
    {
        private static List<string[]> allData = new List<string[]>();
        public static void Get()
        { 
            FileStream fileStream = new FileStream("Movies.txt", FileMode.OpenOrCreate);
            StreamReader streamReader = new StreamReader(fileStream);
            while (!streamReader.EndOfStream)
            {
                allData.Add(streamReader.ReadLine().Split('/'));
            }
            streamReader.Close();
            fileStream.Close();
            Set();
        }
        private static void Set() // Overall Complexity: Ѳ(E)
        {
            foreach (string[] data in allData)
            {
                for (int i = 1; i < data.Length; ++i)
                {
                    for (int j = i + 1; j < data.Length; ++j)
                    {
                        Edge.AddEdge(data[i], data[j], data[0]);
                    }
                }
            }
        }
    }

    public static class QueriesFile
    {
        public static void SolveAll()
        {
            FileStream read = new FileStream("Queries.txt", FileMode.Open);
            FileStream write = new FileStream("Answers.txt", FileMode.Create);
            StreamReader sr = new StreamReader(read);
            StreamWriter sw = new StreamWriter(write);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Length <= 2)
                    break;
                string[] query = line.Split('/');

                sw.Write(BFS.Find(query[0], query[1]));
            }

            stopWatch.Stop();
            sw.Write(stopWatch.ElapsedMilliseconds + " ms");

            sw.Close();
            sr.Close();
            write.Close();
            read.Close();
        }

        public static void CompareResults()
        {
            try
            {
                FileStream fs = new FileStream("Correct.txt", FileMode.Open);
                FileStream fss = new FileStream("Answers.txt", FileMode.Open);
                StreamReader correct = new StreamReader(fs);
                StreamReader ours = new StreamReader(fss);

                int i = 1;
                while (!correct.EndOfStream)
                {
                    if (correct.ReadLine() != ours.ReadLine())
                    {
                        Console.Write(i + ",\t");
                    }
                    ++i;
                }

                ours.Close();
                correct.Close();
                fss.Close();
                fs.Close();
            }
            catch
            {
                Console.WriteLine("Error comparing files.");
            }
        }
    }

}
