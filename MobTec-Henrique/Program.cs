using System;
using MobTec.Controller;
using MobTec.Util;

namespace MobTec {
    class Program {
        static void Main (string[] args) {
            bool sair = false;
            #region Usuário

            #endregion
            #region Transação
            do {
                int codigo = MenuUtil.MostrarMenuTransacoes ();
                switch (codigo) {
                    case 1:
                        //Cadastrar transação
                        ControllerTransacao.CadastrarTransacao ();
                        break;
                    case 2:
                        //Ver todas as transações
                        ControllerTransacao.ListarTransacoes ();
                        break;
                    case 3:
                        ControllerTransacao.ComprimirExtrato();
                    break; 
                    case 4:
                        ControllerTransacao.GerarRelatorioTransacoes();
                    break;   
                    case 0:
                        sair = true;
                        break;

                    default:
                        break;
                }
            } while (sair == false);
        }
            #endregion
    }
}