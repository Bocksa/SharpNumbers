/* 
 * Created by Cian McNamara, 2024.
 * This file is to test the different super number classes.
 */

using System;

namespace SharpNumbers {
    internal class Program {
        static void Main(string[] args) {
            long n1 = 5992269695472;
            long n2 = -1011;

            superint foo = n1;
            superint bar = n2;
            superint result = foo + bar;

            /* 
             *  Test Cases are located below. (who needs proper unit testing anyway)
             */

            if (foo == bar) {
                Console.WriteLine($"{foo} = {bar}");
            } else {
                Console.WriteLine($"{foo} != {bar}");
            }

           Console.WriteLine($"{foo} + {bar} = {result} // Verified: {n1 + n2}");
            Console.ReadKey();
        }
    }
}
