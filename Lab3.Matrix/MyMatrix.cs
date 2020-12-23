using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Matrix
{
    class MyMatrix
    {
        
        private double[,] matrix;
        public int height { get; }
        public int width { get; }
        
        public MyMatrix(int rows, int colms)
        {
            matrix = new double[rows, colms];
            this.height = rows;
            this.width = colms;
        }
        public MyMatrix(MyMatrix obj)
        {
            matrix = obj.matrix;
            this.height = obj.height;
            this.width = obj.width;
        }
        public MyMatrix(double[,] arr)
        {

            if (arr.GetLength(0) == arr.GetLength(1))
            {
                matrix = arr;
                this.height = arr.GetLength(0);
                this.width = arr.GetLength(1);
            }
            else
            {
                Console.WriteLine("Потребувалось ввести квадратну матрицю.");
            }
        }
        public MyMatrix(string[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                this.matrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
                this.height = matrix.GetLength(0);
                this.width = matrix.GetLength(1);
                try
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        for (int j = 0; j < matrix.GetLength(1); j++)
                        {
                            this.matrix[i, j] = double.Parse(matrix[i, j]);
                        }
                    }
                }
                catch(Exception exp)
                {
                    Console.WriteLine("Помилка. Було введено не числове значення.");
                }
                
            }
            else
            {
                Console.WriteLine("Потребувалось ввести квадратну матрицю.");
            }
        }
        
        public MyMatrix(string s)//конструктор з рядка
        {
            string[] arr = s.Split(' ');
            if (Math.Sqrt(arr.Length) % 1 == 0)
            {
                this.height = this.width = (int)Math.Sqrt(arr.Length);
                matrix = new double[this.height, this.width];

                int p = 0;
                for (int i = 0; i < this.height; i++)
                {
                    for (int j = 0; j < this.width; j++)
                    {
                        matrix[i, j] = double.Parse(arr[p]);
                        p++;
                    }
                }
            }
            else
            {
                Console.WriteLine("Потребувалось ввести таку кількість змінних, щоб утворилась квадратна матриця.");
            }
        }
        public double this[int row, int colm]
        {
            set
            {
                if (CheckMatrix(row, colm))
                {
                    matrix[row, colm] = value;
                }
            }
            get
            {
                if (CheckMatrix(row, colm))
                {
                    return matrix[row, colm];
                }
                return 0;
            }
        }
        private bool CheckMatrix(int row, int colm)
        {
            if ((row >= 0 & row < matrix.GetLength(0)) && (colm >= 0 & colm < matrix.GetLength(1))) 
                return true;
            return false;
        }
        public void FillMatrix(MyMatrix matrix)
        {
            Random rand = new Random();
            for (int i = 0; i < matrix.height; i++)
            {
                for (int j = 0; j < matrix.width; j++)
                {
                    matrix.matrix[i, j] = rand.Next(-1, 9);
                }
            }
        }
        public static MyMatrix operator *(MyMatrix matrixA, MyMatrix matrixB)
        {
            if (matrixA.matrix.Length != matrixB.matrix.Length)
            {
                throw new Exception("Множення неможливе, оскільки кiлькiсть стовпцiв першої матрицi не дорівнює кількостi рядкiв другої матрицi.");
            }
            MyMatrix matrixC = new MyMatrix(matrixA.height, matrixB.width);
            for (var i = 0; i < matrixA.height; i++)
            {
                for (var j = 0; j < matrixB.width; j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.width; k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }
            return matrixC;
        }
        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    result = result + matrix[i, j] + " ";
                }
                result += '\n';
            }
            return result;
        }
        
        public double[,] GetTransponedArray(MyMatrix ob)
        {
            double[,] result = new double[ob.height, ob.width];
            for (int i = 0; i < result.GetLength(0); i++)
            {
                for (int j = 0; j < result.GetLength(1); j++)
                {
                    result[i, j] = ob[j, i];
                }
            }
            return result;
        }
        
        public MyMatrix GetTransponedCopy(MyMatrix ob)
        {
            double[,] resultArr = GetTransponedArray(ob);
            return new MyMatrix(resultArr);
        }
        public void TransponeMe(MyMatrix ob)
        {
            this.matrix = GetTransponedArray(ob);
        }
    }
}
