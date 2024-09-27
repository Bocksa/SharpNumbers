using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* 
 * Created by Cian McNamara, 2024.
 * This file is to test the different super number classes.
 * 
 */

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            usuperint foo = new usuperint("400");
            usuperint bar = new usuperint(69);

            foo = foo.Add(bar);

            Console.WriteLine(foo.ToString());
            Console.ReadKey();
        }
    }
}
