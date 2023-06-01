using CsvHelper.Configuration.Attributes;

namespace Mandatory_I
{
    internal class League
    {
        [Index(0)]
        public string LeagueName { get; set; }
        [Index(1)]
        public int NumOfPosChampionsLeague { get; set; }
        [Index(2)]
        public int NumOfPosEuLeague { get; set; }
        [Index(3)]
        public int NumOfPosConfLeague { get; set; }
        [Index(4)]
        public int NumOfPosUpperLeague { get; set; }
        [Index(5)]
        public int NumOfPosLowerLeague { get; set; }

        public League(string leagueName, int numOfPosChampionsLeague, int numOfPosEuLeague, int numOfPosConfLeague, int numOfPosUpperLeague, int numOfPosLowerLeague)
        {
            this.LeagueName = leagueName;
            this.NumOfPosChampionsLeague = numOfPosChampionsLeague;
            this.NumOfPosEuLeague = numOfPosEuLeague;
            this.NumOfPosConfLeague = numOfPosConfLeague;
            this.NumOfPosUpperLeague = numOfPosUpperLeague;
            this.NumOfPosLowerLeague = numOfPosLowerLeague;
        }

        public void PrintLeagueSetup()
        {
            Console.WriteLine(
                "League Name: " + this.LeagueName +
                "\nNumber of positions to promote to Champions League: " + this.NumOfPosChampionsLeague +
                "\nNumber of positions to promote to Europe League: " + this.NumOfPosEuLeague +
                "\nNumber of positions to promote to Conference League: " + this.NumOfPosConfLeague +
                "\nNumber of positions to promote to an Upper League: " + this.NumOfPosUpperLeague +
                "\nNumber of positions to relegate to a Lower League: " + this.NumOfPosLowerLeague);
        }
    }
}
