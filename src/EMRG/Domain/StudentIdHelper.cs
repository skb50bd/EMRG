using System;

namespace Domain
{
    public static class StudentIdHelper
    {
        public static Season GetSeason(this DateTime dt)
        {
            if (dt.Month < 5) return Season.Spring;
            if (dt.Month < 9) return Season.Summer;
            return Season.Fall;
        }

        public static string GetIdPrefix(DateTime dt, int programCode)
            => dt.Year + "-" + (int)dt.GetSeason() + "-" + programCode + "-";
    }
}