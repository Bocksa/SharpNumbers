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
            int n1 = int.MaxValue;
            int n2 = int.MaxValue;

            usuperint foo = n1;
            usuperint bar = n2;

            //int Case = n1 * n2;

            /* 
             *  Test Cases are located below. (who needs proper unit testing anyway)
             */

            if (foo == bar) {
                Console.WriteLine($"{foo} = {bar}");
            } else {
                Console.WriteLine($"{foo} != {bar}");
            }

            foo = foo * bar;

            Console.WriteLine($"Is {foo} correct? {/*foo.ToString() == Case.ToString()*/ foo}");
            Console.ReadKey();
        }
    }
}
