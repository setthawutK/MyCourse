using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class t1 : Queue
    {
        private object[] data;
        private int SIZE;
        private int cap;
        private int firstindex;

        public t1(int cap) 
        {
            data = new object[cap];
            SIZE = firstindex = 0;
        }


        public object dequeue()
        {
            object e = peek();           
            data[firstindex] = null;
            firstindex = (firstindex + 1) % data.Length;
            SIZE--;
            return e;
        }
        public object dequeue1()
        {
            object e = peek();
            data[firstindex++] = null;
            SIZE--;
            return e;
        }

        private void ensureCapacity1()
        {
            if (SIZE == data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0; i < SIZE; i++)
                    tempdata[i] = data[i];
                data = tempdata;
            }
        }
        private void ensureCapacity()
        {
            if (SIZE == data.Length)
            {
                object[] tempdata = new object[2 * SIZE];
                for (int i = 0, j = firstindex; i < SIZE; i++, j = (firstindex + 1) % data.Length)
                    tempdata[i] = data[j];               
                firstindex = 0;
                data = tempdata;
            }
        }

        public void enqueue1(object e)
        {
            ensureCapacity1();
            data[firstindex + SIZE] = e; 
            SIZE++;
        }

        public void enqueue(object e)
        {
            ensureCapacity();
            int b = (firstindex + SIZE) % data.Length;
            data[b] = e;
            SIZE++;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            if (isEmpty()) throw new System.MissingMemberException();
            return data[firstindex];
        }

        public int size()
        {
            return SIZE;
        }

        //public class ArrayUtil
        //{
        //    public static void radixSort(int[] data, int d)
        //    {
        //        Queue[] q = new ArrayQueue[10];
        //        for (int i = 0; i < q.length; i++)
        //            q[i] = new ArrayQueue();
        //        for (int k = 0; k < d; k++)
        //        {
        //            for (int i = 0; i < data.Length; i++)
        //                q[getDigit(data[i], k)].enqueue(data[i]);
        //            for (int i = 0, j = 0; i < q.Length; i++)
        //            {
        //                while (!q[i].isEmpty())
        //                    data[j++] = (int)q[i].dequeue();
        //            }
        //        }
        //    }
        //    private static int getDigit(int v, int k)
        //    {
        //        int n = v.Value;
        //        for (int i = 0; i < k; i++) n /= 10;
        //        return n % 10;
        //    }
        //}

    }
}

