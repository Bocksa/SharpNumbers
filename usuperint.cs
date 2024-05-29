using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    class usuperint {
        List<byte> index_list; // Stores the position of a number in terms of scientific notation (i*10^n)
        public usuperint(ulong num) {
            string string_number = num.ToString();
            List<byte> temp_list = new List<byte>();

            foreach (byte character in string_number) {
                byte temp_character = (byte)(character - '0');
                temp_list.Add(temp_character);
            }
            index_list = temp_list;
        }

        public usuperint add(usuperint input) {
            List<byte> list = new List<byte>(); // List which will hold all edits

            if (input.index_list.Count > index_list.Count) {
                for (int i = 0; i < input.index_list.Count - 1; i++) {
                    list = incrementList(list, i, input);
                }
            } else {
                for (int i = 0; i < index_list.Count - 1; i++) {
                    list = incrementList(list, i, input);
                }
            }

            usuperint output = new usuperint();
            output.index_list = list;
            return output;
        }
        public usuperint subtract(usuperint input) {
            List<byte> list = new List<byte>(); // List which will hold all edits

            if (input.index_list.Count > index_list.Count) {
                for (int i = 0; i < input.index_list.Count; i++) {
                    list = decrementList(list, i, input);
                }
            }
            else {
                for (int i = 0; i < index_list.Count; i++) {
                    list = decrementList(list, i, input);
                }
            }

            usuperint output = new usuperint();
            output.index_list = list;
            return output;
        }
        public usuperint mult(usuperint input) {
            List<byte> list = new List<byte>();

            usuperint output = new usuperint();
            output.index_list = list;
            return output;
        }
        private usuperint() {
            // :]
        }
        private List<byte> incrementList(List<byte> list, int i, usuperint input) {
            list.Insert(i, ((byte)(input.index_list[i] + index_list[i])));
            if (list[i] > 9) {
                return roundUp(i, list);
            } else {
                return list;
            }
        }
        private List<byte> decrementList(List<byte> list, int i, usuperint input) {
            int value = index_list[i] - input.index_list[i];
            if (value < 0) {
                list.Insert(i, 0);
                return roundDown(i, list, value);
            }
            list.Insert(i, (byte)(value));
            return list;
        }
        private List<byte> roundUp(int i, List<byte> list) {
            try {
                list.Insert(i + 1, (byte)Math.DivRem((int)list[i], 10, out int result));
                list.Insert(i, (byte)(list[i] % 10));
            } catch (Exception e) {

            }
            return list;
        }
        private List<byte> roundDown(int i, List<byte> list, int value) {
            try {
                value = 10 + value;

            } catch (Exception e) {

            }
            return list;
        }
    }
}
