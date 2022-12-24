
namespace Core.Persistance
{
    public interface IUpdateAuditing
    {
        string UpdatedUser { get; set; }

        DateTime? UpdatedDate { get; set; }
    }
}
