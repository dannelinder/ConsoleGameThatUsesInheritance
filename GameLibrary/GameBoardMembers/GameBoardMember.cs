using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.GameBoardMembers
{
    public abstract class GameBoardMember
    {
        public char DisplayChar { get; set; }

        public GameBoardMember(char memberID)
        {
            DisplayChar = memberID;
        }
    }
}
