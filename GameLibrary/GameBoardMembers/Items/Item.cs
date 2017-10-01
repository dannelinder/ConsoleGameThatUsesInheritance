using GameLibrary.GameBoardMembers.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers.Items
{
    public abstract class Item : GameBoardMember, ICollectable
    {
        public string Name { get; private set; }

        public Item(string name) : base('I')
        {
            Name = name;
        }

        public abstract string GetItemString();
        public abstract void UseItemProperty(Player player);

    }
}
