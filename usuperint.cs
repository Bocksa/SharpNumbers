using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    class usuperint {
        List<int> split_number = new List<int>();

        /*
         * Inserts all input characters into the split_number list in reverse order.
         */

        public usuperint(string number) {
            for (int i = number.Length - 1;  i >= 0; i--) {
                split_number.Add(int.Parse(number[i].ToString()));
            }
        }
    }
}