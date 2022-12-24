using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Domain.Entities
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the meta keywords
        /// </summary>
        public string MetaKeywords { get; set; }

        /// <summary>
        /// Gets or sets the meta description
        /// </summary>
        public string MetaDescription { get; set; }

        /// <summary>
        /// Gets or sets the meta title
        /// </summary>
        public string MetaTitle { get; set; }

        public string UrlImage { get; set; }

        /// <summary>
        /// Gets or sets the parent category identifier
        /// </summary>
        public int? ParentCategoryId { get; set; }

        #region Relations
        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public Category? ParentCategory { get; set; }
        public virtual ICollection<Category> SubCategories { get; set; }


        #endregion

    }
}
