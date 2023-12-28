namespace CbrConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            ServiceReference1.DailyInfoSoapClient client = new ServiceReference1.DailyInfoSoapClient(new ServiceReference1.DailyInfoSoapClient.EndpointConfiguration());
            var result = client.GetCursOnDate(DateTime.Now);
            foreach (var item in result.Nodes)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}