

namespace ECommerce.Core.Domain.AppUser
{
    public class UserAuthGroup
    {
        public int Id { get; set; }

        /// <inheritdoc />
        public int UserId { get; set; }

        /// <inheritdoc />
        public int AuthGroupId { get; set; }

        /// <summary>
        /// Application user.
        /// </summary>
        public virtual AppUser User { get; set; }

        /// <summary>
        /// Application role.
        /// </summary>
        public virtual AuthGroup AuthGroup { get; set; }
    }
}
