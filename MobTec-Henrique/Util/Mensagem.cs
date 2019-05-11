using System;
using MobTec.Util.EnumUtil;

namespace MobTec.Util {
    public class Mensagem {
        public static void MostrarMensagem (string mensagem, TipoMensagemEnum tipoMensagem) {
            switch (tipoMensagem) {
                case TipoMensagemEnum.ALERTA:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case TipoMensagemEnum.ERRO:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case TipoMensagemEnum.SUCESSO:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
            System.Console.WriteLine(mensagem);
            Console.ResetColor ();
        }
    }
}