namespace Mandatory_I
{
    /// <summary>
    /// Allows the user to select a specific directory from bin/Debug/net6.0/test 
    /// in order to determine where to pull the data from for processing.
    /// Tries to handle exceptions gracefully.
    /// </summary>
    /// <returns>
    /// Either the name of the directory or -1 as a string
    /// </returns>
    internal class DirectorySelector
    {
        public static string SelectDirectory()
        {
            Console.Clear();
            Console.WriteLine(
                "Please select the directory to process:" +
                "\n\nHint: You can add your own files in the directory and select it from here.\n"
                );
            DirectoryInfo baseDirectory = new(@"test");
            try
            {
                int i = 1;
                foreach (DirectoryInfo directoryInfo in baseDirectory.GetDirectories())
                {
                    Console.WriteLine(i + ". " + directoryInfo.Name);
                    i++;
                }
                Console.WriteLine("0. Go back");
                string? selectedDirectoryIndex = Console.ReadLine();
                if (!string.IsNullOrEmpty(selectedDirectoryIndex)) 
                {
                    if (!selectedDirectoryIndex.Equals("0"))
                    {
                        if (Int32.TryParse(selectedDirectoryIndex, out int index))
                        {
                            try
                            {
                                return baseDirectory.GetDirectories()[index - 1].Name;
                            }
                            catch (IndexOutOfRangeException exception)
                            {
                                Console.WriteLine(
                                    "Invalid number inserted." +
                                    "\nException: " + exception.GetType().Name
                                    );
                                return "-1";
                            }

                        }
                        else
                        {
                            Console.WriteLine("Invalid Input.");
                            return "-1";
                        }
                    }
                    Console.Clear();
                    return "-1"; 
                } else
                {
                    Console.WriteLine("Invalid Input.");
                    return "-1";
                }
                
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine(
                    "Uh oh! Something went terribly wrong." +
                    "\nYou are missing the \"test\" directory." +
                    "\nPlease clone the repository or add the missing directory manually" +
                    "\nException: \n" + exception.GetBaseException().GetType().FullName
                    );
                return "-1";
            }
        }
    }
}
