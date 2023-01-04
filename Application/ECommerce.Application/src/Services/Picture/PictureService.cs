

using AutoMapper;
using ECommerce.Application.Abstracts.Picture;
using ECommerce.Application.Abstracts.Picture.Dtos;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;

namespace ECommerce.Application.Services.Picture
{
    public class PictureService : IPictureService
    {
        private readonly IRepository<Domain.Entities.Picture> _pictureRepository;
        private readonly IMapper _mapper;

        public PictureService(IMapper mapper, IRepository<Domain.Entities.Picture> pictureRepository)
        {
            _mapper = mapper;
            _pictureRepository = pictureRepository;
        }

        public async Task<IDataResult<PictureAddOutDto>> AddAsync(PictureAddInDto request)
        {
            var picture = _mapper.Map<Domain.Entities.Picture>(request);

            await _pictureRepository.AddAsync(picture);

            var outPicture = _mapper.Map<PictureAddOutDto>(picture);

            return new SuccessDataResult<PictureAddOutDto>(outPicture);
        }

        public async Task<IResult> DeleteAsync(int Id)
        {
            var picture = await _pictureRepository.GetFirstOrDefaultAsync(predicate: x => x.Id == Id);

            await _pictureRepository.DeleteAsync(picture);

            return new SuccessResult();
        }
    }
}
