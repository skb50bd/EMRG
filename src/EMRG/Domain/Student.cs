using System;

namespace Domain
{
    public class Student : Document
    {
        public string StudentId => 
            AdmissionDate.Year + "-" 
            + (AdmissionDate.Month - 1) / 4 + 1 + "-" 
            + Program.Code + "-" 
            + Roll;

        public int Roll { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public int ProgramId { get; set; }
        public Program Program { get; set; }

        public DateTimeOffset AdmissionDate { get; set; }

        public DateTimeOffset DateOfBirth { get; set; }
        public int CreditsAttained { get; set; }
        public int CreditsTaken { get; set; }
    }
}