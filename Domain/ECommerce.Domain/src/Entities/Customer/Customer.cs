using ECommerce.Core.Persistance.Entity;
using ECommerce.Domain.Enums;


namespace ECommerce.Domain.Entities
{
    public class Customer:IEntity<int>,ISoftDelete
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public GenderEnum Gender { get; set; }

        public bool IsConfirmEmail { get; set; }

        public bool IsConfirmPhone { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime RegisterEmailConfirmDate { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether the customer is active
        /// </summary>
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }

        #region Relations
        public virtual CustomerSetting CustomerSetting { get; set; }
        #endregion
    }
}
