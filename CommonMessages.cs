using Spectre.Console;
using System;
using System.Xml.Linq;

namespace FirstFantasy
{
    public class CommonMessages
    {
        public static string inputIsNullOrEmptyCommand(string input)
        {
            if(string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                return "Digite a letra inicial do comando ou o comando inteiro para prosseguir!";
            }
            return "";
        }

        public static void YouDiedMessage(string eName)
        {
            AnsiConsole.MarkupLine($"Você foi [bold red]DERROTADO[/] por [bold red]{eName}... :([/]");
        }

        public static void YouDefeatedEnemy(string eName)
        {
            AnsiConsole.MarkupLine($"[bold green]Você derrotou {eName}! Parabens e siga sua jornada![/]");
        }

        public static void ClearBattleMessagesAfterBattle()
        {
            Console.WriteLine("Aperte alguma tecla para prosseguir e limpar o texto do histórico de batalha...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
