using AutoMapper;
using ECommerce.Application.Abstracts.Category;
using ECommerce.WebAPI.ViewModels.Category;

namespace ECommerce.WebAPI.Profiles
{
    public class CategoryApiProfiles : Profile
    {
        public CategoryApiProfiles()
        {
            this.CreateMap<CategoryListWithChildrenOutDto, MobileMenu>();
        }
    }
}
