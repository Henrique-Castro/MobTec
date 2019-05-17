using System;
using System.Collections.Generic;
using Mobtec.Utils;
using MobTec_Finalizado.Model;
using MobTec_Finalizado.Repositorio;
using MobTec_Finalizado.Util;
using MobTec_Finalizado.Util.EnumUtil;

namespace MobTec_Finalizado.Controller
{
    public class ControllerTransacao
    {
        public static void CadastrarTransacao (ModelUsuario usuarioLogado) {
            RepositorioTransacao repositorio = new RepositorioTransacao ();
            string tipo, descricao;
            float valor;
            do {
                System.Console.Write ("Tipo de transação: ");
                tipo = Console.ReadLine ();
                if (String.IsNullOrEmpty (tipo)) {
                    Mensagem.MostrarMensagem ("Este campo não pode ficar vazio.", TipoMensagemEnum.ALERTA);
                }
            } while (String.IsNullOrEmpty (tipo));
            do {
                System.Console.Write ("Descrição: ");
                descricao = Console.ReadLine ();
                if (String.IsNullOrEmpty (descricao)) {
                    Mensagem.MostrarMensagem ("Este campo não pode ficar vazio.", TipoMensagemEnum.ALERTA);
                }
            } while (String.IsNullOrEmpty (descricao));
            do {
                System.Console.Write ("Valor: ");
                valor = float.Parse (Console.ReadLine ());
                if (!ValidacaoUtil.ValidarPreco (valor)) {
                    Mensagem.MostrarMensagem ("Este campo não pode ficar vazio.", TipoMensagemEnum.ALERTA);
                }
            } while (!ValidacaoUtil.ValidarPreco (valor));
            ModelTransacao transacao = new ModelTransacao(usuarioLogado.IdUsuario,tipo,descricao,valor);
            transacao.IdUsuario = usuarioLogado.IdUsuario;
            repositorio.GravarTransacao (transacao);
            Mensagem.MostrarMensagem ("Transação registrada com sucesso.", TipoMensagemEnum.SUCESSO);
        }
        public static void ListarTransacoes(ModelUsuario usuarioLogado){
            RepositorioTransacao repositorio = new RepositorioTransacao();
            List<ModelTransacao> listaRetornada = repositorio.Listar(usuarioLogado);
            if(listaRetornada == null){
                Mensagem.MostrarMensagem("Não há transações anteriores", TipoMensagemEnum.ALERTA);
            }else{
            foreach (var transacaoRetornada in listaRetornada)
            {
                System.Console.WriteLine("____________________________");
                System.Console.WriteLine($"Usuário: {usuarioLogado.Nome}");
                System.Console.WriteLine($"Tipo: {transacaoRetornada.Tipo}     ");
                System.Console.WriteLine($"Descrição: {transacaoRetornada.Descricao}     ");
                System.Console.WriteLine($"Valor: {transacaoRetornada.Valor}     ");
                System.Console.WriteLine($"Data: {transacaoRetornada.Data}     ");
            }
            }
        }
        public static void ComprimirExtrato(ModelUsuario usuario){
            RepositorioTransacao repositorio = new RepositorioTransacao();
            
            repositorio.Comprimir();
            Mensagem.MostrarMensagem("yay", TipoMensagemEnum.SUCESSO);
        }
        public static void GerarRelatorioTransacoes(ModelUsuario usuario){
            RepositorioTransacao repositorio = new RepositorioTransacao();
            repositorio.GerarRelatorio(usuario);
        }
    }
}