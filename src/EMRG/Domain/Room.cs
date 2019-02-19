using System.Collections.Generic;

namespace Domain
{
    public class Room:Document
    {
        public int Number { get; set; }
        public List<Section> Sections { get; set; }

    }
}