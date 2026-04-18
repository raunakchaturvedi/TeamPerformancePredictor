namespace TPPProject.Models
{
    public class BurnoutRisk
    {
        public int BurnoutRiskId { get; set; }

        public int? EmployeeId { get; set; }

        public Employee? Employee { get; set; }

        public int WorkingHours { get; set; }
        public int OvertimeHours { get; set; }
        public int StressLevel { get; set; }
        public int LeaveCount { get; set; }

        public string RiskLevel { get; set; } = "";
    }
}