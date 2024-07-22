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
        public int Health = 10;
        public int Coins = 0;
        public int Damage = 1;
        public int ArmorValue = 0;
        public int potion = 5;

        //public Player(string name)
        //{
        //    Name = name;
        //}
    }
}
