
namespace ECommerce.Core.Persistance.Entity
{
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
