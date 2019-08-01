using System.Text;
using System.Net;

namespace WebServer
{
    public class BrowserResponse
    {
        public static void Send(WebPage webPage, HttpListenerResponse response)
        {
            
 
            var buffer = Encoding.UTF8.GetBytes(webPage.data);
 
            response.ContentLength64 = buffer.Length;
            using(var outputStream = response.OutputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
            }
        }
    }






}
