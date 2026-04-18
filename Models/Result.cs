namespace TPPProject.Models
{
    public class Result
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = "";
        public string ProjectName { get; set; } = "";
        public string TeamLead { get; set; } = "";

        public int TotalEmployees { get; set; }

        public int HighBurnoutCount { get; set; }
        public int MediumBurnoutCount { get; set; }
        public int LowBurnoutCount { get; set; }

        public int HighPerformanceCount { get; set; }
        public int MediumPerformanceCount { get; set; }
        public int LowPerformanceCount { get; set; }

        public int TeamScore { get; set; }
        public string TeamPerformanceLevel { get; set; } = "";
    }
}
