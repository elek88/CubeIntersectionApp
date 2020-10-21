using System;
using CubeIntersection.ApplicationServices.Cubes;
using CubeIntersection.ApplicationServices.Mappers;
using CubeIntersection.Domain.Entities.Cubes;
using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using Xunit;

namespace CubeIntersection.ApplicationServices.Test
{
    //TODO: Add more testing for serviceTests CubeService
    public class CubeServiceTest
    {
        [Fact]
        public void InsertCube_Success()
        {
            //Arrange
            var cubeRepositoryMock = new Mock<ICubeRepository>();
            var mapperMock = new Mock<IMapper<Cube, CubeDto>>();
            var cubeService = new CubeService(cubeRepositoryMock.Object, mapperMock.Object);
            var cubeDto = new CubeDto
            {
                Id = Guid.NewGuid().ToString(),
                Height = 1,
                Width = 1,
                Length = 1,
                X = 0,
                Y = 0,
                Z = 0,
            };

            cubeRepositoryMock.Setup(cr => cr.Save(It.IsAny<Cube>()));

            //Act
            cubeService.Insert(cubeDto);

            //Assert
            cubeRepositoryMock.Verify(cr => cr.Save(It.IsAny<Cube>()), Times.Once());
        }

        [Fact]
        public void InsertCube_InvalidCubeFails()
        {
            //Arrange
            var cubeRepositoryMock = new Mock<ICubeRepository>();
            var mapperMock = new Mock<IMapper<Cube, CubeDto>>();
            var cubeService = new CubeService(cubeRepositoryMock.Object, mapperMock.Object);
            var cubeDto = new CubeDto
            {
                Id = Guid.NewGuid().ToString(),
                Height = -1,
                Width = 1,
                Length = 1,
                X = 0,
                Y = 0,
                Z = 0,
            };

            cubeRepositoryMock.Setup(cr => cr.Save(It.IsAny<Cube>())).Throws<ArgumentException>();

            //Act
            Action action = () => cubeService.Insert(cubeDto);

            //Assert
            using (new AssertionScope())
            {
                action.Should().Throw<ArgumentException>();
                cubeRepositoryMock.Verify(cr => cr.Save(It.IsAny<Cube>()), Times.Never());
            }
        }
    }
}
