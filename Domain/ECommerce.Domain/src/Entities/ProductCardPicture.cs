using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Domain.Entities
{
    public class ProductCardPicture:IEntity<int>
    {
        public int Id { get; set; }


        #region Relations
        public int PictureId { get; set; }
        public Picture Picture { get; set; }
        public int ProductCardId { get; set; }
        public ProductCard ProductCard { get; set; }

        #endregion
    }
}
