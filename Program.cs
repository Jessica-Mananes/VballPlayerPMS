﻿
using System;
using System.Collections.Generic;

namespace VballPlayerPMS
{
    internal class Program
    {
        static List<PlayerName> players = new List<PlayerName>();
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t-------------------------- Volleyball Player Profile Management System --------------------------");
            string adminUsername = "batakmagvball";
            string adminPassword = "jessica1124";
            string username, password;

            do
            {
                Console.Write("Enter username: ");
                username = Console.ReadLine();

                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (username != adminUsername || password != adminPassword)
                {
                    Console.WriteLine("Login Error: your password or username is Incorrect. PLease Try again..");
                }
                else
                {
                    Console.WriteLine("\n-------------------------- Login Successful! --------------------------");
                }

            } while (username != adminUsername || password != adminPassword);

            string[] options = { "[1] Create Profile", "[2] Edit Profile", "[3] View Profile", "[4] Delete Profile", "[5] Exit Program" };
            int choice;
            do
            {
                Console.WriteLine("\n--------------------------------------------------------------------------------------------------------------------  ");
                Console.WriteLine("\nPlease select an option to proceed ");


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
                        Console.WriteLine("Invalid input: Please choose only numbers from 1-5. ");
                        break;
                }

                if (choice != 5)
                {
                    Console.WriteLine("\n*Press any key to continue* ");
                    Console.ReadKey();
                }
            } while (choice != 5);
        }

        static void CreateProfile()// Method for Create Profile
        {
            Console.WriteLine("\nYou selected ~ Create Profile ~ ");

            Console.Write("Enter a player name: ");
            string name = Console.ReadLine();


            Console.Write("Enter a player age: ");
            int age = Convert.ToInt16(Console.ReadLine());

            Console.Write("Enter player's position (e.g. Spiker, Libero, Setter: ");
            string position = Console.ReadLine();

            players.Add(new PlayerName(name, age, position));
            Console.WriteLine("\n\t-------------------------- Player added successfully! --------------------------\n");

        }

        static void EditProfile() // Method for Edit Profile
        {
            Console.WriteLine("\nYou selected ~ Edit Profile ~ ");

            if (players.Count == 0)
            {
                Console.WriteLine("No player profiles available to edit.");
                return;
            }

            ViewProfile();

            int index;
            while (true)
            {
                Console.Write("Enter the index or number of the player to edit:  ");
                index = Convert.ToInt16(Console.ReadLine());

                if (index >= 0 && index < players.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nThe number you entered is not on the list!");
                }
            }

            Console.Write("Enter new name: ");
            players[index].Name = Console.ReadLine();

            Console.Write("Enter new age: ");
            int newAge = Convert.ToInt16(Console.ReadLine());
            while (newAge <= 0)
            {
                Console.Write("Invalid input. Enter a valid age: ");
            }
            players[index].Age = newAge;

            Console.Write("Enter new position: ");
            players[index].Position = Console.ReadLine();

            Console.WriteLine("\n\t -------------------------- Player's profile updated successfully! --------------------------\n");
        }

        static void ViewProfile() // Method for View Profile 
        {

            if (players.Count == 0)
            {
                Console.WriteLine("No player profiles available.");
                return;
            }

            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"[{i}] Name:{players[i].Name} | Age:{players[i].Age} | Position:{players[i].Position}");

            }

        }

        static void DeleteProfile() // Method for Delete Profile
        {
            Console.WriteLine("\nYou selected ~ Delete Profile ~ ");

            if (players.Count == 0)
            {
                Console.WriteLine("No player profiles available to delete.");
                return;
            }
            ViewProfile();
            Console.Write("Enter the index or number of the player to delete: ");
            int index = Convert.ToInt16(Console.ReadLine());
            if (index < 0 || index >= players.Count)
            {
                Console.WriteLine("Invalid index!");
                return;
            }

            players.RemoveAt(index);
            Console.WriteLine("\n\t -------------------------- Player profile deleted successfully! --------------------------\n");

        }

    }


    class PlayerName// CLASS
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