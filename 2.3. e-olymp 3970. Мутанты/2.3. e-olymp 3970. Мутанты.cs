/* Мутанты
 * 
 * Уже долгое время в Институте Искусств, Мутантов и Информационных Технологий разводят милых разноцветных зверюшек.
 * Для удобства каждый цвет обозначен своим номером, всего цветов не более 109. В один из прекрасных дней в питомнике случилось чудо:
 * все зверюшки выстроились в ряд в порядке возрастания цветов. Пользуясь случаем, лаборанты решили посчитать, 
 * сколько зверюшек разных цветов живёт в питомнике, и, по закону жанра, попросили вас написать программу, 
 * которая поможет им в решении этой нелёгкой задачи.
 * 
 * Входные данные
 * 
 * В первой строке входного файла содержится единственное число N (0 ≤ N ≤ 105) - количество зверюшек в Институте.
 * В следующей строке находится N упорядоченных по неубыванию неотрицательных целых чисел, не превосходящих 109 и разделённых пробелами - их цвета.
 * В третьей строке файла записано число M (1 ≤ M ≤ 100000) - количество запросов вашей программе,
 * в следующей строке через пробел записаны M целых неотрицательных чисел (не превышающих 109+1).
 * 
 * Выходные данные
 * 
 * Выходной файл должен содержать M строчек. Для каждого запроса выведите число зверюшек заданного цвета в питомнике.
 */
using System;
namespace _2._3._e_olymp_3970._Мутанты
{
    class Program //by TheSkyMaks
    {
        static int Binary_Search_Left(int[] arr, int left, int right, int key)
        {// Функція для пошуку числа зліва
            int mid;
            while (left < right)//цикл, який викон. при left < right
            {// O (log(animal_count))
                mid = (left + right) / 2;
                if (key <= arr[mid])//якщо requested_color[i] <= animal_color[mid], то
                    right = mid;    // <-
                else                //інакше
                    left = mid + 1; // <-
            }
            return left;// повернення left
        }
        static int Binary_Search_Right(int[] arr, int left, int right, int key)
        {// Функція для пошуку числа справа
            int mid;
            while (left < right)//цикл, який викон. при left < right
            {// O (log(animal_count))
                mid = (left + right) / 2;
                if (key >= arr[mid])//якщо requested_color[i] >= animal_color[mid], то 
                    left = mid + 1; // <-
                else                //інакше
                    right = mid;    // <-
            }
            return right;// повернення right
        }
        static void Main()
        {
            int animal_count = int.Parse(Console.ReadLine());     //N (0 ≤ N ≤ 105) - количество зверюшек в Институте
            string[] splitString = Console.ReadLine().Split(' '); // их цвета 
            int[] animal_color = new int[animal_count]; //масив кольорів звірів
            for (int i = 0; i < animal_count; ++i) //цикл від i = 0 до i < animal_count, з кроком 1
                int.TryParse(splitString[i], out animal_color[i]); //Спроба отримання animal_color[i] з splitString[i]
            int request_count = int.Parse(Console.ReadLine());   //M (1 ≤ M ≤ 100000) - количество запросов вашей программе
            splitString = Console.ReadLine().Split(' ');         //M целых неотрицательных чисел (не превышающих 109+1)
            int[] requested_color = new int[request_count];//масив чисел М
            for (int i = 0; i < request_count; ++i)//цикл від i = 0 до i < request_count, з кроком 1 
            {   // O(request_count)
                int.TryParse(splitString[i], out requested_color[i]);//Спроба отримання requested_color[i] з splitString[i]
                int left = Binary_Search_Left(animal_color, 0, animal_count, requested_color[i]);  // звернення до функцій,з
                int right = Binary_Search_Right(animal_color, 0, animal_count, requested_color[i]);//  певними параметрами
                Console.WriteLine(right - left);//Результат програми
            }
        } // O(request_count x 2 x log(animal_count)) - загальний час при найгіршому виконанні програми
    }
}