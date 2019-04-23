using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Driver;

namespace Graph
{
    public class Discoveries : Dictionary <Node, Tuple <int,int> >
    {
        public Discoveries(Node owner) : base()
        {
            this[owner] = new Tuple<int, int>(0, 0);
            foreach (var neighbour in owner.neighbours)
            {
                Edge edge = neighbour.Value;
                this[edge.Next(owner)] = new Tuple<int, int>(1, edge.weight);
            }
        }
    }
}
