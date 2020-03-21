/* Делимость
Имеется набор целых чисел a1, a2, ..., an. Найти количество чисел от l до r включительно,
которые делятся хотя бы на одно число из этого набора.
Входные данные:
Состоит из нескольких тестов. Первая строка каждого теста содержит два целых числа l (1 ≤ l ≤ 109) и r (1 ≤ r ≤ 109).
Следующая строка содержит количество элементов n (1 ≤ n ≤ 18) в наборе и сам набор этих чисел.
Каждое число в наборе принимает значение от 1 до 109.
Выходные данные:
Для каждого теста в отдельной строке вывести количество чисел от l до r включительно,
которые делятся хотя бы на одно из чисел из набора a1, a2, ..., an.
 */

using System;

namespace _5._3._e_olymp_1534._Делимость //by TheSkyMaks
{
    internal class Program
    {
        private static void Main()
        {
            while (true)
            {
                string[] splitString = Console.ReadLine().Split(' ');
                if (!int.TryParse(splitString[0], out int leftSide))
                {
                    break;
                }
                int.TryParse(splitString[1], out int rightSide);
                string[] sDivisors = Console.ReadLine().Split(' ');
                int[] divisors = new int[20];
                int amountOfDivisor = sDivisors.Length;
                for (int i = 0; i < amountOfDivisor; ++i)
                {//O(amountOfDivisor)
                    int.TryParse(sDivisors[i], out divisors[i]);
                }
                double result = Algorithm(rightSide, divisors, amountOfDivisor) - Algorithm(leftSide - 1, divisors, amountOfDivisor);
                Console.WriteLine(result);
            }
        }

        private static long TheGreatestCommonDivisor(long a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            return TheGreatestCommonDivisor(b, Convert.ToInt32(a % b));
        }

        private static long Algorithm(int chyslo, int[] divide, int amountOfDivisor)
        {
            long GCD, result = 0;
            for (int i = 1; i < Math.Pow(2, amountOfDivisor); ++i) //1 << amount_of_divisor
            {//O(2^amountOfDivisor)
                long theGreatestCommonFactor = 1;
                int bits = 0;
                for (int j = 0; j < amountOfDivisor; ++j)
                {//O(amountOfDivisor)
                    if ((i & (1 << j)) != 0)
                    {// checks if the j - th bit of counter is set. In more detail, 1 << j uses shifting of 1 to generate a bit mask
                     //in which only the j-th bit is set.The & operator then masks out the j-bit of counter;
                     //if the result is not zero (which means that the j-th bit of counter was set), the condition is satisfied.
                        bits++;
                        GCD = TheGreatestCommonDivisor(theGreatestCommonFactor, divide[j]);
                        theGreatestCommonFactor = theGreatestCommonFactor / GCD * divide[j];
                        if (theGreatestCommonFactor > chyslo)
                        {
                            break;
                        }
                    }
                }
                if (bits % 2 != 0)
                {
                    result += chyslo / theGreatestCommonFactor;
                }
                else
                {
                    result -= chyslo / theGreatestCommonFactor;
                }
            }
            return result;
        }
    }//O(amountOfDivisor^2 x 2^amountOfDivisor)
}