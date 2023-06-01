namespace Mandatory_I
{
    internal class DirectoryProcessor
    {

        public static void ProcessDirectory(string directoryName)
        {
            List<League> Leagues = new();
            List<Team> Teams = new();
            List<Round> Rounds = new();
            List<Standing> Standings = new();

            if (!File.Exists(@"test/" + directoryName + "/setup.csv"))
            {
                Console.WriteLine(
                    "Error! " +
                    "\nThe specified directory is missing the \"setup.csv\" file." +
                    "\nPlease check the integrity of your data and try again."
                    );
                return;
            }
            if (!File.Exists(@"test/" + directoryName + "/teams.csv"))
            {
                Console.WriteLine(
                    "Error! " +
                    "\nThe specified directory is missing the \"teams.csv\" file." +
                    "\nPlease check the integrity of your data and try again."
                    );
                return;
            }
            // Process team data from CSV into collection
            CSVToCollectionProcessor<Team> csvToTeamCollectionProcessor = new();
            csvToTeamCollectionProcessor.ProcessCSV(directoryName, "teams.csv", Teams);

            // Process league data from CSV into collection
            CSVToCollectionProcessor<League> csvToLeagueCollectionProcessor = new();
            csvToLeagueCollectionProcessor.ProcessCSV(directoryName, "setup.csv", Leagues);

            // Process round data from CSV into collection
            for (int i = 1; i <= 32; i++)
            {
                CSVToCollectionProcessor<Round> csvToRoundCollectionProcessor = new();
                csvToRoundCollectionProcessor.ProcessCSV(directoryName, "round-" + i + ".csv", Rounds);
            }

            Standing standing = new();
            Standings = standing.ComputeStandings(Teams, Rounds);
            standing.PrintStandings(Standings);
            Console.WriteLine("\nHint: You can find the output CSV in the selected directory");

            CollectionToCSVProcessor<Standing> standingCollectionToCSVProcessor = new();
            standingCollectionToCSVProcessor.ProcessCSV(directoryName, "output.csv", Standings);

        }
    }
}
