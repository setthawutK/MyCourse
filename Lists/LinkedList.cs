using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class LinkedList : List
    {

        public LinkedList() 
        {
            first.next = first.back = first;
        }

        private class LinkedNode
        {
            public object e;
            public LinkedNode next,back;
           
            public LinkedNode(object e, LinkedNode back, LinkedNode next)
            {
                this.e = e;
                this.back = back;
                this.next = next;
                
            }
        }
        private int SIZE;
        private LinkedNode first = new LinkedNode(null, null, null);

        private LinkedNode nodeAt(int index)
        {
            LinkedNode node = first;
            for (int j = -1; j < index; j++)
                node = node.next;
            return node;
        }

        private void addBefore(LinkedNode node, object e)
        {
            LinkedNode before = node.back;
            LinkedNode here = new LinkedNode(e, before, node);
            before.next = node.back = here;
            SIZE++;
        }

        public void add(int index, object e)
        {
            addBefore(nodeAt(index), e);
        }

        public void add(object e)
        {
           addBefore(first, e);
        }

        public bool contains(object e)
        {
            return indexOf(e) != -1; 
        }

        public object get(int index)
        {
           return nodeAt(index).e;
        }

        public int indexOf(object e)
        {
            LinkedNode node = first.next;
            for (int i = 0; i < SIZE; i++)
            {
                if(node.e.Equals(e)) 
                    return i;
                node = node.next;
            }                         
            return -1;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        private void removeNode(LinkedNode node)
        {
            LinkedNode before = node.back;
            LinkedNode after = node.next;
            before.next = after;
            after.back = before;
            SIZE--;
        }

        public void remove(int index)
        {
            removeNode(nodeAt(index));
        }

        public void remove(object e)
        {
            LinkedNode node = first.next;
            while (node != first && !node.e.Equals(e))
               node = node.next;
            removeNode(node);
        }

        public void set(int index, object e)
        {
            nodeAt(index).e = e;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
