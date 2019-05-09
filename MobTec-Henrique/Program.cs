using System;
using MobTec.Util;

namespace MobTec
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Usuário

            #endregion

            int codigo = MenuUtil.MostrarMenuTransacoes();
            switch (codigo)
            {
                case 1:
                    //Cadastrar transação
                break;
                case 2:
                    //Ver todas as transações
                break;
                default:
                break;
                
            }
        }
    }
}
