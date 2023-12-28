using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcServer;

namespace GrpcClient
{
  internal class Program
  {
    private static async Task Main()
    {
      using var channel = GrpcChannel.ForAddress("https://localhost:5001");

      var client = new Greeter.GreeterClient(channel);

      var reply = await client.SayHelloAsync(new HelloRequest
      {
        Name = "GreeterClient"
      });

      Console.WriteLine("Greeting: " + reply.Message);
    }
  }
}