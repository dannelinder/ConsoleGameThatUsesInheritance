using GameLibrary.GameBoardMembers;
using GameLibrary.GameBoardMembers.Characters;
using GameLibrary.GameBoardMembers.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary
{
    public class BackPack
    {
        public List<Item> Items { get; set; }
        public int MaxItems { get; set; }

        public BackPack()
        {
            Items = new List<Item>();
            MaxItems = 10;
        }

        public bool AddItem(Item item)
        {
            bool itemPickedUp = false;

            int index = Items.Count();
            if (index < MaxItems)
            {
                Items.Add(item);
                itemPickedUp = true;
            }
            return itemPickedUp;

        }

        public string[] GetListOfItemsInBag()
        {
            int count = Items.Count;
            string[] returnArray = new string[count];
            int index = 0;

            foreach (var item in Items)
            {
                returnArray[index++] = item.GetItemString();
            }
            return returnArray;
        }

        public void ThrowItem(int inListIndex, Player player, Room[,] world)
        {
            int[] XandY = player.GetPosition();
            int X = XandY[0];
            int Y = XandY[1];

            if (X - 1 > 0)
            {
                world[X - 1, Y].Item = Items.ElementAt(inListIndex);
            }

            else
            {
                world[X + 1, Y].Item = Items.ElementAt(inListIndex);
            }

            Console.Clear();
            Console.WriteLine($"You through away a {Items.ElementAt(inListIndex).Name}");
            Items.RemoveAt(inListIndex);
            Console.ReadKey(true);
        }

        public virtual void UseItem(int inListIndex, Player player)
        {
            Items.ElementAt(inListIndex).UseItemProperty(player);
            Console.Clear();
            Console.WriteLine($"You used a {Items.ElementAt(inListIndex).Name}");
            Items.RemoveAt(inListIndex);
            Console.ReadKey(true);
        }

        private int GetNumberOfItems()
        {
            int numberOfItems = 0;

            foreach (var item in Items)
            {
                if (item != null)
                {
                    numberOfItems++;
                }
            }
            return numberOfItems;
        }
    }
}