using ECommerce.Core.Persistance.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Domain.Entities
{
    public class ProductCardAttribute : IEntity<int>
    {
        public int Id { get; set; }

        public int? ParentProductCardAttributeId { get; set; }
        public int ProductAttributeGroupId { get; set; }
        public int AttributeId { get; set; }

        #region Relations
        public virtual Attribute_ Attribute { get; set; }
        public virtual ProductAttributeGroup ProductAttributeGroup { get; set; }
        public virtual ProductCard ProductCard { get; set; }
        public ProductCardAttribute? ParentProductCardAttribute { get; set; }
        public virtual ICollection<ProductCardAttribute> SubProductCardAttributes { get; set; }

        #endregion
    }
}
