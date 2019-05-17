using System;
using Microsoft.VisualBasic.CompilerServices;
using Mobtec.Util;
using MobTec_Finalizado.Controller;
using MobTec_Finalizado.Model;
using MobTec_Finalizado.Util;
using MobTec_Finalizado.Util.EnumUtil;

namespace MobTec_Finalizado {
    class Program {
        static void Main (string[] args) {

            bool sair = false;
            bool voltar = false;
            do {
                int opcaoDeslogado = MenuUtil.MenuDeslogado ();
                switch (opcaoDeslogado) {
                    case 1:
                        ControllerUsuario.CadastrarUsuario ();
                        break;
                    case 2:
                        ModelUsuario usuarioRecuperado = ControllerUsuario.EfetuarLogin ();
                        if (usuarioRecuperado != null) {
                            Mensagem.MostrarMensagem ($"Bem-Vindo, {usuarioRecuperado.Nome}\n ", TipoMensagemEnum.SUCESSO);
                            //Menu Logado (Transações)
                            do {
                                int opcaoLogado = MenuUtil.MenuLogado ();
                                switch (opcaoLogado) {
                                    case 1:
                                        ControllerTransacao.CadastrarTransacao (usuarioRecuperado);
                                        break;
                                    case 2:
                                        ControllerTransacao.ListarTransacoes (usuarioRecuperado);
                                        break;
                                    case 3:
                                        ControllerTransacao.ComprimirExtrato (usuarioRecuperado);
                                        break;
                                    case 4:
                                        ControllerUsuario.VerSaldo (usuarioRecuperado);
                                        break;
                                    case 5:
                                        ControllerTransacao.GerarRelatorioTransacoes (usuarioRecuperado);
                                        break;
                                    case 0:
                                        voltar = true;
                                        break;
                                    default:
                                        Mensagem.MostrarMensagem ("Opção inválida", TipoMensagemEnum.ERRO);
                                        Console.ReadLine();
                                        continue;
                                }
                            } while (voltar == false);
                        }
                        break;
                        //FIM DO CASO 2 (EFETUAR LOGIN)
                    case 0:
                        sair = true;
                        break;
                    default:
                        Mensagem.MostrarMensagem ("Opção inválida", TipoMensagemEnum.ERRO);
                        Console.ReadLine();
                        
                        continue;
                }

            } while (sair == false);
        }
    }
}