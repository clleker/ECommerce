
namespace Core.Persistance
{
    public interface IInsertAuditing
    {
        string InsertedUser { get; set; }

        DateTime? InsertedDate { get; set; }
    }
}
