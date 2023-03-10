

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

        public int[] CategoryIds { get; set; }

        /// <summary>
        /// Attribute Groups --> Boyut, Renk 
        /// </summary>
        public ProductAttributesGroupAddInDto[] ProductAttributeGroups { get; set; }
    }

   
    public class ProductAttributesGroupAddInDto
    {
        public int ProductId { get; set; }

        public int AttributeGroupId { get; set; }

        public ProductCardAttributesAddInDto[] ProductCardAttributes { get; set; }
    }

    public class ProductCardAttributesAddInDto
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int ProductAttributeGroupId { get; set; }
        public ProductCardItemAddInDto ProductCardItem{ get; set; }
    }

    public class ProductCardItemAddInDto
    {
        public string Sku { get; set; }

        public string Barcode { get; set; }

        public ProductCardPriceAddInDto ProductCardPrice { get; set; }

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
}
