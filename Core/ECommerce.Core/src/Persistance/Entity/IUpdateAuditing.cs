
namespace ECommerce.Core.Persistance.Entity
{
    public interface IUpdateAuditing
    {
        string UpdatedUser { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}
