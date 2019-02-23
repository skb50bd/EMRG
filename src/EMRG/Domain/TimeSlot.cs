using System;
using System.ComponentModel.DataAnnotations;

namespace Domain {
    public class TimeSlot : Entity
    {
        [Required]
        public DayOfWeek DayOfWeek { get; set; }

        [DataType(DataType.Time)]
        [Required]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
    }
}