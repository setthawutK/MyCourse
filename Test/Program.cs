using System;
using Collections;
using Lists;
using Sets;
using Stacks;

//using System.Collections;
// Collections;
//using Lists;
//using Set;




namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Collection x = new LinkedSet();

            //Collection x = new ArraySetA(5);
            //Collection x = new ArrayListTest(5);
            // x = new ArrayList(5);
            //List x = new ArrayList(5);
            //Collection x = new LinkedSetL();
            //List x = new SinglyLinkedList();
         
            
            List x = new LinkedList();
            x.add("(");
            x.add("2");
            x.add("+");
            x.add("3");
            x.add(")");
            x.add("*");
            x.add("4");            
            ArrayStack.InfixToPostfix(x);

            //ArraySta

            //Console.WriteLine(ArrayStack.infixToPostfix());
            Console.ReadLine();
            //Console.WriteLine(ArrayStack.IsCorrectParentheses("(())}"));  // จะแสดงผลเป็น false
            //Console.ReadLine();
            //x.add(3,"esz");
            //x.remove(1);
            //Console.WriteLine(x.size());
            //Console.WriteLine(x.contains(3));
            //Console.WriteLine(x.contains(4));

        }
    }
}
