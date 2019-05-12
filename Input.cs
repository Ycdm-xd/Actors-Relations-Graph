using System;
using System.Collections.Generic;
using System.IO;

using Graph;
using Driver;

namespace Input
{
    public static class MovieFile
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
        private static void Set()
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
}
