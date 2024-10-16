/* 
 * Created by Cian McNamara, 2024.
 * This file is to test the different super number classes.
 */

using System;

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            long n1 = 5992269695472;
            long n2 = 1011;

            usuperint foo = n1;
            usuperint bar = n2;

            /* 
             *  Test Cases are located below. (who needs proper unit testing anyway)
             */

            var x = bar.ShiftRight(2);
            var y = bar.ShiftLeft(2);

            if (foo == bar) {
                Console.WriteLine($"{foo} = {bar}");
            } else {
                Console.WriteLine($"{foo} != {bar}");
            }

            Console.WriteLine($"{foo} / {bar} = {foo.FastDiv(bar)} // Verified: {n1 / n2}");
            Console.ReadKey();
        }
    }
}
