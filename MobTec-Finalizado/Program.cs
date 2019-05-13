using System;
using Microsoft.VisualBasic.CompilerServices;
using Mobtec.Util;
using MobTec_Finalizado.Controller;
using MobTec_Finalizado.Model;

namespace MobTec_Finalizado {
    class Program {
        static void Main (string[] args) {
            #region Usuario
            bool sair = false;
            bool voltar = false;
            do {
                MenuUtil.MenuDeslogado ();
                System.Console.Write ("Digite o número da opçâo : ");
                int opcaoDeslogado = int.Parse (Console.ReadLine ());
                System.Console.WriteLine (" ");

                switch (opcaoDeslogado) {
                    case 1:
                        ControllerUsuario.CadastrarUsuario ();
                        break;
                    case 2:
                        ModelUsuario usuarioRecuperado = ControllerUsuario.EfetuarLogin ();
                        if (usuarioRecuperado != null) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine ($" \nBem-Vindo {usuarioRecuperado.Nome}\n ");
                            Console.ResetColor ();
                            do {
                                int opcaoLogado;
                                MenuUtil.MenuLogado ();
                                System.Console.Write ("Digite o número da opção : ");
                                opcaoLogado = int.Parse (Console.ReadLine ());
                                switch (opcaoLogado) {
                                    case 1:
                                        ControllerTransacao.CadastrarTransacao ();
                                        break;
                                    case 2:
                                        ControllerTransacao.ListarTransacoes ();
                                        break;
                                    case 3:
                                        ControllerTransacao.ComprimirExtrato ();
                                        break;
                                    case 4: //VEr Saldo
                                        if (usuarioRecuperado.Saldo >= 0) {
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            System.Console.WriteLine ($"Saldo Atual : {usuarioRecuperado.Saldo}");
                                            Console.ResetColor ();
                                        } else {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            System.Console.WriteLine ($"Saldo Atual : {usuarioRecuperado.Saldo}");
                                            Console.ResetColor ();
                                        }
                                        break;
                                    case 5:
                                        ControllerTransacao.GerarRelatorioTransacoes ();
                                        break;
                                    case 0:
                                        return;
                                    default:
                                        System.Console.WriteLine ("Opção Invalida");
                                        continue;
                                }

                            } while (voltar == false);
                        }
                        break;
                    default:
                        System.Console.WriteLine ("Opção Inválida");
                        continue;
                }

                #endregion

                //     #region Transação

                //     do {
                //         int codigo = MenuUtil.MenuLogado ();
                //         switch (codigo) {
                //             case 1:
                //                 //Cadastrar transação
                //                 ControllerTransacao.CadastrarTransacao ();
                //                 break;
                //             case 2:
                //                 //Ver todas as transações
                //                 ControllerTransacao.ListarTransacoes ();
                //                 break;
                //             case 3:
                //                 ControllerTransacao.ComprimirExtrato ();
                //                 break;
                //             case 4:
                //                 ControllerTransacao.GerarRelatorioTransacoes ();
                //                 break;
                //             case 0:
                //                 sair = true;
                //                 break;

                //             default:
                //                 break;
                //         }
                //     } while (sair == false);
                //     #endregion
            } while (sair == false);

        }
    }
}