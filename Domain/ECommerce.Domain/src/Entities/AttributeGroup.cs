
using ECommerce.Core.Persistance.Entity;

namespace ECommerce.Domain.Entities
{
    public   class AttributeGroup : IEntity<int>
    {
        /// <summary> PK. </summary>
        public int Id { get; set; }

        /// <summary> Group Name </summary>
        public string Title { get; set; }

        #region Relations
        public ICollection<ProductAttributeGroup> ProductAttributeGroups { get; set; }
        #endregion
    }
}
