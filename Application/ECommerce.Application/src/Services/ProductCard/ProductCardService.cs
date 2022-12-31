using AutoMapper;
using ECommerce.Application.Abstracts.ProductCard;
using ECommerce.Application.Abstracts.ProductCard.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using Ecommerce.Core.Common.Extensions;
using ECommerce.Core.Persistance.PagedList;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ECommerce.Application.Services.Storage;

namespace ECommerce.Application.Services.ProductCard
{
    public class ProductCardService : IProductCardService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Domain.Entities.ProductCard> _productCardRepository;
        private readonly IStorage _storageService;


        public ProductCardService(
            IMapper mapper,
            IRepository<Product> productRepository,
            IRepository<Domain.Entities.ProductCard> productCardRepository,
            IStorage storageService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productCardRepository = productCardRepository;
            _storageService = storageService;
        }

        public async Task<IResult> AddAsync(ProductCardAddInDto request)
        {
            //ValidationTool.Validate(new AttributeAddInDtoValidator(), request);

            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                ShortDescription = request.ShortDescription,
                LongDescription = request.LongDescription,
                ProductDetail = request.ProductDetail,
                AdditionalInfo = request.AdditionalInfo,
                ProductCategories = request.CategoryIds.Select(categoryId => new ProductCategory
                {
                    CategoryId = categoryId,
                }).ToList(),
                ProductAttributeGroups = request.ProductCardAttributesGroup.Select(x => new ProductAttributeGroup
                {
                    AttributeGroupId = x.AttributeGroupId,
                    ProductCardAttributes = x.ProductCardAttributes.Select(y => new ProductCardAttribute
                    {
                        AttributeId = y.AttributeId,
                        ParentId = y.ParentId,
                        ProductAttributeGroupId = y.ProductAttributeGroupId,//- 
                        ProductCard = y != null ? new Domain.Entities.ProductCard
                        {
                            Sku = y.ProductCardItem.Sku,
                            Barcode = y.ProductCardItem.Barcode,
                            Pictures = null,
                            ProductCardPrice = new ProductCardPrice
                            {
                                SalesPrice = y.ProductCardItem.ProductCardPrice.SalesPrice,
                                IncludingVatPrice = y.ProductCardItem.ProductCardPrice.IncludingVatPrice,
                            },
                        } : null
                    }).ToList(),
                }).ToList()
            };

            await _productRepository.AddAsync(product);

            return new SuccessResult();
        }

        public async Task<IResult> AddPicturesToProduct(ProductPictureAddInDto request)
        {
            var blogServiceResult = await _storageService.UploadAsync("images", request.Pictures);

            foreach (var item in blogServiceResult)
            {
                Console.WriteLine(item);
            }
            //category.UrlImage = string.Concat(blogServiceResult[0].pathOrContainerName, blogServiceResult[0].fileName);

            return null;
        }


        //public async Task<IDataResult<IPagedList<ProductExtendedListAdminOutDto>>> GetListProductByPagingAsync(ProductPagedListAdminInDto request)
        //{
        //    var query = _productRepository.GetQueryable(
        //         selector: x => new ProductExtendedListAdminOutDto
        //         {
        //             Id = x.Id,
        //             AdditionalInfo = x.AdditionalInfo,
        //             LongDescription = x.LongDescription,
        //             Name = x.Name,
        //             ProductDetail = x.ProductDetail,
        //             ShortDescription = x.ShortDescription,
        //             Categories = x.ProductCategories.Select(y => new CategoryListAdminSubOutDto { CategoryId = y.Category.Id, CategoryName = y.Category.Name })
        //         },
        //        predicate: x => !x.IsDeleted && (string.IsNullOrEmpty(request.ProductName) || EF.Functions.Like(EF.Functions.Collate(x.Name, "Latin1_general_CI_AI"), $"%{request.ProductName}%")),
        //        include: x => x.Include(x => x.ProductCategories).ThenInclude(x => x.Category));

        //    if (request.Orders?.Any() == true)
        //    {
        //        query = request.Orders.Aggregate(query, (current, order) => order.DirectionDesc ? current.OrderByDescending(order.ColumnName) : current.OrderBy(order.ColumnName));
        //    }
        //    var result = await query.ToPagedListAsync(request.PageIndex, request.PageSize).ConfigureAwait(false);

        //    return new DataResult<IPagedList<ProductListAdminOutDto>>(result, true);
        //}


        public async Task<IDataResult<IPagedList<ProductExtendedListAdminOutDto>>> GetExtendedProductCardListByPagingAsync(ProductPagedListAdminInDto request)
        {
            var query = _productCardRepository.GetQueryable(
                selector: x => new ProductExtendedListAdminOutDto
                {
                    ProductCardId = x.Id,
                    AdditionalInfo = x.ProductCardAttribute.ProductAttributeGroup.Product.AdditionalInfo,
                    LongDescription = x.ProductCardAttribute.ProductAttributeGroup.Product.LongDescription,
                    Name = x.ProductCardAttribute.ProductAttributeGroup.Product.Name,
                    ProductDetail = x.ProductCardAttribute.ProductAttributeGroup.Product.ProductDetail,
                    Attribute = new ProductExtendedAttributeSubAdminOutDto
                    {
                        AttributeId = x.ProductCardAttribute.Attribute.Id,
                        AttributeName = x.ProductCardAttribute.Attribute.Name
                    },
                    AttributeGroup = new ProductExtendedAttributeGroupSubAdminOutDto
                    {
                        AttributeGroupId = x.ProductCardAttribute.ProductAttributeGroup.AttributeGroupId,
                        AttributeGroupName = x.ProductCardAttribute.ProductAttributeGroup.AttributeGroup.Title
                    },
                    ShortDescription = x.ProductCardAttribute.ProductAttributeGroup.Product.ShortDescription,
                    Categories = x.ProductCardAttribute.ProductAttributeGroup.Product.ProductCategories.Select(y => new CategoryListAdminSubOutDto { CategoryId = y.Category.Id, CategoryName = y.Category.Name }),
                    Barcode = x.Barcode,
                    Sku = x.Sku,
                    SalesPrice = x.ProductCardPrice.SalesPrice

                },
                predicate: x => (string.IsNullOrEmpty(request.ProductName) || EF.Functions.Like(EF.Functions.Collate(x.ProductCardAttribute.ProductAttributeGroup.Product.Name, "Latin1_general_CI_AI"), $"%{request.ProductName}%")),
                include: x => x.Include(x => x.ProductCardAttribute)
                .ThenInclude(x => x.ProductAttributeGroup)
                .ThenInclude(x => x.Product)
                .ThenInclude(x => x.ProductCategories)
                .ThenInclude(x => x.Category)
                .Include(x => x.ProductCardAttribute)
                .ThenInclude(x => x.Attribute)
                .Include(x => x.ProductCardPrice));

            if (request.Orders?.Any() == true)
            {
                query = request.Orders.Aggregate(query, (current, order) => order.DirectionDesc ? current.OrderByDescending(order.ColumnName) : current.OrderBy(order.ColumnName));
            }
            var result = await query.ToPagedListAsync(request.PageIndex, request.PageSize).ConfigureAwait(false);

            return new DataResult<IPagedList<ProductExtendedListAdminOutDto>>(result, true);

        }
    }
}
