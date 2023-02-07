using Roman;

internal class Program
{
    private static void Main(string[] args)
    {
        ArabicToRomanConverter1 obj1 = new ArabicToRomanConverter1();
        ArabicToRomanConverter2 obj2 = new ArabicToRomanConverter2();
        obj2.LoadArabicToRomanMapping();
        //Have restrictions upto 3999 because from 4000 it has special chars
        Console.WriteLine("Please Enter Arabic Number Between 1 to 3999\nOther Number To Exit");
        string? input = Console.ReadLine();
        bool isNumberInput = int.TryParse(input, out int inputNumber);
        if (!isNumberInput || inputNumber == 0 || inputNumber > 3999)
        {
            Console.WriteLine("Invalid Input, Program terminted ...");
        }
        while (isNumberInput && inputNumber > 0)
        {
            if (inputNumber == 0 || inputNumber > 3999) 
                break; 

            string romanResult = obj1.ConvertArabicToRoman(inputNumber);
            Console.WriteLine("Result1 without Loop => {0}", romanResult);

            romanResult = obj2.ConvertArabicNumberToRoman(inputNumber);
            Console.WriteLine("Result2 with Loop => {0}\n", romanResult);

            input = Console.ReadLine();
            isNumberInput = int.TryParse(input, out int inputNumber1);
            if (!isNumberInput || inputNumber1 == 0 || inputNumber1 > 3999)
            {
                Console.WriteLine("Invalid Input, Program terminted ...");
            }
            inputNumber = inputNumber1;
        }
        Console.ReadLine();
    }
}