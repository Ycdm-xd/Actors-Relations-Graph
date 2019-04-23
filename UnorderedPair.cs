using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph
{
#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
    public class UnorderedPair<T> : Tuple<T, T>
    {
        public UnorderedPair(T item1, T item2) : base(item1, item2) {; }
        public override bool Equals(object obj)
        {
            UnorderedPair<T> other = (UnorderedPair<T>)obj;
            return ((Item1.Equals(other.Item1) && Item2.Equals(other.Item2)) || (Item2.Equals(other.Item1) && Item1.Equals(other.Item2)));
        }
    }
}
