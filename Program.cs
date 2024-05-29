using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            usuperint foo = new usuperint(9999999999999999999);
            usuperint bar = new usuperint(9999999999999999999);

            foo = foo.add(bar);

            Console.WriteLine(foo.ToString());
            Console.ReadKey();
        }
    }
}
