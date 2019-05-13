using System;
using Mobtec.Repositorio;
using Mobtec.Utils;
using Mobtec.ViewController;
using Mobtec.ViewModel;

namespace Mobtec {
    class Program {

        bool Sair = false;
        static void Main (string[] args) {
            do {
                MenuUtils.MenuDeslogado ();
                System.Console.Write ("Digite o número da opçâo : ");
                int opcaoDeslogado = int.Parse (Console.ReadLine ());
                System.Console.WriteLine (" ");

                switch (opcaoDeslogado) {
                    case 1:
                        UsuarioViewController.CadastrarUsuario ();
                        break;
                    case 2:
                        UsuarioViewModel usuarioRecuperado = UsuarioViewController.EfetuarLogin ();
                        if (usuarioRecuperado != null) {
                            Console.ForegroundColor = ConsoleColor.Green;
                            System.Console.WriteLine ($" \nBem-Vindo {usuarioRecuperado.Nome}\n ");
                            Console.ResetColor ();
                            do {
                                int opcaoLogado;
                                MenuUtils.MenuLogado ();
                                System.Console.Write ("Digite o número da opção : ");
                                opcaoLogado = int.Parse (Console.ReadLine ());
                                switch (opcaoLogado) {
                                    case 1://Receita
                                        
                                        break;
                                    case 2://Despesas

                                        break;
                                    case 3://Extrato De Transações

                                    break;
                                    case 4://VEr Saldo
                                        if (usuarioRecuperado.Saldo >= 0){
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            System.Console.WriteLine($"Saldo Atual : {usuarioRecuperado.Saldo}");
                                            Console.ResetColor();
                                        }else{
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            System.Console.WriteLine($"Saldo Atual : {usuarioRecuperado.Saldo}");
                                            Console.ResetColor();
                                        }
                                    break;
                                    default:
                                        System.Console.WriteLine("Opção Invalida");
                                    continue;
                                }

                            } while (true);
                        }
                    break;
                    default:
                    System.Console.WriteLine("Opção Inválida");
                    continue;
                }   
            } while (true);
        }
    }
}