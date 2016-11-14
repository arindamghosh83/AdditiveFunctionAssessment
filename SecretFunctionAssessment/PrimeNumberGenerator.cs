using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFunctionAssessment
{
    public static class PrimeNumberGenerator
    {
        public static int[] GetPrimes(int number)
        {

            List<Int32> primes = new List<Int32>() { 2 };

            for (int i = 3; i <= number; i += 2)  // Find the next prime number 
            {
                Int32 sqrt = (Int32)Math.Sqrt(i);
                if (primes.TakeWhile(p => p <= sqrt).All(p => i % p != 0))
                {
                    primes.Add(i);
                }
            }
            return primes.ToArray();

        }
    }
}
