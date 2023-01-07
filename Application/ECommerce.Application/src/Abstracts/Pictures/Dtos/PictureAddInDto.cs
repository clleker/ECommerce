

using ECommerce.Domain.Enums;

namespace ECommerce.Application.Abstracts.Picture.Dtos
{
    public class PictureAddInDto
    {
        public FileTypeEnum FileType { get; set; }
        public string FilePath { get; set; }
    }
}
