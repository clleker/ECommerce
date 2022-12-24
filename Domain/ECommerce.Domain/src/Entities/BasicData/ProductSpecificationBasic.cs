using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Domain.Entities.BasicData
{
    public class ProductSpecificationBasic:IEntity<int>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
