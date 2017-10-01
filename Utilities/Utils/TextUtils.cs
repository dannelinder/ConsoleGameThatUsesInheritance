using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utilities
{
    public static class TextUtils
    {
        /// <summary>
        /// Animates by delaying the display-time of each char in the string. Only works in console applications.
        /// </summary>
        /// <param name="value">The value to animate</param>
        public static void Animate(string value)
        {
            foreach (char c in value)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
            Thread.Sleep(1500);
        }
    }
}
