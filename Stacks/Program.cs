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
            Stack x = new ArrayStack(5);
            
            Console.WriteLine(ArrayStack.IsCorrectParentheses("(())}"));  // จะแสดงผลเป็น false
            Console.ReadLine();
        }
    }
}
