using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Core.Domain.AppUser
{
    public class AppRole:IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public ICollection<AuthGroupRole> AuthGroupRoles { get; set; }
    }
}
