using System;

using SharedLibrary;

namespace Domain
{
    public class Metadata : Entity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }

        public string CreationSummary => $"Created {CreatedAt.Natural()} ago by {CreatedBy}" ;
        public string UpdationSummary => $"Updated {UpdatedAt.Natural()} ago by {UpdatedBy}" ;
        public string Summary 
            => CreatedAt.LocalDateTime() == UpdatedAt.LocalDateTime() 
                    ? CreationSummary 
                    : UpdationSummary;

        private Metadata() { }

        private Metadata(string username)
        {
            CreatedBy = username;
            UpdatedBy = username;
            CreatedAt = DateTimeOffset.Now;
            UpdatedAt = DateTimeOffset.Now;
        }

        private Metadata(string creator, DateTimeOffset creationTime, string modifier)
        {
            CreatedBy = creator;
            CreatedAt = creationTime;
            UpdatedBy = modifier;
        }

        public static Metadata Created(string username) => new Metadata(username);

        public Metadata Updated(string username)
        {
            UpdatedBy = username;
            UpdatedAt = DateTimeOffset.Now;

            return this;
        }
    }
}
