using System;
using Spectre.Console;

namespace FirstFantasy
{
    public class Encounters
    {
        private static Random rand = new Random();
        // Encontro generico
        public static void FirstEncounter()
        {
            AnsiConsole.MarkupLine("[bold yellow]Você se depara com uma porta e decide abrir ela[/]");
            Console.WriteLine("Inimigo aparece...");
            Combat(false, "Besta fera", 3, 6);
        }

        // Encontros
        // Encontro de ferramentas
        // Encontro de buff/debuff

        // Encontro de batalha
        public static void Combat(bool random, string eName, int ePower, int eHealth)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {
                // Implementar lógica de encontro aleatório
            }
            else
            {
                // 'e' is the enemy Variables
                n = eName;
                p = ePower;
                h = eHealth;
            }

            int eDamage = 0;
            int pAtk = 0;
            bool runSuccessful = false;

            while (eHealth > 0)
            {
                AnsiConsole.MarkupLine("[bold yellow]=========================[/]");
                AnsiConsole.MarkupLine("[bold yellow]|  (A)tacar  (D)efender |[/]");
                AnsiConsole.MarkupLine("[bold yellow]|  (F)ugir   (C)ura     |[/]");
                AnsiConsole.MarkupLine("[bold yellow]=========================[/]");
                AnsiConsole.MarkupLine($"Sua Vida: [green]{Game.player.Health}[/]; Poções: [cyan]{Game.player.PotionsCount}[/]");
                AnsiConsole.MarkupLine($"[bold red]Vida de {eName}: {h}[/]");

                string input = Console.ReadLine()?.ToLower() ?? "";

                switch (input)
                {
                    case "a":
                    case "atacar":
                        AnsiConsole.MarkupLine($"[bold red]{Game.player.Name} ataca {eName}![/]");

                        // Logica de dano ao atacar
                        eDamage = p - Game.player.ArmorValue;
                        eDamage = eDamage < 0 ? 0 : eDamage; 
                        pAtk = rand.Next(1, Game.player.WeaponValue) + rand.Next(1, Game.player.Damage);
                        Game.player.Health -= eDamage;
                        h -= pAtk;
                        AnsiConsole.MarkupLine($"Você causou [bold blue]{pAtk} de dano[/] ao inimigo e " +
                            $"recebeu [bold red]{eDamage} de dano de {n}[/]");

                        // Lógica adicional
                        break;

                    case "d":
                    case "defender":
                        AnsiConsole.MarkupLine($"[bold blue]{Game.player.Name} se defende![/]");

                        eDamage = (p/2) - Game.player.ArmorValue;
                        eDamage = eDamage < 0 ? 0 : eDamage;
                        pAtk = (rand.Next(0, Game.player.WeaponValue) + rand.Next(1, Game.player.Damage))/2;

                        Game.player.Health -= eDamage;
                        h -= pAtk;
                        AnsiConsole.MarkupLine($"Você recebeu {eDamage} de dano!");

                        // Lógica adicional
                        break;

                    case "f":
                    case "fugir":
                        AnsiConsole.MarkupLine($"[bold yellow]{Game.player.Name} tenta fugir![/]");

                        if(rand.Next(0, 2) == 0)
                        {
                            AnsiConsole.MarkupLine($"[bold yellow]{Game.player.Name} Não consegue fugir![/]");
                            eDamage = p - Game.player.ArmorValue;
                            eDamage = eDamage < 0 ? 0 : eDamage;
                            AnsiConsole.MarkupLine($"[bold pink]Você recebeu {eDamage} de dano de {n}![/]");;
                            continue;
                        }

                        AnsiConsole.MarkupLine($"[bold purple]{Game.player.Name} consegue fugir![/]");
                        runSuccessful = true;
                        Console.ReadKey();

                        // go to store
                        break;

                    case "c":
                    case "cura":
                        AnsiConsole.MarkupLine($"[bold green]{Game.player.Name} usa uma poção![/]");
                        if(Game.player.PotionsCount == 0)
                        {
                            AnsiConsole.MarkupLine($"[bold yeallow] Você está sem pocões no momento.");
                            AnsiConsole.MarkupLine($"{n} Ataca e você recebe {eDamage} de dano!");
                            eDamage = p - Game.player.ArmorValue;
                            eDamage = eDamage < 0 ? 0 : eDamage;
                            continue;
                        }

                        AnsiConsole.MarkupLine($"Você pega uma poção da sua bolsa e toma ela.");
                        Game.player.Health += Game.player.PotionHealValue;
                        AnsiConsole.MarkupLine($"Você recuperou {Game.player.PotionHealValue}.");
                        Game.player.PotionsCount--;
                        // Lógica adicional
                        break;

                    default:
                        AnsiConsole.MarkupLine($"[bold red]Comando inválido: {input}. Tente novamente.[/]");
                        break;
                }

                if(Game.player.Health <= 0) 
                {
                    AnsiConsole.MarkupLine($"Você foi derrotado por [bold red]{n}... :([/]");
                }

                if (runSuccessful)
                    break;

                if (eHealth <= 0)
                {
                    AnsiConsole.MarkupLine($"[bold green]Você derrotou {eName}! Parabens e siga sua jornada![/]");
                    break;
                }
            }
            if (eHealth <= 0)
            {
                AnsiConsole.MarkupLine($"[bold green]Você derrotou {eName}! Parabens e siga sua jornada![/]");
            }
        }
    }
}
