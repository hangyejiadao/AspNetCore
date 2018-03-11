using System;
using System.IO;
using System.Threading;
using Microsoft.AspNetCore.DataProtection;
namespace 限制受保护的负载的生存期
{
    class Program
    {
        static void Main(string[] args)
        {
            var provider = DataProtectionProvider.Create(new DirectoryInfo(@"c:\myapp-keys\"));
            var baseProtector = provider.CreateProtector("Contoso.TimeLimitedSample");

            // convert the normal protector into a time-limited protector
            var timeLimitedProtector = baseProtector.ToTimeLimitedDataProtector();

            // get some input and protect it for five seconds
            Console.Write("Enter input: ");
            string input = Console.ReadLine();
            string protectedData = timeLimitedProtector.Protect(input, lifetime: TimeSpan.FromSeconds(5));
            Console.WriteLine($"Protected data: {protectedData}");

            // unprotect it to demonstrate that round-tripping works properly
            string roundtripped = timeLimitedProtector.Unprotect(protectedData);
            Console.WriteLine($"Round-tripped data: {roundtripped}");

            // wait 6 seconds and perform another unprotect, demonstrating that the payload self-expires
            Console.WriteLine("Waiting 6 seconds...");
            Thread.Sleep(6000);
            timeLimitedProtector.Unprotect(protectedData);

            Console.ReadKey();
        }
    }
}
