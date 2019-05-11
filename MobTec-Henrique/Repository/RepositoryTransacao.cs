using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.IO.Packaging;
using MobTec.Model;
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
            FileStream arquivoFonte = File.OpenRead("transacoes.csv");
            FileStream arquivoDestino = File.Create("banco_de_dados" + ".zip");
            byte[] buffer = new byte[arquivoFonte.Length]; //https://stackoverflow.com/questions/11153542/how-to-compress-files
            arquivoFonte.Read(buffer, 0, buffer.Length);

            GZipStream gZipStream = new GZipStream(arquivoDestino, CompressionMode.Compress);

            arquivoFonte.Close();
            arquivoDestino.Close();
        }
    }
}