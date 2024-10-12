using System;
using System.Text;
using System.Linq;

namespace oop1
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------ТИПЫ----------------
            //1a
            byte a1 = 147;
            Console.WriteLine("byte a1: " + a1);

            sbyte a2 = 127;
            Console.WriteLine("sbyte a2: " + a2);

            short b1 = 32157;
            Console.WriteLine("short b1: " + b1);

            ushort b2 = 54785;
            Console.WriteLine("ushort b2: " + b2);

            int c1 = 1143595647;
            Console.WriteLine("int c1: " + c1);

            uint c2 = 3594687295;
            Console.WriteLine("uint c2: " + c2);

            long d1 = 8224972032484775807;
            Console.WriteLine("long d1: " + d1);

            ulong d2 = 14598744073709551615;
            Console.WriteLine("ulong d2: " + d2);


            float e_1 = 3.402823f;
            Console.WriteLine("float e_1: " + e_1);

            double f_1 = 1.79769313486;
            Console.WriteLine("double f_1: " + f_1);

            decimal g_1 = 7.922816251426654783m;
            Console.WriteLine("decimal g_1: " + g_1);


            char h_1 = 'a';
            Console.WriteLine("char h_1: " + h_1);

            string i_1 = "abcd i fghi !@#";
            Console.WriteLine("string i_1: " + i_1);


            bool j_1 = false;
            Console.WriteLine("bool j_1: " + j_1);
            bool k_1 = true;
            Console.WriteLine("bool k_1: " + k_1);


            //1b
            // Явные приведения
            float m1 = 7.592f;
            float m2 = 1.616f;
            byte m3 = (byte)(m1 + m2);
            sbyte m4 = (sbyte)(m1 + m2);
            short m5 = (short)(m1 + m2);
            int m6 = (int)(m1 + m2);
            long m7 = (long)(m1 + m2);
            Console.WriteLine("float-->byte: " + m3);
            Console.WriteLine("float-->sbyte: " + m4);
            Console.WriteLine("float-->short: " + m5);
            Console.WriteLine("float-->int: " + m6);
            Console.WriteLine("float-->long: " + m7);

            // Неявные приведения
            byte bnum = 8;
            short snum = bnum;
            int inum = snum;
            long lnum = inum;
            float fnum = lnum;
            Console.WriteLine("byte->short->int->long->float: " + fnum);

            // Convert
            double doublevalue = 125.456; int intvalue12 = Convert.ToInt32(doublevalue);
            Console.WriteLine("Преобразовать: " + intvalue12);
            int intValue = 1;
            bool boolValue = Convert.ToBoolean(intValue); Console.WriteLine("Преобразовать: " + boolValue);
            int intValue123 = 123;
            string stringValue = Convert.ToString(intValue123); Console.WriteLine("Преобразовал int в строку: " + stringValue);

            //1c упаковка и распококвка 
            int n1 = 7;
            Console.WriteLine("n1: " + n1);
            object n2 = n1;
            int n3 = (int)n2;
            Console.WriteLine("n3: " + n3);

            double n4 = 7.7879;
            Console.WriteLine("n4: " + n4);
            object n5 = n4;
            double n6 = (double)n5;
            Console.WriteLine("n6: " + n6);

            //1d
            var d1_1 = "Неявно типизированная переменная";
            Console.WriteLine(d1_1);
            var d2_1 = 5;
            var d3_1 = 7.74;
            var d4_1 = d2_1 + d3_1;
            Console.WriteLine("d4_1: " + d4_1);

            //1e
            //int? e1 = null;
            int? e1 = 15;
            if (e1 == null) Console.WriteLine("null");
            else Console.WriteLine("Число");

            //1f
            var f1 = 5;
            /*f1 = 0.4444;*/
            Console.WriteLine("f1: " + f1);

            //--------------Строки-----------------
            //2a литералы
            string str1 = "nnn";
            string str2 = "nnn";
            string str3 = "ppp";
            string str4 = "\\ryffh\\";
            Console.WriteLine($"Сравнение 1 и 2 строки: {str1 == str2}");
            Console.WriteLine($"Сравнение 2 и 3 строки: {String.Compare(str2, str3)}");

            //2b

            string str11 = "Это первая строка";
            string str22 = "Это вторая строка";
            string str33 = "Это третья строка";

            Console.WriteLine($"Сцепление строк: {String.Concat(str11, str22)}");
            Console.WriteLine($"Копирование строки: {String.Copy(str22)}");
            string substr = str33.Substring(11);
            Console.WriteLine($"Выделение подстроки: {substr}");
            Console.WriteLine($"Разделение строки на слова: ");
            string[] strArr = str11.Split();

            for (int ind = 0; ind < strArr.Length; ind++)
            {
                Console.WriteLine(strArr[ind]);
            }
            Console.WriteLine($"Вставка подстроки в заданную позицию: {str22.Insert(4, substr)}");
            Console.WriteLine($"Удаление заданной подстроки: {str33.Remove(4)}");

            //2c
            string emtstr = "";
            string nullstr = null;
            Console.WriteLine($"IsNullOrEmpty: {string.IsNullOrEmpty(emtstr)}");
            Console.WriteLine($"IsNullOrEmpty: {string.IsNullOrEmpty(nullstr)}");

            Console.WriteLine($"Вывод пустой строки: {emtstr}");
            Console.WriteLine($"Вывод нулевой строки: {nullstr}");
            Console.WriteLine($"Сравнение 1 и 2 строки: {emtstr == nullstr}");
            Console.WriteLine($"Сцепление: {String.Concat(emtstr, nullstr)}");

            //2d
            StringBuilder testStr = new StringBuilder("rrkkkkrrrr", 7);
            testStr.Remove(2, 4);
            testStr.Insert(0, str33.Substring(11));
            testStr.Append("end");
            Console.WriteLine($"StringBuilder: {testStr}");

            //--------------МАССИВЫ-----------------
            //3a
            int[,] matrix = { { 1, 1, 1 }, { 0, 0, 0 }, { 1, 0, 1 } };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{matrix[i, j]} \t");
                }
                Console.WriteLine();
            }

            //3b
            string[] srtArr = { "aaa", "bbbbb", "ccccccc" };
            Console.WriteLine($"Длина массива: {srtArr.Length}");

            foreach (string str in srtArr)
            {
                Console.WriteLine(str);
            }
            Console.WriteLine("Введите позицию: ");
            int pos = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите строку: ");
            string strpos = Convert.ToString(Console.ReadLine());

            srtArr[pos] = strpos;
            Console.WriteLine("--------");

            foreach (string str in srtArr)
            {
                Console.WriteLine(str);
            }

            //3c
            double[][] jaggedArr = new double[3][];
            jaggedArr[0] = new double[2];
            jaggedArr[1] = new double[3];
            jaggedArr[2] = new double[4];

            Console.WriteLine("Заполните ступенчатый массив: ");
            for (int i = 0; i < 2; i++)
            {
                jaggedArr[0][i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                jaggedArr[1][i] = Convert.ToDouble(Console.ReadLine());
            }

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                jaggedArr[2][i] = Convert.ToDouble(Console.ReadLine());
            }

            foreach (double[] row in jaggedArr)
            {
                foreach (double number in row)
                {
                    Console.Write($"{number} \t");
                }
                Console.WriteLine();
            }

            //3d

            var strok = "hello"; Console.WriteLine("Строка:" + strok.GetType());
            var new_arr = new[] { 1, 2, 3 }; Console.WriteLine("Массив: " + new_arr.GetType());

            //--------------Кортежи-----------------

            //4a
            (int, string, char, string, ulong) tuple = (12, "krrr", 'r', "black", 11111);

            //4b
            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item5);

            //4c
            // (int age, string name, char letter, string color, ulong userNumber) = tuple;
            //(var age, var name, var letter, var color, var userNumber) = tuple;
            var (age, name, letter, color, userNumber) = tuple;

            (int age2, string name2, _, string color2, ulong userNumber2) = tuple;


            Console.WriteLine($"items: {age} {name}");

            //4d
            var tuple1ToCompare = (7, 27, 4, 85, 6, 7, 5);
            var tuple2ToCompare = (7, 27, 4, 85, 5, 7, 5);
            if (tuple1ToCompare == tuple2ToCompare)
            {
                Console.WriteLine("true");
            }
            else
            { Console.WriteLine("false"); }


            //--------------Функции-----------------

            (int, int, int, char) LocalFunction(int[] numbers, string str1)
            {
                int max = numbers[0];
                int min = numbers[0];
                int sum = 0;

                for (int iiii = 0; iiii < numbers.Length; iiii++)
                {
                    if (numbers[iiii] > max)
                    {
                        max = numbers[iiii];
                    }
                    if (numbers[iiii] < min)
                    {
                        min = numbers[iiii];
                    }
                    sum += numbers[iiii];
                }
                char smb = str1[0];
                var tuple1 = (max, min, sum, smb);
                return tuple1;
            }
            int[] nums = new int[4];
            nums[0] = 10;
            nums[1] = 50;
            nums[2] = 70;
            nums[3] = 150;
            string str5 = "margo";
            Console.WriteLine(LocalFunction(nums, str5));

            //--------------Работа с checked/ unchecked:-----------------

            int numb = 100;
            int LocalFunction2()
            {
                int check = Int32.MaxValue;
                unchecked
                {
                    check = check + numb;
                }
                return check;
            }
            int LocalFunction1()
            {
                int check = Int32.MaxValue;
                checked
                {
                    check = check + numb;
                    Console.WriteLine(check);
                }
                return check;
            }
            Console.WriteLine(LocalFunction2());
            Console.WriteLine(LocalFunction1());

        }
    }
}