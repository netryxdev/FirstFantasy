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
            Enemy bestaFera = new Enemy
            {
                Name = "Besta fera",
                MaxHp = 20,
                Hp = 10,
                Atk = 3,
                ArmorValue = 1,
                PotionsCount = 1,
                PotionHealValue = 3
            };

            Combat(false, bestaFera);
        }

        // Encontros
        // Encontro de ferramentas
        // Encontro de buff/debuff

        // Encontro de batalha
        public static void Combat(bool random, Enemy e)
        {
            string eName = "";
            int eAtk = 0;
            int eHealth = 0;

            if (random)
            {
                // Implementar lógica de encontro aleatório
            }
            else
            {
                eName = e.Name;
                eAtk = e.Atk;
                eHealth = e.MaxHp;
            }

            int eDamage = 0;
            int playerDamage = 0;
            bool runSuccessful = false;

            while (eHealth > 0)
            {
                AnsiConsole.MarkupLine($"Sua Vida: [green]{Game.player.Hp}[/]; Poções: [cyan]{Game.player.PotionsCount}[/]");
                AnsiConsole.MarkupLine($"[bold red]{eName}: Vida: {eHealth} / Dano: {eAtk}[/]");// separar os status para liha de baixo

                AnsiConsole.MarkupLine("[bold yellow]=========================[/]");
                AnsiConsole.MarkupLine("[bold yellow]|  (A)tacar  (D)efender |[/]");
                AnsiConsole.MarkupLine("[bold yellow]|  (F)ugir   (C)ura     |[/]");
                AnsiConsole.MarkupLine("[bold yellow]=========================[/]");

                string input = Console.ReadLine()?.ToLower() ?? "";

                switch (input)
                {
                    case "a":
                    case "atacar":
                        Console.Clear();
                        AnsiConsole.MarkupLine($"[bold red]{Game.player.Name} ataca {eName}![/]");

                        // Atk do player
                        playerDamage = BattleActions.PlayerAttack();
                        eHealth -= playerDamage;

                        //Atk do inimigo
                        eDamage = EnemyActions.EnemyAttack(eAtk);

                        AnsiConsole.MarkupLine($"Você causou [bold blue]{playerDamage} de dano[/] a {eName} e " +
                        $"recebeu [bold red]{eDamage} de dano de {eName}[/]");
                        Console.WriteLine("");
                        break;

                    case "d":
                    case "defender":
                        Console.Clear();
                        AnsiConsole.MarkupLine($"[bold blue]{Game.player.Name} se defende![/]");

                        eDamage = BattleActions.DefendFromEnemyAttack(e.Atk);
                        playerDamage = EnemyActions.DefendFromPlayerAttack();

                        eHealth -= playerDamage;
                        AnsiConsole.MarkupLine($"Você recebeu {eDamage} de dano!");

                        Console.WriteLine("");
                        break;

                    case "f":
                    case "fugir":
                        Console.Clear();
                        AnsiConsole.MarkupLine($"[bold yellow]{Game.player.Name} tenta fugir![/]");

                        if(rand.Next(0, 2) == 0)
                        {
                            AnsiConsole.MarkupLine($"[bold yellow]{Game.player.Name} Não consegue fugir![/]");
                            eDamage = EnemyActions.EnemyAttack(e.Atk);
                            AnsiConsole.MarkupLine($"[bold pink]Você recebeu {eDamage} de dano de {e.Name}![/]");;
                            break;
                        }

                        AnsiConsole.MarkupLine($"[bold purple]{Game.player.Name} consegue fugir![/]");
                        runSuccessful = true;
                        Console.ReadKey();

                        Console.WriteLine("");
                        // go to store
                        break;

                    case "c":
                    case "cura":
                        Console.Clear();
                        AnsiConsole.MarkupLine($"[bold green]{Game.player.Name} usa uma poção![/]");
                        if(Game.player.PotionsCount == 0)
                        {
                            eDamage = EnemyActions.EnemyAttack(e.Atk);
                            BattleActions.PlayerWithoutPotion(eName, eDamage);
                            break;
                        }

                        BattleActions.PlayerUsesPotion();
                        Console.WriteLine("");
                        break;

                    default:
                        AnsiConsole.MarkupLine($"[bold red]Comando inválido: {input}. Escolha um dos 4 comandos acima.[/]");
                        Console.WriteLine("");
                        break;
                }

                if(Game.player.Hp <= 0) 
                {
                    CommonMessages.YouDiedMessage(e.Name);
                }

                if (runSuccessful)
                    break;
            }
            if (eHealth <= 0)
            {
                // Ajustar mensagem aqui futuramente para ganhar XP ou Itens!
                CommonMessages.YouDefeatedEnemy(eName);
                CommonMessages.ClearBattleMessagesAfterBattle();
            }
        }
    }
}
