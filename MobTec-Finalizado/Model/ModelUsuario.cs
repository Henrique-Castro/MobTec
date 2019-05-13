using System;

namespace MobTec_Finalizado.Model
{
    public class ModelUsuario : ModelBase
    {
        public string  Email {get;set;}
        public string Senha {get;set;}
        public string Nome {get;set;}
        public float Saldo {get;set;}

        public ModelUsuario(){
            
        }
        public ModelUsuario(string nome, string email, string senha, float saldo){
            Nome = nome;
            Email = email;
            Senha = senha;
            Saldo = saldo;
        }
    }
}