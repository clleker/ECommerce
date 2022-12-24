
using FluentValidation;


namespace ECommerce.Application.Abstracts.ProductCard
{
    public class ProductCardAddInDtoValidator : AbstractValidator<ProductCardAddInDto>
    {
        public ProductCardAddInDtoValidator()
        {
            RuleFor(c => c.Name).NotEmpty().MaximumLength(100);
        }
    }
 
 
    
}
