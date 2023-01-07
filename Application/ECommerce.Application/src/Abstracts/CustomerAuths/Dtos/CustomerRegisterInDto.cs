

using ECommerce.Domain.Enums;

namespace ECommerce.Application.Abstracts.Customer.Dtos
{
    public class CustomerRegisterInDto
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
