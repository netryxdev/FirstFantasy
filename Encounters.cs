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
        public static void Combat(bool random, string enemyName, int enemyPower, int enemyHealth)
        {
            string eName = "";
            int ePower = 0;
            int eHealth = 0;

            if (random)
            {
                // Implementar lógica de encontro aleatório
            }
            else
            {
                eName = enemyName;
                ePower = enemyPower;
                eHealth = enemyHealth;
            }

            int eDamage = 0;
            int pAtk = 0;
            bool runSuccessful = false;

            while (h > 0)
            {
                Console.Clear();
                AnsiConsole.MarkupLine($"Sua Vida: [green]{Game.player.Health}[/]; Poções: [cyan]{Game.player.PotionsCount}[/]");
                AnsiConsole.MarkupLine($"[bold red]{eName}: Vida: {h} / Dano: {p}[/]");

                AnsiConsole.MarkupLine("[bold yellow]=========================[/]");
                AnsiConsole.MarkupLine("[bold yellow]|  (A)tacar  (D)efender |[/]");
                AnsiConsole.MarkupLine("[bold yellow]|  (F)ugir   (C)ura     |[/]");
                AnsiConsole.MarkupLine("[bold yellow]=========================[/]");

                string input = Console.ReadLine()?.ToLower() ?? "";

                switch (input)
                {
                    case "a":
                    case "atacar":
                        AnsiConsole.MarkupLine($"[bold red]{Game.player.Name} ataca {eName}![/]");

                        // Logica de dano ao atacar
                        eDamage = ePower - Game.player.ArmorValue;
                        eDamage = eDamage < 0 ? 0 : eDamage; 
                        pAtk = rand.Next(1, Game.player.WeaponValue) + rand.Next(1, Game.player.Damage);
                        Game.player.Health -= eDamage;
                        enemyHealth -= pAtk;
                        AnsiConsole.MarkupLine($"Você causou [bold blue]{pAtk} de dano[/] ao inimigo e " +
                            $"recebeu [bold red]{eDamage} de dano de {eName}[/]");

                        // Lógica adicional
                        break;

                    case "d":
                    case "defender":
                        AnsiConsole.MarkupLine($"[bold blue]{Game.player.Name} se defende![/]");

                        eDamage = (ePower/2) - Game.player.ArmorValue;
                        eDamage = eDamage < 0 ? 0 : eDamage;
                        pAtk = (rand.Next(0, Game.player.WeaponValue) + rand.Next(1, Game.player.Damage))/2;

                        Game.player.Health -= eDamage;
                        enemyHealth -= pAtk;
                        AnsiConsole.MarkupLine($"Você recebeu {eDamage} de dano!");

                        // Lógica adicional
                        break;

                    case "f":
                    case "fugir":
                        AnsiConsole.MarkupLine($"[bold yellow]{Game.player.Name} tenta fugir![/]");

                        if(rand.Next(0, 2) == 0)
                        {
                            AnsiConsole.MarkupLine($"[bold yellow]{Game.player.Name} Não consegue fugir![/]");
                            eDamage = enemyPower - Game.player.ArmorValue;
                            eDamage = eDamage < 0 ? 0 : eDamage;
                            AnsiConsole.MarkupLine($"[bold pink]Você recebeu {eDamage} de dano de {enemyName}![/]");;
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
                            AnsiConsole.MarkupLine($"{enemyName} Ataca e você recebe {eDamage} de dano!");
                            eDamage = enemyPower - Game.player.ArmorValue;
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
                    AnsiConsole.MarkupLine($"Você foi derrotado por [bold red]{enemyName}... :([/]");
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
