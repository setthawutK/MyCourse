using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    public class ArrayQueue : Queue
    {
        private object[] data;
        private int SIZE;
        private int cap;
        private int firstindex;

        public ArrayQueue(int cap)
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

        public static void radixSort(int[] data)
        {
            int maxValue = getMax(data);
            int maxDigit = (int)Math.Floor(Math.Log10(maxValue) + 1);

            Queue[] q = new ArrayQueue[10]; // สร้าง array ที่เก็บได้ 10 ArrayQueue
            for (int i = 0; i < q.Length; i++)
                q[i] = new ArrayQueue(1); // สร้าง ArrayQueue แต่ละตัวใน array
            for (int k = 0; k < maxDigit; k++)
            {
                for (int i = 0; i < data.Length; i++) 
                    q[getDigit(data[i], k)].enqueue(data[i]); //นำข้อมูลแต่ละตัวใน data[] โดยคิดตามหลักที่ k ลงถัง q 
                for (int i = 0, j = 0; i < q.Length; i++)
                {
                    while (!q[i].isEmpty()) //dequeue ในถัง q มาใส่ data[] เหมือนเดิม
                        data[j++] = (int)q[i].dequeue();
                }
                Console.WriteLine("After sorting digit (" + (k + 1) + ") : " + string.Join(", ", data));
            }
            Console.WriteLine("Sorting completed : " + string.Join(", ", data));

        }
 
        private static int getMax(int[] data)
        {
            int max = data[0];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > max)
                    max = data[i];
            }
            return max;
        }
        private static int getDigit(int n, int k)
        {
            for (int i = 0; i < k; i++) 
                n /= 10;
            return n % 10;        
        }    
        

    }

}

