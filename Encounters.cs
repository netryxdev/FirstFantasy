using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFantasy
{
    public class Encounters
    {
        // Encontro generico

        //Encontros
        public static void FirstEncounter()
        {
            Console.WriteLine("Você se depara com uma porta e decide abrir ela");
        }

        //Encontro de ferramentas

        // Encontro de buff/debuff

        // encontro de batalha
        public static void Combat(bool random, string name, int power, int health)
        {
            string n = "";
            int p = 0;
            int h = 0;

            if (random)
            {

            }
            else
            {

            }

            while (health > 0)
            {
                Console.WriteLine("=========================");
                Console.WriteLine("|  (A)tacar  (D)efender |");
                Console.WriteLine("|  (F)ugir   (C)ura     |");
                Console.WriteLine("=========================");
                Console.WriteLine($"Vida: {Game.player.Health}; Poções: {Game.player.potion};");

                string input = Console.ReadLine() ?? "";
                input.ToLower();

                switch (input)
                {
                    case "a":
                    case "atacar":
                        Console.WriteLine($"{Game.player.Name} ataca o inimigo!");
                        // Logica adicional
                        break;

                    case "d":
                    case "defender":
                        Console.WriteLine($"{Game.player.Name} se defende!");
                        // Logica adicional
                        break;

                    case "f":
                    case "fugir":
                        Console.WriteLine($"{Game.player.Name} tenta fugir!");
                        // Logica adicional
                        break;

                    case "c":
                    case "cura":
                        Console.WriteLine($"{Game.player.Name} usa uma poção!");
                        // Logica adicional
                        break;

                    default:
                        Console.WriteLine(Generic.inputIsNullOrEmptyCommand(input));
                        break;
                }
            }

        }
    }
}
