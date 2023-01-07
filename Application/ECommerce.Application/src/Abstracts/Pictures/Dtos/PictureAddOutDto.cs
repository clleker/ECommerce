

using ECommerce.Domain.Enums;

namespace ECommerce.Application.Abstracts.Picture.Dtos
{
    public class PictureAddOutDto
    {
        public int Id { get; set; }
        public FileTypeEnum FileType { get; set; }
        public string FilePath { get; set; }
    }
}
