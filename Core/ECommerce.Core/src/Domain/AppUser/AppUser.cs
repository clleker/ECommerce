using ECommerce.Core.Persistance.Entity;


namespace ECommerce.Core.Domain.AppUser
{
    public class AppUser : IEntity<int>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public bool Status { get; set; }

        public ICollection<UserAuthGroup> UserAuthGroups { get; set; }
    }
}
