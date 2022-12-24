using AutoMapper;
using ECommerce.Domain.Entities;


namespace ECommerce.Application.Abstracts.Attribute
{
    public class AttributeProfiles:Profile
    {
        public AttributeProfiles()
        {
            this.CreateMap<AttributeAddInDto, Attribute_>();
            this.CreateMap<Attribute_, AttributeListOutDto>();
        }
    }
}
