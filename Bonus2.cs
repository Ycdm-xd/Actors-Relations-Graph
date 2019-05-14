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
    public class Bonus2
    {
        public static void Asdf()
        {
            Console.Write("Input Actor/Actress pair slash separated: ");
            string[] bothActorsSlashActresses = Console.ReadLine().Split('/');

            Node source = Program.allNodes[bothActorsSlashActresses[0]];
            Node destination = Program.allNodes[bothActorsSlashActresses[1]];
            Queue<Node> queue = new Queue<Node>();

            BFSinfo.Initialize(source);
            queue.Enqueue(source);
            while (queue.Count > 0) 
            {
                Node current = queue.Dequeue();
                List<Edge> ToDo;
                ToDo = current.neighbours.Values.ToList();

                foreach (var edge in ToDo)
                {
                    Node neighbour = edge.Next(current);
                    BFSinfo Ninfo = neighbour.info;

                    if (Ninfo.color == Color.grey)
                    {
                        if (Ninfo.strength < current.info.strength + edge.weight)
                            Ninfo.color = Color.white;
                    }

                    if (Ninfo.color == Color.white)
                    {
                        Ninfo.color = Color.grey;
                        Ninfo.parent = current;

                        Ninfo.parentEdge = edge;
                        Ninfo.strength = current.info.strength + edge.weight;
                    }
                }
                current.info.color = Color.black;
            }

            Console.WriteLine("Result: " + destination.info.strength);
        }
    }
}
