using System.Collections.Generic;

namespace Domain
{
    public class Schedule : TrackedEntity
    {
        public List<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>(3);
    }
}