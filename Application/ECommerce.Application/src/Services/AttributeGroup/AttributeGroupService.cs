using AutoMapper;
using ECommerce.Application.Abstracts.AttributeGroup;
using ECommerce.Core.Application.CrossCuttingConcerns.Aspects;
using ECommerce.Core.Application.ObjectDesign;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Services
{
    public class AttributeGroupService: IAttributeGroupService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AttributeGroup> _attributeGroupRepository;

        public AttributeGroupService(
            IMapper mapper,
            IRepository<AttributeGroup> attributeRepository)
        {
            _mapper = mapper;
            _attributeGroupRepository = attributeRepository;
        }

        //[ValidationAspect(typeof(AttributeGroupAddInDto), Priority = 1)]
        public async Task<IResult> AddAsync(AttributeGroupAddInDto request)
        {
            var attributeGroup = _mapper.Map<AttributeGroup>(request);

            var dbAttributeGroup = await _attributeGroupRepository.GetFirstOrDefaultAsync(predicate: x => x.Title == attributeGroup.Title).ConfigureAwait(false);

            if (dbAttributeGroup != null) throw new Exception();

            await _attributeGroupRepository.AddAsync(attributeGroup);

            return new SuccessResult();
        }
        public async Task<IResult> DeleteAsync(int id)
        {
            await _attributeGroupRepository.DeleteAsync(new AttributeGroup { Id = id });

            return new SuccessResult();
        }

        //[ValidationAspect(typeof(AttributeGroupUpdateInDto), Priority = 1)]
        public async Task<IResult> UpdateAsync(AttributeGroupUpdateInDto request)
        {
            var attributeGroup = _mapper.Map<AttributeGroup>(request);

            var dbAttributeGroup = await _attributeGroupRepository.GetFirstOrDefaultAsync(predicate: x => x.Title == attributeGroup.Title && x.Id != attributeGroup.Id).ConfigureAwait(false);

            if (dbAttributeGroup != null) throw new Exception();

            await _attributeGroupRepository.UpdateAsync(attributeGroup);

            return new SuccessResult();
        }

        public async Task<IDataResult<AttributeGroupGetByIdOutDto>> GetByIdAsync(int id)
        {
            var result = await _attributeGroupRepository.GetFirstOrDefaultAsync(
                predicate: x => x.Id == id,
                selector: x => new AttributeGroupGetByIdOutDto
                {
                    Id = x.Id,
                    Title = x.Title,
                }).ConfigureAwait(false);

            return new SuccessDataResult<AttributeGroupGetByIdOutDto>(result);
        }

        public async Task<IDataResult<List<AttributeGroupListOutDto>>> GetListAsync()
        {
            var result = await _attributeGroupRepository.GetListAsync(selector: x => new AttributeGroupListOutDto
            {
                Id = x.Id,
                Title = x.Title,
            }).ConfigureAwait(false);

            return new SuccessDataResult<List<AttributeGroupListOutDto>>(result);

        }

    }
}
