using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roman
{
    internal class ArabicToRomanConverter2
    {
        Dictionary<string, int> romanNumbersDictionary;
        public ArabicToRomanConverter2()
        {
            romanNumbersDictionary = new Dictionary<string, int>();
        }

        public void LoadArabicToRomanMapping()
        {
            //Loading the Mapping into Dictionary
            romanNumbersDictionary.Add("I", 1);
            romanNumbersDictionary.Add("IV", 4);
            romanNumbersDictionary.Add("V", 5);
            romanNumbersDictionary.Add("IX", 9);
            romanNumbersDictionary.Add("X", 10);
            romanNumbersDictionary.Add("XL",40);
            romanNumbersDictionary.Add("L", 50);
            romanNumbersDictionary.Add("XC",90);
            romanNumbersDictionary.Add("C" ,100);
            romanNumbersDictionary.Add("CD",400);
            romanNumbersDictionary.Add("D",500);
            romanNumbersDictionary.Add("CM",900);
            romanNumbersDictionary.Add("M",1000);
        }
            
        public string ConvertArabicNumberToRoman(int ArabicNumber)
        {
            try
            {
                string RomanNumber = string.Empty;
                foreach (var item in romanNumbersDictionary.Reverse()) //Loop through 13 times
                {
                    if (ArabicNumber <= 0)
                        break;
                    //Will loop through until number is bigger than Dictionary Number
                    while (ArabicNumber >= item.Value)
                    {
                        RomanNumber += item.Key;
                        ArabicNumber -= item.Value;
                    }
                }
                return RomanNumber;
            }
            catch (Exception ex)
            {
                String exception = String.Format("Exception occur in ConvertArabicNumberToRoman() => {0}", ex.ToString());
                Console.WriteLine(exception);
                return exception;
            }
        }
    }
}
