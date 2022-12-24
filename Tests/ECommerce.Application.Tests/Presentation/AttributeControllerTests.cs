using ECommerce.AdminAPI.Controllers;
using ECommerce.Application.Abstracts.Attribute;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Tests.Presentation
{
 
    public class AttributeControllerTests
    {
        private IAttributeService _attributeService;

        public AttributeControllerTests(IAttributeService attributeService)
        {
            _attributeService = attributeService;
        }

        //[Test]
        //public void GetList_IsWorking()
        //{
        //    //Arrange
        //    var api = new AttributesController(_attributeService);
        //    var exceptedValue = 3; 
        //    //Action
        //    var result = api.GetList();
        //    //Assert
        //    Assert.AreEqual(exceptedValue, result);

        //}
    }
}
