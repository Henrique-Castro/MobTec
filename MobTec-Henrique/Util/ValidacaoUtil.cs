using System;
namespace MobTec.Util
{
    public class ValidacaoUtil
    {
        public static bool ValidarPreco(float preco){
            if(preco != 0){
            return true;
            }else{
                return false;
            }
        }
    }
}