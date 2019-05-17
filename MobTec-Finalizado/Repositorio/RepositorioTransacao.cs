using System.Collections.Generic;
using System.IO;
using MobTec_Finalizado.Controller;
using MobTec_Finalizado.Model;
using Ionic.Zip;
using Spire.Doc;
using System;

namespace MobTec_Finalizado.Repositorio
{
    public class RepositorioTransacao
    {
        List<ModelTransacao> ListaDeTransacoes = new List<ModelTransacao> ();
        public void GravarTransacao (ModelTransacao transacao) {
            ListaDeTransacoes.Add (transacao);
            var sw = new StreamWriter ("transacoes.csv", true);
            sw.WriteLine ($"{transacao.IdUsuario};{transacao.Tipo};{transacao.Descricao};{transacao.Data};{transacao.Valor}");
            sw.Close ();
        }
        public List<ModelTransacao> Listar (ModelUsuario usuarioLogado) {//TERMINAR A LIGAÇÃO DO USUÁRIO COM A TRANSAÇÃO ATRAVEZ DO ID
            if (!File.Exists ("transacoes.csv")) {
                return null;
            } else {
                string[] listaNaoTratada = File.ReadAllLines ("transacoes.csv");
                for (int i = 0; i < listaNaoTratada.Length; i++) {
                    string[] dados = listaNaoTratada[i].Split (';');
                    ModelTransacao transacao = new ModelTransacao (int.Parse(dados[0]),dados[1], dados[2], DateTime.Parse (dados[3]), float.Parse (dados[4]));
                    ListaDeTransacoes.Add (transacao);
                }
                return ListaDeTransacoes;
            }
        }
        public void Comprimir () {
            using (Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile ()) {
                zip.AddFile ("transacoes.csv");
                zip.Save ("banco_de_dados.zip");
            }
        }
        public List<ModelTransacao> BuscarTransacaoPorUsuario(ModelUsuario usuario){
            ListaDeTransacoes = Listar(usuario);
            List<ModelTransacao> listaDeTransacoesDoUsuario = new List<ModelTransacao>();
            foreach (var transacao in ListaDeTransacoes)
            {
                
                if(transacao != null && transacao.IdUsuario == usuario.IdUsuario){
                    listaDeTransacoesDoUsuario.Add(transacao);
                    continue;
                }else{
                    return null;
                }
            }
            return listaDeTransacoesDoUsuario;
        }
        public bool GerarRelatorio (ModelUsuario usuario) {
            if (!File.Exists ("transacoes.csv")) {
                return false;
            } else {
                var doc = new Document ();

                Section sessao = doc.AddSection ();

                var paragrafo = sessao.AddParagraph();

                paragrafo.AppendText ("Relatório\n");

                string[] listaNaoTratada = File.ReadAllLines ("transacoes.csv");
                for (int i = 0; i < listaNaoTratada.Length; i++) {
                    string[] dados = listaNaoTratada[i].Split (';');
                    if(int.Parse(dados[0]) == usuario.IdUsuario){
                    paragrafo.AppendText ($"\nUsuário: {usuario.Nome}\nTipo de transação: {dados[1]}\nDescrição: {dados[2]}\nData e hora: {dados[3]}\nValor: R${dados[4]}");
                    }
                    else{
                        continue;
                    }
                }

                doc.SaveToFile ($"Relatorio_{usuario.Nome}.docx", FileFormat.Docx);
                return true;
            }
        }
    }
}