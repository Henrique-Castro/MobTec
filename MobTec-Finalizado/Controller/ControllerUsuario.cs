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
            string nome, email, senha, confirmaSenha, dataCapturada, saldoString, confirmSaldoString;
            DateTime dataDateTime;
            float saldo;
            Console.Clear();
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
            do {
                System.Console.WriteLine ("Digite a sua data de nascimento (dd/mm/aaaa)");
                dataCapturada = Console.ReadLine ();
                if (!ValidacaoUtil.ValidarData (dataCapturada, out dataDateTime)) {
                    Mensagem.MostrarMensagem ("Digite uma data válida.", TipoMensagemEnum.ALERTA);
                } else {
                    ValidacaoUtil.ValidarData (dataCapturada, out dataDateTime);
                }

            } while (!ValidacaoUtil.ValidarData (dataCapturada, out dataDateTime));
            do {
                System.Console.Write ("Digite O Valor Do Seu Saldo Atual : R$");
                saldoString = Console.ReadLine ();
                System.Console.Write ("Só para ter certeza, confirme o seu saldo:");
                confirmSaldoString = Console.ReadLine ();

                if (!ValidacaoUtil.ValidarSaldo (saldoString, confirmSaldoString, out saldo)) {
                    Mensagem.MostrarMensagem ("Digite um saldo válido", TipoMensagemEnum.ALERTA);
                } else {
                    ValidacaoUtil.ValidarSaldo (saldoString, confirmSaldoString, out saldo);
                }
            } while (!ValidacaoUtil.ValidarSaldo (saldoString, confirmSaldoString, out saldo));

            ModelUsuario usuario = new ModelUsuario (nome, email, senha, saldo);

            
            usuarioRepositorio.Inserir (usuario);

            Mensagem.MostrarMensagem ("Usuário cadastrado com sucesso.", TipoMensagemEnum.SUCESSO);
        } //fim cadastro de usuário

        public static ModelUsuario EfetuarLogin () {
            string email, senha;
            Console.Clear();
            do {
                System.Console.Write ("Digite seu email : ");
                email = Console.ReadLine ();
            } while (!ValidacaoUtil.ValidadorDeEmail (email));

            System.Console.Write ("Digite sua senha : ");
            senha = Console.ReadLine ();

            ModelUsuario usuarioRecuperado = usuarioRepositorio.Login (email, senha);

            if (usuarioRecuperado != null) {
                return usuarioRecuperado;
            }
            Mensagem.MostrarMensagem("Usuário ou Senha Inválidas", TipoMensagemEnum.ERRO);
            return null;
        } //Fim Efetuar Login
        public static void VerSaldo (ModelUsuario usuario) {
            Mensagem.MostrarMensagem ($"Saldo Atual : {usuario.Saldo}", TipoMensagemEnum.DESTAQUE);
        }
    }
}