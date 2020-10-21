using System;
using System.Collections.Generic;
using System.Linq;
using CubeIntersection.Domain.Entities.Cubes;

namespace CubeIntersection.Infrastructure.Repositories
{
    /// <summary>
    /// The cube respository class.
    /// </summary>
    /// <seealso cref="CubeIntersection.Domain.Entities.Cubes.ICubeRepository" />
    public class CubeRepository : ICubeRepository
    {
        /// <summary>
        /// The cube collection
        /// </summary>
        private static List<Cube> _cubeCollection = new List<Cube>();

        /// <summary>
        /// Saves the specified cube.
        /// </summary>
        /// <param name="cube">The cube.</param>
        /// <exception cref="ArgumentException">The cube with id {cube.Id} is already in repository</exception>
        public void Save(Cube cube)
        {
            if (_cubeCollection.FirstOrDefault(c => c.Id == cube.Id) != null)
            {
                throw new ArgumentException($"The cube with id {cube.Id} is already in repository");
            }
            _cubeCollection.Add(cube);
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="ArgumentException">The cube with id {id} is not in repository</exception>
        public void Remove(string id)
        {
            var cube = _cubeCollection.FirstOrDefault(c => c.Id == id);
            if (cube == null)
            {
                throw new ArgumentException($"The cube with id {id} is not in repository");
            }
            _cubeCollection.Remove(cube);
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        public void RemoveAll()
        {
            _cubeCollection.Clear();
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// A Cube
        /// </returns>
        public Cube Get(string id)
        {
            return _cubeCollection.FirstOrDefault(c => c.Id == id);
        }

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <returns>
        /// Several Cubes
        /// </returns>
        public IEnumerable<Cube> GetByIds(IEnumerable<string> ids)
        {
            var cubes = new List<Cube>();
            foreach (var id in ids)
            {
                var cube = Get(id);
                if (cube != null)
                {
                    cubes.Add(cube);
                }
            }
            return cubes;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>
        /// Several Cubes
        /// </returns>
        public IEnumerable<Cube> GetAll()
        {
            return _cubeCollection;
        }
    }
}
