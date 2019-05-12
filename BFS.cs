using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graph;
using Driver;

namespace Solution
{
    public class BFS
    {
        public static void Find(string from, string to)
        {
            bool known = false;
            Node source = Program.allNodes[from];
            Node destination = Program.allNodes[to];
            Queue<Node> queue = new Queue<Node>();

            BFSinfo.Initialize(source);
            queue.Enqueue(source);
            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();
                foreach (var edge in current.neighbours.Values)
                {
                    Node neighbour = edge.Next(current);
                    BFSinfo Ninfo = neighbour.info;
                    if (Ninfo.color == Color.white)
                    {
                        Ninfo.color = Color.grey;
                        Ninfo.distance = current.info.distance + 1;
                        Ninfo.parent = current;

                        Ninfo.parentEdge = edge;
                        Ninfo.strength = current.info.strength + edge.weight;

                        queue.Enqueue(neighbour);
                    }
                }
                current.info.color = Color.black;
            }
        }
    }
}
