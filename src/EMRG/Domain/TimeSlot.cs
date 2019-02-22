using System;

namespace Domain
{
    public class TimeSlot : TrackedEntity
    {
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
    }
}