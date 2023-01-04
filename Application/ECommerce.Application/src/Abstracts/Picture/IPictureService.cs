using ECommerce.Application.Abstracts.Picture.Dtos;
using ECommerce.Core.Application.ObjectDesign;


namespace ECommerce.Application.Abstracts.Picture
{
    public interface IPictureService : IApplicationService
    {
        Task<IDataResult<PictureAddOutDto>> AddAsync(PictureAddInDto request);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id">Picture Id</param>
        /// <returns></returns>
        Task<IResult> DeleteAsync(int Id);
    }
}
