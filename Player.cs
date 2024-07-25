using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFantasy
{
    public class Player
    {
        public string Name { get; set; } = "";
        public int Health { get; set; } = 10;
        public int Coins { get; set; } = 0;
        public int Damage { get; set; } = 1;
        public int ArmorValue { get; set; } = 0;
        public int PotionsCount { get; set; } = 5;
        public int PotionHealValue { get; set; } = 2;
        public int WeaponValue { get; set; } = 1;
    }
}
