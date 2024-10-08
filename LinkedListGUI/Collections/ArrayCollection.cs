
using System.Security.Cryptography;

namespace Collections
{
    public class ArrayCollection : Collection
    {
        private int SIZE;
        private int cap;
        private object[] data;
        
        

        public ArrayCollection(int cap)
        {
            data = new object[cap];
            this.cap = cap;
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
            ensureCapacity();   
            data[SIZE++] = e;
            //SIZE++;
            //++x >>> before x++ >>> after
          
        }

        public bool contains(object e)
        {
            return indexOf(e) != -1;


            //while(data[i] != e)
            //{
            // }

        }

        private int indexOf(object e)
        {
            for (int i =0; i < SIZE; i++)
                if (data[i].Equals(e)) return i;
            return -1;

        }
        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public void remove(object e)
        {
            int i = indexOf(e);
            if (indexOf(e) != -1)
            {
                data[i] = data[--SIZE];
                data[SIZE] = null;
            }          
            return;
           
            
        }

        public int size()
        {
            return SIZE;
        }
    }
}
