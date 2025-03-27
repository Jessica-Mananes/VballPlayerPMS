using System;
using PMSLogic;
namespace VballPlayerPMS
{
    internal class Program
    {
        static PlayerService playerService = new(); 

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
                    Console.WriteLine("\n\t********** Login ERROR: Incorrect username or password. Please try again. ****");
                }
                else
                {
                    Console.WriteLine("\n\t-------------------------- LOGIN SUCCESSFUL --------------------------");
                }
            } while (username != adminUsername || password != adminPassword);

            // MENU OPTIONS
            string[] options = { "[1] Create Profile", "[2] Edit Profile", "[3] View Profile", "[4] Delete Profile", "[5] Exit Program" };
            int choice;

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
                    Console.WriteLine("\n\t********** Invalid input: Please choose only numbers from 1-5. ****");
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

                Console.WriteLine("\n\t********** ERROR: Input cannot be null or empty. Please enter a valid value. ******");
            }
        }

        static void CreateProfile()
        {
            Console.WriteLine("\nYou selected >>> CREATE PROFILE <<< ");
            string name = GetValidInput("Enter a player name: ");

            int age;
            while (true)
            {
                Console.Write("Enter a player age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                {
                    break;
                }
                Console.WriteLine("\n\t********** ERROR: Please enter a valid positive number for age. **********\n");
            }

            string position = GetValidInput("Enter player's position (e.g. Spiker, Libero, Setter): ");
            playerService.AddPlayer(name, age, position);
        }

        static void EditProfile()
        {
            Console.WriteLine("\nYou selected >>> EDIT PROFILE <<< ");

            if (playerService.GetPlayerCount() == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available to edit. Please create a profile first. ****");
                return;
            }

            ViewProfile();

            int index;
            while (true)
            {
                Console.Write("\nEnter the index number of the player to edit: ");
                if (int.TryParse(Console.ReadLine(), out index) && index >= 0 && index < playerService.GetPlayerCount())
                {
                    break; 
                }
                Console.WriteLine("\n\t********** ERROR: Invalid index. Please enter a valid player index. ****");
            }

           
            string name = GetValidInput("Enter new name: ");

            int age;
            while (true)
            {
                Console.Write("Enter new age: ");
                if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                {
                    break;
                }
                Console.WriteLine("\n\t********** ERROR: Please enter a valid positive number for age. **********\n");
            }

            string position = GetValidInput("Enter new position (e.g. Spiker, Libero, Setter): ");

           
            playerService.EditPlayer(index, name, age, position);
        }


        static void ViewProfile() => playerService.ViewPlayers();

        static void DeleteProfile()
        {
            Console.WriteLine("\nYou selected >>> DELETE PROFILE <<< ");
            if (playerService.GetPlayerCount() == 0)
            {
                Console.WriteLine("\n\t********** No player's profiles available to delete. ****");
                return;
            }

            ViewProfile();
            Console.Write("\nEnter the index number of the player to delete: ");
            int index = int.Parse(Console.ReadLine());
            playerService.DeletePlayer(index);
        }
    }
}
