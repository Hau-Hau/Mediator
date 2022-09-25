// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Jab;
using Mediator;
using SimpleConsoleJab.Module;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var sp = new ServiceProvider();
        var mediator = sp.GetService<IMediator>();
        var ping = new Ping(Guid.NewGuid());
        var pong = await mediator.Send(ping);
        Debug.Assert(ping.Id == pong.Id);
    }
}

[ServiceProvider]
[Import(typeof(Mediator.IMediatorModule))]
public partial class ServiceProvider { }
