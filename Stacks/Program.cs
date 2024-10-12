using Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stacks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //object[] d = { "(", 1, "+", "2", ")", "*", "4" };
            List x = new LinkedList();
            x.add("("); x.add("1"); x.add("+"); x.add("2"); x.add(")"); x.add("*"); x.add("4");  
            ArrayStack.InfixToPostfix(x); 
            Console.ReadLine();



        }
    }
}
