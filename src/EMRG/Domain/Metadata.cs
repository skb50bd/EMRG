using System;

namespace Domain
{
    public class Metadata : Entity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatetAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
