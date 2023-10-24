using System;
using System.Collections.Generic;

namespace StringCalculator.Model
{
    public class NegativesNotAlloweException : Exception
    {
        public NegativesNotAlloweException(IEnumerable<int> numbers) : base("Negatives not allowed: " + string.Join(" ", numbers))
        {
        }
    }
}
