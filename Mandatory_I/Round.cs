using CsvHelper.Configuration.Attributes;

namespace Mandatory_I
{
    internal class Round
    {
        [Index(0)]
        public string TeamOneAbbreviation { get; set; }
        [Index(1)]
        public int ScoreTeamOne { get; set; }
        [Index(2)]
        public string TeamTwoAbbreviation { get; set; }
        [Index(3)]
        public int ScoreTeamTwo { get; set; }

        public Round(string teamOneAbbreviation, int scoreTeamOne, string teamTwoAbbreviation, int scoreTeamTwo)
        {
            TeamOneAbbreviation = teamOneAbbreviation;
            ScoreTeamOne = scoreTeamOne;
            TeamTwoAbbreviation = teamTwoAbbreviation;
            ScoreTeamTwo = scoreTeamTwo;
        }
    }
}
