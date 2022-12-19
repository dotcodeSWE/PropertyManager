using Api.Controllers.Base.v1;
using Api.Dto.Requests.Base.v1;
using Api.Dto.Response.Base.v1;
using DotCode.ApiUtils;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Customer.Core.Domain;

namespace Customer.Api.Test.Controller
{
    public class CustomerControllerTest
    {
        [Fact]
        public async Task MethodToTest_Should_ReturnSomething_When_SomethingIsDone()
        {
            //Arrange
            var logger = new Mock<ILogger<CustomerController>>();
            var mediator = new Mock<IMediator>();
            //var mapper = new BaseMapper(typeof(CustomerController)).Mapper;

            mediator.Setup(x => x.Send(It.IsAny<PostCustomerRequestDto>(), It.IsAny<CancellationToken>())).ReturnsAsync(() => new Customer
            {
                BaseProp = "Test"
            });

            var request = new PostCustomerRequestDto
            {
                BaseProp = "Test"
            };

            //var sut = new CustomerController(logger.Object, mediator.Object); // mapper

            //Act
            //var res = await sut.PostCustomer(request);

            //Assert
            //var viewResult = Assert.IsType<OkObjectResult>(res);
            //var testTemp = Assert.IsAssignableFrom<BaseResponseDto<CustomerResponseDto>>(viewResult.Value);


            //Assert.NotNull(testTemp);
            //Assert.Equal("Test", testTemp.Result.BaseProp);

        }
    }
}