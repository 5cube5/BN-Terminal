using System;
using System.Diagnostics;
using System.IO;

namespace BigNavigationTerminal
{
    internal class Program
    {
        private static string[] commands = { "help", "search", "open"};

        static void Main(string[] args)
        {
            Console.Title = "BN Terminal 1.0";
            Console.WindowHeight = 40;

            // Display available commands to the user
            Console.WriteLine("Available commands: " + string.Join(", ", commands) + "\n logged in as " + Environment.UserName);

            while (true)
            {
                // Read user input
                string userInput = Console.ReadLine().Trim().ToLower();

                // Split the user input into individual commands using ";"
                string[] userCommands = userInput.Split(';');

                // Process each command
                foreach (var userCommand in userCommands)
                {
                    // Split the user command into command and parameters
                    string[] inputParts = userCommand.Trim().Split(' ', 2);

                    // Extract the command
                    string command = inputParts[0];

                    // Check if the command is valid
                    if (Array.Exists(commands, c => c.Equals(command)))
                    {
                        // Execute the command
                        ExecuteCommand(command, inputParts.Length > 1 ? inputParts[1] : "");
                    }
                    else
                    {
                        // Command not recognized
                        Console.WriteLine($"Invalid command '{command}'. Type 'help' for a list of available commands.");
                    }
                }
            }
        }

        static void ExecuteCommand(string command, string parameters)
        {
            switch (command)
            {
                case "help":
                    // Implement logic for the 'help' command
                    Console.WriteLine("Available commands: " + string.Join(", ", commands));
                    break;

                case "search":
                    // Implement logic for the 'search' command
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = "https://www.google.com/search?q=" + parameters,
                        UseShellExecute = true
                    });
                    break;

                case "open":
                    string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string fullPath = Path.Combine(desktopPath, parameters);

                    try
                        {
                            Process.Start("explorer.exe", fullPath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error opening file or folder: {ex.Message}");
                        }

                    break;




                default:
                    Console.WriteLine($"Command '{command}' not implemented.");
                    break;
            }
        }
    }
}
