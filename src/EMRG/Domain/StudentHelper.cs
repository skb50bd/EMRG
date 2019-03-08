using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public static class StudentHelper
    {
        public static Season GetSeason(this DateTime dt)
        {
            if (dt.Month < 5) return Season.Spring;
            if (dt.Month < 9) return Season.Summer;
            else return Season.Fall;
        }

        public static int CalculateAge(this DateTime dob) 
            => (int)(DateTime.Today.Subtract(dob).TotalDays / 365);

        public static int CalculateCreditsTaken(this Student student) 
            => student.Sections?.Select(s => s.Course)
                    .Distinct()
                    .Sum(c => c.Credits) ?? 0;

        public static int CalculateCreditsEarned(this Student student)
            => student.Enrollments?.Where(e => e.Grade > Grade.F)
                    .Select(e => e.Section.Course)
                    .Distinct()
                    .Sum(c => c.Credits) ?? 0;

        public static IDictionary<Course, float> GetBestScores(
            this Student student)
        {
            var courses = student.Enrollments
                ?.Select(e => e.Section.Course)
                .Distinct() ?? new List<Course>();
            var res = new Dictionary<Course, float>();
            foreach (var c in courses)
            {
                res[c] = student.Enrollments
                    ?.Where(e => e.Section.Course == c)
                    .Select(e => e.GradePoint)
                    .Max() ?? 0;
            }
            return res;
        }

        public static float CalculateTotalGradePoints(this Student student)
            => student.GetBestScores().Sum(e => e.Value);

        public static float CalculateCgpa(this Student student)
            => student.CreditsEarned != 0 
                ? student.TotalGradePoints / student.CreditsEarned
                : 0;
    }
}