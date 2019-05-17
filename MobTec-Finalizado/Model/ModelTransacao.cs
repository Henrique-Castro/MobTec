using System;

namespace MobTec_Finalizado.Model
{
    public class ModelTransacao : ModelBase
    {
        public string Tipo, Descricao;
        public float Valor;

        public ModelTransacao(){

        }
        public ModelTransacao(int idUsuario,string tipo, string descricao, float valor){
            IdUsuario = idUsuario;
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
            Data = DateTime.Now;
        }
        public ModelTransacao(int idUsuario, string tipo, string descricao, DateTime data, float valor){
            Tipo = tipo;
            Descricao = descricao;
            Valor = valor;
            Data = data;
        }
    }
}