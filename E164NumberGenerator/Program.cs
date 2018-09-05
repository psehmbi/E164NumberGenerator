using System;
using System.IO;

namespace E164NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            MsidnGenerator MsisdnGenerator = new MsidnGenerator();
            var msisdns = MsisdnGenerator.ValidMsisdnList(10);
            File.Delete("recipients.csv");
            Console.WriteLine("Valid MSISDNs:");
            foreach (var msisdn in msisdns)
            {
                //File.AppendAllText("recipients.csv", $"{{\"address\": {{\"msisdn\": \"{msisdn}\"}}}},\n");
                File.AppendAllText("recipients.csv", $"{msisdn},\n");

                Console.WriteLine(msisdn);
            }
            var invalidMsisdn = MsisdnGenerator.InvalidMsisdn();
            Console.WriteLine();
            Console.WriteLine("Invalid MSISDN:");
            Console.WriteLine(invalidMsisdn);
            Console.ReadLine();
        }
    }
}
