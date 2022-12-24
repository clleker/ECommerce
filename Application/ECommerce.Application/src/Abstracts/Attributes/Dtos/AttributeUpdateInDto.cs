
namespace ECommerce.Application.Abstracts.Attribute
{
    public class AttributeUpdateInDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Attribute name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

    }
}
