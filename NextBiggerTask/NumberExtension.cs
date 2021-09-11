using System;

namespace NextBiggerTask
{
    public static class NumberExtension
    {
        /// <summary>
        /// Finds the nearest largest integer consisting of the digits of the given positive integer number and null if no such number exists.
        /// </summary>
        /// <param name="number">Source number.</param>
        /// <returns>
        /// The nearest largest integer consisting of the digits  of the given positive integer and null if no such number exists.
        /// </returns>
        /// <exception cref="ArgumentException">Thrown when source number is less than 0.</exception>
        public static int? NextBiggerThan(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException($"Value of {nameof(number)} cannot be less zero.", nameof(number));
            }

            int leftPart = number;
            int rightPart;
            int smallerDigit = leftPart % 10;
            int biggerDigit;
            int smallerRank = 1;
            int biggerRank = 1;
            int result = 0;

            do
            {
                biggerDigit = smallerDigit;
                smallerDigit = leftPart % 10;
                leftPart /= 10;
                smallerRank *= 10;
            } while (smallerDigit >= biggerDigit && leftPart > 0);
            if (smallerDigit >= biggerDigit || number == int.MaxValue)
            {
                return null;
            }

            smallerRank /= 10;
            leftPart = number / smallerRank;

            rightPart = number % (leftPart * smallerRank);
            int newRightpart = rightPart;
            biggerDigit = rightPart % 10;

            while (smallerDigit >= biggerDigit)
            {
                rightPart /= 10;
                biggerDigit = rightPart % 10;
                biggerRank *= 10;
            }

            rightPart = newRightpart;
            leftPart /= 10;
            leftPart = (leftPart * 10) + biggerDigit;

            smallerDigit *= biggerRank;
            if (biggerRank == 1)
            {
                biggerRank = 10;
                rightPart = ((rightPart / biggerRank) * biggerRank) + smallerDigit;
            }
            else
            {
                rightPart = (rightPart - ((rightPart / biggerRank) * biggerRank)) + smallerDigit;
            }

            newRightpart = rightPart;
            while (newRightpart > 0)
            {
                result *= 10;
                result += newRightpart % 10;
                newRightpart /= 10;
            }

            result += leftPart * smallerRank;

            return result;
        }
    }
}
