

namespace Core.Persistance
{

    public interface IDeleteAuditing : ISoftDelete
    {
        string DeletedUser { get; set; }

        DateTime? DeletedDate { get; set; }
    }
}
