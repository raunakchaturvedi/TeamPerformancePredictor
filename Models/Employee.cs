using System.Collections.Generic;

namespace TPPProject.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; } = "";
        public string Department { get; set; } = "";

        public int TeamId { get; set; }
        public Team? Team { get; set; }

        public List<BurnoutRisk>? BurnoutRisks { get; set; }
        public List<Performance>? Performances { get; set; }
    }
}