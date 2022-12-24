

namespace ECommerce.Application.Abstracts.AuthGroup.Dtos
{
    public class AuthGroupWithRoleAddInDto
    {
        /// <summary>
        /// AuthRoleGroupName e.g --> Sales Management,Admin etc.
        /// </summary>
        public string Name { get; set; }

        public int[] RoleIds { get; set; }
    }
}
