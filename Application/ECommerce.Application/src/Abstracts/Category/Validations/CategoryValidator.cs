
using FluentValidation;


namespace ECommerce.Application.Abstracts.Category
{
    public class CategoryAddInDtoValidator : AbstractValidator<CategoryAddInDto>
    {
        public CategoryAddInDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        }
    }
    public class CategoryUpdateInDtoValidator : AbstractValidator<CategoryUpdateInDto>
    {
        public CategoryUpdateInDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
            RuleFor(c => c.Slug).NotEmpty().MaximumLength(100);
        }
    }


  
}
