using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    class usuperint {
        private List<int> split_number = new List<int>();
        public usuperint(string number) {
            split_number = ConvertFromStringToIndexOrderList(number);
        }
        public usuperint(long number) {
            split_number = ConvertFromStringToIndexOrderList(number.ToString());
        }
        private usuperint() {
            /*
             * This is not public because I don't see a reason why anyone might need it.
             * This is purely used for creating temporary usuperints for math operations.
             */
        }
        public usuperint Add(usuperint n2) {
            usuperint temp = new usuperint();
            if (split_number.Count > n2.split_number.Count) {
                for (int i = 0; i < split_number.Count; i++) {
                    if (i < n2.split_number.Count) {
                        temp.split_number.Add(n2.split_number[i] + split_number[i]);
                    } else {
                        temp.split_number.Add(split_number[i]);
                    }
                }
            } else {
                for (int i = 0; i < n2.split_number.Count; i++) {
                    if (i < split_number.Count) {
                        temp.split_number.Add(n2.split_number[i] + split_number[i]);
                    } else {
                        temp.split_number.Add(n2.split_number[i]);
                    }
                }
            }

            temp.Clean();

            return temp;
        }

        private List<int> ConvertFromStringToIndexOrderList(string number) {
            /*
             * Loops through a string from last to first character and inserts the characters as integers into a list.
             */
            List<int> temporaryList = new List<int>();
            for (int i = number.Length - 1; i >= 0; i--) {
                temporaryList.Add(int.Parse(number[i].ToString()));
            }
            return temporaryList;
        }
        /* 
         * Before writing this only god knew the horrors that would come from this.
         * Soon only god will know the journey I went on by writing this.
         */
        private void Clean() {

        }
    }
}