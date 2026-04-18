using System.Collections.Generic;

namespace TPPProject.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = "";
        public string ProjectName { get; set; } = "";
        public string TeamLead { get; set; } = "";

        public List<Employee>? Employees { get; set; }
    }
}