using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFantasy
{
    public class EnemyActions
    {
        private static Random rand = new();

        public void EnemyTurn(Enemy e)
        {
            float healthRatio = (float)e.Hp / e.MaxHp;
            float playerHealthRatio = (float)Game.player.Hp/ Game.player.MaxHp;

            if (healthRatio < 0.3f && e.PotionsCount > 0)
            {
                EnemyUsesPotion(e);
            }
            else if (playerHealthRatio < 0.3f)
            {
                EnemyAttack(e.Atk);
            }
            else
            {
                DefendFromPlayerAttack();
            }
        }

        public static int EnemyAttack(int enemyAtk)
        {
            int eDamage = enemyAtk - Game.player.ArmorValue;
            eDamage = eDamage < 0 ? 0 : eDamage;
            Game.player.Hp -= eDamage;
            return eDamage;
        }

        public static int DefendFromPlayerAttack()
        {
            int playerDamage = (rand.Next(0, Game.player.WeaponAtkValue) + rand.Next(1, Game.player.Atk)) / 2;
            return playerDamage;
        }

        public static void EnemyUsesPotion(Enemy e)
        {
            AnsiConsole.MarkupLine($" {e.Name}pega uma poção da sua bolsa e toma ela.");
            Game.player.Hp += Game.player.PotionHealValue;
            AnsiConsole.MarkupLine($"{e.Name} recuperou {Game.player.PotionHealValue}.");
            Game.player.PotionsCount--;
        }
    }
}
