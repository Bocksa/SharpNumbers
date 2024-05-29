using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            usuperint foo = new usuperint((ulong)(2000000000000));
            usuperint bar = new usuperint((ulong)(2000000000000));

            foo = foo.subtract(bar);

            Console.WriteLine(foo.ToString());
            Console.ReadKey();
        }
    }
}
