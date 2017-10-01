using GameLibrary.GameBoardMembers.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Utils;

namespace GameLibrary.GameBoardMembers.Items
{
    public class Potion : Item
    {
        public int HealValue { get; private set; }

        public Potion(/*string name, int healValue*/) : base("Potion")
        {
            if (RandomUtils.GetRandomFromPercentage(33))
            {
                HealValue = 10;
            }

            else if (RandomUtils.GetRandomFromPercentage(33))
            {
                HealValue = 15;
            }

            else
            {
                HealValue = 20;
            }

        }

        public override string GetItemString()
        {
            return $"Item:{Name}\tHealvalue:{HealValue}";
        }

        public override void UseItemProperty(Player player)
        {
            player.Health += HealValue;
        }
    }
}
