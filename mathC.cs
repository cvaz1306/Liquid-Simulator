using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRR3Liquid
{
    public class SquareRootWithRemainderResult
    {
        public int LargestPerfectSquare { get; set; }
        public double SquareRoot { get; set; }
        public double Remainder { get; set; }
    }

    public class SquareRootCalculator
    {
        public static SquareRootWithRemainderResult CalculateSquareRootWithRemainder(int number)
        {
            int largestPerfectSquare = (int)Math.Floor(Math.Sqrt(number)) * (int)Math.Floor(Math.Sqrt(number));
            double remainder = number - largestPerfectSquare;
            double squareRoot = Math.Sqrt(largestPerfectSquare);

            return new SquareRootWithRemainderResult
            {
                LargestPerfectSquare = largestPerfectSquare,
                SquareRoot = squareRoot,
                Remainder = remainder
            };
        }
    }
}
