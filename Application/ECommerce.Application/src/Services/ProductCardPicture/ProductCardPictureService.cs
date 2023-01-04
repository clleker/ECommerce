using AutoMapper;
using ECommerce.Application.Abstracts.ProductCard;
using ECommerce.Application.Abstracts.ProductCard.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;
using ECommerce.Application.Services.Storage;
using ECommerce.Application.Abstracts.Picture;
using ECommerce.Application.Abstracts.Picture.Dtos;
using ECommerce.Domain.Enums;
using ECommerce.Application.Abstracts.Picture.Constant;
using Microsoft.EntityFrameworkCore;
using ECommerce.Application.Services.Storage.Azure;

namespace ECommerce.Application.Services.ProductCard
{
    public class ProductCardPictureService : IProductCardPictureService
    {
        private readonly IRepository<ProductCardPicture> _productCardPictureRepository;
        private readonly IPictureService _pictureService;
        private readonly IStorage _storageService;
        private readonly IMapper _mapper;
        private readonly IBlobService _blobService;


        public ProductCardPictureService(
            IMapper mapper,
            IStorage storageService,
            IPictureService pictureService,
            IRepository<ProductCardPicture> productCardPictureRepository,
            IBlobService blobService)
        {
            _mapper = mapper;
            _storageService = storageService;
            _pictureService = pictureService;
            _productCardPictureRepository = productCardPictureRepository;
            _blobService = blobService;
        }

        //birden fazla ilişkili Attributeler için ürün ekleme

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


        public async Task<IDataResult<List<ProductCardPictureListOutDto>>> GetListByProductCardId(int productCardId)
        {
            var blobAddress = _blobService.GetBlobAddress();

            var pictureList = await _productCardPictureRepository.GetListAsync(
                selector: x => new ProductCardPictureListOutDto
                {
                    ProductPictureId = x.Id,
                    FilePath = string.Concat(blobAddress, "/", x.Picture.FilePath)
                },
             predicate: x => x.ProductCardId == productCardId,
             include: x => x.Include(x => x.Picture)
             );

            return new SuccessDataResult<List<ProductCardPictureListOutDto>>(pictureList);
        }
    }
}
