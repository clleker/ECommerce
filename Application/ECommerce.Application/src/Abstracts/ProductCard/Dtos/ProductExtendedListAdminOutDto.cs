

namespace ECommerce.Application.Abstracts.ProductCard.Dtos
{
    public class ProductExtendedListAdminOutDto
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

        public ProductExtendedAttributeSubAdminOutDto Attribute { get; set; }

        public ProductExtendedAttributeGroupSubAdminOutDto AttributeGroup { get; set; }

        public string Barcode { get; set; }

        public string Sku { get; set; }

        public decimal SalesPrice { get; set; }

        public IEnumerable<CategoryListAdminSubOutDto> Categories { get; set; }

    }

    public class CategoryListAdminSubOutDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }


    public class ProductExtendedAttributeSubAdminOutDto
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
    }
    public class ProductExtendedAttributeGroupSubAdminOutDto
    {
        public int AttributeGroupId { get; set; }
        public string AttributeGroupName { get; set; }
    }

}
