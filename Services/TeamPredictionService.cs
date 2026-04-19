namespace TPPProject.Services
{
    public class TeamPredictionService
    {
        public int CalculateTeamScore(
            int highPerformance,
            int mediumPerformance,
            int highBurnout,
            int mediumBurnout)
        {
            return (highPerformance * 2)
                 + (mediumPerformance * 1)
                 - (highBurnout * 2)
                 - (mediumBurnout * 1);
        }

        public string GetTeamPerformanceLevel(int teamScore)
        {
            if (teamScore >= 2)
                return "High";
            else if (teamScore >= 0)
                return "Medium";
            else
                return "Low";
        }
    }
}