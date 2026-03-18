using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace InheritanceAndServiceClass
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var builder1 = Microsoft.AspNetCore.Builder
                .WebApplication.CreateBuilder(args);

            Console.WriteLine("Hello, World!");
        }
    }
}
