using System.Collections.Generic;

namespace CubeIntersection.ApplicationServices.Cubes
{
    /// <summary>
    /// The cube service interface.
    /// </summary>
    public interface ICubeService
    {
        /// <summary>
        /// Inserts the specified cube.
        /// </summary>
        /// <param name="cube">The cube.</param>
        void Insert(CubeDto cube);

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
        /// <returns></returns>
        CubeDto Get(string id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CubeDto> GetAll();

        /// <summary>
        /// Gets the with collisions.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<CubeDto> GetWithCollisions(string id);

        /// <summary>
        /// Gets the collisions with others.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="othersIds">The others ids.</param>
        /// <returns></returns>
        IEnumerable<CubeDto> GetCollisionsWithOthers(string id, IEnumerable<string> othersIds);

        /// <summary>
        /// Gets all with collisions.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CubeDto> GetAllWithCollisions();

        /// <summary>
        /// Gets the intersections with other.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        IEnumerable<IntersectionDto> GetIntersectionsWithOther(string id);

        /// <summary>
        /// Gets the intersections with others.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="ids">The ids.</param>
        /// <returns></returns>
        IEnumerable<IntersectionDto> GetIntersectionsWithOthers(string id, IEnumerable<string> ids);

        /// <summary>
        /// Gets all intersections.
        /// </summary>
        /// <returns></returns>
        IEnumerable<IntersectionDto> GetAllIntersections();
    }
}