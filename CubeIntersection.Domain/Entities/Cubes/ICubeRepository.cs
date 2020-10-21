using System.Collections.Generic;

namespace CubeIntersection.Domain.Entities.Cubes
{
    /// <summary>
    /// The cube repository interface.
    /// </summary>
    public interface ICubeRepository
    {
        /// <summary>
        /// Saves the specified cube.
        /// </summary>
        /// <param name="cube">The cube.</param>
        void Save(Cube cube);

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        void Remove(string id);

        /// <summary>
        /// Removes all.
        /// </summary>
        void RemoveAll();

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>A Cube</returns>
        Cube Get(string id);

        /// <summary>
        /// Gets the by ids.
        /// </summary>
        /// <param name="ids">The identifiers.</param>
        /// <returns>Several Cubes</returns>
        IEnumerable<Cube> GetByIds(IEnumerable<string> ids);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Several Cubes</returns>
        IEnumerable<Cube> GetAll();
    }
}