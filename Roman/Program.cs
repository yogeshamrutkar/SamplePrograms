using Roman;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        ArabicToRomanConverter2 obj2 = new ArabicToRomanConverter2();
        ArabicToRomanConverter1 obj1 = new ArabicToRomanConverter1();
        obj2.LoadArabicToRomanMapping();

        Console.WriteLine("Please Enter Arabic Number Between 1 to 3999\nOther Number To Exit");
        string? input = Console.ReadLine();
        bool isNumberInput = int.TryParse(input, out int num);
        if (!isNumberInput || num == 0 || num > 3999)
        {
            Console.WriteLine("Invalid Input, Program terminted ...");
        }
        while (isNumberInput && num > 0)
        {
            if (num == 0 || num > 3999) 
                break;

            string romanResult = obj1.ConvertArabicToRoman(num);
            Console.WriteLine("Result1 without Loop => {0}", romanResult);

            romanResult = obj2.ConvertArabicNumberToRoman(num);
            Console.WriteLine("Result2 with Loop => {0}\n", romanResult);

            input = Console.ReadLine();
            isNumberInput = int.TryParse(input, out int num1);
            if (!isNumberInput || num1 == 0 || num1 > 3999)
            {
                Console.WriteLine("Invalid Input, Program terminted ...");
            }
            num = num1;
        }
        Console.ReadLine();
    }
}