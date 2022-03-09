using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Projeto01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Gerador de númeors Aleatórios";
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();

            int num, sorteiolinha, sorteioColuna;
            const int QTD_COL = 3;
            const int QTD_LIN = 3;
            int[,] matriz = new int[QTD_LIN, QTD_COL];
            Random random = new Random(); //Objeto resposável por geração de números aleatórios

            do
            {
                Console.Clear();
                Console.WriteLine("Olá será que você está preparado para vencer este jogo, tente a sorte e veremos o seu resultado! Bom jogo");
                matriz = cadastrarNumeros(QTD_LIN, QTD_COL);
                Console.WriteLine("\n---------MEMORIZE---------");
                exibirDados(matriz);
                Thread.Sleep(5000); //aguardar 5 segundos
                Console.Clear(); //limpa a tela
                sorteiolinha = random.Next(0, QTD_LIN); //gera número de 0 até  qtd_lin que no caso é 3
                sorteioColuna = random.Next(0, QTD_COL); //gera número de 0 até  qtd_col que no caso é 3
                Console.Write("\nQual número consta na posição:linha {0}, coluna {1} da matriz: ", sorteiolinha, sorteioColuna);
                while (!int.TryParse(Console.ReadLine(), out num) || num < 1 || num > 49)
                    Console.Write("Número inválido! Digite número inteiro: ");

                //metodo verifica passa por parametro o valor que está em uma posição da matriz e o numero digitado pelo usuario, sendo que retornará true ou false
                if (verifica(matriz[sorteiolinha, sorteioColuna], num))
                    Console.WriteLine("\nParabéns! Você acertou!\n");
                else
                    Console.WriteLine("\nQue pena que você errou! Número correto seria: {0}", matriz[sorteiolinha, sorteioColuna]);

                exibirDados(matriz);
                Console.WriteLine("\n\nPressione p para continuar ou qualquer outra tecla encerrar este programa: ");
            } while (Console.ReadKey().KeyChar == 'p');
        }//fim do metodo main

        static int[,] cadastrarNumeros(int nlin, int ncol)
        {
          int[,] n = new int[nlin, ncol];
          Random randow = new Random();
          for (int l = 0; l < nlin; l++)
            
              for (int c = 0; c < ncol ; c++)
                n[l, c] = randow.Next(0, 50);  
            return n;
        }

        static bool verifica(int numeroMatriz, int numUsuario)
        {
           return numeroMatriz == numUsuario ? true : false;
            /* ou usando if
            * if(numeroMatriz == numUsuario
            *      return true;
            * else
            *      return false;
            *      */
        }

        static void exibirDados(int[,] n)
        {
           //Exibição dos Dados da Matriz
           for (int i = 0; i < n.GetLength(0); i++)
           {
               for (int j = 0; j < n.GetLength(1); j++)
               {
                  Console.Write("{0:D2}\t", n[i, j]);
               }
               Console.WriteLine();
           }
        }
        
    }
}
