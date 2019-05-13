using System;
using System.Collections.Generic;
using Mobtec.Repositorio;
using Mobtec.Utils;
using Mobtec.ViewModel;

namespace Mobtec.ViewController
{
    public class UsuarioViewController
    {   
        static UsuarioRepositorio usuarioRepositorio = new UsuarioRepositorio();

        public static void CadastrarUsuario(){
            string nome, email, senha, confirmaSenha;
            DateTime data;
            int saldo;

            do
            {
                Console.Write("Digite o nome do usuário : ");
                nome = Console.ReadLine();

                if (string.IsNullOrEmpty(nome))
                {   
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Nome inválido");
                    Console.ResetColor();
                }
            } while (string.IsNullOrEmpty(nome));

            do
            {
                Console.Write("Digite o seu E-Mail : ");
                email = Console.ReadLine();

                if(!ValidacaoUtil.ValidadorDeEmail(email)){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Email inválido");
                    Console.ResetColor();
                }

            } while (!ValidacaoUtil.ValidadorDeEmail(email));

            do
            {
                Console.Write("Digite a senha : ");
                senha = Console.ReadLine();

                Console.Write("Confirme a senha : ");
                confirmaSenha = Console.ReadLine();

                if(!ValidacaoUtil.ValidadorDeSenha(senha, confirmaSenha)){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Senha inválida");
                    Console.ResetColor();
                }
            } while (!ValidacaoUtil.ValidadorDeSenha(senha, confirmaSenha));

            System.Console.WriteLine("Digite a sua data de nascimento (dd/mm/aaaa)");
            data = DateTime.Parse(Console.ReadLine());

            System.Console.Write("Digite O Valor Do Seu Saldo Atual : R$");
            saldo = int.Parse(Console.ReadLine());

            UsuarioViewModel usuario = new UsuarioViewModel();
            usuario.Nome = nome;
            usuario.Email = email;
            usuario.Senha = senha;
            usuario.DataNascimento = data;
            usuario.Saldo = saldo;
            
            usuarioRepositorio.Inserir(usuario);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário Cadastrado com sucesso");
            Console.ResetColor();

            List<UsuarioViewModel> ListaDeUsuarios = new List<UsuarioViewModel>(); 
            ListaDeUsuarios.Add(usuario);
        }//fim cadastro de usuário

        public static UsuarioViewModel EfetuarLogin(){
            string email, senha;

            System.Console.Write("Digite seu email : ");
            email = Console.ReadLine();
            
            System.Console.Write("Digite sua senha : ");
            senha = Console.ReadLine();

            UsuarioViewModel usuarioRecuperado = usuarioRepositorio.BuscarUsuario(email, senha);

            if (usuarioRecuperado != null)
            {
                return usuarioRecuperado;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Usuário ou Senha Inválidas");
            Console.ResetColor();
            return null;
        }//Fim Efetuar Login

    }
}