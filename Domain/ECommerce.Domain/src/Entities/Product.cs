using ECommerce.Core.Persistance.Entity;
using Nop.Core.Domain.Catalog;

namespace ECommerce.Domain.Entities
{
    public class Product : IEntity<int>, IDeleteAuditing
    {
        public int Id { get; set; }

        public string Name { get; set; }

        /// <summary>
        ///it's for Product Card
        /// </summary>
        public string ShortDescription { get; set; }

        /// <summary>
        /// it's for products' detail page
        /// </summary>
        public string LongDescription { get; set; }

        /// <summary>
        /// it's for products' detail page
        /// </summary>
        public string ProductDetail { get; set; }

        public string AdditionalInfo { get; set; }

        #region Relations
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public ICollection<Specification> ProductSpecifications { get; set; }
        public ICollection<ProductAttributeGroup> ProductAttributeGroups { get; set; }

        public string DeletedUser { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool IsDeleted { get; set; }
        #endregion

    }
}
