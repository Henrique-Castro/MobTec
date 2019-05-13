using System;

namespace Mobtec.Utils
{
    public class MenuUtils
    {
        public static void MenuDeslogado(){
            Console.WriteLine ("============FINANÇA DE MESA============");
            System.Console.WriteLine("||     1 - Cadastrar-Se              ||");
            System.Console.WriteLine("||     2 - Fazer Login               ||");
            System.Console.WriteLine("=======================================");
        }

        public static void MenuLogado(){
            System.Console.WriteLine("=========CADASTRO DE TRANSAÇÕES=========");
            System.Console.WriteLine("||     1 - Receita                    ||");
            System.Console.WriteLine("||     2 - Despesas                   ||");
            System.Console.WriteLine("||     3 - Extrato De Transações      ||");
            System.Console.WriteLine("||     4 - Ver Saldo                  ||");
            System.Console.WriteLine("=======================================");
        }
    }
}