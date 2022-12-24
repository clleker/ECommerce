
using FluentValidation;


namespace ECommerce.Application.Abstracts.AttributeGroup
{
    public class AttributeGroupAddInDtoValidator : AbstractValidator<AttributeGroupAddInDto>
    {
        public AttributeGroupAddInDtoValidator()
        {
            RuleFor(c => c.Title).NotEmpty().MaximumLength(100);
        }
    }
    public class AttributeGroupUpdateInDtoValidator : AbstractValidator<AttributeGroupUpdateInDto>
    {
        public AttributeGroupUpdateInDtoValidator()
        {
            RuleFor(c => c.Title).NotEmpty().MaximumLength(100);
        }
    }
 
    
}
