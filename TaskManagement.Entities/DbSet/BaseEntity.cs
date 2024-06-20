namespace TaskManagement.Entities.DbSet
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; } = new Guid();
        public int Status { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }

    }
}
