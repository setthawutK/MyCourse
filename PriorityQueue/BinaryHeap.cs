using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class BinaryHeap : PriorityQueue
    {
        private object[] data;
        private int SIZE;
        private int cap;

        public BinaryHeap(int cap)
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

        public object dequeue()
        {
            object max = peek();
            data[0] = data[--SIZE];
            data[SIZE] = null;
            if (SIZE > 1) reorderDown(0);
            return max;
        }

        //ลูกซ้าย 2k+1 , ลูกขวา 2k+2
        //พ่อ (k-1)/2
        private void reorderDown(int k)
        {
            int p;
            while ((p = 2 * k + 1) < SIZE)
            {
                if (p + 1 < SIZE && isGreaterThan(p + 1, p)) p++;
                if (!isGreaterThan(p, k)) break;
                swap(k, p);
                k = p;
            }
        }
        private void reorderUp(int k)
        {

            while (k > 0)
            {
                int p = (k - 1) / 2;
                if (!isGreaterThan(k, p)) break;
                swap(k, p);
                k = p;
            }

        }

        private void swap(int i, int j)
        {
            object t = data[i];
            data[i] = data[j];
            data[j] = t;
        }
        private bool isGreaterThan(int i, int j)
        {
            IComparable e = (IComparable)data[i];
            return e.CompareTo(data[j]) > 0;
        }

        public void enqueue(object e)
        {
            ensureCapacity();
            data[SIZE] = e;
            reorderUp(SIZE++);
        }

        public bool isEmpty()
        {
            return SIZE == 0;
        }

        public object peek()
        {
            if (isEmpty()) throw new MissingMemberException();
            return data[0];
        }

        public int size()
        {
            return SIZE;
        }
        public static void HeapSort(object[] x)
        {

        }
    }
}
