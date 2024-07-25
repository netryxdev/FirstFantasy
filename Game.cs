using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Numerics;
using Spectre.Console;
using System.Xml.Linq;

namespace FirstFantasy
{
    public class Game
    {
        public static Player player = new Player();
        private const string SaveFile = "savegame.json";

        public void Start() 
        {
            if (File.Exists(SaveFile))
            {
                //LoadGame();
            }
            else
            {
                AnsiConsole.MarkupLine("[bold yellow]=======================[/]");
                AnsiConsole.MarkupLine("|  FirstFantasy v0.1! |");
                AnsiConsole.MarkupLine("[bold yellow]=======================[/]");
                Console.WriteLine(" ");
                Console.WriteLine("Vamos iniciar a aventura! Digite seu nome: ");
                player.Name = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrEmpty(player.Name))
                {
                    Console.WriteLine("Parece que você não se lembra do próprio nome... " +
                        "Será que bateu a cabeça muito forte? ou seria um problema de memória?");
                    Console.WriteLine("Vamos tentar mais uma vez... Digite seu nome: ");

                    player.Name = Console.ReadLine() ?? string.Empty;

                    if (string.IsNullOrEmpty(player.Name))
                    {
                        Console.WriteLine("Já que você não consegue se lembrar, vou te dar um apelido.");
                        Console.WriteLine("Seu nome será Kurosawa!");
                        player.Name = "Kurosawa";
                    }
                }

                Console.WriteLine($"Olá, {player.Name}! Sua aventura começa agora.");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Você acorda num lugar escuro, não lembra como chegou aqui...");
                Console.WriteLine("Há uma porta na sua frente");
                Encounters.FirstEncounter();
                AnsiConsole.MarkupLine($"[bold green]Fim da batalha![/]");
            }
        }

        private void MainLoop()
        {
            bool playing = true;
            while (playing)
            {
                Console.WriteLine("O que você quer fazer?");
                Console.WriteLine("1. Explorar");
                Console.WriteLine("2. Salvar e Sair");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Explore();
                        break;
                    case "2":
                        SaveGame();
                        playing = false;
                        break;
                    default:
                        Console.WriteLine("Escolha inválida.");
                        break;
                }
            }
        }

        private void Explore()
        {
            Console.WriteLine("Você explora a área e encontra um monstro!");
            // Adicione mais lógica aqui
        }

        public void SaveGame()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(player, options);
            File.WriteAllText(SaveFile, jsonString);
            Console.WriteLine("Jogo salvo.");
        }

        public void LoadGame()
        {
            string jsonString = File.ReadAllText(SaveFile);
            player = JsonSerializer.Deserialize<Player>(jsonString);
            Console.WriteLine("Jogo carregado.");
        }
    }
}
