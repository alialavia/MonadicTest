using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static Maybe SafeRead()
        {
            var s = Console.ReadLine();
            int n;
            return int.TryParse(s, out n) ? Maybe.Just(n) : Maybe.Nothing;
        }

        private static void Main(string[] args)
        {
            var justObject = Maybe.Just(new object());
            Func<object, Maybe> func = o => SafeRead();
            Console.WriteLine(justObject >= func >= func >= func);
        }
    }
}
