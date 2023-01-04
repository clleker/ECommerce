using ECommerce.Core.Persistance.Entity;
using ECommerce.Domain.Enums;

namespace ECommerce.Domain.Entities
{
    public class Picture:IEntity<int>
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public FileTypeEnum FileType { get; set; }

        public ICollection<ProductCardPicture> ProductCardPictures { get; set; }

    }
}
