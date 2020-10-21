using System;
using CubeIntersection.Domain.Entities.Base;
using CubeIntersection.Domain.Entities.Utils;

namespace CubeIntersection.Domain.Entities.Cubes
{
    /// <summary>
    /// The cube class.
    /// </summary>
    /// <seealso cref="CubeIntersection.Domain.Entities.Base.Entity" />
    public class Cube : Entity
    {

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public double Length { get; private set; }

        /// <summary>
        /// Gets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public double Height { get; private set; }

        /// <summary>
        /// Gets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public double Width { get; private set; }

        /// <summary>
        /// Gets or sets the center coordinates.
        /// </summary>
        /// <value>
        /// The center coordinates.
        /// </value>
        public Coordinates CenterCoordinates { get; set; }

        /// <summary>
        /// Prevents a default instance of the <see cref="Cube"/> class from being created.
        /// </summary>
        private Cube()
        {
        }


        /// <summary>
        /// Creates the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="length">The length.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="centerCoordinates">The center coordinates.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// id
        /// or
        /// centerCoordinates
        /// </exception>
        /// <exception cref="ArgumentException">Length, width and height values have to be greater than 0</exception>
        public static Cube Create(string id, double length, double width, double height, Coordinates centerCoordinates)
        {
            if(string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            if (length <= 0 || width <= 0 || height <= 0) throw new ArgumentException("Length, width and height values have to be greater than 0");
            if (centerCoordinates == null) throw new ArgumentNullException(nameof(centerCoordinates));
            return new Cube()
            {
                Id = id,
                Length = length,
                Width = width,
                Height = height,
                CenterCoordinates = centerCoordinates
            };
        }

        /// <summary>
        /// Determines whether [is collided with other] [the specified other cube].
        /// </summary>
        /// <param name="otherCube">The other cube.</param>
        /// <returns>
        ///   <c>true</c> if [is collided with other] [the specified other cube]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsCollidedWithOther(Cube otherCube)
        {

            if (!otherCube.GetSpaceInX().IsInInterval(this.GetSpaceInX().Start) && !otherCube.GetSpaceInX().IsInInterval(this.GetSpaceInX().End))
            {
                return false;
            }

            if (!otherCube.GetSpaceInY().IsInInterval(this.GetSpaceInY().Start) && !otherCube.GetSpaceInY().IsInInterval(this.GetSpaceInY().End))
            {
                return false;
            }

            if (!otherCube.GetSpaceInZ().IsInInterval(this.GetSpaceInZ().Start) && !otherCube.GetSpaceInZ().IsInInterval(this.GetSpaceInZ().End))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the intersection volume with other.
        /// </summary>
        /// <param name="otherCube">The other cube.</param>
        /// <returns></returns>
        public double GetIntersectionVolumeWithOther(Cube otherCube)
        {
            if (!this.IsCollidedWithOther(otherCube)) return 0;
            var intersectionLength = Math.Abs(Math.Min(this.GetSpaceInX().End, otherCube.GetSpaceInX().End) -
                                              Math.Max(this.GetSpaceInX().Start, otherCube.GetSpaceInX().Start));
            var intersectionHeight = Math.Abs(Math.Min(this.GetSpaceInY().End, otherCube.GetSpaceInY().End) -
                                              Math.Max(this.GetSpaceInY().Start, otherCube.GetSpaceInY().Start));
            var intersectionWidth = Math.Abs(Math.Min(this.GetSpaceInZ().End, otherCube.GetSpaceInZ().End) -
                                             Math.Max(this.GetSpaceInZ().Start, otherCube.GetSpaceInZ().Start));
            return intersectionLength * intersectionWidth * intersectionHeight;
        }

        /// <summary>
        /// Gets the space in x.
        /// </summary>
        /// <returns></returns>
        private Interval GetSpaceInX()
        {
            var interval = new Interval(this.CenterCoordinates.X - this.Length / 2, this.CenterCoordinates.X + this.Length / 2);
            return interval;
        }


        /// <summary>
        /// Gets the space in y.
        /// </summary>
        /// <returns></returns>
        private Interval GetSpaceInY()
        {
            var interval = new Interval(this.CenterCoordinates.Y - this.Height / 2, this.CenterCoordinates.Y + this.Height / 2);
            return interval;
        }

        /// <summary>
        /// Gets the space in z.
        /// </summary>
        /// <returns></returns>
        private Interval GetSpaceInZ()
        {
            var interval = new Interval(this.CenterCoordinates.Z - this.Width / 2, this.CenterCoordinates.Z + this.Width / 2);
            return interval;
        }
    }
}
