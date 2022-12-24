using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Core.Domain.AppUser
{
    public class AuthGroupRole : IEntity<int>
    {
        public int Id { get; set; }

        /// <inheritdoc />
        public int RoleId { get; set; }

        /// <inheritdoc />
        public int AuthGroupId { get; set; }

        /// <summary>
        /// Application user.
        /// </summary>
        public virtual AppRole Role { get; set; }

        /// <summary>
        /// Application role.
        /// </summary>
        public virtual AuthGroup AuthGroup { get; set; }

    }
}
