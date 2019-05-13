using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using MobTec.Model;
using Ionic.Zip;
using SautinSoft.Document;
using SautinSoft.Document.Tables;

namespace MobTec_Henrique.Repository {
    public class RepositoryTransacao {
        List<ModelTransacao> ListaDeTransacoes = new List<ModelTransacao> ();
        public void GravarTransacao (ModelTransacao transacao) {
            ListaDeTransacoes.Add (transacao);

            var sw = new StreamWriter ("transacoes.csv");
            sw.WriteLine ($"{transacao.Tipo};{transacao.Descricao};{transacao.Data};{transacao.Valor}");
            sw.Close ();

        }
        public List<ModelTransacao> Listar () {
            if (!File.Exists ("transacoes.csv")) {
                return null;
            } else {
                string[] listaNaoTratada = File.ReadAllLines ("transacoes.csv");
                ListaDeTransacoes = new List<ModelTransacao> ();
                for (int i = 0; i < listaNaoTratada.Length; i++) {
                    string[] dados = listaNaoTratada[i].Split (';');
                    ModelTransacao transacao = new ModelTransacao (dados[0], dados[1], DateTime.Parse (dados[2]), float.Parse (dados[3]));
                    ListaDeTransacoes.Add (transacao);
                }
                return ListaDeTransacoes;
            }
        }
        public void Comprimir () {
            using(Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile()){
                zip.AddFile("transacoes.csv");
                zip.Save("banco_de_dados.zip");
            }
        }
        public void GerarRelatorio(){
            var docx = new DocumentCore();
            var section = new Section(docx);

            docx.Sections.Add(section);

            var table = new Table(docx);

            string[] listaNaoTratada = File.ReadAllLines ("transacoes.csv");
            foreach (var transacao in Listar())
            {
                if(transacao != null){
                    var linha = new TableRow(docx);
                    
                    foreach (var dado in transacao.Split(";"))
                    {
                        
                    }
                }
            }
        }
    }
}