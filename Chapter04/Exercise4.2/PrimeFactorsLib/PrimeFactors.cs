
    namespace Packt;
    public class PrimeOperations
    {
        public string PrimeFactors(int a)
        {
            string results = "";
            int remainder = a;
            if (isPrime(a)) 
            {
                results = results +" " + a.ToString();
            }
            else
            {
                for (int p = 2; p <= a; p++)
                {
                    if ((a % p == 0)&&(isPrime(p)))
                    {
                        results = results + " " + p.ToString();
                        remainder = a / p;
                        break;
                    }

                }
                results = results + PrimeFactors(remainder);

            }
            return results;
        }
        public bool isPrime(int b)
        {
            if (b <= 1) return false;
            if (b == 2) return true;
            if (b % 2 == 0) return false;
            for (int i = 3; i <= b/2; i += 2)
            {
                if (b % i == 0)
                return false;
            }
            return true;
        }
    }
