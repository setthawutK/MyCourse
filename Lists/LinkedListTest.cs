using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class LinkedListTest : List
    {
        private class LinkedNode
        {
            public object e;
            public LinkedNode back, next;
      
            public LinkedNode(object e, LinkedNode back, LinkedNode next)
            {
                this.e = e;
                this.back = back;
                this.next = next;
            }
        }
        private int SIZE;
        private LinkedNode first = new LinkedNode(null, null, null);

        public LinkedListTest() {
            first.back = first.next = first;
        }
        private void addBefore(LinkedNode node, object e)
        {
            LinkedNode p = node.back;
            LinkedNode x = new LinkedNode(e, p, node);
            p.next = node.back = x;
            ++SIZE;
        }
        public void add(int index, object e)
        {
            addBefore(nodeAt(index), e);
        }

        public void add(object e)
        {
            addBefore(first, e);
        }

        private LinkedNode nodeAt(int index)
        {
            LinkedNode node = first;
            for (int j = -1; j < index; j++)
                node = node.next;
            return node;
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

        private void removeNode(LinkedNode node)
        {
            LinkedNode p = node.back; //ปมก่อนหน้า
            LinkedNode x = node.next; //ปมถัดไป
            p.next = x;
            x.back = p;
            --SIZE;

        }
        public void remove(int index)
        {
            removeNode(nodeAt(index));
        }

        public void remove(object e)
        {
            LinkedNode node = first.next;
            while (node != first) // ค้นจนกลับไปเจอfirst
            {
                if (node.e.Equals(e))
                {   
                    removeNode(node); 
                    return; 
                }
                node = node.next;
            }
        }

        public void set(int index, object e)
        {
            LinkedNode node = nodeAt(index);
            node.e = e;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
