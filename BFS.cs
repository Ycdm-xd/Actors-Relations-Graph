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
        public static string Find(string from, string to)
        {
            bool known = false;
            Node source = Program.allNodes[from];   // Ѳ(1) Dictionary search
            Node destination = Program.allNodes[to];// Ѳ(1) Dictionary search
            Queue<Node> queue = new Queue<Node>();

            BFSinfo.Initialize(source);             // Initialize complexity
            queue.Enqueue(source);
            while (queue.Count > 0)                 // O(
            {
                Node current = queue.Dequeue();
                List<Edge> ToDo;

                //if (current.discoveries.ContainsKey(destination))
                //{
                //    ToDo = new List<Edge>
                //    {
                //        current.discoveries[destination]
                //    };
                //}
                //else
                //{
                    ToDo = current.neighbours.Values.ToList();
                //}

                foreach (var edge in ToDo)
                {
                    Node neighbour = edge.Next(current);
                    BFSinfo Ninfo = neighbour.info;

                    if (neighbour == destination)
                        known = true;

                    if (Ninfo.color == Color.grey)
                    {
                        if (Ninfo.distance == current.info.distance + 1)
                            if (Ninfo.strength < current.info.strength + edge.weight)
                                Ninfo.Reset(false);
                    }

                    if (Ninfo.color == Color.white)
                    {
                        Ninfo.color = Color.grey;
                        Ninfo.distance = current.info.distance + 1;
                        Ninfo.parent = current;

                        Ninfo.parentEdge = edge;
                        Ninfo.strength = current.info.strength + edge.weight;

                        if (!known)
                            queue.Enqueue(neighbour);
                    }
                }
                current.info.color = Color.black;
            }

            return BackTrack.StringResult(source, destination);
        }
    }
}
