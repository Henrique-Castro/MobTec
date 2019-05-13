using System;
using System.Collections.Generic;
using System.IO;
using MobTec_Finalizado.Model;

namespace MobTec_Finalizado.Repositorio
{
    public class RepositorioUsuario
    {
        public List<ModelUsuario> listaDeUsuarios;

         public ModelUsuario Inserir(ModelUsuario usuario) {
            //listaDeUsuarios.Add (usuario);

            StreamWriter sw = new StreamWriter ("usuario.csv", true);
            sw.WriteLine ($"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento};{usuario.Saldo}");
            sw.Close ();
            return usuario;
         }
        public List<ModelUsuario> Listar () {
            List<ModelUsuario> listaDeUsuarios = new List<ModelUsuario> ();
            ModelUsuario usuario;

            if (!File.Exists ("usuario.csv")) {
                return null;
            }

            string[] ususarios = File.ReadAllLines ("usuario.csv");

            foreach (var item in ususarios) {
                if (item != null) {

                    string[] dadosDoUsuario = item.Split (";");
                    usuario = new ModelUsuario ();
                    usuario.Nome = dadosDoUsuario[0];
                    usuario.Email = dadosDoUsuario[1];
                    usuario.Senha = dadosDoUsuario[2];
                    usuario.DataNascimento = DateTime.Parse (dadosDoUsuario[3]);
                    usuario.Saldo = int.Parse(dadosDoUsuario[4]);

                    listaDeUsuarios.Add (usuario);
                }
            }
            return listaDeUsuarios;
        }
        public ModelUsuario BuscarUsuario (string email, string senha) {
            List<ModelUsuario> listaDeUsuarios = Listar();

            foreach (var item in listaDeUsuarios) {
                if (item != null) {
                    if (email.Equals (item.Email) && senha.Equals (item.Senha)) {
                        return item;
                    }
                }
            }
            return null;
        }
    }
}