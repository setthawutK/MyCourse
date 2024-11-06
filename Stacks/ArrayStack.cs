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

        // หลักการ Priority มากกว่าจะทำการ push และดำเนินการก่อน
        //                                   +  -  *  /  ^  (   )
        private static int[] OutPriority = { 2, 2, 3, 3, 5, 6, 1 };
        private static int[] InPriority = { 2, 2, 3, 3, 4, 0};
        private static bool isOperator(String input)
        {
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


        public static List InfixToPostfix(List infix)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < infix.size(); i++)
                s.Append(infix.get(i).ToString());
            if (!IsCorrectParentheses(s.ToString()))
            {
                Console.WriteLine("False");
                return infix;
            }                       

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
                    while (!x.isEmpty() && inPriority((String)x.peek()) >= j) //ถ้า*ข้างใน* stack ไม่ว่างและ ค่า Priority มากกว่าเท่ากับตัวที่รับเข้ามาจาก List infix
                        postfix.add(x.pop());  //จะทำการ add ตัวบนสุดใน stack  ไปยัง list postfix
                    if (C.Equals(")")) 
                        x.pop();
                    else x.push(C); //ถ้า*ข้างใน* stack ค่า Priority น้อยกว่าตัวที่รับเข้ามาจาก List infix จะ push ตัวที่รับมาลง

                }
            }
            while (!x.isEmpty())
                postfix.add(x.pop());
            showPostfix(postfix);
            calculatePostfix(postfix);
            return postfix;         
        }


        private static void showPostfix(List x) //แสดง Postfix
        {
            for (int i = 0; i < x.size(); i++)
                Console.Write(" " + x.get(i));
            Console.WriteLine();
        }


        private static void calculatePostfix(List p) //คำนวน Postfix
        {
            Stack x = new ArrayStack(p.size());

            for (int i = 0; i < p.size(); i++)
            {
                String C = (String)p.get(i);
                if (!isOperator(C))
                    x.push(C);
                else
                {
                    double b = Convert.ToDouble(x.pop());
                    double a = Convert.ToDouble(x.pop());
                    double res = 0;

                    int opIndex = operators.IndexOf(C);
                    switch (opIndex)
                    {
                        case 0: // "+"
                            res = a + b;
                            break;
                        case 1: // "-"
                            res = a - b;
                            break;
                        case 2: // "*"
                            res = a * b;
                            break;
                        case 3: // "/"
                            res = a / b;
                            break;
                        case 4: // "^"
                            res = Math.Pow(a, b);
                            break;
                        default :
                            break;
                    }
                    x.push(res);
                 
                }
            }
            Console.WriteLine(" result : " + x.pop());
        }

        public static bool isPalindrome(string s)
        {
            Stack stack = new ArrayStack(s.Length);
            string result = "";
            for ( int i = 0; i < s.Length; i++)
                stack.push(s[i]);
            while (!stack.isEmpty())
            {
                result += stack.pop();
                
            }
            Console.WriteLine(s);
            Console.WriteLine(result);    
            return result == s;
        
        }
        
        public static bool isPalindromeNumber(int x)
        {
            if (x < 0) return false;
            long reversed = 0;
            long temp = x; //121
            while (temp != 0)
            {
                reversed = (reversed * 10) + (temp % 10); // 1,12,121
                temp /= 10; //12,1,0
            }
            Console.WriteLine(x);
            Console.WriteLine(reversed);
            return reversed == x;
        }

        public bool isPalindromeNumber2(int x)
        {

            if (x < 0) return false;

            string str = x.ToString();
            Stack<char> stack = new Stack<char>();
            string result = "";
            for (int i = 0; i < str.Length; i++)
                stack.Push(str[i]);
            while (stack.Count > 0)
                result += stack.Pop();
            return result == str;

        }
        public static bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;

            while (left < right)
            {
                if (Char.ToLower(s[left]) == Char.ToLower(s[right]))
                {
                    left++;
                    right--;
                }
                else if (!Char.IsLetterOrDigit(s[left]))
                    left++;
                else if (!Char.IsLetterOrDigit(s[right]))
                    right--;
                else return false;
            }
            return true;
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            int n = nums.Length;
            for (int i = 0; i < n - 1; i++){
                for (int j = i + 1; j < n; j++)
                    if (nums[i] + nums[j] == target)
                        return new int[] { i, j };                
            }
            return new int[] { };
        }


        public static int[] TwoSum2(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                    return new int[] { map[complement], i };
                map[nums[i]] = i;
            }
            throw new InvalidOperationException("No two sum solution");
        }

        public static int Fibonacci(int n)
        {
            if (n <= 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

       

    }
}
