using System;
using System.IO;

namespace Sudoku.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //// encontra números repetidos 
            //int[] linha1 = {1,3,2,5,7,9,4,6,8};

            //         //{4,9,8,2,6,1,3,7,5},
            //         //{7,5,6,3,8,4,2,1,9},
            //         //{6,4,3,1,5,8,7,9,2},
            //         //{5,2,1,7,9,3,8,4,6},
            //         //{9,8,7,4,2,6,5,3,1},
            //         //{2,1,4,9,3,5,6,8,7},
            //         //{3,6,5,8,1,7,9,2,4},
            //         //{8,7,9,6,4,2,1,5,3}};
            //for (int i = 0; i < linha1.Length; i++)
            //{
            //    for (int j=0; j < linha1.Length; i++)
            //    {
            //        if (linha1[i] == linha1[j])
            //        {
            //            Console.WriteLine($"duplicatas: {linha1[i]}");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Linha correta");
            //        }
            //    }
            //}



            StringReader StringSudoku = new StringReader("1 3 2 5 7 9 4 6 8" + "\n" +
                                                "4 9 8 2 6 1 3 7 5" + "\n" +
                                                "7 5 6 3 8 4 2 1 9" + "\n" +
                                                "6 4 3 1 5 8 7 9 2" + "\n" +
                                                "5 2 1 7 9 3 8 4 6" + "\n" +
                                                "9 8 7 4 2 6 5 3 1" + "\n" +
                                                "2 1 4 9 3 5 6 8 7" + "\n" +
                                                "3 6 5 8 1 5 9 2 4" + "\n" +
                                                "8 7 9 6 4 2 1 5 3");



            int[,] linhasSudoku = new int[9, 9];
            int[,] colunaSudoku = new int[9, 9];
            int[,] blocoSudoku = new int[9, 9];

          //  using (StringReader sudoReader = new StringReader(StringSudoku))
            {

                string linhaSudoku = "";

                for (int x = 0; x < 9; x++)
                {
                    linhaSudoku = StringSudoku.ReadLine();

                    string[] valores = linhaSudoku.Trim().Split();

                    for (int y = 0; y < 9; y++)
                    {
                        linhasSudoku[x, y] = Convert.ToInt32(valores[y]);
                    }
                }

                //COLUNA
                for (int y = 0; y < 9; y++)
                    for (int x = 0; x < 9; x++)
                        colunaSudoku[y, x] = linhasSudoku[x, y];

                //BLOCOS
                int l = 0;
                for (int k = 0; k < 9; k++)
                {
                    l = 0;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int x = i + k % 3 * 3;
                            int y = j + k / 3 * 3;
                            blocoSudoku[k, l] = linhasSudoku[x, y];
                            l++;
                        }
                    }
                }
                Verifica(linhasSudoku);
                Verifica(colunaSudoku);
                Verifica(blocoSudoku);

                Console.WriteLine("SIM");
                Console.ReadLine();
            }
        }

        private static void Verifica(int[,] linhasSudoku)
        {
            for (int k=0; k < 9; k++)
                for(int i=0; i<9; i++)
                    for (int j = i+1; j<9; j++)
                        if (linhasSudoku[k, i] == linhasSudoku[k, j])
                        {
                            Console.WriteLine("NÃO");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }

        }
    }
}
