using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ArabicToRomanConverter
{
    public static class RomanConverter
    {
        readonly static String[] basicRoman = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        readonly static String[] tensRoman = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        readonly static String[] hundredsRoman = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        readonly static String[] thousandsRoman = { "", "M", "MM", "MMM" };

        [FunctionName("ArabicToRomanConverter")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string sResult = string.Empty;
            string sArabicNumber = req.Query["number"];
            if (string.IsNullOrEmpty(sArabicNumber))
            {
                sResult = string.Format("Invalid Input {0}, Please Provide Arabic Number as input", sArabicNumber);
                log.LogInformation(sResult);
                return new OkObjectResult(sResult);
            }
            if(!int.TryParse(sArabicNumber, out int num))
            {
                sResult = string.Format("Invalid Input {0}, Please Provide Valid Input", sArabicNumber);
                log.LogInformation(sResult);
                return new OkObjectResult(sResult);
            }

            if (num <= 0 || num > 3999)
            {
                sResult = string.Format("Invalid Input {0}, Please Provide Number in Between 1 to 3999", sArabicNumber);
                log.LogInformation(sResult);
                return new OkObjectResult(sResult);
            }
            string romanNumber = await NumberConverter(num);
            sResult = string.Format("Arabic Input Number = {0} and Converted Roman Number is = {1}", sArabicNumber, romanNumber); 
            return new OkObjectResult(sResult);
        }

        public static Task<string> NumberConverter(int romanNumber)
        {
            string result = thousandsRoman[romanNumber / 1000] +
                                hundredsRoman[(romanNumber % 1000) / 100] +
                                tensRoman[(romanNumber % 100) / 10] +
                                basicRoman[romanNumber % 10];

            return Task.FromResult(result);
        }
    }
}
