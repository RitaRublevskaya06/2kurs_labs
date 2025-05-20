using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_01
{
    class Calculator
    {
        private static int Evaluate(int first, int second, string operation)
        {
            switch (operation[0])
            {
                case '&':
                    return first & second;
                case '|':
                    return first | second;
                case '^':
                    return first ^ second;
                default:
                    throw new InvalidOperationException();
            }
        }

        public static int Parse(string[] source)
        {
            if (source.Length < 2)
                throw new IndexOutOfRangeException();
            if (source[source.Length - 1][0] == '~')
            {
                if (Int32.TryParse(source[source.Length - 2], out int negInt))
                    return ~negInt;
                else
                    throw new InvalidOperationException();
            }
            if (source.Length < 3)
                throw new IndexOutOfRangeException();
            if (Int32.TryParse(source[source.Length - 1 - 2], out int firstValue)
                && Int32.TryParse(source[source.Length - 1], out int secondValue))
                return Evaluate(firstValue, secondValue, source[source.Length - 1 - 1]);
            else
                throw new InvalidOperationException();
        }
    }
}
