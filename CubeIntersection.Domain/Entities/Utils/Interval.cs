using System;

namespace CubeIntersection.Domain.Entities.Utils
{
    /// <summary>
    /// The interval class.
    /// </summary>
    public class Interval
    {
        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public double Start { get; set; }

        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public double End { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Interval"/> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <exception cref="ArgumentException">End value have to be greater than start</exception>
        public Interval(double start, double end)
        {
            if (end < start)
            {
                throw new ArgumentException("End value have to be greater than start");
            }

            this.Start = start;
            this.End = end;
        }

        /// <summary>
        /// Determines whether [is in interval] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if [is in interval] [the specified number]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsInInterval(double number)
        {
            return number >= this.Start && number <= this.End;
        }
    }
}