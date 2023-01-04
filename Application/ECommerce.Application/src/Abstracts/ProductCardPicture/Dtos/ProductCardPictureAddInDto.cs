using Microsoft.AspNetCore.Http;


namespace ECommerce.Application.Abstracts.ProductCard.Dtos
{
    public class ProductCardPictureAddInDto
    {
        public int ProductCardId { get; set; }

        public IFormFileCollection Pictures { get; set; }
    }
}
