using System;
using System.Collections.Generic;
using Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace Collections
{
    public class LinkedHeaderCollection : Collection
    {
        private class LinkedNode
        {
            public object e;
            public LinkedNode next;

            public LinkedNode(object e, LinkedNode next)
            {
                this.e = e;
                this.next = next;
            }
        }   
        private int SIZE;
        private LinkedNode first = new LinkedNode(null, null); //first = null; same same

        public void add(object e)
        {
            first.next = new LinkedNode(e, first.next);
            SIZE++;
        }

        public void remove(object e)
        {
            LinkedNode node = first; //can put next
            while (node.next != null) //can put next
            {
                if (node.next.e.Equals(e))
                {
                    node.next = node.next.next;
                    SIZE--; return;
                }
                node = node.next;
            }
        }

        public bool isEmpty()
        {
            throw new NotImplementedException();
        }

        public bool contains(object e)
        {
            LinkedNode node = first.next;
            while (node != null)
            {
                if (node.e.Equals(e))
                    return true;
                node = node.next;
            }
            return false;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
