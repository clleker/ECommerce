
namespace ECommerce.WebAPI.ViewModels.Category
{
    public class MobileMenu
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Label { get; set; }
        public IEnumerable<MobileMenu> SubMenu { get; set; }
    }
}
