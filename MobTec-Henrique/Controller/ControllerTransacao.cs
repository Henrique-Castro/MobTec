using System;
using System.ComponentModel;
using MobTec.Model;

namespace MobTec.Controller {
    public class ControllerTransacao {
        public static void CadastrarTransacao () {
            string tipo, descricao;
            float valor;
            do {
                System.Console.Write ("Tipo de transação: ");
                tipo = Console.ReadLine ();
                if (String.IsNullOrEmpty (tipo)) {
                    System.Console.WriteLine ("Este campo não pode ficar vazio.");
                }
            } while (String.IsNullOrEmpty (tipo));
            do {
                System.Console.Write ("Descrição: ");
                descricao = Console.ReadLine ();
            } while (descricao == null);
            do {
                System.Console.Write ("Valor: ");
                valor = float.Parse (Console.ReadLine ());
            } while (valor == 0 || valor == null);

            ModelTransacao transacao = new ModelTransacao (tipo, descricao, valor);

        }
    }
}