/* 
 * Created by Cian McNamara, 2024.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpNumbers {
    public class usuperfloat {
        private usuperint num;
        private long floatingPointLocation = 1;

        /// <summary>
        /// Represents an infini-bit unsigned superinteger.
        /// </summary>
        /// <param name="number"></param>
        public usuperfloat(string number) {
            floatingPointLocation = GetDecimalLocationInString(number);
            num = new usuperint(RemoveDecimalFromString(number));
        }

        /// <summary>
        /// Represents an infini-bit unsigned superinteger.
        /// </summary>
        /// <param name="number"></param>
        public usuperfloat(double number) {
            floatingPointLocation = GetDecimalLocationInString(number.ToString());
            num = new usuperint(RemoveDecimalFromString(number.ToString()));
        }

        /// <summary>
        /// Represents an infini-bit unsigned superinteger.
        /// </summary>
        /// <param name="number"></param>
        public usuperfloat(usuperint number) {
            floatingPointLocation = 1;
            num = number;
        }

        /// <summary>
        /// Represents an infini-bit unsigned superinteger.
        /// </summary>
        /// <param name="number"></param>
        public usuperfloat(superint number) {
            floatingPointLocation = 1;
            num = new usuperint(number);
        }

        /// <summary>
        /// Returns the current location of the decimal point or 1 if one is not present.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private long GetDecimalLocationInString(string number) {
            int location = number.IndexOf('.');
            return location > 1 ? location : 1;
        }

        /// <summary>
        /// Removes the decimal point in a string.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string RemoveDecimalFromString(string number) {
            string[] split_number = number.Split('.');
            return split_number[0] + split_number[1];
        }
    }
}
