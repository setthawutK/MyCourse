using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public class ArrayList : List
    {
        private object[] data;
        private int SIZE;
        private int cap;
        public ArrayList(int cap)
        {
            data = new object[cap];
            SIZE = 0;
            //this.cap = cap;
        }
       
        public void add(int index, object e)
        {
            ensureCapacity();
            for(int i = SIZE; i > index; i--)
                data[i] = data[i - 1];
            data[index] = e;
            SIZE++;
        }

        private void ensureCapacity()
        {
            if (SIZE + 1 > data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
        }

        public void add(object e)
        {
            add(SIZE, e);
        }

        public bool contains(object e)
        {
            return indexOf(e) != -1;
        }

        public object get(int index) //ไม่ต้องตรวจสอบช่วงเพราะ indexOf ตรวจแล้ว
        {           
            return data[index];
        }

        public int indexOf(object e) //O(n)
        {
            for (int i = 0; i < SIZE; i++)
                if (data[i].Equals(e)) return i;
            return -1;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(int index)
        {
            
            for (int i = index + 1; i < SIZE; i++)
                data[i - 1] = data[i];
            SIZE--;
            data[SIZE] = null;
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if (i >= 0) remove(i);
                      
                
        }

        public void set(int index, object e) //ตรวจสอบช่วงด้วย
        {
            if (index < 0 || index >= SIZE)
            {
                return;
            }
            data[index] = e;
        }

        public int size()
        {
            return SIZE;
        }
    }
}
