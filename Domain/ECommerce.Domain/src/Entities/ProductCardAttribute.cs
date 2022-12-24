using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Domain.Entities
{
    public class ProductCardAttribute : IEntity<int>
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        #region Relations
        public int ProductAttributeGroupId { get; set; }
        public int AttributeId { get; set; }

        public virtual Attribute_ Attribute { get; set; }
        public virtual ProductAttributeGroup ProductAttributeGroup { get; set; }
        public virtual ProductCard ProductCard { get; set; }

        #endregion
    }
}
