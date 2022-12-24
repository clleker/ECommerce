

using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Domain.Entities
{
    public class ProductCard : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the SKU
        /// </summary>
        public string Sku { get; set; }

        public string Barcode { get; set; }

        #region Relations
        public int ProductCardAttributeId { get; set; }
        public virtual ProductCardAttribute ProductCardAttribute { get; set; }
        public virtual ProductCardPrice ProductCardPrice { get; set; }
        public ICollection<ProductCardPicture> Pictures { get; set; }

        #endregion
    }
}
