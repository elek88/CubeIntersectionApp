namespace CubeIntersection.Domain.Entities.Cubes
{
    /// <summary>
    /// The coordinates class.
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        public double X { get; }
        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        public double Y { get; }
        /// <summary>
        /// Gets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        public double Z { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinates"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Coordinates(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
    }
}