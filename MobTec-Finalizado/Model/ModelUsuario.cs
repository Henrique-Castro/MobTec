using System;

namespace MobTec_Finalizado.Model
{
    public class ModelUsuario
    {
        public string  Email {get;set;}
        public string Senha {get;set;}
        public string Nome {get;set;}
        public DateTime DataNascimento {get;set;}
        public float Saldo {get;set;}
    }
}