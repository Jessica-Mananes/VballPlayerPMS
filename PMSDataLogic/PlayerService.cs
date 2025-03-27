using System;
using System.Collections.Generic;

namespace PMSDataLogic
{
    public class PlayerService
    {
        private readonly List<Player> players = new();

        public void AddPlayer(string name, int age, string position)
        {
            players.Add(new Player(name, age, position));
            Console.WriteLine("\n\t-------------------------- Player's Profile ADDED successfully! --------------------------\n");
        }

        public void EditPlayer(int index, string name, int age, string position)
        {
            if (index < 0 || index >= players.Count)
            {
                Console.WriteLine("\n\t********** ERROR: Invalid index. ****");
                return;
            }

            players[index].Name = name;
            players[index].Age = age;
            players[index].Position = position;

            Console.WriteLine("\n\t-------------------------- Player's profile UPDATED successfully! --------------------------\n");
        }

        public void DeletePlayer(int index)
        {
            if (index < 0 || index >= players.Count)
            {
                Console.WriteLine("\n\t********** ERROR: Invalid index. ****");
                return;
            }

            players.RemoveAt(index);
            Console.WriteLine("\n\t-------------------------- Player's profile DELETED successfully! --------------------------\n");
        }

        public void ViewPlayers()
        {
            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available. ****");
                return;
            }

            Console.WriteLine("\n-------------------------- List of Player's Profiles --------------------------");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"[{i}] Name: {players[i].Name} | Age: {players[i].Age} | Position: {players[i].Position}");
            }
        }

        public int GetPlayerCount() => players.Count;
    }
}