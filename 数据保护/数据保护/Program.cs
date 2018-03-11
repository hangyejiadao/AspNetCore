using System;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
namespace 数据保护
{
    class Program
    {
        static void Main(string[] args)
        {
            #region A

            // add data protection services
            //var serviceCollection = new ServiceCollection();
            //serviceCollection.AddDataProtection();
            //var services = serviceCollection.BuildServiceProvider();

            //// create an instance of MyClass using the service provider
            //var instance = ActivatorUtilities.CreateInstance<MyClass>(services);
            //instance.RunSample();
            //Console.ReadKey();

            #endregion

            #region B

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();
            var services = serviceCollection.BuildServiceProvider();

            //Get an IDataProtector from the IServiceProvider
            var protector = services.GetDataProtector("Contoso.Example.v2");
            Console.WriteLine("Enter Input:");

            string input = Console.ReadLine();
            //protect the payload
            string protectedPayload = protector.Protect(input);
            Console.WriteLine($"Protect returned:{protectedPayload}");
            //unprotect the payload
            string unprotectedPayload = protector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotect returned:{unprotectedPayload}");
            Console.ReadLine();

            #endregion
        }
    }

    public class MyClass
    {
        IDataProtector _protector;

        public MyClass(IDataProtectionProvider provider)
        {
            _protector = provider.CreateProtector("Contoso.MyClass.v1");
        }

        public void RunSample()
        {
            Console.WriteLine("Enter input:");
            string input = Console.ReadLine();
            //protect the payload
            string protectedPayload = _protector.Protect(input);
            Console.WriteLine($"Protect returned: {protectedPayload}");

            // unprotect the payload
            string unprotectedPayload = _protector.Unprotect(protectedPayload);
            Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
        }
    }
}
