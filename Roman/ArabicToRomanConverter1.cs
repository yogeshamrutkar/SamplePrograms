using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    // This is better one in terms of performance
    // We can enhance for 4000, 5000 here
    internal class ArabicToRomanConverter1
    {
        readonly String[] basicRoman = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        readonly String[] tensRoman = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        readonly String[] hundredsRoman = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        readonly String[] thousandsRoman = { "", "M", "MM", "MMM" };
        
        public String ConvertArabicToRoman(int num)
        {
            try
            {
                string result = thousandsRoman[num / 1000] +
                                hundredsRoman[(num % 1000) / 100] +
                                tensRoman[(num % 100) / 10] +
                                basicRoman[num % 10];
                return result;
            }
            catch(Exception ex)
            {
                String exception = String.Format("Exception occur in ConvertArabicToRoman() => {0}", ex.ToString());
                Console.WriteLine(exception);
                return exception;
            }
        }
    }
}
