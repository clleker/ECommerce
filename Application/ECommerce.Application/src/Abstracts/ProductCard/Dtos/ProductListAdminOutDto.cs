using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Abstracts.ProductCard.Dtos
{
    public class ProductListAdminOutDto
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

        /// <summary>
        /// it's for products' detail page
        /// </summary>
        public string AdditionalInfo { get; set; }

        public string CategoryName { get; set; }

    }
}
