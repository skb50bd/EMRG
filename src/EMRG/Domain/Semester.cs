using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Semester: Document
    {
        public Season Season { get; set; }
        public int Year { get; set; }

        public override string ToString() => Name;
        public string Name => Season.ToString() + " " + Year;
    }

    public enum Season
    {
        Spring = 1,
        Summer = 2,
        Fall = 3
    }
}
