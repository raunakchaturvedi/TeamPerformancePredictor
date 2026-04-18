using System.ComponentModel.DataAnnotations;
namespace TPPProject.Models

{
    public class ActivityLog
    {
        [Key]
        public int LogId { get; set; }
        public int EmployeeId { get; set; }

        public DateTime WeekStartDate { get; set; }

        public float HoursWorked { get; set; }
        public float TasksCompleted { get; set; }
        public float MeetingsAttended { get; set; }
        public float OvertimeHours { get; set; }
        public float LeaveDaysTaken { get; set; }
        public float DeadlinesMissed { get; set; }
        public float PeerCollaborationScore { get; set; }

        public Employee? Employee { get; set; }
    }
}
