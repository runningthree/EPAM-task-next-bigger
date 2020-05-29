using System;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Takes a positive integer number and returns the nearest largest integer
        /// consisting of the digits of the original number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits of the original number,
        /// and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown if source number less than zero.</exception>
        public static int? NextBiggerThan(int number)
        {
            throw new NotImplementedException("You need to implement this function.");
        }
    }
}