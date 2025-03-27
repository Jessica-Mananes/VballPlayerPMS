﻿using System;
using System.Collections.Generic;

namespace VballPlayerPMS
{
    internal class Program
    {
        static List<PlayerName> players = new List<PlayerName>();

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t-------------------------- Volleyball Players Profile Management System --------------------------");

            string adminUsername = "batakmagvball";
            string adminPassword = "jess";
            string username, password;

            do// DO-WHILE LOOP FOR LOGGING IN

            {
                Console.Write("\nEnter username: ");
                username = Console.ReadLine();

                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (username != adminUsername || password != adminPassword)
                {
                    Console.WriteLine("\n\t********** Login ERROR: Incorrect username or password. Please try again. ********");
                }
                else
                {
                    Console.WriteLine("\n\t-------------------------- LOGIN SUCCESSFUL --------------------------");
                }
            } while (username != adminUsername || password != adminPassword);

            // MENU OPTIONS
            string[] options = { "[1] Create Profile", "[2] Edit Profile", "[3] View Profile", "[4] Delete Profile", "[5] Exit Program" };
            int choice;

            //DO-WHILE FOR SELECTING OPTIONS, IF OPTION 5 IS NOT SELECTED THE LOOP WILL CONTINUE TO EXECUTE.
            do
            {
                Console.WriteLine("\n------------------------------------------------------------------------------------------------");
                Console.WriteLine("Please select an option to proceed");

                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }

                Console.Write("\nEnter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("\n\t********** Invalid input: Please choose only numbers from 1-5. ********");
                    continue;
                }

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
                }

                if (choice != 5)
                {
                    Console.WriteLine("\n*Press any key to continue* ");
                    Console.ReadKey();
                }
            } while (choice != 5);
        }

        //--------------------METHODS---------------------//

        // Method to ensure valid input (no null or empty values)
        static string GetValidInput(string prompt)
        {
            string input;
            while (true)
            {
                Console.Write(prompt);
                input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input; 
                }

                Console.WriteLine("\n\t********** ERROR: Input cannot be null or empty. Please enter a valid value. **********\n");
            }
        }

        // METHOD FOR CREATING PROFILES
        static void CreateProfile()
        {
            Console.WriteLine("\nYou selected >>> CREATE PROFILE <<< ");

            string name = GetValidInput("Enter a player name: ");

            int age;
            while (true)
            {
                Console.Write("Enter a player age: ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out age) && age > 0)
                {
                    break;
                }
                Console.WriteLine("\n\t********** ERROR: Please enter a valid positive number for age. **********\n");
            }

            string position = GetValidInput("Enter player's position (e.g. Spiker, Libero, Setter): ");

            players.Add(new PlayerName(name, age, position));
            Console.WriteLine("\n\t-------------------------- Player's Profile ADDED successfully! --------------------------\n");
        }

        // METHOD FOR EDITING PROFILES
        static void EditProfile()
        {
            Console.WriteLine("\nYou selected >>> EDIT PROFILE <<< ");

            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available to edit. Please create a profile first. ********");
                return;
            }

            ViewProfile(); //calling the View Profile Method

            int index;
            while (true)
            {
                Console.Write("\nEnter the index number of the player to edit: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < players.Count)
                {
                    break;
                }
                Console.WriteLine("\n\t********** ERROR: Please enter a valid index number. ********");
            }

            players[index].Name = GetValidInput("\nEnter new name: ");

            int newAge;
            while (true)
            {
                Console.Write("Enter new age: ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out newAge) && newAge > 0)
                {
                    break;
                }
                Console.WriteLine("\n\t********** ERROR: Please enter a valid positive number for age. **********\n");
            }
            players[index].Age = newAge;

            players[index].Position = GetValidInput("Enter new position (e.g. Spiker, Libero, Setter): ");

            Console.WriteLine("\n\t-------------------------- Player's profile UPDATED successfully! --------------------------\n");
        }

        // METHOD FOR VIEWING PROFILES
        static void ViewProfile()
        {
            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available. ********");
                return;
            }

            Console.WriteLine("\n-------------------------- List of Player's Profiles --------------------------");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"[{i}] Name: {players[i].Name} | Age: {players[i].Age} | Position: {players[i].Position}");
            }
        }

        // METHOD FOR DELETING PROFILES
        static void DeleteProfile()
        {
            Console.WriteLine("\nYou selected >>> DELETE PROFILE <<< ");

            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available to delete. ******** ");
                return;
            }

            ViewProfile(); //calling the View Profile Method

            int index;
            while (true)
            {
                Console.Write("\nEnter the index number of the player to delete: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < players.Count)
                {
                    break;
                }
                Console.WriteLine("\n\t********** ERROR: Please enter a valid index number. ********");
            }

            players.RemoveAt(index);
            Console.WriteLine("\n\t-------------------------- Player's profile DELETED successfully! --------------------------\n");
        }
    }

    // PLAYER CLASS
    class PlayerName
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }

        public PlayerName(string name, int age, string position)
        {
            Name = name;
            Age = age;
            Position = position;
        }
    }
}
