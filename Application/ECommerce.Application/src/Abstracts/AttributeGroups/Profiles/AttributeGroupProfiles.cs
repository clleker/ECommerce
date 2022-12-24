

using AutoMapper;

namespace ECommerce.Application.Abstracts.AttributeGroup
{
    public class AttributeGroupProfiles:Profile
    {
        public AttributeGroupProfiles()
        {
            this.CreateMap<AttributeGroupAddInDto, Domain.Entities.AttributeGroup>();
            this.CreateMap<AttributeGroupUpdateInDto, Domain.Entities.AttributeGroup>();
        }
    }
}
