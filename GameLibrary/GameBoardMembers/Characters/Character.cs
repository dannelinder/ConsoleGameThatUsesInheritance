using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers.Characters
{
    public abstract class Character : GameBoardMember
    {
        public int Health { get; set; }
        public int Strength { get; set; }

        public Character(int health, int strength, char memberID) : base(memberID)
        {
            Strength = strength;
            Health = health;
        }

        public virtual string Attack(Character opponent)
        {
            string returnString = "";

            bool isStillFighting = true;
            bool thisTurn = true;

            while (isStillFighting)
            {
                if (thisTurn)
                {
                    opponent.Health -= this.Strength;
                    if (opponent.Health <= 0)
                    {
                        returnString = "You lost this fight!";
                        isStillFighting = false;
                    }
                    thisTurn = false;
                }
                else
                {
                    this.Health -= opponent.Strength;
                    if (this.Health <= 0)
                    {
                        returnString = "You won this fight!!";
                        isStillFighting = false;
                    }

                    thisTurn = true;
                }
            }
            return returnString;
        }
    }
}
