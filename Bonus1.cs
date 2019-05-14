using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Graph;
using Driver;
using Solution;

namespace Bonus
{
    public class Bonus1
    {
        public static void NotThatHardTbh()
        {
            Console.Write("Input Actor/Actress: ");
            string actorSlashActress = Console.ReadLine();
            actorSlashActress = "Bacon, Kevin"; // !!!!!
            FileStream fs = new FileStream("Bonus1.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
         
            Node source = Program.allNodes[actorSlashActress];
            Queue<Node> queue = new Queue<Node>();
            BFSinfo.Initialize(source);
            queue.Enqueue(source);
            long[] Freqz = new long[12];

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                List<Edge> ToDo = current.neighbours.Values.ToList();

                foreach (var edge in ToDo)
                {
                    Node neighbour = edge.Next(current);
                    BFSinfo Ninfo = neighbour.info;
                    if (Ninfo.color == Color.white)
                    {
                        Ninfo.color = Color.grey;
                        Ninfo.distance = current.info.distance + 1;

                        if (Ninfo.distance > 11)
                            ++Freqz[11];
                        else
                            ++Freqz[current.info.distance];

                        queue.Enqueue(neighbour);
                    }
                }
                //current.info.color = Color.black;
            }

            sw.WriteLine("Deg. of Separ.  Frequency");
            sw.WriteLine("-------------------------");
            sw.WriteLine("0".PadLeft(10) + "1".PadLeft(10));
            for (int i = 0; i < 12; ++i)
            {
                string s = (i == 11) ? ">11" : (i + 1).ToString();
                sw.WriteLine(s.ToString().PadLeft(10) + Freqz[i].ToString().PadLeft(10));
            }

            sw.Close();
            fs.Close();
        }
    }
}
