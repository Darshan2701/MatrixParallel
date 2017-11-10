using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMatrixMultiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IMatricMul matrix = new MatricMul();

            Console.WriteLine("Matrix Multiplication of two 13 * 13 matrices ");
            matrix.MatrixMultiplication(13, 13, 13);

            Console.WriteLine("Matrix Multiplication of two 50 * 50 matrices");
            matrix.MatrixMultiplication(50, 50, 50);


            Console.WriteLine("Matrix Multiplication of two 100 * 100 matrices");
            matrix.MatrixMultiplication(100, 100, 100);

            Console.WriteLine("Matrix Multiplication of two 500 * 500 matrices");
            matrix.MatrixMultiplication(500, 500, 500);

            Console.WriteLine("Matrix Multiplication of two 1000 * 1000 matrices");
            matrix.MatrixMultiplication(1000, 1000, 1000);
            //Console.WriteLine("Press any key to exit..");
            Console.ReadLine();


            //Console.WriteLine("Enter the size of matrices: \n");
            //int a = int.Parse(Console.ReadLine());
            //int b = int.Parse(Console.ReadLine());
            //int c = int.Parse(Console.ReadLine());

            //Console.WriteLine("Matric Multiplication of " + a + "*" + b + "matrices");
            //matrix.MatrixMultiplication(a, b, c);
            //Console.ReadLine();

     
        }
    }
}
