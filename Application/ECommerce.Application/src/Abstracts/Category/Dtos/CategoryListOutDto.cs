

namespace ECommerce.Application.Abstracts.Category
{
    public class CategoryListOutDto
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

        public string ParentCategoryName { get; set; }
    }
}
