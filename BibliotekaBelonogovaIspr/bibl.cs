using System;

namespace BibliotekaBelonogovaIspr
{
    public static class bibl
    {
        public static double Execute(double n, char op, double k)
        {
            switch (op)
            {
                case '+': return n + k;
                case '-': return n - k;
                case '*': return n * k;
                case '/':
                    if (k == 0) throw new DivideByZeroException("Деление на ноль невозможно");
                    return n / k;
                case '^': return Math.Pow(n, k);
                default: throw new ArgumentException($"Недопустимый оператор: {op}");
            }
        }

        public static int GetPriority(char op)
        {
            switch (op)
            {
                case '^':
                    return 3;
                case '*':
                case '/':
                    return 2;
                case '+':
                case '-':
                    return 1;
                default:
                    return 0;
            }
        }
    }
}