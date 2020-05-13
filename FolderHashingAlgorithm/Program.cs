using System;
using System.Collections.Generic;
using System.Text;

namespace FolderHashingAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "lorem ipsum dolor";

            int sum = GetHashedCodeWithAscii(password);
            int sum2 = GetHashedCodeWithFolds(password);
            //int[] hashCodes = new int[password.Length];
            Console.WriteLine(sum2);
        }

        private static int GetHashedCodeWithFolds(string password)
        {
            List<string> splitedTexts = new List<string>();
            for (int i = 0; i < password.Length; i++)
            {
                if (i % 4 == 0 && i + 4 < password.Length)
                {
                    splitedTexts.Add(password.Substring(i, 4));
                }
                else if (i % 4 == 0)
                {
                    splitedTexts.Add(password.Substring(i, password.Length - i));
                }
            }
            List<int> sums = new List<int>();
            foreach (var item in splitedTexts)
            {
                sums.Add(Convert.ToInt32(StringToBinary(ReverseString(item)), 2));
            }
            int sum = 0;
            foreach (var item in sums)
            {
                sum += item;
            }
            return sum;
        }
        public static string ReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            //Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        private static int GetHashedCodeWithAscii(string password)
        {
            int sum = 0;
            for (int i = 0; i < password.Length; i++)
            {
                sum += Convert.ToInt32(password[i]);
            }
            return sum;
        }
    }
}
