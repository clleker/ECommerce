using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Core.Domain.AppUser
{
    public class AuthGroup:IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// GroupName
        /// </summary>
        public string Name { get; set; }

        public ICollection<UserAuthGroup> UserAuthGroups { get; set; }

        public ICollection<AuthGroupRole> AuthGroupRoles { get; set; }

    }
}
