namespace CubeIntersection.ApplicationServices.Cubes
{
    /// <summary>
    /// The intersection dto class.
    /// </summary>
    public class IntersectionDto
    {
        /// <summary>
        /// Gets or sets the cube identifier.
        /// </summary>
        /// <value>
        /// The cube identifier.
        /// </value>
        public string CubeId { get; set; }

        /// <summary>
        /// Gets or sets the other cube identifier.
        /// </summary>
        /// <value>
        /// The other cube identifier.
        /// </value>
        public string OtherCubeId { get; set; }

        /// <summary>
        /// Gets or sets the volume.
        /// </summary>
        /// <value>
        /// The volume.
        /// </value>
        public double Volume { get; set; }
    }
}
