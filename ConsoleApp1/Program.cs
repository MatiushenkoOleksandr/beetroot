using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var enteredNumber1 = Convert.ToInt16(Console.ReadLine());
            var enteredNumber2 = Convert.ToInt16(Console.ReadLine());
            var enteredNumber3 = Convert.ToInt16(Console.ReadLine());
            var enteredNumber4 = Convert.ToInt16(Console.ReadLine());
            var result = Sum(enteredNumber1, enteredNumber2);
            var resultMax = Max(enteredNumber2, enteredNumber1);
            var resultMin = Min(enteredNumber1, enteredNumber2);

            var resultMax2 = Max(enteredNumber2, enteredNumber1, enteredNumber3, enteredNumber4);
            var resultMin2 = Min(enteredNumber2, enteredNumber1, enteredNumber3, enteredNumber4);

            Console.WriteLine("Sum from number1 to number 2 = ");
            Console.WriteLine(result);

            Console.WriteLine("Max from number 1 and number 2 = ");
            Console.WriteLine(resultMax);

            Console.WriteLine("Min from number 1 and number 2 = ");
            Console.WriteLine(resultMin);


            Console.WriteLine("Min from number 1, number 2, number 3, number 4   = ");
            Console.WriteLine(resultMin2);


            Console.WriteLine("Max from number 1, number 2, number 3, number 4   = ");
            Console.WriteLine(resultMax2);

            Console.WriteLine("enter text and count");
            var enteredText = Console.ReadLine();
            var enteredCount = Convert.ToInt16(Console.ReadLine());

            var resultRepeat = Repeat(enteredText, enteredCount);
            Console.WriteLine(resultRepeat);
            Console.ReadKey();
        }

        static int Sum(int from, int to)
        {
            bool fromTo = from > to;
            if (fromTo)
            {
                return Sum(to, from);
            }
            if (from == to)
            {
                return from;
            }
            return from + Sum(from + 1, to);
        }

        static int Max(int num1, int num2)
        {
            if (num1 > num2)
            {
                return num1;
            }
            else if (num1 < num2)
            {
                return num2;

            }
            else
            {
                return num1;
            }
        }

        static int Min(int num1, int num2)
        {
            if (num1 < num2)
            {
                return num1;
            }
            else if (num1 > num2)
            {
                return num2;

            }
            else
            {
                return num1;
            }
        }
        static bool TrySumIfOdd(int num1, int num2)
        {
            int sum = 0;
            if (num1 > num2)
            {
                var num3 = num1;
                num1 = num2;
                num2 = num3;
            }

            for (int i = num1; i <= num2; i++)
            {
                sum = sum + i;
            }
            bool isOdd = sum % 2 == 1;
            return isOdd;
        }
        static int Max(int num1, int num2, int num3, int num4)
        {
            int max = 0;
            if (max < num1)
            {
                max = num1;
            }
            if (max < num2)
            {
                max = num2;
            }
            if (max < num3)
            {
                max = num3;
            }
            if (max < num4)
            {
                max = num4;
            }
            return max;



        }
        static int Min(int num1, int num2, int num3, int num4)
        {
            int min = num1;
            if (min > num2)
            {
                min = num2;
            }
            if (min > num3)
            {
                min = num3;
            }
            if (min > num4)
            {
                min = num4;
            }
            return min;


        }
        static string Repeat(string text, int count)
        {
            string result = "";
            for(int i =0; i < count; i++)
            {
                result +=text;
            }
            return result;
        }

    }

}
