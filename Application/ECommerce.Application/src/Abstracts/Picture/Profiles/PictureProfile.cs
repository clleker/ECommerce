using AutoMapper;
using ECommerce.Application.Abstracts.Picture.Dtos;

namespace ECommerce.Application.Abstracts.Picture.Profiles
{
    public class PictureProfile : Profile
    {
        public PictureProfile()
        {
            this.CreateMap<PictureAddInDto, Domain.Entities.Picture>();
            this.CreateMap<Domain.Entities.Picture, PictureAddOutDto>();
        }
    }
}
