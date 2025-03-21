
using System;
using System.Collections.Generic;

namespace VballPlayerPMS
{
    internal class Program
    {
        static List<PlayerName> players = new List<PlayerName>();
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t-------------------------- Volleyball Players Profile Management System --------------------------");
            string adminUsername = "jfm";
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
                    Console.WriteLine("\n\t********** Login ERROR: your password or username is incorrect. Please try again.. **********");
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
                Console.WriteLine("\n------------------------------------------------------------------------------------------------");
                Console.WriteLine("Please select an option to proceed");


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

        static void CreateProfile()// Method for Create Profile
        {
            Console.WriteLine("\nYou selected >>> CREATE PROFILE <<< ");

            Console.Write("Enter a player name: ");
            string name = Console.ReadLine();


            Console.Write("Enter a player age: ");
            int age = Convert.ToInt16(Console.ReadLine());

            Console.Write("Enter player's position (e.g. Spiker, Libero, Setter): ");
            string position = Console.ReadLine();

            players.Add(new PlayerName(name, age, position));
            Console.WriteLine("\n\t-------------------------- Player's ADDED successfully! --------------------------\n");

        }


        static void EditProfile() // method for Edit Profile
        {
            Console.WriteLine("\nYou selected >>> EDIT PROFILE <<< ");

            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available to edit. Please create profile first **********");
                return;
            }

            ViewProfile();

            int index;
            while (true)
            {
                Console.Write("\nEnter the index or number of the player to edit: ");
                index = Convert.ToInt16(Console.ReadLine());

                if (index >= 0 && index < players.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\n\t********** The number you entered is not on the list! **********");
                }
            }

            Console.Write("\nEnter new name: ");
            players[index].Name = Console.ReadLine();

            int newAge;

            while (true) // check if the input is a positive integer.
            {
                Console.Write("Enter new age: ");

                try
                {
                    newAge = Convert.ToInt16(Console.ReadLine());

                    if (newAge > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\t********** ERROR: Age must be a positive number. Please try again. **********\n");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\t********** ERROR: Please enter a valid number for age.**********\n");
                }

            }

            players[index].Age = newAge;

            Console.Write("Enter new position: ");
            players[index].Position = Console.ReadLine();

            Console.WriteLine("\n\t -------------------------- Player's profile UPDATED successfully! --------------------------\n");
        }


        static void ViewProfile() // Method for View Profile 
        {

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

        static void DeleteProfile() // Method for Delete Profile
        {
            Console.WriteLine("\nYou selected >>> DELETE PROFILE <<< ");

            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available to delete.********** ");
                return;
            }

            ViewProfile();

            int index;
            while (true)
            {
                Console.Write("\nEnter the index or number of the player to delete: ");
                try
                {
                    index = Convert.ToInt16(Console.ReadLine());
                    if (index >= 0 && index < players.Count)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\n\t********** The number you entered is not on the list! **********");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\t********** ERROR: Please enter a valid number. **********\n");
                }
            }


            players.RemoveAt(index);
            Console.WriteLine("\n\t -------------------------- Player's profile DELETED successfully! --------------------------\n");

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