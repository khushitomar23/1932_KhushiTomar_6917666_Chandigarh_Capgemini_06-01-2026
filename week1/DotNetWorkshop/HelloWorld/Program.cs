using System;
using GreeterLib;                       // your class library
using Newtonsoft.Json;                  // NuGet package
using Microsoft.Extensions.DependencyInjection; // for DI

class Program
{
    static void Main(string[] args)
    {
        // DI setup
        var services = new ServiceCollection();
        services.AddSingleton<IGreeter, Greeter>();
        var provider = services.BuildServiceProvider();

        // Resolve Greeter via DI
        var greeter = provider.GetRequiredService<IGreeter>();
        greeter.Greet("Khushi");

        // Newtonsoft.Json demo
        var obj = new { Name = "Khushi", Skill = "Networking" };
        string json = JsonConvert.SerializeObject(obj);
        Console.WriteLine(json);
    }
}