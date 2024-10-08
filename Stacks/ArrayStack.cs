using Lists;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    public class ArrayStack : Stack
    {
        private object[] data;
        private int SIZE;
        private int cap;


        public ArrayStack(int cap)
        {
            data = new object[cap];
            this.cap = cap;
        }

        public bool isEmpty()
        {
            return SIZE == 0;
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

        public object peek()
        {
            if (isEmpty())
                throw new System.MissingMemberException();
            return data[SIZE - 1];
        }

        public object pop()
        {
            object e = peek();
            data[--SIZE] = null;
            return e;
        }

        public void push(object e)
        {
            ensureCapacity();
            data[SIZE++] = e;
        }

        public int size()
        {
            return SIZE;

        }

        public static bool IsCorrectParentheses(string t)
        {
            Stack x = new ArrayStack(t.Length);
            String open = "{([", close = "})]"; //indexOf จะตรงกัน { กับ } = 0 , ( กับ ) = 1, [ กับ ] = 2
            for (int i = 0; i < t.Length; i++)
            {
                String C = t[i].ToString(); //รับค่า char แต่ละตัวของ string t
                if (open.IndexOf(C) >= 0) //เช็ค C ว่าอยู่ใน open ไหม ถ้าไม่จะ return -1 ไม่เข้าเงื่อนไข
                    x.push(C);  
                else
                {
                    int j = close.IndexOf(C);
                    if (j >= 0)
                        if (x.isEmpty() || !open[j].ToString().Equals(x.pop()))
                            return false;
                }

            }
            return x.isEmpty();
        }



        private static String operators = "+-*/^()";
        //private static String operatorx = "+-*/^";


        private static int[] priority = { 1, 1, 2, 2, 3 };
        // หลักการ Priority มากกว่าจะทำการ push และดำเนินการก่อน
        private static int[] OutPriority = { 2, 2, 3, 3, 5, 6, 1 };
        private static int[] InPriority = { 2, 2, 3, 3, 4, 0};
        private static bool isOperator(String input)
        {
            //String operators = "+-*/^"; จะเรียกทุกครั้งที่ใช้ method นี้ จึงกำหนดข้างบนดีกว่า
            return operators.IndexOf(input) >= 0;
           
        }

        // priority น้อยกว่าหรือเท่ากับ push stack
        // priority มากกว่า add list
        // Priority((String)x.peek()) >= p
        private static int inPriority(String input)
        {
            return InPriority[operators.IndexOf(input)];
        }
        private static int outPriority(String input)
        {
            return OutPriority[operators.IndexOf(input)];
        }

        private static int Priority(String input)
        {
            return priority[operators.IndexOf(input)];
        }
        
        public static List infixToPostfix(List infix)
        {
            List postfix = new ArrayList(infix.size());
            Stack x = new ArrayStack(infix.size());
            for (int i = 0; i < infix.size(); i++)
            {
                String C = (String)infix.get(i);
                if(!isOperator(C))
                    postfix.add(C);
                else
                {
                    int j = Priority(C);
                    while(!x.isEmpty() && Priority((String)x.peek()) >= j ) //ถ้า Priority ของตัวบนสุดใน stack มากกว่าหรือเท่ากับตัวนอก จะ add
                        postfix.add(x.pop()); //หรือง่ายๆจะ addไป postfix เรื่อยๆถ้ายังมากกว่าหรือเท่ากับ แต่พอน้อยกว่าก็จะ push j แทน
                    x.push(C);            

                }
            }
            while (!x.isEmpty())
                postfix.add(x.pop());
            checkPostifx(postfix);
            return postfix;
                              
        }
        public static List InfixToPostfix(List infix)
        {
            List postfix = new ArrayList(infix.size());
            Stack x = new ArrayStack(infix.size());
            for (int i = 0; i < infix.size(); i++)
            {
                String C = (String)infix.get(i);
                if (!isOperator(C))
                    postfix.add(C);
                else
                {
                    int j = outPriority(C);
                    while (!x.isEmpty() && inPriority((String)x.peek()) >= j)//ถ้า Priority ของตัวบนสุดใน stack มากกว่าหรือเท่ากับตัวนอก จะ add
                        postfix.add(x.pop()); //หรือง่ายๆจะ addไป postfix เรื่อยๆถ้ายังมากกว่าหรือเท่ากับ แต่พอน้อยกว่าก็จะ push j แทน
                    if (C.Equals(")")) 
                        x.pop();
                    else x.push(C);

                }
            }
            while (!x.isEmpty())
                postfix.add(x.pop());
            checkPostifx(postfix);
            return postfix;

            
        }

        private static void checkPostifx(List x)
        {
            for (int i = 0; i < x.size(); i++)
            {
                //x.get(i);
                Console.Write(" " + x.get(i));
            }
        }

      
    }
}
