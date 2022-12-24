using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Domain.Entities
{
    public class Picture:IEntity<int>
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }

        public ICollection<ProductCardPicture> ProductCardPictures { get; set; }


    }
}
