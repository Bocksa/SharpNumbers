using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    public class superint {
        private List<int> split_number = new List<int>();
        public bool IsNegative { get; set; }

        /// <summary>
        /// Represents an infini-bit signed superinteger.
        /// </summary>
        /// <param name="number"></param>
        public superint(long number) {
            string convertedNumber = number.ToString();
            IsNegative = convertedNumber.StartsWith("-");
            split_number = ConvertFromStringToIndexOrderList(convertedNumber);
        }

        /// <summary>
        /// Represents an infini-bit signed superinteger.
        /// </summary>
        /// <param name="number"></param>
        public superint(string number) {
            IsNegative = number.StartsWith("-");
            split_number = ConvertFromStringToIndexOrderList(number);
        }

        /// <summary>
        /// Represents an infini-bit signed superinteger.
        /// </summary>
        /// <param name="number"></param>
        public superint(usuperint number) {
            IsNegative = false;
            split_number = ConvertFromStringToIndexOrderList(number.ToString());
        }

        /// <summary>
        /// Represents an infini-bit signed superinteger.
        /// </summary>
        public superint() {
            /*
             * If for some reason the general public wants to create a blank superint, be my guest.
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

            if (IsNegative) {
                tempString = $"{tempString}-";
            }

            char[] charArray = tempString.ToCharArray();
            string output = string.Empty;

            for (int i = charArray.Length - 1; i >= 0; i--) {
                output = output + charArray[i];
            }

            if (output == string.Empty || output == "-") {
                output = "0";
            }

            return output;
        }

        /// <summary>
        /// Adds two usuperints together.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        public superint Add(superint n2) {
            superint temp = new superint();
            usuperint convertedThis = new usuperint(this);
            usuperint convertedN2 = new usuperint(n2);

            if (this.IsNegative && n2.IsNegative) {
                temp = new superint(convertedThis + convertedN2);
                temp.IsNegative = true;
            } else if (!this.IsNegative && !n2.IsNegative) {
                temp = new superint(convertedThis + convertedN2);
                temp.IsNegative = false;
            } else {
                if (convertedN2 > convertedThis && n2.IsNegative) {
                    temp = new superint(convertedN2 - convertedThis);
                    temp.IsNegative = true;
                } else if (convertedN2 > convertedThis && !n2.IsNegative) {
                    temp = new superint(convertedN2 - convertedThis);
                    temp.IsNegative = false;
                } else if (convertedThis > convertedN2 && n2.IsNegative) {
                    temp = new superint(convertedThis - convertedN2);
                    temp.IsNegative = false;
                } else {
                    temp = new superint(convertedThis - convertedN2);
                    temp.IsNegative = true;
                }
            }

            temp.Clean();

            return temp;
        }

        /// <summary>
        /// Subtracts two usuperints from eachother.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public superint Sub(superint n2) {
            superint temp = new superint();

            if (this < n2) {
                throw new ArgumentException($"LHS is less than RHS", nameof(n2));
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
        /// Multiplies two usuperints.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        public superint Mult(superint n2) {
            superint temp = new superint();

            if (split_number.Count >= n2.split_number.Count) {
                for (int offset = 0; offset < split_number.Count; offset++) {
                    superint subtemp = new superint();

                    for (int i = 0; i < n2.split_number.Count; i++) {
                        int selection_a = split_number[offset];
                        int selection_b = n2.split_number[i];
                        subtemp.InsertAtLocation(i + offset, selection_a * selection_b);
                    }

                    subtemp.Clean();
                    temp = temp + subtemp;
                }
            } else {
                for (int offset = 0; offset < n2.split_number.Count; offset++) {
                    superint subtemp = new superint();
                    subtemp.split_number.DefaultIfEmpty(0);

                    for (int i = 0; i < split_number.Count; i++) {
                        int selection_a = n2.split_number[offset];
                        int selection_b = split_number[i];
                        subtemp.InsertAtLocation(i + offset, selection_a * selection_b);
                    }

                    subtemp.Clean();
                    temp = temp + subtemp;
                }
            }

            temp.Clean();

            if (n2.IsNegative && !IsNegative) {
                temp.IsNegative = true;
            } else if (!n2.IsNegative && IsNegative) {
                temp.IsNegative = true;
            } else {
                temp.IsNegative = false;
            }

            return temp;
        }

        /// <summary>
        /// Divides two usuperints.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        public superint Div(superint n2) {
            superint temp = this;
            superint counter = 0;

            if (n2 == 0) {
                throw new DivideByZeroException();
            }

            while (temp >= n2) {
                counter = counter + 1;
                if (counter == 1) {
                    temp = this - n2;
                } else {
                    temp = temp - n2;
                }
            }

            if (n2.IsNegative && !IsNegative) {
                temp.IsNegative = true;
            } else if (!n2.IsNegative && IsNegative) {
                temp.IsNegative = true;
            } else {
                temp.IsNegative = false;
            }

            if (temp.IsNegative) {
                counter.IsNegative = true;
            }

            return counter;
        }

        /// <summary>
        /// Returns the modulo of two usuperints.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        public superint Mod(superint n2) {
            superint temp = this;

            while (temp > n2) {
                temp = temp - n2;
            }

            temp.Clean();
            return temp;
        }

        /// <summary>
        /// Conducts a leftward (additive) decimal shift.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public superint ShiftLeft(long n) {
            superint temp = new superint();
            temp.split_number = split_number;

            if (n < 0) {
                ShiftRight(n * -1);
            }

            for (int i = temp.split_number.Count - 1; i >= 0; i--) {
                try {
                    int currentEntry = temp.split_number[i];
                    InsertAtLocation((int)(i + n), currentEntry);
                    temp.split_number[i] = 0;
                } catch (Exception e) {
                    throw (e);
                }
            }

            return temp;
        }

        /// <summary>
        /// Conducts a rightward (subtractive) decimal shift.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public superint ShiftRight(long n) {
            superint temp = new superint();
            temp.split_number = split_number;

            if (n < 0) {
                ShiftLeft(n * -1);
            }

            for (int i = 0; i < temp.split_number.Count; i++) {
                try {
                    temp.split_number[(int)(i - n)] = temp.split_number[i];
                    temp.split_number[i] = 0;
                } catch { }
            }

            return temp;
        }

        /// <summary>
        /// Checks if the current usuperint is greater than the input usuperint.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        public bool IsGreaterThan(superint n2) {
            if (n2.split_number.Count == split_number.Count) {
                for (int i = split_number.Count - 1; i >= 0; i--) {
                    if (split_number[i] > n2.split_number[i]) {
                        break;
                    } else {
                        return false;
                    }
                }
                return true;
            } else if (n2.split_number.Count < split_number.Count) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// Checks if the current usuperint is less than the input usuperint.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        public bool IsLessThan(superint n2) {
            if (n2.split_number.Count == split_number.Count) {
                for (int i = split_number.Count - 1; i >= 0; i--) {
                    if (split_number[i] < n2.split_number[i]) {
                        return true;
                    }
                }
                return false;
            } else if (n2.split_number.Count < split_number.Count) {
                return false;
            } else {
                return true;
            }
        }

        /// <summary>
        /// Checks if both usuperints are equal.
        /// </summary>
        /// <param name="n2"></param>
        /// <returns></returns>
        public bool IsEqualTo(superint n2) {
            if (n2.split_number.Count == split_number.Count) {
                for (int i = 0; i < split_number.Count; i++) {
                    if (split_number[i] != n2.split_number[i]) {
                        return false;
                    }
                }
            } else {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Loops through a string from last to first character and inserts the characters as integers into a list.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private List<int> ConvertFromStringToIndexOrderList(string number) {
            var temporaryList = new List<int>();
            if (IsNegative) {
                for (int i = number.Length - 1; i >= 1; i--) {
                    temporaryList.Add(int.Parse(number[i].ToString()));
                }
            } else {
                for (int i = number.Length - 1; i >= 0; i--) {
                    temporaryList.Add(int.Parse(number[i].ToString()));
                }
            }

            return temporaryList;
        }

        /// <summary>
        /// Puts split_number in the correct format if it is out of format.
        /// </summary>
        private void Clean() {
            if (split_number.Count != 0) {
                for (int i = 0; i < split_number.Count; i++) {
                    int currentEntry = split_number[i];
                    if (currentEntry < 0) {
                        BorrowFromHigherIndex(currentEntry, i);
                    } else if (currentEntry > 9) {
                        PassToHigherIndex(currentEntry, i);
                    }
                }
                if (!IsFormattedCorrectly()) {
                    Clean();
                }
                if (HasLeadingZeros()) {
                    RemoveLeadingZeros();
                }
            }
        }

        /// <summary>
        /// Increments the current index and puts the correct value into the upper index in split_number.
        /// </summary>
        /// <param name="currentEntry"></param>
        /// <param name="i"></param>
        private void PassToHigherIndex(int currentEntry, int i) {
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
        private void BorrowFromHigherIndex(int currentEntry, int i) {
            split_number[i] = 10 + currentEntry;
            split_number[i + 1] = split_number[i + 1] - 1;
        }

        /// <summary>
        /// Checks if the formatting is correct on split_number.
        /// </summary>
        /// <returns></returns>
        private bool IsFormattedCorrectly() {
            for (int i = 0; i < split_number.Count; i++) {
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
            if (split_number.Count == 0) {
                return false;
            }

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
            for (int i = split_number.Count - 1; i > 0; i--) {
                if (split_number[i] == 0) {
                    split_number.RemoveAt(i);
                } else {
                    break;
                }
            }
        }

        /// <summary>
        /// Inserts a given input to a potentially out of range location in a list.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="input"></param>
        private void InsertAtLocation(int location, int input) {
            if (split_number.Count <= location) {
                for (int i = split_number.Count; i < location; i++) {
                    split_number.Add(0);
                }
                split_number.Add(input);
            } else {
                split_number[location] = input;
            }
        }

        public static implicit operator superint(long number) {
            return new superint(number);
        }
        public static implicit operator superint(string number) { 
            return new superint(number);
        }
        public static superint operator +(superint lhs, superint rhs) {
            return lhs.Add(rhs);
        }
        public static superint operator -(superint lhs, superint rhs) {
            return lhs.Sub(rhs);
        }
        public static superint operator *(superint lhs, superint rhs) {
            return lhs.Mult(rhs);
        }
        public static superint operator /(superint lhs, superint rhs) {
            return lhs.Div(rhs);
        }
        public static   superint operator %(superint lhs, superint rhs) {
            return lhs.Mod(rhs);
        }
        public static superint operator +(superint number) {
            return number + 1;
        }
        public static superint operator --(superint number) {
            return number - 1;
        }
        /*public static usuperint operator >>(usuperint lhs, uint rhs) {
            return lhs.ShiftRight(rhs);
        }
        public static usuperint operator <<(usuperint lhs, uint rhs) {
            return lhs.ShiftLeft(rhs);
        }*/
        public static bool operator ==(superint lhs, superint rhs) {
            return lhs.IsEqualTo(rhs);
        }
        public static bool operator !=(superint lhs, superint rhs) {
            return !lhs.IsEqualTo(rhs);
        }
        public static bool operator >(superint lhs, superint rhs) {
            return lhs.IsGreaterThan(rhs);
        }
        public static bool operator <(superint lhs, superint rhs) {
            return lhs.IsLessThan(rhs);
        }
        public static bool operator >=(superint lhs, superint rhs) {
            if (lhs > rhs || lhs == rhs) {
                return true;
            } else {
                return false;
            }
        }
        public static bool operator <=(superint lhs, superint rhs) {
            if (lhs < rhs || lhs == rhs) {
                return true;
            } else {
                return false;
            }
        }
    }
}
