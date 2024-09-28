/* 
 * Created by Cian McNamara, 2024.
 * This file is to test the different super number classes.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            uint k = 4;
            k.ToString();
            usuperint foo = new usuperint(699);
            usuperint bar = new usuperint(420);

            foo = foo.Add(bar);

            Console.WriteLine(foo.ToString());
            Console.ReadKey();
        }
    }
}
