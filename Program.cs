using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            usuperint foo = new usuperint(487226);
            usuperint bar = new usuperint(100000);
            foo = foo.subtract(bar);
            Console.ReadKey();
        }
    }
}
