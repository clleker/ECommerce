
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Abstracts.ProductCard
{
    public class ProductCardAddInDto
    {
        public int Id { get; set; }

        public string Name { get; set; }
        /// <summary>
        ///it's for Product Card
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// it's for products' detail page
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        /// it's for products' detail page
        /// </summary>
        public string ProductDetail { get; set; }

        /// <summary>
        /// it's for products' detail page
        /// </summary>
        public string AdditionalInfo { get; set; }

        public ProductCardAttributesGroupAddInDto[] ProductCardAttributesGroupAddInDto { get; set; }

    }

    public class ProductCardAttributesGroupAddInDto
    {
        public int ProductId { get; set; }

        public int AttributeGroupId { get; set; }

        public ProductCardAttributesAddInDto[] ProductCardAttributesAddInDto { get; set; }
    }

    public class ProductCardAttributesAddInDto
    {
        public int AttributeId { get; set; }
        public int ProductAttributeGroupId { get; set; }
        public int ParentId { get; set; }
        public ProductCardItemAddInDto ProductCardItemAddInDto { get; set; }
    }

    public class ProductCardItemAddInDto
    {
        public string Sku { get; set; }

        public string Barcode { get; set; }

        public ProductCardPriceAddInDto ProductCardPriceAddInDto { get; set; }

        public IList<ProductCardPictureAddInDto> ProductCardPictureAddInDto { get; set; }
    }

    public class ProductCardPriceAddInDto
    {
        /// <summary>
        /// SalesPrice
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// IncludingVatPrice
        /// </summary>
        public decimal IncludingVatPrice { get; set; }

        /// <summary>
        /// PurePrice
        /// </summary>
        public decimal PurePrice { get; set; }
        /// <summary>
        /// Gets or sets the ProductCost
        /// </summary>
        public decimal ProductCost { get; set; }
    }

    public class ProductCardPictureAddInDto
    {
        public string Dummy { get; set; }
        public IFormFile[] Pictures { get; set; }
    }

}
