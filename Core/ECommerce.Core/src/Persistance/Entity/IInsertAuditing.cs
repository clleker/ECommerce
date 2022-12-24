
namespace ECommerce.Core.Persistance.Entity
{
    public interface IInsertAuditing
    {
        string InsertedUser { get; set; }

        DateTime? InsertedDate { get; set; }
    }
}
