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
            usuperint foo = new usuperint("9999999999999999999999999999999");
            usuperint bar = new usuperint("9999999999999999999999999999");

            /* 
             *  Test Cases are located below. (who needs proper unit testing anyway)
             */

            foo.Add(bar);
            foo.Sub(bar);
            //foo.Mult(bar); TBA
            //foo.Div(bar); TBA

            foo = foo.Sub(bar);

            Console.WriteLine(foo.ToString());
            Console.ReadKey();
        }
    }
}
