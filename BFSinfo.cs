using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Driver;
using Graph;

namespace Solution
{
    public enum Color { white, grey, black }

    public class BFSinfo
    {
        public Node parent;
        public Edge parentEdge;
        public Color color;
        public long distance;
        public long strength;
        public BFSinfo() : base()
        {
            Reset(false);
        }
        public void Reset(bool isSource) // Linear
        {
            parent = null;
            parentEdge = null;
            strength = 0;
            if (isSource)
            {
                distance = 0;
                color = Color.grey;
            }
            else
            {
                distance = long.MaxValue;
                color = Color.white;
            }
        }
        public static void Initialize(Node source) // Ѳ(V)
        {
            foreach (var node in Program.allNodes.Values)
            {
                node.info.Reset(node == source);
            }
        }
    }
}
