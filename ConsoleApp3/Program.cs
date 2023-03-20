using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var word1 = Console.ReadLine();
            var word2 = Console.ReadLine();
            var r = Compare(word1, word2);
            Console.WriteLine(r);
            int a;
            int b;
            int c;
            Analyze(word1, out a, out b, out c);
            Console.WriteLine($"numbers = {a}, letters = {b} others = {c}");


        }

        static bool Compare(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }

            return true;
        }

        static void Analyze(string str, out int numbers, out int letters, out int others)
        {
            numbers = 0;
            letters = 0;
            others = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    numbers++;
                }
                else if (char.IsLetter(str[i]))
                {
                    letters++;
                }
                else
                {
                    others++;
                }
            }

        }
        static string Sort(string str)
        {
            {
                char[] chars = str.ToCharArray();

                Array.Sort(chars, StringComparer.OrdinalIgnoreCase);

                str = new string(chars);
                return str;
            }
        }
        static char[] Duplicate(string str2)
        {
            
            char[] duplicate = new char[0];
            char[] seen = new char[str2.Length];
            int duplicateIndex = 0;
            int seenIndex = 0;

            foreach (char c in str2)
            {
                bool isDuplicate = false;
                for (int i = 0; i < seenIndex; i++)
                {
                    if (c == seen[i])
                    {
                        isDuplicate = true;
                        break;
                    }
                }

                if (isDuplicate)
                {
                    bool isAlreadyAdded = false;
                    for (int i = 0; i < duplicateIndex; i++)
                    {
                        if (c == duplicate[i])
                        {
                            isAlreadyAdded = true;
                            break;
                        }
                    }

                    if (!isAlreadyAdded) 
                    {
                        Array.Resize(ref duplicate, duplicate.Length + 1);
                        duplicate[duplicateIndex++] = c;
                    }
                }
                else
                {
                    seen[seenIndex++] = c;
                }
            }

          

            return duplicate;
        }

       
    }
}




