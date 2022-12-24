using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Domain.Entities
{
    public class CustomerSetting:IEntity<int>
    {
        public int Id { get; set; }


        #region Relations
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        #endregion


    }
}
