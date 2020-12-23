using System;

namespace Lab3.Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix matrix = new MyMatrix("1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 1 2 3 4 5 6 7 8");
            matrix.TransponeMe(matrix);
            Console.WriteLine(matrix);
            Console.Read();
        }
    }
}
