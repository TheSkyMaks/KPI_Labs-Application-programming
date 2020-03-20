/* Пересечение отрезков - 2
На декартовой плоскости задано n отрезков координатами своих концов. Определить, пересекаются ли они. Множество отрезков пересекается, 
если среди них существует хотя бы два, которые имеют как минимум одну общую точку.
Входные данные
Каждая строка содержит целочисленные координаты концов отрезка (x1[i], y1[i]) - (x2[i], y2[i]). 
Известно, что n ≤ 6*105и -2000 ≤ x1[i], y1[i], x2[i], y2[i] ≤ 2000.
Выходные данные
Вывести "intersect" если отрезки пересекаются и "NOT intersect" иначе.
 */
using System;

namespace _6._3._e_olymp_1505._Пересечение_отрезков___2 //by TheSkyMaks
{
    class Program
    {
        static void Main()
        {
            int[] x1 = new int[20];
            int[] y1 = new int[20];
            int[] x2 = new int[20];
            int[] y2 = new int[20];

            for (int i = 0; i < 20; i++)
            {//O(20)
                string[] splitString = Console.ReadLine().Split(' ');//отрезок                
                if (!int.TryParse(splitString[0], out x1[i]))
                {
                    break;
                }
                int.TryParse(splitString[1], out y1[i]);
                int.TryParse(splitString[2], out x2[i]);
                int.TryParse(splitString[3], out y2[i]);
                for (int j = 0; j < i; j++)
                {//0(i)

                    int A1 = y2[i] - y1[i];
                    int B1 = x1[i] - x2[i];
                    int C1 = (-A1 * x1[i]) - (B1 * y1[i]);

                    int A2 = y2[j] - y1[j];
                    int B2 = x1[j] - x2[j];
                    int C2 = (-A2 * x1[j]) - (B2 * y1[j]);

                    int f1 = (A1 * x1[j]) + (B1 * y1[j]) + C1;
                    int f2 = (A1 * x2[j]) + (B1 * y2[j]) + C1;
                    int f3 = (A2 * x1[i]) + (B2 * y1[i]) + C2;
                    int f4 = (A2 * x2[i]) + (B2 * y2[i]) + C2;

                    if (f1 * f2 < 0 && f3 * f4 < 0) // строгое пересечение
                    {
                        Console.WriteLine("intersect");
                        return;
                    }
                }
            }
            Console.WriteLine("NOT intersect");
        }
    }//0(20 x i)
}
