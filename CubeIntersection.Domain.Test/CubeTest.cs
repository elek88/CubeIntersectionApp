using System;
using CubeIntersection.Domain.Entities.Cubes;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace CubeIntersection.Domain.Test
{
    public class CubeTest
    {
        [Fact]
        public void CreateCube_Success()
        {
            //Act
            var cube = Cube.Create("1", 2, 3, 4, new Coordinates(1, 1, 1));

            //Arrange
            using (new AssertionScope())
            {
                cube.Should().NotBeNull();
                cube.Id.Should().Be("1");
                cube.Length.Should().Be(2);
                cube.Width.Should().Be(3);
                cube.Height.Should().Be(4);
                cube.CenterCoordinates.X.Should().Be(1);
                cube.CenterCoordinates.Y.Should().Be(1);
                cube.CenterCoordinates.Z.Should().Be(1);
            }
        }

        [Fact]
        public void CreateCubeWithNoIdThrowsArgumentNullException()
        {
            //Act
            Action action = () => Cube.Create(null, 2, 3, 4, new Coordinates(1, 1, 1));

            //Arrange
            using (new AssertionScope())
            {
                action.Should().Throw<ArgumentNullException>();
            }
        }

        [Fact]
        public void CreateCubeWithNoPositiveDimensionsThrowArgumentException()
        {
            //Act
            Action action = () => Cube.Create("1", -1, 3, 4, new Coordinates(1, 1, 1));

            //Arrange
            using (new AssertionScope())
            {
                action.Should().Throw<ArgumentException>();
            }
        }

        [Fact]
        public void CubeCollidesWithOtherCube_InXaxis()
        {
            //Assert
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(0, 0, 0));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(1,0,0));
            
            //Act
            var cube1CollidesCube2 = cube1.IsCollidedWithOther(cube2);
            var cube2CollidesCube1 = cube1.IsCollidedWithOther(cube1);

            //Arrange
            using (new AssertionScope())
            {
                cube1CollidesCube2.Should().BeTrue();
                cube2CollidesCube1.Should().BeTrue();
            }
        }

        [Fact]
        public void CubeCollidesWithOtherCube_InYaxis()
        {
            //Assert
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(0, 0, 0));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(0, 1, 0));

            //Act
            var cube1CollidesCube2 = cube1.IsCollidedWithOther(cube2);
            var cube2CollidesCube1 = cube1.IsCollidedWithOther(cube1);

            //Arrange
            using (new AssertionScope())
            {
                cube1CollidesCube2.Should().BeTrue();
                cube2CollidesCube1.Should().BeTrue();
            }
        }

        [Fact]
        public void CubeCollidesWithOther_InZaxis()
        {
            //Assert
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(0, 0, 0));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(0, 0, 1));

            //Act
            var cube1CollidesCube2 = cube1.IsCollidedWithOther(cube2);
            var cube2CollidesCube1 = cube1.IsCollidedWithOther(cube1);

            //Arrange
            using (new AssertionScope())
            {
                cube1CollidesCube2.Should().BeTrue();
                cube2CollidesCube1.Should().BeTrue();
            }
        }


        [Fact]
        public void CubeNoCollidesWithOther()
        {
            //Assert
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(10, 10, 10));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(1, 1, 1));

            //Act
            var result = cube1.IsCollidedWithOther(cube2);

            //Arrange
            result.Should().BeFalse();
        }

        [Fact]
        public void CubeNoIntersectionWithOther()
        {
            //Assert
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(10, 10, 10));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(1, 1, 1));

            //Act
            var intersectionVolume = cube1.GetIntersectionVolumeWithOther(cube2);

            //Arrange
            intersectionVolume.Should().Be(0);
        }

        [Fact]
        public void CubeIntersectionWithOther()
        {
            //Assert
            var cube1 = Cube.Create("1", 1, 1, 1, new Coordinates(0, 0, 0));
            var cube2 = Cube.Create("2", 1, 1, 1, new Coordinates(0.5, 0, 0));

            //Act
            var intersectionVolume = cube1.GetIntersectionVolumeWithOther(cube2);

            //Arrange
            intersectionVolume.Should().Be(0.5);
        }

    }
}
