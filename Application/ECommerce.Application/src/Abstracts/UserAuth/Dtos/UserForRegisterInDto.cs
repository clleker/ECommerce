

namespace ECommerce.Application.Abstracts.Auth.Dtos
{
    public class UserForRegisterInDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
