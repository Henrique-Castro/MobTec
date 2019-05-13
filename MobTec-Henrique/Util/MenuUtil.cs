using System;
using System.Collections.Generic;

namespace MobTec.Util
{
    public class MenuUtil
    {
        public static int MostrarMenuTransacoes(){
            List<string> menu = new List<string>{
                "_______________________________________",
                "             TRANSAÇÕES                ",
                "_______________________________________",
                "                                       ",
                "       1- Nova transação               ",
                "       2- Extrato de transações        ",
                "       3- Comprimir extrato            ",
                "       4- Gerar relatório              ",
                "       0- Voltar                       ",
                "_______________________________________"
            };
            foreach(string linha in menu){
                System.Console.WriteLine(linha);
            }
            return int.Parse(Console.ReadLine());
        }
    }
}