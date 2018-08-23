using System;

namespace E164NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            MsidnGenerator MsisdnGenerator = new MsidnGenerator();
            var result = MsisdnGenerator.GenerateRandomMsisdn(100);
            
            foreach (var msisdn in result)
            {
                Console.WriteLine(msisdn);
            }
            Console.WriteLine(result.Count + " numbers generated");
            Console.ReadLine();
        }
    }
}
