using System;
using System.Data;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Calculate_Test
{
    internal class Program
    {
        //private string pattern = @"[0-9+*/()-]";

        private static void Main(string[] args)
        {
            Console.WriteLine("Example : 23+2");

            do
            {
                Console.Write("Input : ");
                var inputData = Console.ReadLine();

                if (string.IsNullOrEmpty(inputData))
                {
                    Console.WriteLine("Please input..");
                    continue;
                }
                if (!IsValidNumericOperation(inputData))
                {
                    Console.WriteLine("Is not valid please try again..");
                    continue;
                }
                DataTable dt = new DataTable();
                var v = dt.Compute(inputData, string.Empty);

                Console.WriteLine("Answer : " + v.ToString());
            } while (true);
        }

        public static bool IsValidNumericOperation(string currencyValue)
        {
            string pattern = @"[0-9(+*/)-]+\b[0-9()]";
            Regex currencyRegex = new Regex(pattern);
            return currencyRegex.IsMatch(currencyValue);
        }
    }
}