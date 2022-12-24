
using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Domain.Entities
{
    public class Attribute_: IEntity<int>
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


        #region Relations
        public ICollection<ProductCardAttribute> ProductCardAttributes { get; set; }
        #endregion

    }
}
