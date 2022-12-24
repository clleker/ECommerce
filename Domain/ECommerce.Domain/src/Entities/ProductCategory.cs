using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Domain.Entities
{
    /// <summary> N to N  </summary>
    public class ProductCategory : IEntity<int>
    {
        public int Id { get; set; }

        #region Relations
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Category Category { get; set; }
        #endregion


    }
}
