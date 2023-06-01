namespace Mandatory_I
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ASCII art
            Console.WriteLine("\r\n\r\n  ______          _   _           _ _   _______    _     _              \r\n |  ____|        | | | |         | | | |__   __|  | |   | |             \r\n | |__ ___   ___ | |_| |__   __ _| | |    | | __ _| |__ | | ___  ___    \r\n |  __/ _ \\ / _ \\| __| '_ \\ / _` | | |    | |/ _` | '_ \\| |/ _ \\/ __|   \r\n | | | (_) | (_) | |_| |_) | (_| | | |    | | (_| | |_) | |  __/\\__ \\   \r\n |_|  \\___/ \\___/ \\__|_.__/ \\__,_|_|_|    |_|\\__,_|_.__/|_|\\___||___/   \r\n   _____  _______      __  _____                                        \r\n  / ____|/ ____\\ \\    / / |  __ \\                                       \r\n | |    | (___  \\ \\  / /  | |__) | __ ___   ___ ___  ___ ___  ___  _ __ \r\n | |     \\___ \\  \\ \\/ /   |  ___/ '__/ _ \\ / __/ _ \\/ __/ __|/ _ \\| '__|\r\n | |____ ____) |  \\  /    | |   | | | (_) | (_|  __/\\__ \\__ \\ (_) | |   \r\n  \\_____|_____/    \\/     |_|   |_|  \\___/ \\___\\___||___/___/\\___/|_|   \r\n                                                                        \r\n                                                                        \r\n\r\n");
            while (true)
            {
                Console.WriteLine(
                    "\nSelect an option from below:" +
                    "\n1. Select processing directory" +
                    "\n0. Exit" +
                    "\n\nHint: Type a number corresponding to the options and press \"ENTER\""
                );
                string? selectedOption = Console.ReadLine();
                if (!string.IsNullOrEmpty(selectedOption))
                {
                    /* A switch statement for two options seems inappropriate but I find it more readable.
                     Moreover, hypothetically, more options could be added more easily to the program later on */
                    switch (selectedOption)
                    {
                        case "0":
                            Environment.Exit(1);
                            break;
                        case "1":
                            string selectedDirectory = DirectorySelector.SelectDirectory();
                            if (selectedDirectory != "-1")
                            {

                                DirectoryProcessor.ProcessDirectory(selectedDirectory);
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid Input. Try again");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input. Try again");
                }
            }
        }
    }
}