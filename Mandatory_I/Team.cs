using CsvHelper.Configuration.Attributes;

namespace Mandatory_I
{
    internal class Team
    {
        [Index(0)]
        public string Abbreviation { get; set; }
        [Index(1)]
        public string FullClubName { get; set; }
        [Index(2)]
        public string SpecialRanking { get; set; }
        /*
            W = Last year's champion
            C = Last year's cup winner
            P = Promoted team
            R = Relegated team
            N = None
        */

        public Team(string abbreviation, string fullClubName, string specialRanking)
        {
            Abbreviation = abbreviation;
            FullClubName = fullClubName;
            SpecialRanking = specialRanking;
        }

        public static string SpecialRankingConverter(string SpecialRanking)
        {
            switch (SpecialRanking)
            {
                case "W":
                    return "Last year's champion";
                case "C":
                    return "Last year's cup winner";
                case "P":
                    return "Promoted team";
                case "R":
                    return "Relegated team";
                case "N":
                    return "None";
                default:
                    return "Invalid special ranking";
            }
        }

        // Prints Club to console
        public void PrintTeamDetails()
        {
            Console.WriteLine(
                "\nTeam abbreviation: " + this.Abbreviation +
                "\nFull name of football club: " + this.FullClubName +
                "\nSpecial Ranking: " + SpecialRankingConverter(this.SpecialRanking));
        }
    }
}
