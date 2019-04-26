using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {


        public struct Node
        {
            public String Name;
            public String Color;
            public int Distance;
            public List<Node> Parent;
            public List<String> Movies;
        }

        public static void AddEdge(ref Dictionary<Node, List<Node>> Graph,ref Node U,ref Node V,ref Dictionary<Tuple<Node, Node>, int> Frequency)
        {
            if (Graph.ContainsKey(U) && Graph.ContainsKey(V))                    // if Both Nodes exist
            {
                if (Graph.ContainsKey(U) && Graph[U].Contains(V))             // if Connected
                {
                    Tuple<Node, Node> x = new Tuple<Node, Node>(U, V);
                    Tuple<Node, Node> y = new Tuple<Node, Node>(V, U);
                    if (Frequency.ContainsKey(x))
                    {
                        Frequency[x]++;
                    }
                    else if (Frequency.ContainsKey(y))
                    {
                        Frequency[y]++;
                    }



                }
                else                                                          // if not connected
                {
                    Graph[U].Add(V);
                    Graph[V].Add(U);
                    Tuple<Node, Node> x = new Tuple<Node, Node>(U, V);
                    Frequency.Add(x, 1);
                }

            }

            else if (Graph.ContainsKey(U) && !Graph.ContainsKey(V))                              // if U exists and V is not existed
            {
                List<Node> Vneigh = new List<Node>();         // List for V neighbours
                Vneigh.Add(U);
                Graph.Add(V, Vneigh);
                Graph[U].Add(V);
                Tuple<Node, Node> tup = new Tuple<Node, Node>(U, V);
                Frequency.Add(tup, 1);
            }
            else if (!Graph.ContainsKey(U) && Graph.ContainsKey(V))                                     // if U is not existed and V exists
            {
                List<Node> Uneigh = new List<Node>();         // List for U neighbours
                Uneigh.Add(V);
             
                Graph.Add(U, Uneigh);
                Graph[V].Add(U);
                Tuple<Node, Node> tup = new Tuple<Node, Node>(U, V);
                Frequency.Add(tup, 1);
            }
            else                                                                                         // if Both U and V are not existed
            {
              //  U.Color = "white";
                //V.Color = "white";
               // U.Distance = int.MaxValue;
                //V.Distance = int.MaxValue;
                List<Node> Uneigh = new List<Node>();
                Uneigh.Add(V);
                List<Node> Vneigh = new List<Node>();
                Vneigh.Add(U);
                
                Graph.Add(U, Uneigh);
                Graph.Add(V, Vneigh);
                Tuple<Node, Node> x = new Tuple<Node, Node>(U, V);
                Frequency.Add(x, 1);
            }


        }
        //public static void init(ref Dictionary<Node, List<Node>> Graph)
        //{

        //    for (int i = 0; i < Graph.Keys.Count; i++)
        //    {

        //        List<Node> currentNodes = Graph[Graph.Keys.ElementAt(i)];

        //        for (int j = 0; j < currentNodes.Count; j++)
        //        {
        //            Node currNode = currentNodes[j];
        //            currNode.Color = "white";
        //            currNode.Distance = int.MaxValue;

        //            //        currentNodes[j] = currNode;
        //        }
        //        //  Graph[Graph.Keys.ElementAt(i)] = currentNodes;
        //    }
        //}
        public static void BFS(Dictionary<Node, List<Node>> Graph, Dictionary<Tuple<Node, Node>, int> Frequency, Node source, Node destination)
        {

        }



        static void Main(string[] args)
        {

            Dictionary<Node, List<Node>> Graph = new Dictionary<Node, List<Node>>();
            Dictionary<Tuple<Node, Node>, int> Frequency = new Dictionary<Tuple<Node, Node>, int>();


            Dictionary<int, Tuple<Node, List<Node>>> Graph2 = new Dictionary<int, Tuple<Node, List<Node>>>();







            Console.WriteLine("INPUT: ");
            //List<Node> NodeList = new List<Node>();
            for (int i = 0; i < 5; i++)   // Number of Edges
            {
                Node U = new Node();
                Node V = new Node();
                String u, v;
                String line;

                line = Console.ReadLine();
                String[] arr = new string[2];
                arr = line.Split(' ');
                u = arr[0];
                v = arr[1];
                U.Name = u;
                V.Name = v;
                AddEdge(ref Graph,ref U,ref  V,ref Frequency);



            }
            Console.WriteLine();
            Console.WriteLine("OUTPUT ");

            foreach (Node i in Graph.Keys)
            {
                Console.Write("Neighbors of " + i.Name + ": ");
               
                foreach (Node j in Graph[i])
                {
                    Console.Write(j.Name + " ");
                }
                Console.WriteLine();
            }
            foreach (Tuple<Node, Node> i in Frequency.Keys)
            {
                Console.Write("Frequency of( " + i.Item1.Name + " , " + i.Item2.Name + ") : ");
                //foreach(int j in Frequency.Values)
                //{
                //    Console.Write(j);
                //}
                Console.WriteLine(Frequency[i]);
            }


        }
    }
}
