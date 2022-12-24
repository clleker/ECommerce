

namespace ECommerce.Application.Abstracts.Customer.Dtos
{
    public class CustomerAddInDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public bool Status { get; set; }
        public DateTime RegisterDate { get; set; }
    }


}
