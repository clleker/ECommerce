
namespace Core.Persistance
{
    public interface ISoftDelete : IEntity
    {
        bool IsDeleted { get; set; }
    }
}
