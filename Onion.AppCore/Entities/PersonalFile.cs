using System;

namespace Onion.AppCore.Entities
{
    public class PersonalFile
    {
        public int Id { get; set; }
        public int ProjectsDone { get; set; }
        public double TotalTimeInProjects { get; set; }
        public double AVGProjectTime { get; set; }
        public DateTime SetProjectDate { get; set; }
        public double SuccessTaskCompletion { get; set; }
        public double AVGTaskCompletionPerMonth { get; set; }
        public double AVGSalary { get; set; }
        public double AVGTaskCost { get; set; }
        public double AVGTaskOverdueTime { get; set; }
        public double AVGTaskComplexity { get; set; }
        public double AVGTaskCompletionTime { get; set; }


        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
