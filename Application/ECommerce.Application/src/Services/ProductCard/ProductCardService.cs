using AutoMapper;
using ECommerce.Application.Abstracts.ProductCard;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services.ProductCard
{
    internal class ProductCardService:IProductCardService
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

    }
}
