using Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class LinkedListQueue : Queue
    {
        private List list;
        public LinkedListQueue()
        {
            list = new LinkedList();
        }

        public object dequeue()
        {
            object e = peek();
            list.remove(0);
            return e;
        }

        public void enqueue(object e)
        {        
            list.add(e);
        }

        public bool isEmpty()
        {           
            return list.isEmpty();
        }

        public object peek()
        {
            if (isEmpty()) throw new MissingMemberException();
            return list.get(0);
        }

        public int size()
        {
            return list.size();
        }
    }
}
