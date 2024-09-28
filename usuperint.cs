/* 
 * Created by Cian McNamara, 2024.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SharpNumbers {
    class usuperint {
        private List<int> split_number = new List<int>();

        /// <summary>
        /// Represents an infini-bit unsigned superinteger.
        /// </summary>
        /// <param name="number"></param>
        public usuperint(string number) {
            split_number = ConvertFromStringToIndexOrderList(number);
        }

        /// <summary>
        /// Represents an infini-bit unsigned superinteger.
        /// </summary>
        /// <param name="number"></param>
        public usuperint(long number) {
            split_number = ConvertFromStringToIndexOrderList(number.ToString());
        }

        private usuperint() {
            /*
             * This is not public because I don't see a reason why anyone might need it.
             * This is used for creating temporary usuperints for math operations.
             */
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            string tempString = string.Empty;

            if (HasLeadingZeros()) {
                RemoveLeadingZeros();
            }

            for (int i = 0; i < split_number.Count; i++) {
                tempString = $"{tempString}{split_number[i]}";
            }

            char[] charArray = tempString.ToCharArray();
            string output = string.Empty;

            for (int i = charArray.Length - 1; i > -1; i--) {
                output = output + charArray[i];
            }

            return output;
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
        /// Loops through every index of both numbers and subtracts the two corresponding index's.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        /// <exception cref="OverflowException"></exception>
        public usuperint Sub(usuperint n2) {
            usuperint temp = new usuperint();

            if (!IsInputValidForSubtraction(n2)) {
                throw new OverflowException();
            }
            
            for (int i = 0; i < split_number.Count; i++) {
                if (i < n2.split_number.Count) {
                    temp.split_number.Add(split_number[i] - n2.split_number[i]);
                } else {
                    temp.split_number.Add(split_number[i]);
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
            var temporaryList = new List<int>();
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
                    DecrementIndex(currentEntry, i);
                } else if (currentEntry > 9) {
                    IncrementIndex(currentEntry, i);
                }
            }
            if (!IsFormattedCorrectly()) {
                Clean();
            }
            if (HasLeadingZeros()) {
                RemoveLeadingZeros();
            }
        }

        /// <summary>
        /// Increments the current index and puts the correct value into the upper index in split_number.
        /// </summary>
        /// <param name="currentEntry"></param>
        /// <param name="i"></param>
        private void IncrementIndex(int currentEntry, int i) {
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

        /// <summary>
        /// Decrements the current index and puts the correct value into the lower index in split_number.
        /// </summary>
        /// <param name="currentEntry"></param>
        /// <param name="i"></param>
        private void DecrementIndex(int currentEntry, int i) {
            int lowerEntry = split_number[i - 1];
            int subNumber = 10 - currentEntry;
            split_number[i] = 0;
            split_number[i - 1] = lowerEntry - subNumber;
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

        /// <summary>
        /// Checks if split_number has leading zeros.
        /// </summary>
        /// <returns></returns>
        private bool HasLeadingZeros() {
            if (split_number[split_number.Count - 1] == 0) {
                return true;
            } else {
                return false;
            }
        }
        
        /// <summary>
        /// Removes the leading zeros in split_number.
        /// </summary>
        private void RemoveLeadingZeros() {
            for (int i = split_number.Count - 1; i >= 0 ; i--) {
                if (split_number[i] == 0) {
                    split_number.RemoveAt(i);
                } else {
                    break;
                }
            }
        }

        /// <summary>
        /// Checks if the input usuperint is greater than the current usuperint.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsInputValidForSubtraction(usuperint input) {
            if (input.split_number.Count == split_number.Count) {
                for (int i = split_number.Count - 1; i >= 0 ; i--) {
                    if (split_number[i] < input.split_number[i]) {
                        return false;
                    }
                }
            } else if (input.split_number.Count  > split_number.Count) {
                return false;
            }

            return true;
        }
    }
}