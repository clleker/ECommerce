using AutoMapper;

namespace ECommerce.Application.Abstracts.Category
{
    public class CategoryProfiles : Profile
    {
        public CategoryProfiles()
        {
            this.CreateMap<CategoryAddInDto, Domain.Entities.Category>();
            this.CreateMap<CategoryUpdateInDto, Domain.Entities.Category>();
            this.CreateMap<Domain.Entities.Category, CategoryListOutDto>();
            this.CreateMap<Domain.Entities.Category, CategoryGetByIdOutDto>();
        }
    }
}
