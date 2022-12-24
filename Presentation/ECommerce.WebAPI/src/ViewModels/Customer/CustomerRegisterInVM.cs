using ECommerce.Domain.Enums;

namespace ECommerce.WebAPI.ViewModels.Customer
{
    public class CustomerRegisterInVM
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public GenderEnum Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool ConditionsOfMembershipStatus { get; set; }
        /// <summary>
        /// KVKK
        /// </summary>
        public bool PersonalDataProtectionStatus { get; set; }
    }
}
