using System;
namespace Mobtec.Utils {
    public class ValidacaoUtil {
        public static bool ValidadorDeEmail (string email) {
            if (email.Contains ("@") && email.Contains (".")) {
                return true;
            }
            return false;
        }

        public static bool ValidadorDeSenha (string senha, string confirmaSenha) {
            if (senha.Equals (confirmaSenha) && senha.Length > 5) {
                return true;
            }
            return false;
        }
        public static bool ValidarPreco (float preco) {
            if (preco != 0) {
                return true;
            } else {
                return false;
            }
        }
        public static bool ValidarData(string data, out DateTime dateTime){
            if(DateTime.TryParse(data, out dateTime) == true){
                DateTime.TryParse(data, out dateTime);
                return true;
            }else{
                return false;
            }
        }
        public static bool ValidarSaldo(string saldoCapturado, string confirmSaldo,out float saldo){
            if(float.TryParse(saldoCapturado,out saldo) == true && saldoCapturado.Equals(confirmSaldo)){
                return true;
            }else{
                return false;
            }
        } 
    }
}