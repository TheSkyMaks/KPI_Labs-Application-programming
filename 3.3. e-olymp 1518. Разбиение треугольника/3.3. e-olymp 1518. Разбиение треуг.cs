/*Разбиение треугольника
Треугольник можно разбить на два треугольника, проведя медиану к его большей стороне (на рисунке сверху такое разбиение показано красным разрезом).
Затем два меньших треугольника можно подобным образом разделить на четыре треугольника (на рисунке такое разбиение показано синими разрезами).
Процесс разрезания треугольников будем продолжать до бесконечности.
Математики заметили, что при описанном разрезании мы получим конечное количество "стилей" треугольников, которые отличаются друг от друга только
размером. По заданным длинам сторон исходного треугольника необходимо определить количество стилей треугольников, которое можно получить.
Два треугольника принадлежат одному стилю, если они подобны.
Входные данные
Первая строка содержит количество тестов n (0 < n < 35). Каждая следующая строка содержит три целых числа
a, b, c (0 < a, b, c < 100) - стороны треугольника. Известно, что площадь каждого входного треугольника положительна.
Выходные данные
Для каждого теста в отдельной строке вывести его номер как показано в примере и целое число t - количество разных стилей треугольников,
которое получится в процессе указанного деления. Считать, что значение t всегда меньше 100.
 */

using System;

namespace _3._3._e_olymp_1518._Разбиение_треугольника //by TheSkyMaks
{
    internal class Program
    {
        private static int styles_count;

        private static void Main()
        {
            int.TryParse(Console.ReadLine(), out int request_count);
            for (int i = 0; i < request_count; ++i)
            { //O(request_count)
                styles_count = 0;
                string[] splitString = Console.ReadLine().Split(' ');
                double.TryParse(splitString[0], out double a);
                double.TryParse(splitString[1], out double b);
                double.TryParse(splitString[2], out double c);
                double[] ac = new double[100]; //Трикутник зі сторонами a,b і c однозначно задається
                double[] bc = new double[100]; //двома величинами: відношеннями a/c i b/c
                Find_styles_count(a, b, c, ac, bc);
                Console.WriteLine("Triangle " + (i + 1) + ": " + styles_count);
            }
        }

        private static void Find_styles_count(double a, double b, double c, double[] ac, double[] bc)
        {
            double[] side = new double[3] { a, b, c };
            Array.Sort(side);
            const double e = 0.00001; //Задамо точність, з якою будуть порівнюватися сторони трикутників
            for (int i = 0; i < styles_count; ++i) //Перевіримо, чи стиль даного трикутника зустрічається вперше.
            {//O(styles_count)                     //Якщо ні, то подальші розрізи не дадуть нових стилів
                if ((Math.Abs(side[0] / side[2] - ac[i]) < e) && (Math.Abs(side[1] / side[2] - bc[i]) < e))
                {
                    return;
                }
            }
            ac[styles_count] = side[0] / side[2]; //Запам'ятовуємо значення ідентифікаторів нового стилю трикутника
            bc[styles_count] = side[1] / side[2];
            styles_count++;
            //Ділимо трикутник медіаною та визначаємо їх стилі
            double mediana = Math.Sqrt((2 * side[0] * side[0]) + (2 * side[1] * side[1]) - (side[2] * side[2])) / 2;
            Find_styles_count(side[0], mediana, side[2] / 2, ac, bc);
            Find_styles_count(side[1], mediana, side[2] / 2, ac, bc);
        }
    }
}