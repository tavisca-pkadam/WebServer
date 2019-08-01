using System;
using WebServer;

namespace WebServerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var webServer = new WebServer.WebServer();
            webServer.Start();
            Console.WriteLine("Your Server has Started");
            Console.WriteLine("Press Any Key To Stop Server");
            Console.ReadKey(true);
        }
    }
}
