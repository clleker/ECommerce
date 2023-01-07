

namespace ECommerce.Application.Abstracts.AuthGroup.Dtos
{
    public class AuthGroupWithRoleUpdateInDto
    {
        public int Id { get; set; }
        /// <summary>
        /// AuthRoleGroupName e.g --> Sales Management,Admin etc.
        /// </summary>
        public int[] RoleIds { get; set; }
    }
}
