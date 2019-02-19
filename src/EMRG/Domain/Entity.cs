namespace Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
    }

    public abstract class TrackedEntity : Entity
    {
        public bool IsRemoved { get; set; }
    }

    public abstract class Document : TrackedEntity
    {
        public Metadata Meta { get; set; }
    }
}
