namespace CubeIntersection.ApplicationServices.Mappers
{
    /// <summary>
    /// The mapper interface.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestination">The type of the destination.</typeparam>
    public interface IMapper<in TSource, out TDestination>
    {

        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        TDestination Map(TSource source);
    }
}
