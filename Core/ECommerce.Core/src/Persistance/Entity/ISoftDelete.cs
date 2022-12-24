
namespace ECommerce.Core.Persistance.Entity
{
    public interface ISoftDelete : IEntity
    {
        bool IsDeleted { get; set; }
    }
}
