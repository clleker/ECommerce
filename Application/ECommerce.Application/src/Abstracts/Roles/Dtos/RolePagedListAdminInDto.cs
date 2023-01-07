using ECommerce.Core.Common.Paging;
using ECommerce.Core.src.Common.Paging;

namespace ECommerce.Application.Abstracts.Roles.Dtos
{
    public class RolePagedListAdminInDto : BasePagingRequestInDto
    {
        public string DisplayName { get; set; }
    }
}
