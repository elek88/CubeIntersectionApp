using System;
using System.Collections.Generic;
using System.Linq;
using CubeIntersection.ApplicationServices.Mappers;
using CubeIntersection.Domain.Entities.Cubes;

namespace CubeIntersection.ApplicationServices.Cubes
{
    /// <summary>
    /// The cube service class.
    /// </summary>
    /// <seealso cref="CubeIntersection.ApplicationServices.Cubes.ICubeService" />
    public class CubeService : ICubeService
    {
        /// <summary>
        /// The cube repository
        /// </summary>
        private readonly ICubeRepository _cubeRepository;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper<Cube,CubeDto> _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CubeService"/> class.
        /// </summary>
        /// <param name="cubeRepository">The cube repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <exception cref="ArgumentException">
        /// cubeRepository
        /// or
        /// mapper
        /// </exception>
        public CubeService(ICubeRepository cubeRepository, IMapper<Cube, CubeDto> mapper)
        {
            this._cubeRepository = cubeRepository ?? throw new ArgumentException(nameof(cubeRepository));
            this._mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        /// <summary>
        /// Inserts the specified cube dto.
        /// </summary>
        /// <param name="cubeDto">The cube dto.</param>
        public void Insert(CubeDto cubeDto)
        {
            var cube = Cube.Create(cubeDto.Id, cubeDto.Length, cubeDto.Width, cubeDto.Height, new Coordinates(cubeDto.X,cubeDto.Y, cubeDto.Z));
            this._cubeRepository.Save(cube);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void Remove(string id)
        {
            this._cubeRepository.Remove(id);
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        public void RemoveAll()
        {
           this._cubeRepository.RemoveAll();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public CubeDto Get(string id)
        {
            var cube = this._cubeRepository.Get(id);
            if (cube == null) return null;
            return this._mapper.Map(cube);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CubeDto> GetAll()
        {
            var cubeDtos = new List<CubeDto>();
            var cubes = this._cubeRepository.GetAll();
            foreach (var cube in cubes)
            {
                cubeDtos.Add(this._mapper.Map(cube));
            }
            return cubeDtos;
        }

        /// <summary>
        /// Gets the with collisions.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<CubeDto> GetWithCollisions(string id)
        {
            var cubeDtos = new List<CubeDto>();
            var cube = this._cubeRepository.Get(id);
            var otherCubes = this._cubeRepository.GetAll().Where(c => c.Id != id);
            foreach (var otherCube in otherCubes)
            {
                if (cube.IsCollidedWithOther(otherCube))
                {
                    cubeDtos.Add(this._mapper.Map(otherCube));
                }
            }
            return cubeDtos;
        }

        /// <summary>
        /// Gets the collisions with others.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="othersIds">The others ids.</param>
        /// <returns></returns>
        public IEnumerable<CubeDto> GetCollisionsWithOthers(string id, IEnumerable<string> othersIds)
        {
            var cubeDtos = new List<CubeDto>();
            var cube = this._cubeRepository.Get(id);
            var otherCubes = this._cubeRepository.GetByIds(othersIds);
            foreach (var otherCube in otherCubes)
            {
                if (cube.IsCollidedWithOther(otherCube))
                {
                    cubeDtos.Add(this._mapper.Map(otherCube));
                }
            }
            return cubeDtos;
        }

        /// <summary>
        /// Gets all with collisions.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CubeDto> GetAllWithCollisions()
        {
            var cubeDtos = new List<CubeDto>();
            var cubes = this._cubeRepository.GetAll();
            foreach (var cube in cubes)
            {
                cubeDtos.AddRange(GetCollisionsWithOthers(cube.Id, cubes.Where(c=>c.Id != cube.Id).Select(c => c.Id)));
            }
            return cubeDtos;
        }

        /// <summary>
        /// Gets the intersections with other.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IEnumerable<IntersectionDto> GetIntersectionsWithOther(string id)
        {
            var intersectionDtos = new List<IntersectionDto>();
            var cube = this._cubeRepository.Get(id);
            var otherCubes = this._cubeRepository.GetAll().Where(c=>c.Id != cube.Id);
            foreach (var otherCube in otherCubes)
            {
                var intersectionVolume = cube.GetIntersectionVolumeWithOther(otherCube);
                if (intersectionVolume > 0)
                {
                    intersectionDtos.Add(new IntersectionDto
                    {
                        CubeId = cube.Id,
                        OtherCubeId = otherCube.Id,
                        Volume = intersectionVolume
                    });
                }
            }
            return intersectionDtos;
        }

        /// <summary>
        /// Gets the intersections with others.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        public IEnumerable<IntersectionDto> GetIntersectionsWithOthers(string id, IEnumerable<string> ids)
        {
            var intersectionDtos = new List<IntersectionDto>();
            var cube = this._cubeRepository.Get(id);
            var otherCubes = this._cubeRepository.GetByIds(ids);
            foreach (var otherCube in otherCubes)
            {
                var intersectionVolume = cube.GetIntersectionVolumeWithOther(otherCube);
                if (intersectionVolume > 0)
                {
                    intersectionDtos.Add(new IntersectionDto
                    {
                        CubeId = cube.Id,
                        OtherCubeId = otherCube.Id,
                        Volume = intersectionVolume
                    });
                }
            }
            return intersectionDtos;
        }

        /// <summary>
        /// Gets all intersections.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IntersectionDto> GetAllIntersections()
        {
            var intersectionDtos = new List<IntersectionDto>();
            var cubes = this._cubeRepository.GetAll();
            foreach (var cube in cubes)
            {
                intersectionDtos.AddRange(GetIntersectionsWithOthers(cube.Id, cubes.Where(c=>c.Id != cube.Id).Select(c=>c.Id)));
            }
            return intersectionDtos;
        }
    }
}