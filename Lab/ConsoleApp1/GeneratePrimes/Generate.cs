namespace ConsoleApp1.GeneratePrimes;

public class Generate
{
    private static bool[] crossedOut;
    private static int[] result;

    public static int[] GeneratePrimes(int maxValue)
    {
        if (maxValue < 2)
        {
            return Array.Empty<int>();
        }
        uncrossIntegersToUp(maxValue);
        crossOutMultiples();
        putUncrossedIntegersIntoResult();
        return result;
    }

    private static void uncrossIntegersToUp(int maxValue)
    {
        crossedOut = new bool[maxValue + 1];
        for (int i = 2; i < crossedOut.Length; i++)
        {
            crossedOut[i] = false;
        }
    }

    private static void crossOutMultiples()
    {
        int limit = determineIterationLimit();
        for (int i = 2; i <= limit; i++)
        {
            if (notCrossed(i))
            {
                crossOutMultiplesOf(i);
            }
        }
    }

    private static int determineIterationLimit()
    {
        double iterationLimit = Math.Sqrt(crossedOut.Length);
        return (int)iterationLimit;
    }

    private static bool notCrossed(int i)
    {
        return crossedOut[i] == false;
    }

    private static void crossOutMultiplesOf(int i)
    {
        for (int j = 2 * i; j < crossedOut.Length; j += i)
        {
            crossedOut[j] = true;
        }
    }

    private static void putUncrossedIntegersIntoResult()
    {
        result = new int[numberOfUncrossedIntegers()];
        for (int j = 0, i = 2; i < crossedOut.Length; i++)
        {
            if (notCrossed(i))
                result[j++] = i;
        }
    }

    private static int numberOfUncrossedIntegers()
    {
        int count = 0;
        for (int i = 2; i < crossedOut.Length; i++)
        {
            if (notCrossed(i))
                count++;
        }
        return count;
    }

    //var s = maxValue + 1;
        //var f = new bool[s];
        //int i;

        //for (i = 0; i < s; i++)
        //{
        //    f[i] = true;
        //}
        //f[0] = f[1] = false;

        //int j;
        //for (i = 0; i < Math.Sqrt(s) + 1; i++)
        //{
        //    if (f[i])
        //    {
        //        for (j = 2 * i; j < s; j += i)
        //        {
        //            f[j] = false;
        //        }
        //    }
        //}
        
        //var count = 0;
        //for (i = 0; i < s; i++)
        //{
        //    if (f[i])
        //        count++;
        //}
        //var primes = new int[count];

        //for (i = 0, j = 0; i < s; i++)
        //{
        //    if (f[i])
        //        primes[j++] = i;
        //}

        //return primes;

    
}