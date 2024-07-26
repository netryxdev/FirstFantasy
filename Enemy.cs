using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstFantasy
{
    public class Enemy
    {
        public string Name { get; set; } = "";
        public int MaxHp { get; set; } = 0;
        public int Hp { get; set; } = 0;
        public int Atk { get; set; } = 0;
        public int ArmorValue { get; set; } = 0;
        public int PotionsCount { get; set; } = 0;
        public int PotionHealValue { get; set; } = 0;
    }
}
