using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;


namespace MyMatrixMultiplication
{
    public class MatricMul : IMatricMul
    {
        class Element
        {
            public long x, y;
        }
        Stopwatch watch = new Stopwatch();

        long y, x, z; 

        public void MatrixMultiplication(int x, int y, int z)
        {
            //long[,] matrixA;
            //long[,] matrixB;
            //long[,] matrixC;
           

            this.x = x;
            this.y = y;
            this.z = z;
            long [,] matrixA = new long[x, y];
            long[,] matrixB = new long[y, z];
            //long[,]  matrixC = new long[x, z];


            var rnd = new Random(int.Parse(DateTime.Now.ToString("HHmmssfff")) + (int)(x * z));
            GenerateMatrices(rnd, x, y, z, matrixA,matrixB);

            watch.Start();
            long count = 0;
            for (int i = 1; i < 11; i++)
            {
                watch.Restart();
                NormalMultiplication(matrixA, matrixB);
                watch.Stop();
                count += watch.ElapsedMilliseconds;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Elapsed time for Normal Multiplcation: " + watch.ElapsedMilliseconds + "ms");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("average time spent is " + count/10.0 +"ms\n");

            count = 0;
            for (int j = 1; j < 11; j++)
            {
                watch.Restart();
                ParallelMultiplication(matrixA, matrixB);
                watch.Stop();
                count += watch.ElapsedMilliseconds;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Elapsed time for parallel Multiplcation: " + watch.ElapsedMilliseconds + "ms");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("average time spent is " + count / 10.0 + "ms\n");
            
           
        }

        private void GenerateMatrices(Random rnd, int x, int y, int z,long[,] matrixA, long[,]matrixB)
        {
            for (long i = 0; i < y; ++i)
            {
                for (long j = 0; j < z; ++j)
                {
                    matrixA[i, j] = rnd.Next(0, x * z);
                    matrixB[i, j] = rnd.Next(0, x * z);
                }
            }
        }

     
        private void NormalMultiplication(long[,]matrixA,long[,] matrixB)
        {
            long[,]matrixCN = new long[x,z];
           
                for (long i = 0; i < y; ++i)
                {
                    for (long j = 0; j < z; ++j)
                    {
                        for (long k = 0; k < x; ++k)
                        {
                            matrixCN[i, j] += matrixA[i, k] * matrixB[k, j];
                        }
                    }
                }
                //PrintResults(x, y, matrixC);
                //Console.ReadLine();
        }

        private void PrintResults(long x, long y, long[,] matrixC)
        {
            Console.WriteLine("Operation complete. Print results? y/n");
            char c = Console.ReadKey().KeyChar;
            if (c == 'y' || c == 'Y')
            {
                Console.WriteLine();
                for (int a = 0; a < x; a++)
                {
                    Console.WriteLine("ROW {0}: ", x);
                    for (int b = 0; b < y; b++)
                    {
                        Console.Write("{0:#.##} ", matrixC[a, b]);
                    }
                    Console.WriteLine();

                }
            }
            
        }

        private void ParallelMultiplication(long[,] matrixA, long[,] matrixB)
        {
            long[,] matrixCP = new long[x, z];
                Parallel.For(0, y, i =>
                {
                   Parallel.For(0, z, j =>
                   // for (int j = 0; j < z; j++)
                    {
                        Element elem = new Element();
                        elem.x = i;
                        elem.y = j;
                        ComputeElement(elem, matrixA, matrixB, matrixCP);

                   // }
                    });
                });
                //PrintResults(x, y, matrixC);
                //Console.ReadLine();
        }

        private void ComputeElement(Object _elem,long[,]matrixA,long[,] matrixB,long[,]matrixC)
        {
            
            Element elem = (Element)_elem;
            matrixC[elem.x, elem.y] = 0;
            for (int i = 0; i < x; ++i)
            {
                matrixC[elem.x, elem.y] += matrixA[elem.x, i] * matrixB[i, elem.y];
            }

        }

    }
}
