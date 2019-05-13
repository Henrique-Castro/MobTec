using System;
using System.Collections.Generic;
using MobTec.Model;
using MobTec.Util;
using MobTec.Util.EnumUtil;
using MobTec_Henrique.Repository;

namespace MobTec.Controller {
    public class ControllerTransacao {

        public static void CadastrarTransacao () {
            RepositoryTransacao repository = new RepositoryTransacao ();
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
            ModelTransacao transacao = new ModelTransacao (tipo, descricao, valor);
            repository.GravarTransacao (transacao);
            Mensagem.MostrarMensagem ("Transação registrada com sucesso.", TipoMensagemEnum.SUCESSO);
        }
        public static void ListarTransacoes(){
            RepositoryTransacao repository = new RepositoryTransacao();
            List<ModelTransacao> listaRetornada = repository.Listar();
            if(listaRetornada == null){
                Mensagem.MostrarMensagem("Não há transações anteriores", TipoMensagemEnum.ALERTA);
            }else{
            foreach (var transacaoRetornada in listaRetornada)
            {
                System.Console.WriteLine("____________________________");
                System.Console.WriteLine($"Tipo: {transacaoRetornada.Tipo}     ");
                System.Console.WriteLine($"Descrição: {transacaoRetornada.Descricao}     ");
                System.Console.WriteLine($"Valor: {transacaoRetornada.Valor}     ");
                System.Console.WriteLine($"Data: {transacaoRetornada.Data}     ");
            }
            }
        }
        public static void ComprimirExtrato(){
            RepositoryTransacao repository = new RepositoryTransacao();
            repository.Comprimir();
            Mensagem.MostrarMensagem("yay", TipoMensagemEnum.SUCESSO);
        }
        public static void GerarRelatorioTransacoes(){
            RepositoryTransacao repository = new RepositoryTransacao();
            repository.GerarRelatorio();
        }
    }
}