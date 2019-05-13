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
            sw.WriteLine ($"{transacao.Tipo};{transacao.Descricao};{transacao.Data};{transacao.Valor}");
            sw.Close ();

        }
        public List<ModelTransacao> Listar () {
            if (!File.Exists ("transacoes.csv")) {
                return null;
            } else {
                string[] listaNaoTratada = File.ReadAllLines ("transacoes.csv");
                for (int i = 0; i < listaNaoTratada.Length; i++) {
                    string[] dados = listaNaoTratada[i].Split (';');
                    ModelTransacao transacao = new ModelTransacao (dados[0], dados[1], DateTime.Parse (dados[2]), float.Parse (dados[3]));
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
        public bool GerarRelatorio () {
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
                    
                    paragrafo.AppendText ($"\n\nTipo de transação: {dados[0]}\nDescrição: {dados[1]}\nData e hora: {dados[2]}\nValor: {dados[3]}");
                }

                doc.SaveToFile ("Relatorio.docx", FileFormat.Docx);
                return true;
            }

        }
    }
}