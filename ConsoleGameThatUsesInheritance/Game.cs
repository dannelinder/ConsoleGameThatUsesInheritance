using GameLibrary.GameBoardMembers;
using GameLibrary.GameBoardMembers.Characters;
using GameLibrary.GameBoardMembers.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using Utilities.Utils;

namespace ConsoleGameThatUsesInheritance
{
    class Game
    {
        Player player;
        Room[,] world;

        const int gameWidth = 20;
        const int gameHeigth = 10;
        public int level = 1;
        bool newPlayer = true;
        bool displayMonsters = false;


        public void Play()
        {
            CreatePlayer();
            CreateWorld();

            if (newPlayer)
            {
                Console.Clear();
                //TextUtils.Animate("Get ready to face the horrors of Dungeons of Doom...");
            }


            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWorld();
                DisplayMonsterStats();
                AskForMovement();
            } while (player.Health > 0 && Monster.MonsterCount != 0);

            GameOver();
        }

        private void DisplayMonsterStats()
        {
            if (displayMonsters)
            {
                Console.WriteLine("\nMonsters:");
                for (int i = 0; i < gameWidth; i++)
                {
                    for (int j = 0; j < gameHeigth; j++)
                    {
                        if (world[i, j].Monster != null)
                        {
                            var monster = world[i, j].Monster;
                            Console.WriteLine($"{monster.GetType().Name}\tHealth:{monster.Health}\tStrength:{monster.Strength}");
                        }
                    }
                }
                Console.WriteLine($"\nMonsters left to kill: {Monster.MonsterCount}");
            }
        }

        void DisplayStats()
        {
            Console.WriteLine($"Level {level}");
            Console.WriteLine($"Health: {player.Health}");
            if (player.Strength != 10)
            {
                Console.WriteLine($"Strength: 10 + ({player.Strength - 10})");
            }
            else
            {
                Console.WriteLine($"Strength: 10");
            }
        }

        private void AskForMovement()
        {

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.B: DisplayBackPack(); break;
                case ConsoleKey.M: displayMonsters = !displayMonsters; break;
                default: isValidMove = false; break;
            }

            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;


                if (world[newX, newY].Monster != null)
                {
                    Console.WriteLine(world[newX, newY].Monster.Attack(player));
                    Console.ReadKey();
                    world[newX, newY].Monster = null;
                    Monster.MonsterCount--;
                }
                else if (world[newX, newY].Item != null)
                {
                    Console.WriteLine();

                    if (player.BackPack.AddItem(world[newX, newY].Item))
                    {
                        Console.WriteLine($"You picked up a {world[newX, newY].Item.Name}!");
                        world[newX, newY].Item = null;
                    }
                    else
                    {
                        Console.WriteLine($"You found a {world[newX, newY].Item.Name}, but your backpack is full!");
                    }
                    Console.ReadKey();

                }
                else
                {
                    // player.Health--;

                }

            }
        }
        private void DisplayBackPack()
        {
            if (player.BackPack.Items.Count > 0)
            {
                int inListIndex = 0;
                string[] backPackItems = player.BackPack.GetListOfItemsInBag();
                bool backPackStillOpen = true;

                while (backPackStillOpen)
                {
                    Console.Clear();
                    Console.WriteLine("Backpack:\t[C]lose backpack\n\t\t[U]se item\n\t\t[T]hrow item\n");
                    for (int i = 0; i < backPackItems.Length; i++)
                    {
                        if (i == inListIndex)
                        {
                            Console.WriteLine($"->{backPackItems[i]}");
                        }
                        else
                        {
                            Console.WriteLine(backPackItems[i]);
                        }
                    }

                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);


                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow: if (inListIndex > 0) { inListIndex--; }; break;
                        case ConsoleKey.DownArrow: if (inListIndex < backPackItems.Length - 1) { inListIndex++; }; break;
                        case ConsoleKey.C: backPackStillOpen = false; break;
                        case ConsoleKey.B: backPackStillOpen = false; break;
                        case ConsoleKey.U: player.BackPack.UseItem(inListIndex, player); backPackStillOpen = false; break;
                        case ConsoleKey.T: player.BackPack.ThrowItem(inListIndex, player, world); backPackStillOpen = false; break;

                    }
                }
            }
            else
            {
                Console.WriteLine("Your backpack is empty!");
                Console.ReadKey(true);
            }

        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write($"{player.DisplayChar}");
                    else if (room.Monster != null)
                        Console.Write($"{room.Monster.DisplayChar}");
                    else if (room.Item != null)
                        Console.Write($"{room.Item.DisplayChar}");
                    else
                        Console.Write(room.DisplayChar);
                }
                Console.WriteLine();

            }

        }

        private void GameOver()
        {
            if (Monster.MonsterCount == 0)
            {
                player.X = 0;
                player.Y = 0;
                level++;
                newPlayer = false;
                Console.Clear();
                TextUtils.Animate("You killed all monsters!");
                Console.Clear();
                TextUtils.Animate("Prepare for the next level...");
                //Console.ReadKey();
            }
            else
            {
                level = 1;
                newPlayer = true;
                player = new Player(200, 0, 0);
                Console.Clear();
                TextUtils.Animate("Game over, you died...");
                //Console.ReadKey();
            }
            Play();
        }

        private void CreateWorld()
        {
            world = new Room[gameWidth, gameHeigth];
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if (player.X != x || player.Y != y)
                    {
                        if (RandomUtils.GetRandomFromPercentage(2 + level))
                            world[x, y].Monster = new Ogre(RandomUtils.GetRandomBetween(0, 3 + level), RandomUtils.GetRandomBetween(0, 3 + level));

                        else if (RandomUtils.GetRandomFromPercentage(5))
                            world[x, y].Monster = new Orc(RandomUtils.GetRandomBetween(0, 3 + level), RandomUtils.GetRandomBetween(0, 3 + level));

                        else if (RandomUtils.GetRandomFromPercentage(2))
                            world[x, y].Item = new Potion();

                        else if (RandomUtils.GetRandomFromPercentage(2))
                            world[x, y].Item = new Weapon("Sword", RandomUtils.GetRandomBetween(0, 1 + level));
                    }
                }
            }
        }

        private void CreatePlayer()
        {
            if (newPlayer)
            {
                player = new Player(200, 0, 0);
            }

        }
    }
}