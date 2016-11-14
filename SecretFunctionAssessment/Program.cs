using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretFunctionAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No arguments passed");
                return;
            }
            else
            {
                try
                {
                    int inputArgs = Convert.ToInt32(args[0]);
                    if (inputArgs <= 2)
                    {
                        Console.WriteLine("Number selected does not have a minimum of two prime numbers");
                        return;
                    }
                    int[] results = PrimeNumberGenerator.GetPrimes(inputArgs);

                    SortedDictionary<int, int> secrets = new SortedDictionary<int, int>();

                    foreach (var result in results)  //Iterate the entire list of prime numbers
                    {
                        secrets.Add(result, Secret(result));  //Stores collection of prime numbers and secrets
                    }
                    ParallelLoopResult asyncresult = Parallel.For(0, results.Length - 1, (int i, ParallelLoopState state) =>
                    {

                        for (int j = i + 1; j < results.Length; j++)
                        {
                            int secreti = secrets[results[i]];  //Retrieve secret from SortedDictionary<int,int> secrets
                            int secretj = secrets[results[j]];
                            int secretij = Secret(results[i] + results[j]); //Retrieve secret by calling the Secret function
                            bool tempresult = (secreti + secretj) == secretij;
                            if (!tempresult)
                            {

                                state.Stop();

                            }

                        }

                    });
                    Console.WriteLine(String.Format("Is Secret function additive {0}", asyncresult.IsCompleted));
                    return;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Input could not be converted to integer" + ex.Message);
                }

            }
        }
        static int Secret(int secret)  //Sample Secret function. 
        {
            return secret;
        }
    }
}
