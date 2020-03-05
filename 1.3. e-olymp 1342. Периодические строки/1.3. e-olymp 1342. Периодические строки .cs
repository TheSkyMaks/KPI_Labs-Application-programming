using System;

namespace Labs // by TheSkyMaks
{
    class Program
    {
        static void Main()
        {
            int period, str_count = Convert.ToInt32(Console.ReadLine());
            bool ok;
            string[] str = new string[str_count];
            for (int i = 0; i < str_count; ++i)
            {
                str[i] = Console.ReadLine();
            }
            for (int n = 0; n < str_count; ++n)
            { 
                period = str[n].Length;
                for (int i = 1; i <= str[n].Length; ++i)
                {
                    ok = true;
                    if (str[n].Length % i == 0)
                    {
                        for (int j = 0; j < str[n].Length / i - 1; ++j)
                        {
                            for (int k = 0; k < i; ++k)
                            {
                                if (str[n][k + j * i] != str[n][k + (j + 1) * i])
                                {
                                    ok = false;
                                    break;
                                }
                            }
                            if (ok == false)
                            {
                                break;
                            }
                        }
                        if (ok == false)
                        {
                            period = i;
                            break;
                        }
                    }
                }
                Console.WriteLine(period);
                Console.WriteLine();
            }
        }
    }
}
