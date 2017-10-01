using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers.Characters
{
    public abstract class Monster : Character, ICollectable
    {
        static public int MonsterCount { get; set; }

        public Monster(int health, int strength) : base(health, strength, 'M')
        {
            MonsterCount++;
        }
    }

    public class Ogre : Monster
    {
        public Ogre(int plusStrength, int plusHealth) : base(17 + plusHealth, plusStrength + 4)
        {
        }
    }

    public class Orc : Monster
    {
        public Orc(int plusStrength, int plusHealth) : base(7 + plusHealth, plusStrength + 9)
        {
        }

        public override string Attack(Character opponent)
        {
            string returnString = "";

            if (this.Strength / opponent.Strength <= 2)
            {
                returnString = "Orc died in fear";
            }

            else
            {
                base.Attack(opponent);
            }
            return returnString;
        }
    }
}
