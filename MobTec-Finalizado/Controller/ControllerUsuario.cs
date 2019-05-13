using System;
using System.Collections.Generic;
using Mobtec.Utils;
using MobTec_Finalizado.Model;
using MobTec_Finalizado.Repositorio;
using MobTec_Finalizado.Util;
using MobTec_Finalizado.Util.EnumUtil;

namespace MobTec_Finalizado.Controller {
    public class ControllerUsuario {
        static RepositorioUsuario usuarioRepositorio = new RepositorioUsuario ();

        public static void CadastrarUsuario () {
            string nome, email, senha, confirmaSenha;
            DateTime data;
            int saldo;

            do {
                Console.Write ("Digite o nome do usuário : ");
                nome = Console.ReadLine ();

                if (string.IsNullOrEmpty (nome)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine ("Nome inválido");
                    Console.ResetColor ();
                }
            } while (string.IsNullOrEmpty (nome));

            do {
                Console.Write ("Digite o seu E-Mail : ");
                email = Console.ReadLine ();

                if (!ValidacaoUtil.ValidadorDeEmail (email)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine ("Email inválido");
                    Console.ResetColor ();
                }

            } while (!ValidacaoUtil.ValidadorDeEmail (email));

            do {
                Console.Write ("Digite a senha : ");
                senha = Console.ReadLine ();

                Console.Write ("Confirme a senha : ");
                confirmaSenha = Console.ReadLine ();

                if (!ValidacaoUtil.ValidadorDeSenha (senha, confirmaSenha)) {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine ("Senha inválida");
                    Console.ResetColor ();
                }
            } while (!ValidacaoUtil.ValidadorDeSenha (senha, confirmaSenha));

            System.Console.WriteLine ("Digite a sua data de nascimento (dd/mm/aaaa)");
            data = DateTime.Parse (Console.ReadLine ());

            System.Console.Write ("Digite O Valor Do Seu Saldo Atual : R$");
            saldo = int.Parse (Console.ReadLine ());

            ModelUsuario usuario = new ModelUsuario (nome, email, senha, saldo);
            usuarioRepositorio.Inserir (usuario);

            Mensagem.MostrarMensagem("Usuário cadastrado com sucesso.", TipoMensagemEnum.SUCESSO);

            List<ModelUsuario> ListaDeUsuarios = new List<ModelUsuario> ();
            ListaDeUsuarios.Add (usuario);
        } //fim cadastro de usuário

        public static ModelUsuario EfetuarLogin () {
            string email, senha;

            System.Console.Write ("Digite seu email : ");
            email = Console.ReadLine ();

            System.Console.Write ("Digite sua senha : ");
            senha = Console.ReadLine ();

            ModelUsuario usuarioRecuperado = usuarioRepositorio.Login (email, senha);

            if (usuarioRecuperado != null) {
                return usuarioRecuperado;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine ("Usuário ou Senha Inválidas");
            Console.ResetColor ();
            return null;
        } //Fim Efetuar Login
        public static void VerSaldo (ModelUsuario usuario) {
            Mensagem.MostrarMensagem($"Saldo Atual : {usuario.Saldo}", TipoMensagemEnum.DESTAQUE);
    }
}
}