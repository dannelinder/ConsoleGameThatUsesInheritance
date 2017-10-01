using GameLibrary.GameBoardMembers.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers.Items
{
    public class Weapon : Item
    {
        public int DamageValue { get; set; }

        public Weapon(string name, int damageValue) : base(name)
        {
            DamageValue = damageValue + 2;
        }

        public override string GetItemString()
        {
            return $"Item:{Name}\tDamagevalue:{DamageValue}";
        }

        public override void UseItemProperty(Player player)
        {
            player.Strength = 10 + DamageValue;
        }

    }
}
