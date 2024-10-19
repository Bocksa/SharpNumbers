/* 
 * Created by Cian McNamara, 2024.
 * This file is to test the different super number classes.
 */

using System;

namespace SharpNumbers {
    public class Program {
        public static void Main(string[] args) {
            long n1 = 100;
            long n2 = 72;

            usuperint foo = n1;
            usuperint bar = n2;
            usuperint result = foo * bar;

            /* 
             *  Test Cases are located below. (who needs proper unit testing anyway)
             */

            if (foo == bar) {
                Console.WriteLine($"{foo} = {bar}");
            } else {
                Console.WriteLine($"{foo} != {bar}");
            }

           Console.WriteLine($"{foo} * {bar} = {result} // Verified: {n1 * n2}");

            Console.ReadKey();
        }
    }
}
