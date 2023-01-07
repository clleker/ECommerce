

using ECommerce.Core.Application.ObjectDesign;


namespace ECommerce.Application.Abstracts.Category
{
    public interface ICategoryService : IApplicationService
    {
        Task<IResult> AddAsync(CategoryAddInDto request);
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(CategoryUpdateInDto request);
        Task<IDataResult<CategoryGetByIdOutDto>> GetByIdAsync(int id);
        Task<IDataResult<List<CategoryListOutDto>>> GetListAsync();
        Task<IDataResult<List<CategoryListWithChildrenOutDto>>> GetListWithChildrenAsync();
    }
}
