using GameLibrary.GameBoardMembers.Characters;
using GameLibrary.GameBoardMembers.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers
{
    public class Room : GameBoardMember
    {
        public Monster Monster { get; set; }
        public Item Item { get; set; }
        //public Potion Potion { get; set; }
        //public Sword Sword { get; set; }

        public Room() : base('.')
        {

        }
    }
}
