using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graph;

namespace Solution
{
    public static class BackTrack
    {
        //public static int DoS = 0;
        //public static int RS = 0;

        public static string StringResult(Node source, Node destination) // Overall: O(E)
        {
            string result = source.name + '/' + destination.name + '\n';
            string ActorsChain = "";
            string MoviesChain = "";
            int DoS = 0, RS = 0;
            Node current = destination;

            while (current != source) // O(Edges) iterations
            {
                var curInfo = current.info;
                ++DoS;
                RS += curInfo.parentEdge.weight;
                ActorsChain = " -> " + current.name + ActorsChain;
                MoviesChain = ' ' + curInfo.parentEdge.movie + " =>" + MoviesChain;

                //Node ToUpdate = current;
                //while (ToUpdate != source)
                //{
                //    var TUInfo = ToUpdate.info;
                //    TUInfo.parent.discoveries[current] = TUInfo.parentEdge;
                //    ToUpdate = TUInfo.parent;
                //}

                current = curInfo.parent;
            }

            ActorsChain = "CHAIN OF ACTORS: " + source.name + ActorsChain + '\n';
            MoviesChain = "CHAIN OF MOVIES:  =>" + MoviesChain + '\n';

            result += "DoS = " + DoS + ", RS = " + RS + '\n';
            result += ActorsChain + MoviesChain + '\n';

            //BackTrack.DoS = DoS;
            //BackTrack.RS = RS;
            return result;
        }
    }
}
