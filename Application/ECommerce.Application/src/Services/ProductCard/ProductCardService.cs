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
using ECommerce.Application.Abstracts.Picture;
using ECommerce.Application.Abstracts.Picture.Dtos;
using ECommerce.Domain.Enums;
using ECommerce.Application.Abstracts.Picture.Constant;

namespace ECommerce.Application.Services.ProductCard
{
    public class ProductCardService : IProductCardService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<Domain.Entities.ProductCard> _productCardRepository;
        private readonly IRepository<ProductCardPicture> _productCardPictureRepository;
        private readonly IRepository<ProductCardAttribute> _productCardAttributeRepository;
        private readonly IPictureService _pictureService;
        private readonly IStorage _storageService;
        private readonly IMapper _mapper;



        public ProductCardService(
            IMapper mapper,
            IRepository<Product> productRepository,
            IRepository<Domain.Entities.ProductCard> productCardRepository,
            IStorage storageService,
            IRepository<ProductCardAttribute> productCardAttributeRepository,
            IPictureService pictureService, IRepository<ProductCardPicture> productCardPictureRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productCardRepository = productCardRepository;
            _storageService = storageService;
            _productCardAttributeRepository = productCardAttributeRepository;
            _pictureService = pictureService;
            _productCardPictureRepository = productCardPictureRepository;
        }

        public async Task<IResult> AddAsync(ProductCardAddInDto request)
        {
            //ValidationTool.Validate(new AttributeAddInDtoValidator(), request);

            #region FirstStepAdd
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
                }).ToList()
            };

            product.ProductAttributeGroups = request.ProductAttributeGroups.Select(x => new ProductAttributeGroup
            {
                AttributeGroupId = x.AttributeGroupId,
            }).ToList();

            await _productRepository.AddAsync(product);
            #endregion


            var productAttrGroupsCount = product.ProductAttributeGroups.Count;

            List<ProductCardAttribute> productCardAttributeList = new();

            for (int i = 0; i < productAttrGroupsCount; i++)
            {
                //bir adet ürün ekleme
                if (i == 0)
                {
                    productCardAttributeList = request.ProductAttributeGroups[i].ProductCardAttributes.Select(y => new ProductCardAttribute
                    {
                        AttributeId = y.AttributeId,
                        ProductAttributeGroupId = product.ProductAttributeGroups[i].Id,
                        ProductCard = productAttrGroupsCount == (i + 1) ? new Domain.Entities.ProductCard
                        {
                            Sku = y.ProductCardItem.Sku,
                            Barcode = y.ProductCardItem.Barcode,
                            ProductCardPrice = new ProductCardPrice
                            {
                                SalesPrice = y.ProductCardItem.ProductCardPrice.SalesPrice,
                                IncludingVatPrice = y.ProductCardItem.ProductCardPrice.IncludingVatPrice,
                            },
                        } : null
                    }).ToList();

                    await _productCardAttributeRepository.AddRangeAsync(productCardAttributeList);
                }
                else
                {
                    AddProductCartAttributeGreaterOne(i);
                }

            }
            #region Inner Method
            //birden fazla ilişkili Attributeler için ürün ekleme
            async Task AddProductCartAttributeGreaterOne(int i)
            {
                List<ProductCardAttribute> temp = new();
                foreach (var parent in productCardAttributeList)
                {
                    temp.AddRange(request.ProductAttributeGroups[i].ProductCardAttributes.DistinctBy(x => x.AttributeId).Select(y => new ProductCardAttribute
                    {
                        AttributeId = y.AttributeId,
                        ProductAttributeGroupId = product.ProductAttributeGroups[i].Id,
                        ParentProductCardAttributeId = i == 0 ? null : parent.Id,
                        ProductCard = productAttrGroupsCount == (i + 1) ? new Domain.Entities.ProductCard
                        {
                            Sku = y.ProductCardItem.Sku,
                            Barcode = y.ProductCardItem.Barcode,
                            ProductCardPrice = new ProductCardPrice
                            {
                                SalesPrice = y.ProductCardItem.ProductCardPrice.SalesPrice,
                                IncludingVatPrice = y.ProductCardItem.ProductCardPrice.IncludingVatPrice,
                            },
                        } : null,
                    }).ToList());
                }
                productCardAttributeList = temp;
                await _productCardAttributeRepository.AddRangeAsync(productCardAttributeList);
            }
            #endregion

            return new SuccessResult();
        }

        //ProductCard = productAttrGroupsCount == (i+1) ? new Domain.Entities.ProductCard
        //{
        //    Sku = y.ProductCardItem.Sku,
        //    Barcode = y.ProductCardItem.Barcode,
        //    ProductCardPrice = new ProductCardPrice
        //    {
        //        SalesPrice = y.ProductCardItem.ProductCardPrice.SalesPrice,
        //        IncludingVatPrice = y.ProductCardItem.ProductCardPrice.IncludingVatPrice,
        //    },
        //} : null

        public async Task<IResult> AddPicturesToProduct(ProductCardPictureAddInDto request)
        {
            var blogServiceResult = await _storageService.UploadAsync("images", request.Pictures);

            foreach (var image in blogServiceResult)
            {
                var picture = await _pictureService.AddAsync(new PictureAddInDto
                {
                    FileType = FileTypeEnum.JPG,
                    FilePath = image.fileName
                });

                if (!picture.Success)
                {
                    return new ErrorResult(PictureConstant.CouldntAddPicture);
                }
                await _productCardPictureRepository.AddAsync(new ProductCardPicture
                {
                    PictureId = picture.Data.Id,
                    ProductCardId = request.ProductCardId
                });
            }

            return new SuccessResult();
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
                    Attribute = 5,
                    //AttributeGroup = new ProductExtendedAttributeGroupSubAdminOutDto
                    //{
                    //    AttributeGroupId = x.ProductCardAttribute.ProductAttributeGroup.AttributeGroupId,
                    //    AttributeGroupName = x.ProductCardAttribute.ProductAttributeGroup.AttributeGroup.Title
                    //},
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

            return new DataResult<IPagedList<ProductExtendedListAdminOutDto>>(result,true);

        }






    }
}
