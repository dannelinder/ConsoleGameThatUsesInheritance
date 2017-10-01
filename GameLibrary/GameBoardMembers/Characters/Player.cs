using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers.Characters
{
    public class Player: Character
    {
        public int X { get; set; }
        public int Y { get; set; }
        public BackPack BackPack { get; set; }

        public Player(int health, int x, int y): base(health, 10, 'P')
        {
            X = x;
            Y = y;
            BackPack = new BackPack();
        }

        public int[] GetPosition()
        {
            return new int[] { X, Y };
        }
    }
}
