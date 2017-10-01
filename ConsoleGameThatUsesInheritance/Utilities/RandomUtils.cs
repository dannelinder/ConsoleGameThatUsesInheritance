using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Utilities
{
    class RandomUtils
    {
        static Random randomizer = new Random();

        /// <summary>
        /// Returns a random number based on the input percentage
        /// </summary>
        /// <param name="percent">The percentage value</param>
        /// <returns>Returns an int between 0 and 100</returns>
        public static bool GetRandomFromPercentage(int percent)
        {
            return (randomizer.Next(0, 101) < percent);
        }

        public static int GetRandomBetween(int betweenLow, int betweenHigh)
        {
            return randomizer.Next(betweenLow, betweenHigh);
        }
    }
}
