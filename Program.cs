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
            usuperint foo = new usuperint("420");
            usuperint bar = new usuperint("69");

            int Case = 420 - 69;

            /* 
             *  Test Cases are located below. (who needs proper unit testing anyway)
             */

            //foo.Add(bar);
            //foo.Sub(bar);
            //foo.Mult(bar);
            //foo.Div(bar);

            foo = foo.Sub(bar);

            Console.WriteLine($"Is {foo.ToString()} correct? {foo.ToString() == Case.ToString()}");
            Console.ReadKey();
        }
    }
}
