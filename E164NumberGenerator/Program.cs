using System;
using System.IO;

namespace E164NumberGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            MsidnGenerator MsisdnGenerator = new MsidnGenerator();
            var numberOfMsisdns = 50000;
            var msisdns = MsisdnGenerator.ValidTimeBasedMsisdnList(numberOfMsisdns);
            File.Delete($"{numberOfMsisdns} recipients.csv");
            Console.WriteLine("Generating MSISDNs...");
            File.AppendAllText($"{numberOfMsisdns} recipients.csv", "msisdn\n");
            var i = 0;

            foreach (var msisdn in msisdns)
            {
                //File.AppendAllText($"{numberOfMsisdns} recipients.csv", $"{{\"address\": {{\"msisdn\": \"{msisdn}\"}}}},\n");
                File.AppendAllText($"{numberOfMsisdns} recipients.csv", $"{msisdn}\n");
                i++;
                Console.Write($"\r{i} msisdns generated");
            }

            Console.WriteLine();
            Console.WriteLine($"Successfully generated file: {Directory.GetCurrentDirectory()}\\{numberOfMsisdns} recipients.csv");
            Console.ReadLine();
        }
    }
}
