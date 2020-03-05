using System;

namespace Labs // by TheSkyMaks
{
    class Program
    {
        static void Main()
        {
            string mnogochlen1 = Console.ReadLine();
            FunctionKoef(mnogochlen1);
            string mnogochlen2 = Console.ReadLine();
            FunctionKoef(mnogochlen2);
        }
        static string[,] FunctionKoef(string mnogochlen)
        {
            string[,] Koefs = new string[10,2]; 
            int Koefs_index = 0, Koefs_index2 = 0;
            for (int i = 0; i < mnogochlen.Length; i++)
            {
                if (mnogochlen[i] == '+' || mnogochlen[i] == '-')
                {
                    Koefs[Koefs_index,0] += mnogochlen[i];
                    for (i = i + 1; i < mnogochlen.Length; i++)
                    {
                        if (mnogochlen[i] != 'x')
                        {
                            if (mnogochlen[i + 1] == '^') 
                            {
                                for (i = i + 1; i < mnogochlen.Length; i++)
                                {
                                    if(mnogochlen[i] != '+' || mnogochlen[i] != '-')
                                    Koefs[Koefs_index2, 1] += mnogochlen[i];                                    
                                }
                                Koefs_index2++;
                            }
                            else
                            {
                                Koefs[Koefs_index, 0] += mnogochlen[i];
                            }
                        }
                        else
                        {
                            Koefs[Koefs_index, 0] += "x";
                            if (mnogochlen[i + 1] == '^') 
                            {
                                for (i = i + 1; i < mnogochlen.Length; i++)
                                {
                                    if (mnogochlen[i] != '+' || mnogochlen[i] != '-')
                                        Koefs[Koefs_index2, 1] += mnogochlen[i];
                                }
                                Koefs_index2++;
                            }
                            Koefs_index++;
                            break;
                        }
                    }
                }
                else if (mnogochlen[i] == 'x')
                {
                    Koefs[Koefs_index, 0] += "1";
                    if (mnogochlen[i + 1] == '^')
                    {
                        for (i = i + 1; i < mnogochlen.Length; i++)
                        {
                            if (mnogochlen[i] != '+' || mnogochlen[i] != '-')
                                Koefs[Koefs_index2, 1] += mnogochlen[i];
                        }
                        Koefs_index2++;
                    }
                    Koefs_index++;
                }
                else
                {
                    string str = "" + mnogochlen[i];
                    if (int.TryParse(str, out _))
                    {
                        Koefs[Koefs_index,0] += mnogochlen[i];
                    }
                }
            }
            
            try
            {
                Console.WriteLine();
                for (int i = 0; i < Koefs.Length; i++)
                {
                    Console.WriteLine(Koefs[i, 0]);
                }
                Console.WriteLine();
                for (int i = 0; i < Koefs.Length; i++)
                {
                    Console.WriteLine(Koefs[i, 1]);
                }
            }
            catch
            {
                Console.WriteLine("debil");
            }
            
            return Koefs;
        }
    }
}

/*
  string mnogochlen1 = Console.ReadLine();
            string str1 = FunctionDoX(mnogochlen1);
            string str2 = FunctionStepen(mnogochlen1);
            string mnogochlen2 = Console.ReadLine();
            string str3 = FunctionDoX(mnogochlen2);
            string str4 = FunctionStepen(mnogochlen2);
            Console.WriteLine(str1 + "x^" + str2 + "   " + str3 + "x^" + str4);
        }
        static string FunctionDoX(string mnogochlen)
        {
            string a = "";
            for (int i = 0; i < mnogochlen.Length; i++)
            {
                if (mnogochlen[i] == 'x')
                {
                    if (i > 0)
                    {
                        for (int j = i - 1; j > -1; j--)
                        {
                            string str1 = "" + mnogochlen[j];
                            if (int.TryParse(str1, out _))
                            {
                                a += mnogochlen[j];
                            }
                            else 
                            {
                                a = "1";
                                a += mnogochlen[j];
                                break;
                            }
                        }
                    }
                    else
                    {
                        a = "1";
                    }
                }
            }
            char[] arr = a.ToCharArray();
            Array.Reverse(arr);
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str +=arr[i];
            }
            return str;
        }
        static string FunctionStepen(string mnogochlen)
        {
            string b = "";
            for (int i = 0; i < mnogochlen.Length; i++)
            {
                if (mnogochlen[i] == 'x')
                {
                    try
                    {
                        if (mnogochlen[i + 1] != '^')
                        {
                            b = "1";                            
                        }
                        else
                        {
                            for (int j = i + 1; j < mnogochlen.Length; j++)
                            {
                                string str1 = "" + mnogochlen[j];
                                if (int.TryParse(str1, out _))
                                {
                                    b += mnogochlen[j];
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            char[] arr = b.ToCharArray();
            string str = "";
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i];

            }
            return str;
     */
