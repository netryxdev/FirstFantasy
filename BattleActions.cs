using Spectre.Console;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFantasy
{
    public class BattleActions
    {
        private static Random rand = new Random();

        public static int PlayerAttack()
        {
            int damage = Game.player.Atk + Game.player.WeaponAtkValue + rand.Next(1, 6);

            if (rand.Next(1, 101) <= Game.player.CriticalChance)
            {
                damage = damage * 2;
                AnsiConsole.WriteLine($"[bold cyan]{Game.player.Name} causou um golpe Crítico!");
            }
            
            return damage;
        }

        public static int EnemyAttack(int enemyAtk)
        {
            int eDamage = enemyAtk - Game.player.ArmorValue;
            eDamage = eDamage < 0 ? 0 : eDamage;
            Game.player.Hp -= eDamage;
            return eDamage;
        }

        public static int DefendFromEnemyAttack(int enemyAtk)
        {
            int eDamage = (enemyAtk / 2) - Game.player.ArmorValue;
            eDamage = eDamage < 0 ? 0 : eDamage;
            Game.player.Hp -= eDamage;
            return eDamage;
        }

        public static int DefendFromPlayerAttack()
        {
            int playerDamage = (rand.Next(0, Game.player.WeaponAtkValue) + rand.Next(1, Game.player.Atk)) / 2;
            return playerDamage;
        }

        public static void PlayerUsesPotion()
        {
            AnsiConsole.MarkupLine($"Você pega uma poção da sua bolsa e toma ela.");
            Game.player.Hp += Game.player.PotionHealValue;
            AnsiConsole.MarkupLine($"Você recuperou {Game.player.PotionHealValue}.");
            Game.player.PotionsCount--;
        }

        public static void PlayerWithoutPotion(string eName, int eDamage)
        {
            AnsiConsole.MarkupLine($"[bold yeallow] Você está sem pocões no momento.");
            AnsiConsole.MarkupLine($"{eName} Ataca e você recebe {eDamage} de dano!");
        }
    }
}
