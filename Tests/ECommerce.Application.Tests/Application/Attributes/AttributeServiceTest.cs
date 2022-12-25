using AutoMapper;
using ECommerce.Core.Persistance.Repository;
using ECommerce.Domain.Entities;
using Moq;


namespace ECommerce.Application.Tests.FeaturesTests.Attributes
{
    /* 
                    Naming Conventions Of Test Methods
     * 1. pattern --> UnitOfWork_Conditions_ExceptedResult  
       2. pattern --> UnitOfWork_ExceptedResult_Conditions

      Note: You're able to use this patterns.You can prefer what you want 
     */
    public class AttributeServiceTests
    {
        private Mock<IRepository<Attribute_>> _attributeRepository;
        private Mock<IMapper> _mapper;

        public AttributeServiceTests()
        {
            _attributeRepository = new Mock<IRepository<Attribute_>>();
            _mapper = new Mock<IMapper>();
        }


        //[Test]
        //public async Task AddAsync_IsExistingAttribute_ThereIsAlreadyAttribute()
        //{
        //    //Arrange
        //    //_attributeRepository.Setup(x => x.GetFirstOrDefaultAsync(predicate :x=> x.Name == It.IsAny<string>())).ReturnsAsync(new Attribute_());
        //    //var serviceResponse = new ErrorResult(Messages.AttributeAlreadyExist);
        //    //_mapper.Setup(x => x.Map<Attribute_>(It.IsAny<AttributeAddInDto>())).Returns(new Attribute_() { Id = 0, Name = "Category", Description = string.Empty });
        //    //var repositoryResult = _attributeRepository.Setup(x => x.GetFirstOrDefaultAsync(
        //    //    predicate: y => y.Name == It.IsAny<string>(),
        //    //    orderBy: null,
        //    //    include:null,
        //    //    disableTracking:false
        //    //    )).ReturnsAsync(null);
        //    //var attributeService = new AttributeService(_mapper.Object, _attributeRepository.Object);


        //    ////Action
        //    //var result = await attributeService.AddAsync(new AttributeAddInDto());

        //    //Assert
        //    //Assert.AreEqual(serviceResponse, result);

        //}

    }
}

