using System;
using System.Collections.Generic;
using System.IO;
using Mobtec.ViewModel;

namespace Mobtec.Repositorio {
    public class UsuarioRepositorio {
        public List<UsuarioViewModel> listaDeUsuarios;

         public UsuarioViewModel Inserir(UsuarioViewModel usuario) {
            //listaDeUsuarios.Add (usuario);

            StreamWriter sw = new StreamWriter ("usuario.csv", true);
            sw.WriteLine ($"{usuario.Nome};{usuario.Email};{usuario.Senha};{usuario.DataNascimento};{usuario.Saldo}");
            sw.Close ();
            return usuario;
         }
        public List<UsuarioViewModel> Listar () {
            List<UsuarioViewModel> listaDeUsuarios = new List<UsuarioViewModel> ();
            UsuarioViewModel usuario;

            if (!File.Exists ("usuario.csv")) {
                return null;
            }

            string[] ususarios = File.ReadAllLines ("usuario.csv");

            foreach (var item in ususarios) {
                if (item != null) {

                    string[] dadosDoUsuario = item.Split (";");
                    usuario = new UsuarioViewModel ();
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
        public UsuarioViewModel BuscarUsuario (string email, string senha) {
            List<UsuarioViewModel> listaDeUsuarios = Listar();

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