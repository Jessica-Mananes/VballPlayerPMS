using System;
using VballPMSBusinessDataLogic;
using System.Collections.Generic;

namespace VballPlayerPMS
{
    internal class Program
    {
        static PlayerService playerService = new PlayerService();

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t-------------------------- Volleyball Players Profile Management System --------------------------");

            string adminUsername = "batakmagvball";
            string adminPassword = "jess";
            string username, password;

            do
            {
                Console.Write("\nEnter username: ");
                username = Console.ReadLine();
                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (username != adminUsername || password != adminPassword)
                {
                    Console.WriteLine("\n\t********** Login ERROR: Incorrect username or password. Try again. **********");
                }
                else
                {
                    Console.WriteLine("\n\t-------------------------- LOGIN SUCCESSFUL --------------------------");
                }
            } while (username != adminUsername || password != adminPassword);

            string[] options = { "[1] Create Profile", "[2] Edit Profile", "[3] View Profile", "[4] Delete Profile", "[5] Exit Program" };
            int choice;

            do
            {
                Console.WriteLine("\n------------------------------------------------------------------------------------------------");
                Console.WriteLine("Please select an option to proceed:");

                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }

                Console.Write("\nEnter your choice: ");
                choice = Convert.ToInt16(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        CreateProfile();
                        break;
                    case 2:
                        EditProfile();
                        break;
                    case 3:
                        ViewProfile();
                        break;
                    case 4:
                        DeleteProfile();
                        break;
                    case 5:
                        Console.WriteLine("\nEXITING THE PROGRAM.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\n\t********** Invalid input: Please choose only numbers from 1-5. ********** ");
                        break;
                }

                if (choice != 5)
                {
                    Console.WriteLine("\n*Press any key to continue* ");
                    Console.ReadKey();
                }
            } while (choice != 5);
        }

        static void CreateProfile()
        {
            Console.WriteLine("\nYou selected >>> CREATE PROFILE <<< ");

            Console.Write("Enter a player name: ");
            string name = Console.ReadLine();

            int age;
            while (true)
            {
                Console.Write("Enter a player age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                    break;
                Console.WriteLine("\n\t********** ERROR: Please enter a valid age. **********\n");
            }

            Console.Write("Enter player's position: ");
            string position = Console.ReadLine();

            playerService.CreateProfile(name, age, position);
            Console.WriteLine("\n\t-------------------------- Player's Profile ADDED successfully! --------------------------\n");
        }

        static void EditProfile()
        {
            Console.WriteLine("\nYou selected >>> EDIT PROFILE <<< ");
            ViewProfile();

            Console.Write("\nEnter the index of the player to edit: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();

                int newAge;
                while (true)
                {
                    Console.Write("Enter new age: ");
                    if (int.TryParse(Console.ReadLine(), out newAge) && newAge > 0)
                        break;
                    Console.WriteLine("\n\t********** ERROR: Enter a valid age. **********\n");
                }

                Console.Write("Enter new position: ");
                string newPosition = Console.ReadLine();

                if (playerService.EditProfile(index, newName, newAge, newPosition))
                    Console.WriteLine("\n\t-------------------------- Player's profile UPDATED successfully! --------------------------\n");
                else
                    Console.WriteLine("\n\t********** ERROR: Invalid index. Profile update failed. **********\n");
            }
        }

        static void ViewProfile()
        {
            List<Player> players = playerService.GetAllProfiles();
            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available. **********");
                return;
            }
            Console.WriteLine("\n-------------------------- List of Player's Profiles --------------------------");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"[{i}] Name:{players[i].Name} | Age:{players[i].Age} | Position:{players[i].Position}");
            }
        }

        static void DeleteProfile()
        {
            Console.WriteLine("\nYou selected >>> DELETE PROFILE <<< ");
            ViewProfile();

            Console.Write("\nEnter the index of the player to delete: ");
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                if (playerService.DeleteProfile(index))
                    Console.WriteLine("\n\t-------------------------- Player's profile DELETED successfully! --------------------------\n");
                else
                    Console.WriteLine("\n\t********** ERROR: Invalid index. Deletion failed. **********\n");
            }
        }
    }
}
