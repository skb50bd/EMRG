using System;

namespace Domain
{
    public class TimeSlot : TrackedEntity
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
        public int SectionId { get; set; }
        public Section Section { get; set; }

    }
}