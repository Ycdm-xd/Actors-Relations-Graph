using System;
using System.Collections.Generic;

using Driver;
using Solution;

namespace Graph
{
    public class Edge
    {
        public int weight;
        public string movie;
        public UnorderedPair<Node> ends;

        public Edge(Node node1, Node node2, string movie, int weight)
        {
            this.movie = movie;
            this.weight = weight;
            ends = new UnorderedPair<Node>(node1, node2);
        }
        public Node Next(Node prev)
        {
            if (ends.Item1 == prev)
                return ends.Item2;
            return ends.Item1;
        }
        public static void AddEdge(string name1, string name2, string movie) // Overall: Linear
        {
            Node node1, node2;
            if (!Program.allNodes.ContainsKey(name1)) // Linear
            {
                node1 = new Node(name1);
                Program.allNodes.Add(name1, node1);
            }
            else
            {
                node1 = Program.allNodes[name1]; // Linear
            }
            if (!Program.allNodes.ContainsKey(name2))
            {
                node2 = new Node(name2);
                Program.allNodes.Add(name2, node2);
            }
            else
            {
                node2 = Program.allNodes[name2];
            }
            node1.AddNode(node2, movie); // Linear
        }
    }

    public class Node
    {
        public string name;
        public BFSinfo info;
        public Dictionary<string, Edge> neighbours; 
        public Dictionary<Node, Edge> discoveries;
        public Node(String name)
        {
            this.name = name;
            neighbours = new Dictionary<string, Edge>();
            discoveries = new Dictionary<Node, Edge>();
            info = new BFSinfo();
        }


        public void AddNode(Node other, string movie) // Linear
        {
            if (!neighbours.ContainsKey(other.name))
            {
                Edge Microsoft = new Edge(this, other, movie, 1);
                neighbours.Add(other.name, Microsoft);
                other.neighbours.Add(name, Microsoft);
            }
            else
            {
                neighbours[other.name].weight += 1;
            }
        }
    }
}
