using System;
using PMSLogic; 

namespace VballPlayerPMS
{
    internal class Program
    {
        static PlayerService playerService = new(); 

        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t---------------- Volleyball Players Profile Management System ----------------");

            string adminUsername = "batakmagvball";
            string adminPassword = "jess";
            string username, password;

            do //DO-WHILE LOOP FOR LOGGING IN
            {
                Console.Write("\nEnter username: ");
                username = Console.ReadLine();

                Console.Write("Enter password: ");
                password = Console.ReadLine();

                if (username != adminUsername || password != adminPassword)
                {
                    Console.WriteLine("\n\t********** ERROR: Incorrect username or password. Try again. ****");
                }
                else
                {
                    Console.WriteLine("\n\t---------------- LOGIN SUCCESSFUL ----------------");
                }
            } while (username != adminUsername || password != adminPassword);

            //OPTIONS
            string[] options = { "[1] Create Profile", "[2] Edit Profile", "[3] View Profile", "[4] Delete Profile", "[5] Exit Program" };
            int choice;

            do //DO-WHILE FOR SELECTING OPTIONS, IF OPTION 5 IS NOT SELECTED THE LOOP WILL CONTINUE TO EXECUTE.
            {
                Console.WriteLine("\n------------------------------------------------------");
                Console.WriteLine("Please select an option to proceed");

                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }

                Console.Write("\nEnter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("\n\t********** Invalid input: Choose a number between 1-5. ****");
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

        //check for null input
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

        //METHOD FOR CREATE PROFILE
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

            if (playerService.AddPlayer(name, age, position))
                Console.WriteLine("\n\t---------------- Player's Profile ADDED successfully! ----------------");
        }

        //METHOD FOR EDIT PROFILE 
        static void EditProfile()
        {
            Console.WriteLine("\nYou selected >>> EDIT PROFILE <<< ");

            if (playerService.GetPlayerCount() == 0)
            {
                Console.WriteLine("\n\t********** No profiles available. Create a profile first. ****");
                return;
            }

            ViewProfile();//Calling the View Profile Method

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

            if (playerService.EditPlayer(index, name, age, position))
                Console.WriteLine("\n\t---------------- Player's Profile UPDATED successfully! ----------------");
            else
                Console.WriteLine("\n\t********** ERROR: Could not update profile. ****");
        }

        //METHOD FOR VIEW PROFILE
        static void ViewProfile()
        {
            var players = playerService.GetAllPlayers();
            if (players.Count == 0)
            {
                Console.WriteLine("\n\t********** No profiles available. ****");
                return;
            }

            Console.WriteLine("\n---------------- List of Player Profiles ----------------");
            for (int i = 0; i < players.Count; i++)
            {
                Console.WriteLine($"[{i}] Name: {players[i].Name} | Age: {players[i].Age} | Position: {players[i].Position}");
            }
        }

        //METHOD FOR DELETE PROFILE
        static void DeleteProfile()
        {
            Console.WriteLine("\nYou selected >>> DELETE PROFILE <<< ");
            if (playerService.GetPlayerCount() == 0)
            {
                Console.WriteLine("\n\t********** No profiles available to delete. ****");
                return;
            }

            ViewProfile(); //Calling the View Profile Method
            Console.Write("\nEnter the index number of the player to delete: ");

            if (int.TryParse(Console.ReadLine(), out int index) && playerService.DeletePlayer(index))
                Console.WriteLine("\n\t---------------- Player's Profile DELETED successfully! ----------------");
            else
                Console.WriteLine("\n\t********** ERROR: Invalid index. ****");
        }
    }
}