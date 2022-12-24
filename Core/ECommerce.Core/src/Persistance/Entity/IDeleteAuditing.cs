

namespace ECommerce.Core.Persistance.Entity
{

    public interface IDeleteAuditing : ISoftDelete
    {
        string DeletedUser { get; set; }

        DateTime? DeletedDate { get; set; }
    }
}
