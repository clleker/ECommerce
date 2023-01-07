
namespace ECommerce.Application.Abstracts.ProductCardAttribute.Dtos
{
    public class ProductCardAttributeOutDto
    {
        /// <summary>
        /// ProductCardAttributeId
        /// </summary>
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int AttributeId { get; set; }

        public string AttributeName { get; set; }

        public List<ProductCardAttributeSubOutDto> ParentList { get; set; }
    }

    public class ProductCardAttributeSubOutDto
    {
        /// <summary>
        /// ProductCardAttributeId
        /// </summary>
        public int Id { get; set; }

        public int ParentId { get; set; }

        public int AttributeId { get; set; }

        public string AttributeName { get; set; }

    }
}
