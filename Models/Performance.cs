namespace TPPProject.Models
{
    public class Performance
    {
        public int PerformanceId { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int TasksCompleted { get; set; }
        public int DeadlinesMet { get; set; }
        public int ProductivityScore { get; set; }
        public int TeamworkScore { get; set; }

        public string PerformanceLevel { get; set; } = "";
    }
}