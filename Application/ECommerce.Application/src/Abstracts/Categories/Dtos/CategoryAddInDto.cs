
using Microsoft.AspNetCore.Http;

namespace ECommerce.Application.Abstracts.Category
{
    public class CategoryAddInDto
    {
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name
        /// </summary>
        public string Name { get; set; }

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

        public IFormFileCollection IconImage { get; set; }

        /// <summary>
        /// Gets or sets the parent category identifier
        /// </summary>
        public int? ParentCategoryId { get; set; }

    }
}
