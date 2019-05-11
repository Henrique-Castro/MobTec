using System;
using MobTec.View;

namespace MobTec.Model
{
    public class ModelTransacao : IDebito, ICredito
    {
        public string Tipo, Descricao;
        public DateTime Data;
        public float Valor;

        public ModelTransacao(){

        }
        public ModelTransacao(string tipo, string descricao, float valor){
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
            Data = DateTime.Now;
        }
        public ModelTransacao(string tipo, string descricao, DateTime data, float valor){
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }
        
        public bool Creditar(float valor)
        {
            System.Console.WriteLine($"Você recebeu R${valor}.");
            return true;
        }

        public bool Debitar(float valor)
        {
            System.Console.WriteLine($"Você gastou R${valor}.");
            return true;
        }
    }
}