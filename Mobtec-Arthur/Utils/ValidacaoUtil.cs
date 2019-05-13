namespace Mobtec.Utils
{
    public class ValidacaoUtil
    {
        public static bool ValidadorDeEmail(string email){
            if (email.Contains("@") && email.Contains("."))
            {
                return true;
            }
            return false;
        }

        public static bool ValidadorDeSenha(string senha, string confirmaSenha){
            if (senha.Equals(confirmaSenha) && senha.Length > 5)
            {
                return true;
            }
            return false;
        }
    }
}