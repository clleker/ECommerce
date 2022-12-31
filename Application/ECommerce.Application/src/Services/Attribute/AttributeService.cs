using AutoMapper;
using ECommerce.Application.Abstracts.Attribute;
using ECommerce.Application.Abstracts.Attributes.Constant;
using ECommerce.Application.Constants;
using ECommerce.Core.Application.CrossCuttingConcerns.Aspects;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Common.Utils;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services
{
    public class AttributeService : IAttributeService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Attribute_> _attributeRepository;
        public AttributeService(
            IMapper mapper,
            IRepository<Attribute_> attributeRepository)
        {
            _mapper = mapper;
            _attributeRepository = attributeRepository;
        }

        [ValidationAspect(typeof(AttributeAddInDtoValidator), Priority = 1)]
        public async Task<IResult> AddAsync(AttributeAddInDto request)
        {
            var attribute = _mapper.Map<Attribute_>(request);

            attribute = ObjectUtils.TrimWhiteSpace(attribute);

            var dbAttribute = await this.GetByNameAsync(attribute.Name).ConfigureAwait(false);

            if (dbAttribute != null)
            {
                return new ErrorResult(Messages.AttributeAlreadyExist);
            }

            await _attributeRepository.AddAsync(attribute).ConfigureAwait(false);

            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(int id)
        {
            var attribute = await _attributeRepository.GetFirstOrDefaultAsync(predicate: x => x.Id == id).ConfigureAwait(false);

            if(attribute == null)
            {
                return new ErrorResult(AttributeConstant.NotFound);
            }

            await _attributeRepository.DeleteAsync(attribute);

            return new SuccessResult();
        }
        public async Task<Attribute_> GetByNameAsync(string attributeName)
        {
            return await _attributeRepository.GetFirstOrDefaultAsync(predicate: x => x.Name == attributeName).ConfigureAwait(false);
        }


        //[ValidationAspect(typeof(AttributeUpdateInDto), Priority = 1)]
        public async Task<IResult> UpdateAsync(AttributeUpdateInDto request)
        {
            var attribute = _mapper.Map<Attribute_>(request);

            attribute = ObjectUtils.TrimWhiteSpace(attribute);

            var dbAttribute = await _attributeRepository.GetFirstOrDefaultAsync(predicate: x => x.Name == attribute.Name && x.Id != attribute.Id).ConfigureAwait(false);

            if (dbAttribute != null)
            {
                return new ErrorResult(AttributeConstant.NotFound);
            }

            await _attributeRepository.UpdateAsync(attribute).ConfigureAwait(false);

            return new SuccessResult();
        }

        public async Task<IDataResult<AttributeGetByIdOutDto>> GetByIdAsync(int id)
        {
            var result = await _attributeRepository.GetFirstOrDefaultAsync(
                predicate: x => x.Id == id,
                selector: x => new AttributeGetByIdOutDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Name = x.Name,
                }).ConfigureAwait(false);

            return new SuccessDataResult<AttributeGetByIdOutDto>(result);
        }

        public async Task<IDataResult<List<AttributeListOutDto>>> GetListAsync()
        {
            var result = await _attributeRepository.GetListAsync(selector: x => new AttributeListOutDto
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
            }).ConfigureAwait(false);

            return new SuccessDataResult<List<AttributeListOutDto>>(result);
        }
    }
}
