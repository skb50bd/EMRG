namespace Domain
{
    public class StudentId : Entity
    {
        public int Year { get; set; }
        public Season Season { get; set; }
        public int Semester => (int)Season;
        public int Program { get; set; }
        public int Roll { get; set; }
        public override string ToString() 
            => $"{Year}-" +
               $"{Semester}-" +
               $"{Program}-" +
               $"{Roll.ToString().PadLeft(3, '0')}";

        public bool AreBatchMates(StudentId sId)
            => Year == sId.Year
            && Season == sId.Season
            && Program == sId.Program;
    }
}