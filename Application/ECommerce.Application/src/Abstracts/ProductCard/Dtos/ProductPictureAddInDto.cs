using Microsoft.AspNetCore.Http;


namespace ECommerce.Application.Abstracts.ProductCard.Dtos
{
    public class ProductPictureAddInDto
    {
        public int ProductCardId { get; set; }

        public IFormFileCollection Pictures { get; set; }
    }
}
