using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class SinglyLinkedListTest : List
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
        private LinkedNode first = new LinkedNode(null, null);
        
        public SinglyLinkedListTest() { }
        public void add(int index, object e)
        {
            LinkedNode node = nodeAt(index - 1);
            node.next = new LinkedNode(e, node.next);
            SIZE++;
        }
        private LinkedNode nodeAt(int index)
        {
            LinkedNode node = first;
            for (int j = -1; j < index; j++) 
                node = node.next;
            return node;
        }
        
        public void add(object e)
        {
            add(SIZE, e);
        }

        public bool contains(object e)
        {
            return indexOf(e) >= 0;
        }

        public object get(int index)
        {
            return nodeAt(index).e;
        }

        public int indexOf(object e)
        {
            LinkedNode node = first.next; 
            for (int i = 0; i < SIZE; i++)
                if (node.e.Equals(e)) return i;
                node = node.next;
            return -1;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }
        private void removeAfter (LinkedNode node)
        {
            if (node.next != null)
            {
                node.next = node.next.next;
                --SIZE;
            }
        }

        public void remove(int index)
        {
            LinkedNode node = nodeAt(index - 1);
            removeAfter(node);
        }

        public void remove(object e)
        {
            LinkedNode node = first;
            while (node.next != null && !node.next.e.Equals(e))
                node = node.next;
            removeAfter(node);
        }

        public void set(int index, object e)
        {
            LinkedNode node = nodeAt(index); 
            if (node != null) 
            {
                node.e = e; 
            }

        }

        public int size()
        {
            throw new NotImplementedException();
        }
    }
}
