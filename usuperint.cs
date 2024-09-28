﻿using System;
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

        /// <summary>
        /// Loops through every index of both numbers and adds the two corresponding index's together.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Loops through a string from last to first character and inserts the characters as integers into a list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private List<int> ConvertFromStringToIndexOrderList(string number) {

            List<int> temporaryList = new List<int>();
            for (int i = number.Length - 1; i >= 0; i--) {
                temporaryList.Add(int.Parse(number[i].ToString()));
            }
            return temporaryList;
        }
        
        /// <summary>
        /// Puts split_number in the correct format if it is out of format.
        /// </summary>
        private void Clean() {
            for (int i = 0; i < split_number.Count  ; i++) {
                int currentEntry = split_number[i];
                if (currentEntry < 0) {
                    int lowerEntry = split_number[i - 1];
                    int subNumber = 10 - currentEntry;
                    split_number[i] = 0;
                    split_number[i - 1] = lowerEntry - subNumber;
                } else if (currentEntry > 9) {
                    int upperNumber = currentEntry / 10;
                    if (split_number.Count - 1 > i) {
                        int upperEntry = split_number[i + 1];
                        split_number[i] = currentEntry % 10;
                        split_number[i + 1] = upperEntry + upperNumber;
                    } else {
                        split_number[i] = currentEntry % 10;
                        split_number.Add(upperNumber);
                    }
                }
            }
            if (!IsFormattedCorrectly()) {
                Clean();
            }
        }

        /// <summary>
        /// Checks if the formatting is correct on split_number.
        /// </summary>
        /// <returns></returns>
        private bool IsFormattedCorrectly() {
            for (int i = 0; i < split_number.Count ; i++) {
                if (split_number[i] > 9 || split_number[i] < 0) {
                    return false;
                }
            }
            return true;
        }
    }
}