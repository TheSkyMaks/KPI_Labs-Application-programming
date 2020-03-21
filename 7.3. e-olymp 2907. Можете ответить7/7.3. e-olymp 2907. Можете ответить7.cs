/*Можете ли Вы ответить на эти вопросы - 3
Задана последовательность целых чисел a1, a2, ..., an (|ai| ≤ 10000 , 1 ≤ n ≤ 50000). Над ней Вам следует выполнить m (m ≤ 50000) операций:
- модифицировать i-ый элемент последовательности
- для заданных xиy вывести MAX {ai + ai+1 + ... + aj, x ≤ i ≤ j ≤ y}
Входные данные
Первая строка содержит значение n. Следующая строка содержит n целых чисел, задающих последовательность a1, a2, ..., an.
Третья строка содержит число m. Следующие m строк содержат запросы вида:
- 0 x y: изменить ax на y (|y| ≤ 10000).
- 1 x y: вывести MAX {ai + ai+1 + ... + aj, x ≤ i ≤ j ≤ y}
Выходные данные
Для каждого запроса вывести ответ как требуется в задаче.
 */

using System;

namespace _7._3._e_olymp_2907._Можете_ответить7 //by TheSkyMaks
{
    internal class Program //TODO
    {
        static void Main()
        {
            Console.WriteLine("");
        }
    }
}
/*
 * Подсказка.
Создадим структуру из 4 элементов: сумма на отрезке, максимальная сумма на отрезке (ответ на запрос), максимальная сумма начинающаяся 
с начала отрезка, максимальная сумма заканчивающаяся в конце отрезка.

Решение.
Создадим на этой структуре ДО. Функцию нужно задать следующим образом: сумма на отрезке, очевидно, равна сумме всех чисел; 
левая сумма – максимум среди [левая сумма левого отрезка], [сумма всех чисел левого отрезка и левая сумма правого отрезка]; 
правая сумма – максимум среди [правая сумма правого отрезка], [сумма всех чисел правого отрезка и правая сумма левого отрезка];
максимальная сумма – максимум среди [максимальная сумма левого отрезка, максимальная сумма правого отрезка,
                                                    правая сумма левого отрезка+левая сумма правого отрезка]

const int inf = 16000;

class Four
{
    int leftSum, rightSum, maxSum, sum;
    Four()
    {
        leftSum = -inf;
        rightSum = -inf;
        maxSum = -inf;
        sum = 0;
    }

    Four(int a, int b, int c, int d)
    {
        leftSum = a;
        rightSum = b;
        maxSum = c;
        sum = d;
    }
};

Four maxSum(Four a, Four b)
{
    Four res;
    res.leftSum = max(a.leftSum, a.sum + b.leftSum);
    res.rightSum = max(b.rightSum, b.sum + a.rightSum);
    res.maxSum = max(a.maxSum, max(b.maxSum, a.rightSum + b.leftSum));
    res.sum = a.sum + b.sum;
    return res;
}

private int max(int leftSum, object p)
{
    throw new NotImplementedException();
}

const int MaxN = 50000;
Four a[MaxN + 5];



static void Main()
{

    ios_base::sync_with_stdio(0);
    cin.tie(0);
    srand(__rdtsc());

    int n;
    cin >> n;
    {
        int t;
        for (int i = 0; i < n; i++)
        {
            cin >> t;
            a[i] = Four(t, t, t, t);
        }
    }

    Four zero(-inf,-inf,-inf,0);
    SegmentTree<Four> st(n, a, maxSum, zero);

    int x, y, m, q;
    cin >> m;
    Four t;
    for (int i = 0; i < m; i++)
    {
        cin >> q >> x >> y;
        if (q == 1)
        {
            t = st.query(x - 1, y - 1);
            cout << t.maxSum << endl;
        }
        else
        {
            st.update(x - 1, Four(y, y, y, y));
        }
    }
}
}
}
*/
