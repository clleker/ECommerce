

namespace ECommerce.Application.Abstracts.AuthGroup.Dtos
{
    public class AuthGroupWithRoleListOutDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RolesListOutSubDto[] Roles { get; set; }
    }

    public class RolesListOutSubDto
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
