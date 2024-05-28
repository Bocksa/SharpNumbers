using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    class usuperint {
        byte[] index_array; // Stores the position of a number in terms of scientific notation (i*10^n)
        public usuperint(ulong num) {
            string string_number = num.ToString();
            byte[] temp_array = new byte[string_number.Length];

            for (int i = string_number.Length - 1; i >= 0; i--) {
                byte character = (byte)(string_number[string_number.Length - 1 - i] - '0');
                temp_array[i] = character;
            }
            index_array = temp_array;
        }

        public usuperint add(usuperint a) {
            usuperint temp = new usuperint();

            for (int i = 0; i < a.index_array.Length - 1; i++) {

            }

            return temp;
        }
        private usuperint() {
            // its needed like this for some reason so i can make a blank one
        }
        private void shift() {

        }
    }
}
