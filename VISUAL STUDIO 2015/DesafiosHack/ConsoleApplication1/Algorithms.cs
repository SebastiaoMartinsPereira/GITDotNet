using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Algorithms
    {
        public static void AVeryBigSum()
        {
            Int64 count = 0;
            Int64 total = 0;

            //lê a quantidade de numeros que terá no array
            string qtdNum = Console.ReadLine();
            //Recebe os valores que estarão no array no formato de string em uma unica linha
            string nums = Console.ReadLine();
            //transforma a string em um array
            String[] ints = nums.Split(' ');
            //Convert cada string no array para inteiro 
            int[] inteiros = Array.ConvertAll(ints, int.Parse);
            //Faz o loop no array de interios e efetua a soma dos valores.
            while (count < int.Parse(qtdNum))
            {
                total += inteiros[count];
                count++;
            }
            //mostra o valor total
            Console.Write(total);
            Console.ReadKey();
        }

        public static void DiagonalDifference()
        {
            //Gerador de Numeros Aleatórios
            Random ram = new Random();

            //Tamanho que terá a matriz
            int size = ram.Next(1, 10);
       
            String linhaArray = "";
            //Define a Matriz Com o Tamanho NxN
            int[,] Matriz = new int[size,size];

            //Preenche a Matriz
            for (int i = 0;i<size; i++)
            {
                //Cri um array de Bity com o mesmo tamanho definido para a Matriz
                byte[] bytes = new byte[size];
                //Preenche a array com valores aleatórios
                ram.NextBytes(bytes);

                //Cria uma String com os valores do array de byte separados por ' '
                foreach (Byte item in bytes)
                {
                    linhaArray += item.ToString() + " ";
                }

                //Cria uma matrize preenche com os valores da string
                string[] aux = linhaArray.Trim().Split(' ');

                //Cria um array de inteiros e realiza o cast de string para inteiros
                int[] auxInt = Array.ConvertAll(aux, int.Parse);

                //Preenche cada campo da matriz linha a linha
                for (int j = 0; j < size ; j++)
                {
                    Matriz[i, j] = auxInt[j];
                }
                    
           }

            Console.Write(sumDiagonalMatrix(Matriz));

            Console.ReadKey();


        //    VERSAO UTILIZADA NA RESOLUCAO DO PROBLEMA
        //            public static void Teste()
        //{

        //    int size = Convert.ToInt32(Console.ReadLine());

        //    String linhaArray = "";

        //    int[,] Matriz = new int[size, size];

        //    for (int i = 0; i < size; i++)
        //    {

        //        linhaArray = Console.ReadLine();

        //        string[] aux = linhaArray.Trim().Split(' ');
        //        int[] auxInt = Array.ConvertAll(aux, int.Parse);

        //        for (int j = 0; j < size; j++)
        //        {
        //            Matriz[i, j] = auxInt[j];
        //        }

        //    }

        //    Console.Write(sumDiagonalMatrix(Matriz));

        //}
    }

        /// <summary>
        /// Calcula a diferenca de valores entre as diagonais de uma matriz.
        /// </summary>
        /// <param name="matriz"></param>
        /// <returns></returns>
        public static int sumDiagonalMatrix(int[,] matriz)
        {
            int sumDiag1 = 0;
            int sumDiag2 = 0;
            int aux = matriz.GetUpperBound(matriz.Rank - 1);

            //realiza a soma dos valores da diagonal 1
            for (int i = 0;i <= matriz.GetUpperBound(matriz.Rank-1);i++)
            {
                sumDiag1 += matriz[i, i];
            }
            //Realiza a soma dos valores da diagonal 2
            for (int i = 0; i <= matriz.GetUpperBound(matriz.Rank-1); i++)
            {
                sumDiag2 += matriz[aux, i];
                aux -= 1;
            }

            int result = sumDiag2 - sumDiag1;
            return Math.Abs(result);
        }


        /// <summary>
        /// Detalha valores de uma matriz
        /// </summary>
        /// <param name="matriz"></param>
        public static void detalhesMatriz(Array matriz)
        {

            Console.WriteLine("Tamanho do Matriz :     {0,3}", matriz.Length);
            Console.WriteLine("Dimensões :     {0,3}", matriz.Rank);
            Console.WriteLine("Lower :     {0,3}", matriz.GetLowerBound(0));
            Console.WriteLine("Upper:     {0,3}", matriz.GetUpperBound(matriz.Rank-1));


            for (int dim = 1; dim <= matriz.Rank; dim++)
            {
                Console.WriteLine("Dimension {0} : {1,3}", dim, matriz.GetUpperBound(dim - 1) + 1);
            }
        }

    }
}

