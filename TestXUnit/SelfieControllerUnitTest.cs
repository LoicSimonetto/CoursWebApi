using Microsoft.AspNetCore.Mvc;
using TestWebAPI.Controllers;
using Xunit;
#pragma warning disable CS8618
using SelfieAWookies.NET.Selfies.Domain;
using Moq;
using TestWebAPI.Application.DTOs;
using SelfiesAWookies.Core.Framework;

namespace TestXUnit
{
    public class SelfieControllerUnitTest
    {
        #region Méthodes publiques
        [Fact]
        public void ShouldAddOneSelfie()
        {
            // ARRANGE
            SelfieDto selfie= new SelfieDto();
            var repositoryMock = new Mock<ISelfieRepository>();

            var unit = new Mock<IUnitOfWork>();
            repositoryMock.Setup(item => item.UnitOfWork).Returns(new Mock<IUnitOfWork>().Object);
            repositoryMock.Setup(item => item.AddOne(It.IsAny<Selfie>())).Returns(new Selfie() {Id = 4 });

            // ACT
            var controller = new SelfiesController(repositoryMock.Object,null);
            var result = controller.AddOne(selfie);

            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var addedSelfie = (result as OkObjectResult).Value as SelfieDto;
            Assert.NotNull(addedSelfie);
            Assert.True(addedSelfie.Id > 0);
        }

        [Fact]
        public void ShouldReturnListOfSelfies()
        {
            List<Selfie> expectedList = new List<Selfie>()
            { 
                new Selfie(){Wookie = new Wookie(){ Id = 1, Selfies = new List<Selfie>()} },
                new Selfie(){Wookie = new Wookie(){ Id = 2, Selfies = new List<Selfie>()} }
            };

            // ARRANGE
            var repositoryMock = new Mock<ISelfieRepository>();
            repositoryMock.Setup(x => x.GetAll(It.IsAny<int>())).Returns(expectedList);

            var controller = new SelfiesController(repositoryMock.Object,null);

            // ACT

            ActionResult result = controller.GetAll();

            // ASSERT
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            var okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            Assert.IsType<List<SelfieResumeDto>>(okResult.Value);
            
            var list = okResult.Value as List<SelfieResumeDto>;
            Assert.True(list.Count == expectedList.Count);
        }
        #endregion

    }
}