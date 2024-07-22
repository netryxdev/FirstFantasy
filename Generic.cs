using System;

namespace FirstFantasy
{
    public class Generic
    {
        public static string inputIsNullOrEmptyInBattle(string input)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return "Digite a letra inicial do comando ou o comando inteiro para prosseguir!";
            }
            return "";
        }
    }
}
