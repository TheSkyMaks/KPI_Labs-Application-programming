using System;

namespace _1._1._e_olymp_1080._Анаграмматическое_ра
{
    internal class Program
    {
        private static void Main()
        {
            int n = Convert.ToInt32(value: Console.ReadLine()) + 1;
            for (int i = 1; i < n; i++)
            {
                string word_1 = Console.ReadLine();
                string word_2 = Console.ReadLine();
                int matchingLetters = 0, length2 = word_2.Length;
                char[] ar_word_2 = word_2.ToCharArray();
                foreach (char v in word_1)
                {
                    for (int k = 0; k < length2; k++)
                    {
                        if (v == ar_word_2[k])
                        {
                            ar_word_2[k] = '#';
                            matchingLetters++;
                            break;
                        }
                    }
                }
                Console.WriteLine("Case #" + i + ":  " + (word_1.Length + length2 - 2 * matchingLetters));
            }
        }
    }
}