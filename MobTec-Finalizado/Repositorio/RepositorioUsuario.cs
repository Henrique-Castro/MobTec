using System;
using System.Collections.Generic;
using System.IO;
using MobTec_Finalizado.Model;

namespace MobTec_Finalizado.Repositorio {
    public class RepositorioUsuario {
        public List<ModelUsuario> ListaDeUsuarios;

        public ModelUsuario Inserir (ModelUsuario usuario) {
            List<ModelUsuario> listaDeUsuarios = Listar ();
            usuario.IdUsuario = listaDeUsuarios.Count + 1;

            ListaDeUsuarios.Add (usuario);

            StreamWriter sw = new StreamWriter ("usuario.csv", true);
            sw.WriteLine ($"{usuario.IdUsuario};{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.Data};{usuario.Saldo}");
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
                    usuario.IdUsuario = int.Parse (dadosDoUsuario[0]);
                    usuario.Nome = dadosDoUsuario[1];
                    usuario.Email = dadosDoUsuario[2];
                    usuario.Senha = dadosDoUsuario[3];
                    usuario.Data = DateTime.Parse (dadosDoUsuario[4]);
                    usuario.Saldo = float.Parse (dadosDoUsuario[5]);

                    listaDeUsuarios.Add (usuario);
                }
            }
            ListaDeUsuarios = listaDeUsuarios;
            return listaDeUsuarios;
        }
        public ModelUsuario Login (string email, string senha) {
            List<ModelUsuario> listaDeUsuarios = Listar ();

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