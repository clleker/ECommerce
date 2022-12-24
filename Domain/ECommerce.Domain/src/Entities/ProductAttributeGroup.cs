

using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Domain.Entities
{
    /// <summary> N to N  </summary>
    public class ProductAttributeGroup : IEntity<int>
    {
        public int Id { get; set; }

        #region Relations
        public int ProductId { get; set; }
        public int AttributeGroupId { get; set; }
        public virtual Product Product { get; set; }
        public virtual AttributeGroup AttributeGroup { get; set; }
        public ICollection<ProductCardAttribute> ProductCardAttributes { get; set; }

        #endregion

    }
}
