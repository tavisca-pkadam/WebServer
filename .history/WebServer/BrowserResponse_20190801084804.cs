using System.Text;
using System.Net;

namespace WebServer
{
    public class BrowserResponse : IBrowser
    {
        public static void Send(string message, HttpListenerResponse response)
        {
            string responseString = "<html><body><h1>"+ message +"</h1></body></html>";
 
            var buffer = Encoding.UTF8.GetBytes(responseString);
 
            response.ContentLength64 = buffer.Length;
            using(var outputStream = response.OutputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }






}
