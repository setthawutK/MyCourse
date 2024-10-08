using System;
using System.Collections.Generic;
using Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlTypes;

namespace Collections
{
    public class LinkedCollection : Collection
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
        private LinkedNode first; //first = null; same same

        public void add(object e)
        {
            first = new LinkedNode(e,first); //first subset ของ new linkedndoedasad
            SIZE++;
        }

        public void remove2(object e)
        {
            if (SIZE == 0) return;
            if (first.e.Equals(e))
            {
                first = first.next;
                SIZE--; return;
            }
            LinkedNode node = first;
            while(node != null)
            {
                if (node.next.e.Equals(e))
                {
                    node.next = node.next.next;
                    SIZE--; return ;
                }
                node = node.next;
            }
        }
        public void remove(object e)
        {
            if (first == null) return;
            if (first.e.Equals(e))
            {
                first = first.next;
                SIZE--; return;
            }
            LinkedNode p = first;
            while(p.next != null)
            {
                if (p.next.e.Equals(e)) //เจอแล้วเปลี่ยน
                {
                    //p = p.next;
                    p.next = p.next.next;
                    SIZE--; return;
                }
                p = p.next;//หาต่อถ้าไม่เจอ
               
            }
           
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public bool contains(object e)
        {
            LinkedNode node = first;
            while (node != null)
            {
                if (node.e.Equals(e))
                    return true;
                node = node.next; //ปมของ node แล้ว ปมนั้นชี้ตัวถัดไป node จึงชี้ ตัว ถัดไป
            }
            return false;
        }

        public int size()
        {
            return SIZE;
        }
        public void add2(object e)
        {
            LinkedNode n = new LinkedNode(null, null);
            n.e = e; // จากพารา e
            n.next = first; // จากพารา next
            first = n;
            SIZE++;
        }

    }
}       
       