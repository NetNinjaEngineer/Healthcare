namespace Healthcare.Domain.Interceptors;
public interface ISoftDeletable
{
    public bool IsDeleted { get; set; }
    public DateTimeOffset? DeletedAt { get; set; }

    public void Delete()
    {
        DeletedAt = DateTime.UtcNow;
        IsDeleted = true;
    }

    public void UndoDelete()
    {
        IsDeleted = false;
        DeletedAt = null;
    }
}
