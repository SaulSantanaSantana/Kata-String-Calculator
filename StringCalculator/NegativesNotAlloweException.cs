using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class NegativesNotAlloweException : Exception
    {
        public NegativesNotAlloweException(IEnumerable<int> numbers) : base("Negatives not allowed: " + string.Join(" ", numbers))
        {
        }
    }
}
