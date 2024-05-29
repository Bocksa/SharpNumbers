using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            usuperint foo = new usuperint(99);
            usuperint bar = new usuperint(99);

            foo = foo.add(bar);

            Console.WriteLine(foo.ToString());
            Console.ReadKey();
        }
    }
}
