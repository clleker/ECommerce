using FluentValidation;


namespace ECommerce.Application.Abstracts.Attribute
{
    public class AttributeAddInDtoValidator : AbstractValidator<AttributeAddInDto>
    {
        public AttributeAddInDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        }
    }
    public class AttributeUpdateInDtoValidator : AbstractValidator<AttributeUpdateInDto>
    {
        public AttributeUpdateInDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        }
    }
 
    
}
