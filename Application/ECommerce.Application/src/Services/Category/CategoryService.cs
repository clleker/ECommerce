using AutoMapper;
using ECommerce.Domain.Entities;
using ECommerce.Application.Services.Storage;
using Microsoft.EntityFrameworkCore;
using ECommerce.Application.Abstracts.Category;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Application.CrossCuttingConcerns.Aspects;

namespace ECommerce.Application.Services.Categories
{
    public class CategoryService: ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _categoryRepository;
        private readonly IStorage _storageService;
        public CategoryService(
            IMapper mapper,
            IRepository<Category> categoryRepository,
            IStorage storageService)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _storageService = storageService;
        }


        [ValidationAspect(typeof(CategoryAddInDto), Priority = 1)]
        public async Task<IResult> AddAsync(CategoryAddInDto request)
        {
            var category = _mapper.Map<Category>(request);

            var blogServiceResult = await _storageService.UploadAsync("images", request.IconImage);

            category.UrlImage = string.Concat(blogServiceResult[0].pathOrContainerName, blogServiceResult[0].fileName);

            await _categoryRepository.AddAsync(category);

            return new SuccessResult();
        }


        public async Task<IResult> DeleteAsync(int id)
        {
            await _categoryRepository.DeleteAsync(new Category { Id = id });

            return new SuccessResult();
        }

        [ValidationAspect(typeof(CategoryUpdateInDto), Priority = 1)]
        public async Task<IResult> UpdateAsync(CategoryUpdateInDto request)
        {
            var category = _mapper.Map<Category>(request);

            var dbcategory = await _categoryRepository.GetFirstOrDefaultAsync(predicate: x => x.Name == category.Name).ConfigureAwait(false);

            await _categoryRepository.UpdateAsync(category);

            return new SuccessResult();
        }

        public async Task<IDataResult<CategoryGetByIdOutDto>> GetByIdAsync(int id)
        {
            var result = await _categoryRepository.GetFirstOrDefaultAsync(
                    predicate: x => x.Id == id,
                     selector: x => new CategoryGetByIdOutDto
                     {
                         Id = x.Id,
                         Description = x.Description,
                         Name = x.Name,
                         MetaDescription = x.MetaDescription,
                         Slug = x.Slug,
                         MetaKeywords = x.MetaKeywords,
                         MetaTitle = x.MetaTitle,
                         ParentCategoryId = x.ParentCategory.Id,
                         ParentCategoryName = x.ParentCategory.Name
                     },
                    include: x => x.Include(x => x.ParentCategory)).ConfigureAwait(false);

            return new SuccessDataResult<CategoryGetByIdOutDto>();
        }

        public async Task<IDataResult<List<CategoryListOutDto>>> GetListAsync()
        {
            var result = await _categoryRepository.GetListAsync(
                     selector: x => new CategoryListOutDto
                     {
                         Id = x.Id,
                         Description = x.Description,
                         Name = x.Name,
                         MetaDescription = x.MetaDescription,
                         Slug = x.Slug,
                         MetaKeywords = x.MetaKeywords,
                         MetaTitle = x.MetaTitle,
                         ParentCategoryId = x.ParentCategory.Id,
                         UrlImage = x.UrlImage,
                         ParentCategoryName = x.ParentCategory.Name
                     },
                     include: x => x.Include(x => x.ParentCategory)).ConfigureAwait(false);

            return new SuccessDataResult<List<CategoryListOutDto>>(result);

        }

        public async Task<IDataResult<List<CategoryListWithChildrenOutDto>>> GetListWithChildrenAsync()
        {
            var result = await _categoryRepository.GetListAsync(
                predicate: x => x.ParentCategoryId == null,
                selector: x => new CategoryListWithChildrenOutDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    MetaKeywords = x.MetaKeywords,
                    MetaTitle = x.MetaTitle,
                    UrlImage = x.UrlImage,
                    Children = x.SubCategories.Select(x => new CategoryListWithChildrenOutDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Slug = x.Slug,
                        Description = x.Description,
                        MetaDescription = x.MetaDescription,
                        MetaKeywords = x.MetaKeywords,
                        MetaTitle = x.MetaTitle,
                        UrlImage = x.UrlImage,
                    }).AsEnumerable()
                },
                include: x => x.Include(x => x.SubCategories)).ConfigureAwait(false);

            return new SuccessDataResult<List<CategoryListWithChildrenOutDto>>();
        }
    }
}
