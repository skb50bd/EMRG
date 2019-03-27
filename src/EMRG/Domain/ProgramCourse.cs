namespace Domain
{
    public class ProgramCourse : Entity
    {
        public int ProgramId { get; set; }
        public Program Program { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public bool IsOptional { get; set; }
    }
}
