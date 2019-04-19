using System;
using System.Collections.Generic;

using Graph;

namespace Driver
{
    public class Program
    {
        public static Dictionary<string, Node> allNodes;
        public static void Main()
        {
            allNodes = new Dictionary<string, Node>();

            Edge.AddEdge("node1", "node2", "movie between 1 and 2 ");
            Edge.AddEdge("node1", "node2", "movie between 1 and 2 dup ");
            Edge.AddEdge("node2", "node1", "movie between 1 and 2 dup ");
            Edge.AddEdge("node1", "node3", "movie between 1 and 3 ");
            Edge.AddEdge("node2", "node3", "movie between 2 and 3 ");
            foreach (var item in allNodes)
            {
                Console.WriteLine("In the node : " + item.Value.name);
                Console.WriteLine("contains :");
                foreach (var it in item.Value.neighbours)
                {
                    Console.Write(it.Value.next.name + " movie is " + it.Value.movie + " weight is " + it.Value.weight + "\n");
                }
            }
        }
    }
}