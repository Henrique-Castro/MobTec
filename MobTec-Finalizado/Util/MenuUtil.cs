using System;

namespace Mobtec.Util
{
    public class MenuUtil
    {
        public static void MenuDeslogado(){
            Console.WriteLine ("============FINANÇA DE MESA============");
            System.Console.WriteLine("||     1 - Cadastrar-Se              ||");
            System.Console.WriteLine("||     2 - Fazer Login               ||");
            System.Console.WriteLine("=======================================");
        }

        public static int MenuLogado(){
            System.Console.WriteLine("=========CADASTRO DE TRANSAÇÕES=========");
            System.Console.WriteLine("||     1- Nova transação              ||");
            System.Console.WriteLine("||     2- Extrato de transações       ||");
            System.Console.WriteLine("||     3 - Comprimir extrato          ||");
            System.Console.WriteLine("||     4 - Ver Saldo                  ||");
            System.Console.WriteLine("||     5- Gerar relatório             ||");
            System.Console.WriteLine("||     0- Voltar                      ||");
            System.Console.WriteLine("=======================================");

            return int.Parse(Console.ReadLine());
        }
    }
}