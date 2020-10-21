using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;
using CubeIntersection.Domain.Entities.Cubes;
using CubeIntersection.Infrastructure.Repositories;

namespace CubeIntersection.Infrastructure.Test
{
    public class CubeRepositoryTest
    {
        [Fact]
        public void Save_Success()
        {
            //Arrange
            var cubeRepository = new CubeRepository();
            var cube = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            //Act
            cubeRepository.Save(cube);

            //Assert
            using (new AssertionScope())
            {
                cubeRepository.Get("1").Should().NotBeNull();
            }

            cubeRepository.RemoveAll();
        }
        [Fact]
        public void Save_ThrowsArgumentExceptionWhenIdAlreadyExists()
        {
            //Arrange
            var cubeRepository = new CubeRepository();
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            var cube2 = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            cubeRepository.Save(cube1);

            //Act
            Action action = () => cubeRepository.Save(cube2);

            //Assert
            using (new AssertionScope())
            {
                action.Should().Throw<ArgumentException>();
            }

            cubeRepository.RemoveAll();
        }

        [Fact]
        public void GetAll_ReturnsAllCubes()
        {
            //Arrange
            var cubeRepository = new CubeRepository();
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(1, 1, 1));
            cubeRepository.Save(cube1);
            cubeRepository.Save(cube2);

            //Act
            var results = cubeRepository.GetAll().ToList();

            //Assert
            using (new AssertionScope())
            {
                results.Count().Should().Be(2);
                ValidateCube(results[0], cube1);
                ValidateCube(results[1], cube2);
            }

            cubeRepository.RemoveAll();
        }

        [Fact]
        public void Get_ReturnsSelectedCube()
        {
            //Arrange
            var cubeRepository = new CubeRepository();
            var cube = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            cubeRepository.Save(cube);

            //Act
            var result = cubeRepository.Get(cube.Id);

            //Assert
            using (new AssertionScope())
            {
                result.Should().NotBeNull();
                ValidateCube(result,cube);
            }

            cubeRepository.RemoveAll();
        }

        [Fact]
        public void Remove_RemoveSelectedCubeIdNotExistsThrowsArgumentException()
        {
            //Arrange
            var cubeRepository = new CubeRepository();

            //Act
            Action action = () => cubeRepository.Remove("1");

            //Assert
            using (new AssertionScope())
            {
                action.Should().Throw<ArgumentException>();
            }

            cubeRepository.RemoveAll();
        }

        [Fact]
        public void Remove_RemoveSelectedCube()
        {
            //Arrange
            var cubeRepository = new CubeRepository();
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(1, 1, 1));
            cubeRepository.Save(cube1);
            cubeRepository.Save(cube2);

            //Act
            cubeRepository.Remove(cube1.Id);

            //Assert
            using (new AssertionScope())
            {
                cubeRepository.Get(cube1.Id).Should().BeNull();
                cubeRepository.GetAll().Count().Should().Be(1);
            }

            cubeRepository.RemoveAll();
        }

        [Fact]
        public void RemoveAll_RemoveAllCube()
        {
            //Arrange
            var cubeRepository = new CubeRepository();
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(1, 1, 1));
            cubeRepository.Save(cube1);
            cubeRepository.Save(cube2);

            //Act
            cubeRepository.RemoveAll();

            //Assert
            using (new AssertionScope())
            {
                cubeRepository.GetAll().Count().Should().Be(0);
            }

            cubeRepository.RemoveAll();
        }

        [Fact]
        public void GetByIds_ReturnsSelectedCubes()
        {
            //Arrange
            var cubeRepository = new CubeRepository();
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(1, 1, 1));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(1, 1, 1));
            var cube3 = Cube.Create("3", 1, 1, 1, new Coordinates(1, 1, 1));
            cubeRepository.Save(cube1);
            cubeRepository.Save(cube2);
            cubeRepository.Save(cube3);


            //Act
            var results= cubeRepository.GetByIds(new List<string> { cube1.Id, cube2.Id }).ToList();

            //Assert
            using (new AssertionScope())
            {
                results.Count().Should().Be(2);
                ValidateCube(results[0], cube1);
                ValidateCube(results[1],cube2);
            }
            cubeRepository.RemoveAll();
        }

        private void ValidateCube(Cube cube, Cube expectedCube)
        {
            cube.Should().NotBeNull();
            cube.Length.Should().Be(expectedCube.Length);
            cube.Height.Should().Be(expectedCube.Height);
            cube.Width.Should().Be(expectedCube.Width);
            cube.CenterCoordinates.X.Should().Be(expectedCube.CenterCoordinates.X);
            cube.CenterCoordinates.Y.Should().Be(expectedCube.CenterCoordinates.Y);
            cube.CenterCoordinates.Z.Should().Be(expectedCube.CenterCoordinates.Z);
        }
    }
}
