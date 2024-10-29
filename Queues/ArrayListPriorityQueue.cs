using Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class ArrayListPriorityQueue : PriorityQueue
    {
        private List list;
        public ArrayListPriorityQueue(int cap)
        {
            list = new ArrayList(cap);
        }
        private int HighestPriorirtyIndex()
        {
            if (list.isEmpty()) throw new MissingMemberException();
            int j = 0;
            for (int i = 1; i < list.size(); i++) { 
                IComparable d = (IComparable)list.get(i);
                if (d.CompareTo(list.get(j)) < 0) 
                    j = i;
            }
            return j;
        }

        public object dequeue()
        {
            int j = (int)peek();
            object result = list.get(j);
            list.remove(j);
            return result;
        }

        public void enqueue(object e)
        {
            list.add( e);
        }

        public bool isEmpty()
        {
            return list.isEmpty();
        }

        public object peek()
        {
            if (list.isEmpty()) throw new MissingMemberException();
            return list.get(HighestPriorirtyIndex());
        }

        public int size()
        {
            return list.size();
        }

        class Rectangle : IComparable
        {
            private double H, W;
            public Rectangle(double H, double W)
            {
                this.H = H;
                this.W = W;
            }
            public int CompareTo(object e)
            {
                Rectangle E = (Rectangle)e;
                double Area1 = W * H;
                double Area2 = E.W * E.H;
                if (Area1 > Area2) return 1;
                if (Area1 < Area2) return -1;
                return 0;

            }
        }


    }
}
