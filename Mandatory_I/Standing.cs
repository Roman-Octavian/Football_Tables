using ConsoleTables;

namespace Mandatory_I
{
    internal class Standing
    {
        private List<Standing> currentStandings = new();

        public int TablePosition { get; set; }
        public string SpecialRanking { get; set; }
        public string FullClubName { get; set; }
        public string Abbreviation { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public int GamesDrawn { get; set; }
        public int GamesLost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int PointsAchieved { get; set; }
        public string WinningStreak { get; set; }

        public Standing() {}

        public Standing(int tablePosition, string specialMarking, string fullClubName, 
            string abbreviation, int gamesPlayed, int gamesWon, 
            int gamesDrawn, int gamesLost, int goalsFor, 
            int goalsAgainst, int goalDifference, int pointsAchieved, string winningStreak)
        {
            TablePosition = tablePosition;
            SpecialRanking = specialMarking;
            FullClubName = fullClubName;
            Abbreviation = abbreviation;
            GamesPlayed = gamesPlayed;
            GamesWon = gamesWon;
            GamesDrawn = gamesDrawn;
            GamesLost = gamesLost;
            GoalsFor = goalsFor;
            GoalsAgainst = goalsAgainst;
            GoalDifference = goalDifference;
            PointsAchieved = pointsAchieved;
            WinningStreak = winningStreak;
        }
        public Standing(Team team)
        {
            TablePosition = TablePosition;
            SpecialRanking = team.SpecialRanking;
            FullClubName = team.FullClubName;
            Abbreviation = team.Abbreviation;
            GamesPlayed = GamesPlayed;
            GamesWon = GamesWon;
            GamesDrawn = GamesDrawn;
            GamesLost = GamesLost;
            GoalsFor = GoalsFor;
            GoalsAgainst = GoalsAgainst;
            GoalDifference = GoalDifference;
            PointsAchieved = PointsAchieved;
            WinningStreak = WinningStreak;
        }

        public List<Standing> ComputeStandings(List<Team> Teams, List<Round> Rounds) 
        {
            List<Standing> standings = new();

            Teams.ForEach(team =>
            {
            Standing partialStanding = new(team);

            Rounds.ForEach(round =>
            {

                if (round.TeamOneAbbreviation == team.Abbreviation &&
                round.TeamTwoAbbreviation == team.Abbreviation)
                {
                    Console.WriteLine(
                        "Round parsing error:" +
                        "\nIn Denmark, a team cannot play against itself." +
                        "\nWait... What do you mean \"In Denmark\"?!"
                        );
                    Thread.Sleep(3500);
                    Environment.Exit(1);
                }
                if (round.TeamOneAbbreviation == team.Abbreviation)
                {
                    partialStanding.GamesPlayed++;
                    switch (round.ScoreTeamOne)
                    {
                        case int ScoreTeamOne when ScoreTeamOne > round.ScoreTeamTwo:
                            partialStanding.GamesWon++;
                            partialStanding.GoalsFor += round.ScoreTeamOne;
                            partialStanding.GoalsAgainst += round.ScoreTeamTwo;
                            partialStanding.GoalDifference += round.ScoreTeamOne - round.ScoreTeamTwo;
                            if (partialStanding.WinningStreak?.Length == 5) partialStanding.WinningStreak = partialStanding.WinningStreak.Substring(1);
                            partialStanding.WinningStreak += "W";
                            break;
                        case int ScoreTeamOne when ScoreTeamOne < round.ScoreTeamTwo:
                            partialStanding.GamesLost++;
                            partialStanding.GoalsFor += round.ScoreTeamOne;
                            partialStanding.GoalsAgainst += round.ScoreTeamTwo;
                            partialStanding.GoalDifference += round.ScoreTeamOne - round.ScoreTeamTwo;
                            if (partialStanding.WinningStreak?.Length == 5) partialStanding.WinningStreak = partialStanding.WinningStreak.Substring(1);
                            partialStanding.WinningStreak += "L";
                            break;
                        case int ScoreTeamOne when ScoreTeamOne == round.ScoreTeamTwo:
                            partialStanding.GamesDrawn++;
                            partialStanding.GoalsFor += round.ScoreTeamOne;
                            partialStanding.GoalsAgainst += round.ScoreTeamTwo;
                            if (partialStanding.WinningStreak?.Length == 5) partialStanding.WinningStreak = partialStanding.WinningStreak.Substring(1);
                            partialStanding.WinningStreak += "D";
                            break;
                        default:
                            break;
                    }
                } else if (round.TeamTwoAbbreviation == team.Abbreviation)
                {
                    partialStanding.GamesPlayed++;
                    switch (round.ScoreTeamTwo)
                    {
                        case int ScoreTeamTwo when ScoreTeamTwo > round.ScoreTeamOne:
                            partialStanding.GamesWon++;
                            partialStanding.GoalsFor += round.ScoreTeamTwo;
                            partialStanding.GoalsAgainst += round.ScoreTeamOne;
                            partialStanding.GoalDifference += round.ScoreTeamTwo - round.ScoreTeamOne;
                            if (partialStanding.WinningStreak?.Length == 5) partialStanding.WinningStreak = partialStanding.WinningStreak.Substring(1);
                            partialStanding.WinningStreak += "W";
                            break;
                        case int ScoreTeamTwo when ScoreTeamTwo < round.ScoreTeamOne:
                            partialStanding.GamesLost++;
                            partialStanding.GoalsFor += round.ScoreTeamTwo;
                            partialStanding.GoalsAgainst += round.ScoreTeamOne;
                            partialStanding.GoalDifference += round.ScoreTeamTwo - round.ScoreTeamOne;
                            if (partialStanding.WinningStreak?.Length == 5) partialStanding.WinningStreak = partialStanding.WinningStreak.Substring(1);
                            partialStanding.WinningStreak += "L";
                            break;
                        case int ScoreTeamOne when ScoreTeamOne == round.ScoreTeamTwo:
                            partialStanding.GamesDrawn++;
                            partialStanding.GoalsFor += round.ScoreTeamTwo;
                            partialStanding.GoalsAgainst += round.ScoreTeamOne;
                            if (partialStanding.WinningStreak?.Length == 5) partialStanding.WinningStreak = partialStanding.WinningStreak.Substring(1);
                            partialStanding.WinningStreak += "D";
                            break;
                        default:
                            break;
                    }
                }
            });
            partialStanding.PointsAchieved = partialStanding.GamesWon * 3 + partialStanding.GamesDrawn;
            /* I've no idea how to calculate football points
            The assignment doesn't say, nor does the wikipedia articles for danish football
            So this will have to do */

            standings.Add(partialStanding);
            });
            standings.Sort((x, y) => y.PointsAchieved.CompareTo(x.PointsAchieved));
            int dashCount = 0;
            for (var i = 0; i < standings.Count; i++)
            {
                standings[i].TablePosition = i + 1 - dashCount;
                if (i != 0)
                {
                    if (standings[i].PointsAchieved == standings[i - 1].PointsAchieved &&
                        standings[i].GoalsFor == standings[i - 1].GoalsFor)
                    {
                        standings[i].TablePosition = 0;
                        dashCount++;
                    }
                }
            }


            return standings;
        }

        public void PrintStandings(List<Standing> standings)
        {
            ConsoleTable table = new("Pos", "Team", "M", "W", "D", "L", "GF", "GA", "GD", "P", "Streak");
            standings.ForEach(standing =>
            {
                if (standing.SpecialRanking != "N")
                {
                    table.AddRow(
                    standing.TablePosition == 0 ? "-" : standing.TablePosition,
                    "(" + standing.SpecialRanking+ ") " + standing.FullClubName + " (" + standing.Abbreviation.Replace("-", "") + ")",
                    standing.GamesPlayed,
                    standing.GamesWon,
                    standing.GamesDrawn,
                    standing.GamesLost,
                    standing.GoalsFor,
                    standing.GoalsAgainst,
                    standing.GoalDifference,
                    standing.PointsAchieved,
                    standing.WinningStreak
                    );
                } else
                {
                    table.AddRow(
                   standing.TablePosition == 0 ? "-" : standing.TablePosition,
                   standing.FullClubName + " (" + standing.Abbreviation.Replace("-", "") + ")",
                   standing.GamesPlayed,
                   standing.GamesWon,
                   standing.GamesDrawn,
                   standing.GamesLost,
                   standing.GoalsFor,
                   standing.GoalsAgainst,
                   standing.GoalDifference,
                   standing.PointsAchieved,
                   standing.WinningStreak
                   );
                }

                
            });
            table.Write(Format.Default);
        }
    }
}
