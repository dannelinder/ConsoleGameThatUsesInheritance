using GameLibrary.GameBoardMembers.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers.Items
{
    class Armor : Item
    {
        public int DefenceValue { get; set; }

        public Armor(string name) : base(name)
        {
        }

        public override string GetItemString()
        {
            throw new NotImplementedException();
        }

        public override void UseItemProperty(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
