namespace Domain
{
    public class CourseEnrollment : Document
    {
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }

        public virtual Course Course => Section?.Course;

        public float? GradePoint { get; set; }
        public Grade? Grade { get; set; }
    }
}
