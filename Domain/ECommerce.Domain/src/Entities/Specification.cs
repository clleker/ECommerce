using ECommerce.Core.Persistance.Entity;

namespace Nop.Core.Domain.Catalog
{
    /// <summary>
    /// Represents a product specification attribute
    /// </summary>
    public partial class Specification : IEntity<int>
    {
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the product identifier
        /// </summary>
        //public int ProductId { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }
    }
}
