using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Domain.Entities
{
    public class ProductCardPrice : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// SalesPrice
        /// </summary>
        public decimal SalesPrice { get; set; }

        /// <summary>
        /// IncludingVatPrice
        /// </summary>
        public decimal IncludingVatPrice { get; set; }

        /// <summary>
        /// PurePrice
        /// </summary>
        public decimal PurePrice { get; set; }
        /// <summary>
        /// Gets or sets the ProductCost
        /// </summary>
        public decimal ProductCost { get; set; }

        #region Relations 
        public int ProductCardId { get; set; }

        public ProductCard ProductCard { get; set; }

        #endregion
    }
}
