using AutoMapper;
using ECommerce.Application.Abstracts.ProductCard;
using ECommerce.Application.Abstracts.ProductCard.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using Ecommerce.Core.Common.Extensions;
using ECommerce.Core.Persistance.PagedList;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Application.Services.ProductCard
{
    public class ProductCardService : IProductCardService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Product> _productRepository;

        public ProductCardService(
            IMapper mapper,
            IRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IResult> AddAsync(ProductCardAddInDto request)
        {
            //ValidationTool.Validate(new AttributeAddInDtoValidator(), request);

            var attribute = _mapper.Map<Attribute_>(request);

            var product = new Product
            {
                Id = request.Id,
                Name = request.Name,
                ShortDescription = request.ShortDescription,
                LongDescription = request.LongDescription,
                ProductDetail = request.ProductDetail,
                AdditionalInfo = request.AdditionalInfo,
                ProductAttributeGroups = request.ProductCardAttributesGroupAddInDto.Select(x => new ProductAttributeGroup
                {
                    AttributeGroupId = x.AttributeGroupId,
                    ProductCardAttributes = x.ProductCardAttributesAddInDto.Select(y => new ProductCardAttribute
                    {
                        AttributeId = y.AttributeId,
                        ParentId = y.ParentId,
                        ProductAttributeGroupId = y.ProductAttributeGroupId,//- 
                        ProductCard = y != null ? new Domain.Entities.ProductCard
                        {
                            Sku = y.ProductCardItemAddInDto.Sku,
                            Barcode = y.ProductCardItemAddInDto.Barcode,
                            Pictures = null,
                            ProductCardPrice = new ProductCardPrice
                            {
                                SalesPrice = y.ProductCardItemAddInDto.ProductCardPriceAddInDto.SalesPrice,
                                IncludingVatPrice = y.ProductCardItemAddInDto.ProductCardPriceAddInDto.IncludingVatPrice,
                            },
                        } : null
                    }).ToList(),
                }).ToList()
            };

            await _productRepository.AddAsync(product);

            return new SuccessResult();
        }

        public async Task<IDataResult<IPagedList<ProductListAdminOutDto>>> GetListProductByPagingAsync(ProductPagedListAdminInDto request)
        {
            var query = _productRepository.GetQueryable(
                 selector: x => new ProductListAdminOutDto
                 {
                     Id = x.Id,
                     AdditionalInfo = x.AdditionalInfo,
                     LongDescription = x.LongDescription,
                     Name = x.Name,
                     ProductDetail = x.ProductDetail,
                     ShortDescription = x.ShortDescription
                 },
                predicate: x => !x.IsDeleted && (string.IsNullOrEmpty(request.ProductName) || x.Name.Contains(request.ProductName)),
                include: x => x.Include(x => x.ProductCategories).ThenInclude(x => x.Category));

            if (request.Orders?.Any() == true)
            {
                query = request.Orders.Aggregate(query, (current, order) => order.DirectionDesc ? current.OrderByDescending(order.ColumnName) : current.OrderBy(order.ColumnName));
            }
            var result = await query.ToPagedListAsync(request.PageIndex, request.PageSize).ConfigureAwait(false);

            return new DataResult<IPagedList<ProductListAdminOutDto>>(result, true);
        }
    }
}
