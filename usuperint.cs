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
            temp_list.Reverse();
            index_list = temp_list;
        }

        public usuperint add(usuperint input) {
            List<byte> list = new List<byte>(); // List which will hold all edits

            if (input.index_list.Count > index_list.Count) {
                for (int i = 0; i < input.index_list.Count; i++) {
                    list = incrementList(list, i, input);
                }
            }
            else {
                for (int i = 0; i < index_list.Count; i++) {
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
        public string ToString() {
            string output = string.Empty;
            int sigFigs = getSignificantFigures();

            if (sigFigs < index_list.Count && sigFigs != 0) {
                index_list.RemoveRange(sigFigs - 1, index_list.Count - sigFigs);
            }
            else if (sigFigs == 0) {
                index_list.Insert(0, 0);
                index_list.RemoveRange(1, index_list.Count - 1);
            }

            List<byte> list = index_list.ToList();
            list.Reverse();

            foreach (byte character in list) {
                output = output + character.ToString();
            }

            return output;
        }
        private usuperint() {
            // :]
        }
        private List<byte> incrementList(List<byte> list, int i, usuperint input) {
            input.sortForOutOfIndexRange(i);
            this.sortForOutOfIndexRange(i);
            sortForOutOfIndexRange(list, i);

            byte temp_select = (byte)(input.index_list[i] + index_list[i] + list[i]);
            swapListElement(list, i, temp_select);

            if (list[i] > 9) {
                return roundUp(i, list);
            }
            else {
                return list;
            }
        }
        private List<byte> decrementList(List<byte> list, int i, usuperint input) {
            input.sortForOutOfIndexRange(i);
            this.sortForOutOfIndexRange(i);
            sortForOutOfIndexRange(list, i);

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
                sortForOutOfIndexRange(list, i + 1);

                byte temp_upper = (byte)(list[i + 1] + Math.DivRem((int)list[i], 10, out int result));
                swapListElement(list, i + 1, temp_upper);

                byte temp_lower = (byte)(list[i] % 10);
                swapListElement(list, i, temp_lower);
            } catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return list;
        }
        private List<byte> roundDown(int i, List<byte> list, int value) {
            try {
                value = 10 + value;

            }
            catch (Exception e) {
                Console.WriteLine(e.ToString());
            }
            return list;
        }
        private int getSignificantFigures() {
            for (int i = index_list.Count - 1; i >= 0; i--) {
                if (index_list[i] != 0) {
                    return i + 1;
                }

            }
            return 0;
        }
        private void sortForOutOfIndexRange(int i) {
            if (index_list.Count <= i) {
                index_list.Add((byte)(0));
            }
        }
        private static void sortForOutOfIndexRange(List<byte> list, int i) {
            if (list.Count <= i) {
                list.Add((byte)(0));
            }
        }
        private static void swapListElement(List<byte> list, int i, byte value) {
            list.RemoveAt(i);
            list.Insert(i, value);
        }
    }
}
