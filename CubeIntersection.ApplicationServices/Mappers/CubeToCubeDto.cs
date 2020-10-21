using System;
using System.Data;
using CubeIntersection.ApplicationServices.Cubes;
using CubeIntersection.Domain.Entities.Cubes;

namespace CubeIntersection.ApplicationServices.Mappers
{
    /// <summary>
    /// The mapper class from cube to cubeDto.
    /// </summary>
    /// <seealso cref="CubeIntersection.ApplicationServices.Mappers.IMapper{CubeIntersection.Domain.Entities.Cubes.Cube, CubeIntersection.ApplicationServices.Cubes.CubeDto}" />
    public class CubeToCubeDto: IMapper<Cube,CubeDto>
    {
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns> A  CubeDto</returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public CubeDto Map(Cube source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return new CubeDto()
            {
                Id = source.Id,
                Length = source.Length,
                Height = source.Height,
                Width = source.Width,
                X = source.CenterCoordinates.X,
                Y = source.CenterCoordinates.Y,
                Z = source.CenterCoordinates.Z
            };
        }
    }
}